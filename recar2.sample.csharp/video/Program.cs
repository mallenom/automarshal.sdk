using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Mallenom.Diagnostics;
using Mallenom.Diagnostics.Logs;
using Mallenom.Localization;
using Mallenom.Primitives;
using Mallenom.Storage;

using Recar2.Core;

namespace Recar2.Samples
{
	static class Program
	{
		private static readonly ILog Log = LogManager.GetCurrentClassLog();

		/// <summary>Точка входа в программу.</summary>
		[STAThread]
		private static void Main()
		{
			//Tracing.TracingIsEnabled = true; // Разрешение логировать дополнительную информацию 

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Настраиваем вывод в лог файлы. Данная настройка необязательна и необходима только для дополнительного логгирования
			TuneLogs();

			if(!Debugger.IsAttached) // Если не подключен дебаггер, то перехватываем все исключения в программе
			{
				Application.ThreadException += Application_ThreadException;
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			}

			// Устанавливаем локализацию языка сообщений в формах настройки (по умолчанию: "ru-RU")
			Locales.LoadFromAssembly(typeof(VideoCore).Assembly);
			Locale.Current = Locales.Known.FirstOrDefault(locale => locale.Culture.Name.Equals(@"en-US"));
			//Locale.Current = Locales.Known.FirstOrDefault(locale => locale.Culture.Name.Equals(@"ru-RU"));

			// Создаем сплешер, так как инициализация ядра требует некоторого времени
			var splash = new SplashForm();
			try
			{
				// Показываем сплешер
				if(!Debugger.IsAttached) splash.Show();
				// Создаем параметры инициализации ядра
				var initializationParameters = new VideoCoreInitializationParameters()
				{
					// Имя директории для сохранения логов. Если не указано, то логи будут храниться в директории %ProgramData%\Mallenom Systems\logs.
					LogDirectory = Path.Combine(Application.StartupPath, "logs"),
					// Имя файла конфигурации. Если не указано, то конфигурация будет храниться в файле %ProgramData%\Mallenom Systems\configs\recar2.cfg.
					ConfigFilename = Path.Combine(Application.StartupPath, "example.cfg"),
					// Количество каналов обработки (распознавания). Если не указано, то будет задействовано число каналов, указанное в лицензии.
					//VideoProcessChannelCount = 1,
					//VideoOnlyViewChannelCount = 0,
					// Режим функционирования ядра
					//Advanced = true,
					// Путь к папке с файлом лицензии
					//LicenseFileLocation = @"D:\Projects\Temp",
					// Использовать латинские символы в тексте номера
					ConvertPlateToCapsLatin = true,
					// Активировать пробную версию, если необходимо
					TrialDelegate = TrialDelegate,
				};
				// Создаем ядро
				using(var core = new VideoCore(initializationParameters))
				{
					// Настраиваем модели стран номеров. Данная настройка необязательна и может быть выполнена из UI
					TuneModels(core);
					// Инициализируем ядро
					core.Initialize();
					// Загружаем настройки из файла конфигурации
					core.LoadSettings();

					// Устанавливаем параметры алгоритма распознавания
					// Устанавливаем область интереса
					core.Settings.Channel(0).Roi.Value = new[]
					{
						new[] // Четыре точки области интереса в относительных размерах изображения
						{
							new PointF(0.04f, 0.05f),
							new PointF(0.94f, 0.05f),
							new PointF(0.90f, 0.84f),
							new PointF(0.03f, 0.95f)
						}
					};

					// Указываем минимальный и максимальный размер номера
					core.Settings.Channel(0).MinPlateSize.Value = new SizeF(0.07f, 0.031f);
					core.Settings.Channel(0).MaxPlateSize.Value = new SizeF(0.17f, 0.075f);

					// использовать в решении цветные изображения
					core.Settings.Channel(0).IsColorImageEnabled.Value = true;

					// Применяем настройки
					core.Settings.Apply();

					// Загружаем настройки интерфейса пользователя
					var configFilename = FileNameGenerator.FromAssemblyLocation("sample.cfg");
					var form = new MainForm(core);
					LoadUISettings(configFilename, form);
					// Закрываем сплешер
					splash.Close();
					// Открываем главную форму приложения
					Application.Run(form);
					// Сохраняем настройки интерфейса пользователя
					SaveUISettings(configFilename, form);
				}
			}
			catch(Exception exc)
			{
				Log.Error("Core initialization fail.", exc);
				splash.Close();
				HandleUnhandledException(exc);
			}
		}

		/// <summary>Вызывается при использовании пробной (trial) версии.</summary>
		/// <param name="state">Состояние пробной версии.</param>
		/// <param name="trailLeft">Оставшийся период использования пробной версии.</param>
		/// <returns>Возвращает флаг, показывающий необходимо ли активировать пробную версию.</returns>
		private static bool TrialDelegate(TrialState state, TimeSpan trailLeft)
		{
			switch(state)
			{
				case TrialState.NonActivate:
					if(MessageBox.Show("Activate trial version?", "Recar2.SDK", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						return true;
					}
					break;
				case TrialState.Activated:
					MessageBox.Show(string.Format("Trial version: days left: {0}.", (int)trailLeft.TotalDays), "Recar2.SDK");
					break;
				case TrialState.Expired:
					MessageBox.Show("Trial period expired.", "Recar2.SDK");
					break;
			}
			return false;
		}

		private static void TuneLogs()
		{
			// Создаем файл логгирования, в который сохраняем только распознанные номера
			var recognizerLogFileAppender = new FileAppender("numbers.log");
			recognizerLogFileAppender.AddFilter(new LoggerMatchFilter("numbers"));
			LogManager.GetRepository().RootLogger.AddAppender(recognizerLogFileAppender);

			// Создаем файл логгирования, в который сохраняем только информационные сообщения
			var infoLogFileAppender = new FileAppender("info.log");
			infoLogFileAppender.AddFilter(new LevelMatchFilter(Level.Info));
			LogManager.GetRepository().RootLogger.AddAppender(infoLogFileAppender);

			// Создаем логгер для вывода на форму информационные сообщения и сообщения об ошибках
			var logViewAppender = new LogViewAppender();
			//logViewAppender.AddFilter(new LevelRangeFilter(Level.Info, Level.Fatal));
			LogManager.GetRepository().RootLogger.AddAppender(logViewAppender);

			// Создаем логгер для вывода на форму информационные сообщения с распознанными номерами
			var numbersLogViewAppender = new LogViewAppender("numbers");
			numbersLogViewAppender.AddFilter(new LoggerMatchFilter("numbers"));
			LogManager.GetRepository().RootLogger.AddAppender(numbersLogViewAppender);
		}

		private static void TuneModels(VideoCore core)
		{
			// Включаем необходимы модели номеров. Данные настройки также можно вызвать из UI.
			// По умолчанию включена только российская модель ("ru") с приоритетом 1.
			if(core.Settings.Models.Exists("ua")) // Если разрешена украинская модель...
			{
				core.Settings.Models["ua"].IsEnabled = true; // ...то включаем ее
				core.Settings.Models["ua"].Priority = 2; // и задаем приоритет
			}
			//core.Settings.Models["ru"].IsEnabled = true; // Российские номера
			//core.Settings.Models["by"].IsEnabled = true; // Белорусские номера
			//core.Settings.Models["ua"].IsEnabled = true; // Украинские номера
			//core.Settings.Models["uz"].IsEnabled = true; // Узбекские номера
			//core.Settings.Models["kz"].IsEnabled = true; // Казахстанские номера
			//core.Settings.Models["kg"].IsEnabled = true; // Киргизские номера

			// Устанавливаем удельные веса шаблонов номеров (0.0..1.0). Данные настройки также можно вызвать из UI.
			// Если 0.0, то шаблон не будет использоваться.
			if(core.Settings.Models.Exists("ru")) core.Settings.Models["ru"].Stencils["RU_N07_000aD055"].Weight = 0.0; // Отключаем данный шаблон
		}

		private static void SaveUISettings(string configFilename, MainForm form)
		{
			XmlDataFormat.SerializeTo(configFilename, writer =>
			{
				var root = writer.BeginChildObject("Configuration");
				form.SaveSettings(root);
				writer.EndChildObject(root);
			});
		}

		private static void LoadUISettings(string configFilename, MainForm form)
		{
			if(File.Exists(configFilename))
			{
				XmlDataFormat.DeserializeFrom(configFilename, reader =>
				{
					var root = reader.TryGetChildStorage("Configuration");
					if(root != null)
					{
						form.LoadSettings(root);
					}
				});
			}
		}

		/// <summary>Перехватываем неперехваченные исключения.</summary>
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs arg)
		{
			try
			{
				HandleUnhandledException((Exception)arg.ExceptionObject);
				Process.GetCurrentProcess().Kill();
			}
			catch
			{
			}
		}

		/// <summary>Перехватываем неперехваченные исключения.</summary>
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs arg)
		{
			try
			{
				HandleUnhandledException(arg.Exception);
				Environment.Exit(0);
			}
			catch
			{
			}
		}

		/// <summary>Обрабатывает неперехваченные исключения.</summary>
		private static void HandleUnhandledException(Exception exc)
		{
			Log.Fatal("Critical shutdown!", exc);
			var message = exc.Message;
			var localizedException = exc as IDisplayedException;
			if(localizedException != null) message = localizedException.DisplayMessage;
			if(localizedException == null || !localizedException.IsSilent)
			{
				using(var form = new ExceptionForm("Critical shutdown!", message, exc))
				{
					form.ShowDialog();
				}
			}
		}
	}
}
