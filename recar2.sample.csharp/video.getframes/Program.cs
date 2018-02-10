using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Mallenom.Diagnostics;
using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;
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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Настраиваем вывод в лог файлы. Данная настройка необязательна и необходима только для дополнительного логгирования
			TuneLogs();

			if(!Debugger.IsAttached) // Если не подключен дебаггер, то перехватываем все исключения в программе
			{
				Application.ThreadException += Application_ThreadException;
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			}

			// Создаем сплешер, так как инициализация ядра требует некоторого времени
			var splash = new SplashForm();
			try
			{
				// Показываем сплешер
				splash.Show();
				// Создаем параметры инициализации ядра
				var initializationParameters = new VideoCoreInitializationParameters()
				{
					// Имя директории для сохранения логов. Если не указано, то логи будут храниться в директории %ProgramData%\Mallenom Systems\logs.
					LogDirectory = Path.Combine(Application.StartupPath, "logs"),
					// Имя файла конфигурации. Если не указано, то конфигурация будет храниться в файле %ProgramData%\Mallenom Systems\configs\recar2.cfg.
					ConfigFilename = Path.Combine(Application.StartupPath, "example.cfg"),
					// Количество каналов обработки (распознавания). Если не указано, то будет задействовано число каналов, указанное в лицензии.
					VideoProcessChannelCount = 1,
					VideoOnlyViewChannelCount = 0,
				};
				// Создаем ядро
				using(var core = new VideoCore(initializationParameters))
				{
					// Настраиваем модели стран номеров. Данная настройка необязательна и может быть выполнена из UI
					TuneModels(core);

					// Регистрируем видеоисточник, в который будем передавать изображения
					var imageVideoSourceProvider = new ImageVideoSourceProvider();
					core.VideoManager.RegisterVideoSourceProvider(imageVideoSourceProvider, metadata: null);
					// Делаем его активным
					core.GetChannel(0).SetVideoSource(new VideoSourceInfo(imageVideoSourceProvider, new VideoSourceProviderMetadata()));

					var matrix = Matrix.LoadFrom(@"data\B258MK35.bmp");
					((ImageVideoSource)core.GetChannel(0).VideoSource).SetImage(matrix);

					// Инициализируем ядро
					core.Initialize();

					// Загружаем настройки из файла конфигурации
					core.LoadSettings();

					// Устанавливаем параметр алгоритма распознавания
					core.Settings.Channel(0).MotionDetectMethod.Value = MotionDetectMethod.None; // Выключаем алгоритм определения движения
					core.Settings.Channel(0).DecisionKeepTimeout.Value = TimeSpan.Zero; // Выключаем блокировку повторного распознавания
					core.Settings.Apply();

					var configFilename = FileNameGenerator.FromAssemblyLocation("sample.cfg");

					var form = new MainForm(core);
					LoadUISettings(configFilename, form);

					// Закрываем сплешер
					splash.Close();
					// Запускаем форму приложения
					Application.Run(form);

					core.SaveSettings();

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
			logViewAppender.AddFilter(new LevelRangeFilter(Level.Info, Level.Fatal));
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
			Log.Fatal("Программа завершена с критической ошибкой.", exc);
			using(var form = new ExceptionForm(exc))
			{
				form.ShowDialog();
			}
		}
	}
}
