using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;
using Mallenom.Storage;

using Recar2.Core;
using Recar2.Core.UI;

namespace Recar2.Samples
{
	/// <summary>Главная форма приложения.</summary>
	partial class MainForm : Form
	{
		#region Data

		private static readonly ILog Log = LogManager.GetCurrentClassLog();
		
		private static readonly ILog NumbersLog = LogManager.GetLog("numbers");

		private readonly VideoCore _core;

		private readonly Matrix _numberMatrix = new Matrix();

		private readonly ImageVideoDisplayController _videoBinding;

		#endregion

		#region Properties

		#endregion

		#region Create & Destroy

		public MainForm(VideoCore core)
		{
			if(core == null) throw new ArgumentNullException("core");

			_core = core;
			
			InitializeComponent();

			_imgVideo.Renderer = ImageRenderer.GDI;
			_imgProcessed.Renderer = ImageRenderer.GDI;

			// Если есть хотя бы один видеоканал, то регистрируем в нем контрол для вывода изображения
			if(_core.Channels.Any())
			{
				_videoBinding = _core.GetChannel(0).RegisterImage(_imgVideo);
				_videoBinding.ShowChannelName = true;
				_videoBinding.ShowRecognizedNumber = false;
				_videoBinding.ShowContextMenu = true;
			}
		}

		#endregion

		#region Load & Save settings

		public void LoadSettings(IObjectStorageReader reader)
		{
		}

		public void SaveSettings(IObjectStorageWriter writer)
		{
		}

		#endregion

		#region Core events handlers

		/// <summary>Обработчик события: обнаружено или потеряно движение.</summary>
		private void Core_OnMotionDetected(object sender, MotionDetectedEventArgs args)
		{
			MethodInvoker mi = () => _txtMotion.BackColor = args.HaveMotion ? Color.LightGreen : Color.LightCoral;
			if(InvokeRequired) BeginInvoke(mi); else mi();
		}

		/// <summary>Обработчик события: номер распознан.</summary>
		private void Core_OnNumberRecognized(object sender, NumberRecognizedEventArgs args)
		{
			if(InvokeRequired)
			{
				BeginInvoke(new EventHandler<NumberRecognizedEventArgs>(Core_OnNumberRecognized), sender, args);
			}
			else
			{
				_txtPlate.Text = args.Number.Text;
				NumbersLog.InfoFormat("'{0}', тип: {1}, источник: {2}.", args.Number, args.Number.NumberType, args.Channel);
				_imgProcessed.Matrix = args.Matrix;
				args.Matrix.CopyTo(_numberMatrix, args.Number.Zone.ToRect());
				_imagePlateZone.Matrix = _numberMatrix;
			}
		}

		#endregion

		#region Control event handlers

		private void MainForm_Load(object sender, EventArgs args)
		{
			// Подписываемся на событие генерации номера
			_core.NumberRecognized += Core_OnNumberRecognized;
			// Подписываемся на событие обнаружения движения в кадре
			_core.MotionDetected += Core_OnMotionDetected;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs args)
		{
			_core.NumberRecognized -= Core_OnNumberRecognized;
			_core.MotionDetected -= Core_OnMotionDetected;

			if(_videoBinding != null) _videoBinding.Dispose();
		}

		private void _btnSetup_Click(object sender, EventArgs args)
		{
			// Показываем форму настроек
			if(_core.ShowSetupForm(this) == DialogResult.OK)
			{
				// Сохраняем настройки в файле конфигурации
				_core.SaveSettings();
			}
		}

		private void _btnStart_Click(object sender, EventArgs args)
		{
			try
			{
				_core.Start();
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка запуска ядра.", exc);
			}
		}

		private void _btnStop_Click(object sender, EventArgs args)
		{
			try
			{
				_core.Stop();
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка останова ядра.", exc);
			}
		}

		#endregion
	}
}
