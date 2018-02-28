using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;
using Mallenom.Localization;
using Mallenom.Localization.WinForms;
using Mallenom.Storage;

using Recar2.Core;
using Recar2.Core.UI;
using Recar2.Samples.UI;

namespace Recar2.Samples
{
	/// <summary>Главная форма приложения.</summary>
	partial class MainForm : Form
	{
		#region Data

		private static readonly ILog Log = LogManager.GetCurrentClassLog();

		private static readonly ILog NumbersLog = LogManager.GetLog("numbers");

		private readonly VideoCore _core;

		private IManualVideoRecordInfo _record1;

		private IManualVideoRecordInfo _record2;

		private readonly Matrix _numberMatrix = new Matrix();

		private readonly ImageVideoDisplayController _videoBinding;

		#endregion

		#region Locale

		class LocaleObserver : ICurrentLocaleObserver
		{
			public event EventHandler LocaleChanged;

			public event EventHandler Stopped;

			public void NotifyChanged()
			{
				var handler = LocaleChanged;
				if(handler != null) LocaleChanged.Invoke(this, EventArgs.Empty);
			}
		}

		private static readonly LocalizationScope LocalizationScope = new LocalizationScope(@"Recar2.MainForm");

		private static string GetLocalizedString(string stringId, string fallback = null)
		{
			return Locale.Current.GetString(LocalizationScope + stringId, fallback);
		}

		private LocaleSelector _localeSelector;

		private LocaleObserver _localeObserver;

		#endregion

		#region Properties

		public bool IsSaveImages { set; get; }

		public string SaveImagesDirectory { get; set; }

		public ImageFormat SaveImagesFileFormat { get; set; }

		#endregion

		#region Create & Destroy

		public MainForm(VideoCore core)
		{
			if(core == null) throw new ArgumentNullException("core");

			_core = core;

			InitializeComponent();
			Font = SystemFonts.MessageBoxFont;

			// Локализация
			this.Localize(LocalizationScope);

			_imgProcessed.Text = GetLocalizedString("AcceptedDecision");

			Text = string.Format(Locale.Current.Culture, Locale.Current.GetString(LocalizationScope + "Title", fallback: "Example {0} / {1}"), core.Version, core.FullVersion);
			_localeSelector = LocaleSelector.Create(_localeSelectorMenu);
			_localeObserver = new LocaleObserver();

			_toolTip.SetLocalizedToolTip(_imgVideo, LocalizationScope + "VideoChannel1Tip");
			_toolTip.SetLocalizedToolTip(_imgProcessed, LocalizationScope + "DetectedVehicleImage");
			
			Locale.ObserveCurrentChanged(_localeObserver);
			_localeObserver.LocaleChanged += (sender, args) => {
				Text = string.Format(Locale.Current.Culture, Locale.Current.GetString(LocalizationScope + "Title", fallback: "Example {0} / {1}"), core.Version, core.FullVersion);
				_imgProcessed.Text = GetLocalizedString("AcceptedDecision");
			};

			_imgVideo.Renderer = ImageRenderer.GDI;
			_imgProcessed.Renderer = ImageRenderer.GDI;

			
			// Если есть хотя бы один видеоканал, то регистрируем в нем контрол для вывода изображения
			if(_core.Channels.Any())
			{
				_videoBinding = _core.GetChannel(channelNum: 0).RegisterImage(_imgVideo);
				_videoBinding.ShowChannelName = true;
				_videoBinding.ShowRecognizedNumber = false;
				_videoBinding.ShowContextMenu = true;
			}

			_cmbSaveImagesFileFormat.Items.Add(ImageFormat.Bmp);
			_cmbSaveImagesFileFormat.Items.Add(ImageFormat.Jpeg);
			_cmbSaveImagesFileFormat.Items.Add(ImageFormat.Png);
			_cmbSaveImagesFileFormat.SelectedIndex = 0;
			SaveImagesFileFormat = (ImageFormat)_cmbSaveImagesFileFormat.SelectedItem;

			// Подписываемся на событие генерации номера
			_core.NumberRecognized += Core_OnNumberRecognized;
			// Подписываемся на событие обнаружения движения в кадре
			_core.MotionDetected += Core_OnMotionDetected;
		}

		#endregion

		#region Load & Save settings

		public void LoadSettings(IObjectStorageReader reader)
		{
			IsSaveImages = reader.TryReadParameter("IsSaveImages", false);
			SaveImagesDirectory = reader.TryReadParameter<string>("SaveImagesDirectory");
			SaveImagesFileFormat = new ImageFormat(reader.TryReadParameter("SaveImagesFileFormat", SaveImagesFileFormat.Guid));
		}

		public void SaveSettings(IObjectStorageWriter writer)
		{
			writer.WriteParameter("IsSaveImages", IsSaveImages);
			writer.WriteParameter("SaveImagesDirectory", SaveImagesDirectory);
			writer.WriteParameter("SaveImagesFileFormat", SaveImagesFileFormat.Guid);
		}

		#endregion

		#region Core events handlers

		/// <summary>Обработчик события: обнаружено или пропало движение.</summary>
		private void Core_OnMotionDetected(object sender, MotionDetectedEventArgs args)
		{
			MethodInvoker mi = () => _txtMotion.BackColor = args.HaveMotion ? Color.Red : Color.DimGray;
			if(InvokeRequired) BeginInvoke(mi);
			else mi();
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
				NumbersLog.InfoFormat("'{0}', type: {1}, source: {2}.", args.Number, args.Number.NumberType, args.Channel);
				_imgProcessed.Matrix = args.Matrix;
				var zoneRect = Rectangle.Intersect(args.Number.Zone.ToRect(), new Rectangle(0, 0, args.Matrix.Width, args.Matrix.Height));
				args.Matrix.CopyTo(_numberMatrix, zoneRect);
				_imagePlateZone.Matrix = _numberMatrix;
				if(_chkBoxIsSaveImages.Checked) SaveImage(args);
			}
		}

		private void SaveImage(NumberRecognizedEventArgs args)
		{
			try
			{
				if(string.IsNullOrEmpty(_txtSaveImagesDirectory.Text)) return;
				if(!Directory.Exists(_txtSaveImagesDirectory.Text))
				{
					Directory.CreateDirectory(_txtSaveImagesDirectory.Text);
				}
				var ext = SaveImagesFileFormat.ToString();
				var filename = Path.Combine(_txtSaveImagesDirectory.Text, string.Format("{0:yyyyMMdd_HHmmssff}_{1}_{2}.{3}", DateTime.Now, args.Number.Text, args.Channel.Id + 1, ext));
				using(var bmp = args.Matrix.CreateBitmap())
				{
					bmp.Save(filename, SaveImagesFileFormat);
				}
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка сохранения файла с изображением.", exc);
			}
		}

		#endregion

		#region Control event handlers

		private void MainForm_Load(object sender, EventArgs args)
		{
			_chkBoxIsSaveImages.Checked = IsSaveImages;
			_txtSaveImagesDirectory.Text = SaveImagesDirectory;
			_cmbSaveImagesFileFormat.SelectedItem = SaveImagesFileFormat;
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs args)
		{
			_core.NumberRecognized -= Core_OnNumberRecognized;
			_core.MotionDetected -= Core_OnMotionDetected;

			if(_videoBinding != null) _videoBinding.Dispose();

			IsSaveImages = _chkBoxIsSaveImages.Checked;
			SaveImagesDirectory = _txtSaveImagesDirectory.Text;
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

		private void _imgVideo_DoubleClick(object sender, EventArgs args)
		{
			using(var form = _core.CreateMultiVideoForm(0))
			{
				form.ShowDialog(this);
			}
		}

		private void _chkBoxSaveImages_CheckedChanged(object sender, EventArgs args)
		{
			_txtSaveImagesDirectory.Enabled = _chkBoxIsSaveImages.Checked;
			_btnView.Enabled = _chkBoxIsSaveImages.Checked;
		}

		private void _btnView_Click(object sender, EventArgs args)
		{
			using(var form = new FolderBrowserDialog())
			{
				if(form.ShowDialog() == DialogResult.OK)
				{
					_txtSaveImagesDirectory.Text = form.SelectedPath;
				}
			}
		}

		private void _btnShowVideoForm_Click(object sender, EventArgs args)
		{
			var form = _core.CreateMultiVideoForm(channelNum: 0);
			form.Show();
		}

		private void _cmbSaveImagesFileFormat_SelectedIndexChanged(object sender, EventArgs args)
		{
			SaveImagesFileFormat = (ImageFormat)_cmbSaveImagesFileFormat.SelectedItem;
		}

		private void _btnShowMySetupForm_Click(object sender, EventArgs e)
		{
			using(var form = new GeneralSettingsMyForm(_core))
			{
				form.ShowDialog(this);
				// Сохраняем настройки в файле конфигурации
				_core.SaveSettings();
			}
		}

		private void _btnShowStencils_Click(object sender, EventArgs args)
		{
			using(var form = new StencilsSampleImagesForm(_core))
			{
				form.ShowDialog();
			}
		}

		#endregion
	}
}
