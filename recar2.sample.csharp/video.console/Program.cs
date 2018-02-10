using System;
using System.IO;
using System.Reflection;

using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;

using Recar2.Core;

namespace Recar2.Samples
{
	class Program
	{
		private static readonly ILog Log = LogManager.GetCurrentClassLog();

		static void Main(string[] args)
		{
			LogManager.GetRepository().RootLogger.AddAppender(new FileAppender());
			LogManager.GetRepository().RootLogger.AddAppender(new ConsoleAppender());

			try
			{
				// Создаем параметры инициализации ядра
				var initializationParameters = new VideoCoreInitializationParameters()
				{
//					// Имя директории для сохранения логов. Если не указано, то логи будут храниться в директории %ProgramData%\Mallenom Systems\logs.
					LogDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "logs"),
//					// Имя файла конфигурации. Если не указано, то конфигурация будет храниться в файле %ProgramData%\Mallenom Systems\configs\recar2.cfg.
					ConfigFilename = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "example.cfg"),
//					// Количество каналов обработки (распознавания). Если не указано, то будет задействовано число каналов, указанное в лицензии.
					VideoProcessChannelCount = 1,
					VideoOnlyViewChannelCount = 0,
					// Запрещаем автоматическую регистрацию видеоисточников
					LookupVideoSources = false,
					// Режим функционирования ядра
					//Advanced = true,
				};
				// Создаем ядро
				using(var core = new VideoCore(initializationParameters))
				{
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
					// Устанавливаем параметр алгоритма распознавания. Опционально
					core.Settings.Channel(0).MotionDetectMethod.Value = MotionDetectMethod.None; // Выключаем алгоритм определения движения
					core.Settings.Channel(0).DecisionKeepTimeout.Value = TimeSpan.Zero; // Выключаем блокировку повторного распознавания
					core.Settings.Apply();

					// Запускам процесс распознавания
					core.Start();

					WaitQuit();
	
					// Останавливаем процесс распознавания
					core.Stop();
				}
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка инициализации ядра распознавания.", exc);
			}
		}

		private static void WaitQuit()
		{
			Log.Info("Working... Press Ctrl-Q to quit.");
			ConsoleKeyInfo ki;
			do
			{
				ki = Console.ReadKey(true);
			} while(ki.Key != ConsoleKey.Q || ki.Modifiers != ConsoleModifiers.Control);
		}
	}
}
