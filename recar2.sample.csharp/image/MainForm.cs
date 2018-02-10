using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Mallenom.Diagnostics.Logs;
using Mallenom.Imaging;
using Mallenom.Storage;

using Recar2.Core.UI;

namespace Recar2.Samples
{
	/// <summary>Главная форма приложения.</summary>
	partial class MainForm : Form
	{
		#region Data

		private static readonly ILog Log = LogManager.GetCurrentClassLog();

		private const string DefaultFilename = @"data\B258MK35.bmp";

		private readonly ImageCore _core;

		private IImageMatrix _matrix;

		private Bitmap _bitmap;

		private string _filename;

		#endregion

		#region Create & Destroy

		public MainForm(ImageCore core)
		{
			if(core == null) throw new ArgumentNullException("core");

			_core = core;

			InitializeComponent();

			_image.Renderer = ImageRenderer.GDI;
			_image.Matrix.Resize(384, 288);
			_chkAsync.Checked = true;
		}

		#endregion

		#region Load & Save settings

		public void LoadSettings(IObjectStorageReader reader)
		{
			var filename = reader.TryReadParameter<string>("ImageFilename");
			LoadImage(filename);
		}

		public void SaveSettings(IObjectStorageWriter writer)
		{
			writer.WriteParameter("ImageFilename", _filename);
		}

		#endregion

		#region Event handlers

		private void MainForm_Load(object sender, EventArgs args)
		{
			if(string.IsNullOrEmpty(_filename))
			{
				LoadImage(Path.Combine(Application.StartupPath, DefaultFilename));
			}
		}

		private void _btnLoadImage_Click(object sender, EventArgs args)
		{
			using(var form = new OpenFileDialog()
			{
				Title = @"Загрузить изображение",
				Filter = @"Изображения(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|Все файлы (*.*)|*.*"
			})
			{
				if(form.ShowDialog(this) != DialogResult.OK) return;
				LoadImage(form.FileName);
			}
		}

		/// <summary>Показывает окно общих настроек.</summary>
		private void _btnSetup_Click(object sender, EventArgs args)
		{
			if(_core.ShowSetupForm(this) == DialogResult.OK)
			{
				// Сохраняем настройки в файла конфигурации
				_core.SaveSettings();
			}
		}

		/// <summary>Показывает окно настройки алгоритмов.</summary>
		private void _btnSetupAlg_Click(object sender, EventArgs args)
		{
			var channel = _core.GetChannel(0);
			if(channel.ShowAlgsSetupForm(this) == DialogResult.OK)
			{
				// Сохраняем настройки в файла конфигурации
				_core.SaveSettings();
			}
		}

		/// <summary>Показывает окно настройки зоны обработки и размеров номера.</summary>
		private void _btnSetupSize_Click(object sender, EventArgs args)
		{
			var channel = _core.GetChannel(0);
			if(channel.ShowCaptureAreaAndPlateSizeSetupForm(_image.Matrix, this) == DialogResult.OK)
			{
				var channelSettings = _core.Settings.Channel(0);
				channelSettings.Reload();

				Log.DebugFormat("MinPlateSize: {0}", channelSettings.MinPlateSize.Value);
				Log.DebugFormat("MaxPlateSize: {0}", channelSettings.MaxPlateSize.Value);
				// Сохраняем настройки в файла конфигурации
				_core.SaveSettings();
			}
		}

		private async void _btnProcessImageFromMatrix_Click(object sender, EventArgs args)
		{
			try
			{
				UpdateControls(false);
				var sw = Stopwatch.StartNew();
				var numbers = _chkAsync.Checked ? await _core.ProcessImageAsync(_matrix) : _core.ProcessImage(_matrix);
				sw.Stop();
				OutputNumbers(numbers);
				Log.DebugFormat("Время обработки: {0} мс (с учетом искусственной задержки).", sw.ElapsedMilliseconds);
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка распознавания номера.", exc);
			}
			finally
			{
				UpdateControls(true);
			}
		}

		private async void _btnProcessImageFromBitmap_Click(object sender, EventArgs args)
		{
			try
			{
				UpdateControls(false);
				var decisions = _chkAsync.Checked ? await _core.ProcessImageAsync(_bitmap) : _core.ProcessImage(_bitmap);
				OutputNumbers(decisions);
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка распознавание номера.", exc);
			}
			finally
			{
				UpdateControls(true);
			}
		}

		private async void _btnProcessImageFromFile_Click(object sender, EventArgs args)
		{
			try
			{
				UpdateControls(false);
				var decisions = _chkAsync.Checked ? await _core.ProcessImageAsync(_filename) : _core.ProcessImage(_filename);
				OutputNumbers(decisions);
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка распознавание номера.", exc);
			}
			finally
			{
				UpdateControls(true);
			}
		}

		#endregion

		#region Methods

		private void LoadImage(string filename)
		{
			try
			{
				_filename = filename;
				_bitmap = new Bitmap(_filename);
				_matrix = Matrix.LoadFrom(_bitmap);
			}
			catch(Exception exc)
			{
				Log.Error("Ошибка загрузки файла.", exc);
				_matrix = new Matrix();
			}
			_image.Text = string.Empty;
			_image.Frames.Clear();
			_image.Matrix = _matrix;
		}

		private void UpdateControls(bool enabled)
		{
			if(!enabled) _image.Text = string.Empty;
			_image.FooterText = enabled ? string.Empty : "Распознавание...";
			_btnSetup.Enabled = enabled;
			_btnLoadImage.Enabled = enabled;
			_btnProcessImageFromMatrix.Enabled = enabled;
			_btnProcessImageFromBitmap.Enabled = enabled;
			_btnProcessImageFromFile.Enabled = enabled;
		}

		private void OutputNumbers(IReadOnlyCollection<PlateNumber> numbers)
		{
			_image.Frames.Clear();
			foreach(var number in numbers)
			{
				Log.InfoFormat("Распознан номер: {0}.", number);
				_image.Frames.Add(new Frame(number.Zone.ToRect()) {Text = number.Text});
			}
			_image.Text = numbers.Any() ? numbers.First().Text : string.Empty;
			_image.Invalidate();
		}

		#endregion
	}
}
