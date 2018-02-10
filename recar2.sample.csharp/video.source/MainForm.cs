using System;
using System.Drawing;
using System.IO;
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

		private const string DefaultFilename = @"data\B258MK35.bmp";

		private readonly VideoCore _core;

		private readonly Matrix _numberMatrix = new Matrix();

		private readonly ImageVideoDisplayController _videoBinding;

		private Form _videoForm;

		#endregion

		#region Properties

		#endregion

		#region Create & Destroy

		public MainForm(VideoCore core)
		{
			if(core == null) throw new ArgumentNullException("core");

			_core = core;
			
			InitializeComponent();

			if(Environment.Is64BitProcess) Text = Text + " (x64)";

			ImageFilename = DefaultFilename;

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

			// Подписываемся на событие генерации номера
			_core.NumberRecognized += Core_OnNumberRecognized;
			// Подписываемся на событие обнаружения движения в кадре
			_core.MotionDetected += Core_OnMotionDetected;
		}

		#endregion

		#region Load & Save settings

		public void LoadSettings(IObjectStorageReader reader)
		{
			ImageFilename = reader.TryReadParameter("ImageFilename", DefaultFilename);
		}

		public void SaveSettings(IObjectStorageWriter writer)
		{
			writer.WriteParameter("ImageFilename", ImageFilename ?? string.Empty);
		}

		private string ImageFilename { set; get; }

		#endregion

		#region Core events handlers

		/// <summary>Обработчик события: обнаружено или пропало движение.</summary>
		private void Core_OnMotionDetected(object sender, MotionDetectedEventArgs args)
		{
			MethodInvoker mi = () => _txtMotion.BackColor = args.HaveMotion ? Color.Red : Color.DimGray;
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
				//Log.InfoFormat("'Лучший' кадр {0:HH:mm:ss.ff}.", args.Number.BestFrameTimeStamp);
				_imgProcessed.Matrix = args.Matrix;
				_imgProcessed.FooterText = args.Number.BestFrameTimeStamp.ToString("HH:mm:ss.ff");
				args.Matrix.CopyTo(_numberMatrix, args.Number.Zone.ToRect());
				_imagePlateZone.Matrix = _numberMatrix;
			}
		}

		#endregion

		#region Control event handlers

		private void MainForm_Load(object sender, EventArgs args)
		{
			_txtImageFilename.Text = ImageFilename;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs args)
		{
			_core.NumberRecognized -= Core_OnNumberRecognized;
			_core.MotionDetected -= Core_OnMotionDetected;

			if(_videoBinding != null) _videoBinding.Dispose();

			ImageFilename = _txtImageFilename.Text;
		}

		private void _btnPushFrame_Click(object sender, EventArgs args)
		{
			try
			{
				var source = (ImageVideoSource)_core.GetChannel(0).VideoSource;
				var path = Path.IsPathRooted(_txtImageFilename.Text) ? _txtImageFilename.Text : Path.Combine(Application.StartupPath, _txtImageFilename.Text);
				using(var image = (Bitmap)Bitmap.FromFile(path))
				{
					source.PushFrame(image, DateTime.Now);
				}
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка передачи кадра в видеоисточник.", exc);
			}
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

		private void _imgVideo_DoubleClick(object sender, EventArgs args)
		{
			ShowVideoForm();
		}

		private void _btnShowVideoForm_Click(object sender, EventArgs e)
		{
			ShowVideoForm();
		}

		private void ShowVideoForm()
		{
			if(_videoForm == null)
			{
				_videoForm = _core.CreateMultiVideoForm(0);
				_videoForm.Closed += (s, a) => _videoForm = null;
				_videoForm.Show(this);
			}
			else
			{
				_videoForm.BringToFront();
				_videoForm.WindowState = FormWindowState.Normal;
			}
		}

		#endregion
	}
}
