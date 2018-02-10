using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Mallenom.Diagnostics;
using Mallenom.Diagnostics.Logs;
using Mallenom.Localization;
using Mallenom.Storage;

using Recar2.Core;

namespace Recar2.Samples
{
	static class Program
	{
		private static readonly ILog Log = LogManager.GetCurrentClassLog();

		/// <summary>Точка входа для запуска программы.</summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Настраиваем вывод в лог файлы. Данная настройка необязательна и необходима только для дополнительного логгирования
			TuneLogs();

			// Если не подключен дебаггер, то перехватываем все исключения в программе
			if(!Debugger.IsAttached)
			{
				Application.ThreadException += Application_ThreadException;
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			}

			// Устанавливаем локализацию языка сообщений в формах настройки (по умолчанию: "ru-RU")
			Locales.LoadFromAssembly(typeof(ImageCore).Assembly);
			//Locale.Current = Locales.Known.FirstOrDefault(locale => locale.Culture.Name.Equals(@"en-US"));
			//Locale.Current = Locales.Known.FirstOrDefault(locale => locale.Culture.Name.Equals(@"ru-RU"));

			// Создаем сплешер, так как ядро требует время на инициализацию
			var splash = new SplashForm();
			try
			{
				// Показываем сплешер
				splash.Show();
				// Создаем параметры инициализации ядра
				var initializationParameters = new ImageCoreInitializationParameters()
				{
					// Имя директории для сохранения логов. Если не указано, то логи будут храниться в директории %ProgramData%\Mallenom Systems\logs.
					LogDirectory = Path.Combine(Application.StartupPath, "logs"),
					// Имя файла конфигурации. Если не указано, то конфигурация будет храниться в файле %ProgramData%\Mallenom Systems\configs\recar2.cfg.
					ConfigFilename = Path.Combine(Application.StartupPath, "example.cfg"),
					// Количество каналов обработки (распознавания). Если не указано, то будет задействовано число каналов, указанное в лицензии.
					//VideoProcessChannelCount = 2,
					// Номера представлять в латинской кодировке
					ConvertPlateToCapsLatin = true,
					// Включаем специальный режим
					Advanced = true,
					// Активировать пробную версию, если необходимо
					TrialDelegate = TrialDelegate
				};
				using(var core = new ImageCore(initializationParameters)) // Создаем объект ядра
				{
					// Настраиваем модели стран номеров. Данная настройка необязательна и может быть выполнена из UI
					TuneModels(core);

					// Получаем настройка канала 0
					var settings = core.Settings.Channel(channelNum: 0);
					//settings.ProcessingStrategy.Value = ProcessingStrategy.Lite;
					settings.IsProcessAllMatrixes.Value = true;
					settings.ZoneSearchMethod.Value = ZoneSearchMethod.ProcessAll;
					//settings.MinPlateSize.Value = new SizeF(0.11f, 0.04f);
					//settings.MaxPlateSize.Value = new SizeF(0.20f, 0.21f);
					// можно указать размер номера в пикселях
					settings.RealZoneSizeMode.Value = ZoneSizeMode.Pixel;
					settings.MinPlateSize.Value = new Mallenom.Primitives.Size(70, 15);
					settings.MaxPlateSize.Value = new Mallenom.Primitives.Size(80, 20);

					settings.LocalizationBrightStep.Value = 5;
					settings.RecognitionBrightStep.Value = 5;

					settings.MaxProbDifference.Value = 0.1;

					settings.Apply();

					// Инициализируем ядро
					core.Initialize();
					// Загружаем настройки из файла конфигурации
					core.LoadSettings();
					// Создаем главную форму
					var form = new MainForm(core);
					// Загружаем настройки интерфейса пользователя
					var configFilename = FileNameGenerator.FromAssemblyLocation("sample.cfg");
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
				splash.Close();
				Log.Error("Ошибка инициализации ядра распознавания.", exc);
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
			// Подключаем необходимые объекты для логгирования
			LogManager.GetRepository().RootLogger.AddAppender(new FileAppender());
			var logViewAppender = new LogViewAppender();
			logViewAppender.AddFilter(new LevelRangeFilter(Level.Info, Level.Fatal));
			LogManager.GetRepository().RootLogger.AddAppender(new LogViewAppender());
		}

		private static void TuneModels(ImageCore core)
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

			// Устанавливаем удельные веса шаблонов номеров (0.0..1.0). Данные настройки также можно вызвать из UI.
			// Если 0.0, то шаблон не будет использоваться.
			if(core.Settings.Models.Exists("ru")) core.Settings.Models["ru"].Stencils["RU_N05_aa000000"].Weight = 1.0; // Включаем данный шаблон
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

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs arg)
		{
			HandleUnhandledException((Exception)arg.ExceptionObject);
			Process.GetCurrentProcess().Kill();
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs arg)
		{
			HandleUnhandledException(arg.Exception);
			Environment.Exit(0);
		}

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
