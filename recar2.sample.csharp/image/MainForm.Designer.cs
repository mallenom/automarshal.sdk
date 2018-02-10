using Mallenom.Imaging;

namespace Recar2.Samples
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._logViewStrip = new Mallenom.Diagnostics.Logs.LogViewToolStrip();
			this._logView = new Mallenom.Diagnostics.Logs.LogView();
			this._btnSetup = new System.Windows.Forms.Button();
			this._toolTip = new System.Windows.Forms.ToolTip(this.components);
			this._image = new Mallenom.Imaging.ScrollImage();
			this._btnProcessImageFromFile = new System.Windows.Forms.Button();
			this._btnProcessImageFromMatrix = new System.Windows.Forms.Button();
			this._btnLoadImage = new System.Windows.Forms.Button();
			this._btnProcessImageFromBitmap = new System.Windows.Forms.Button();
			this._chkAsync = new System.Windows.Forms.CheckBox();
			this._btnSetupSize = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._logViewStrip);
			this.groupBox1.Controls.Add(this._logView);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(3, 368);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(695, 257);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Лог";
			// 
			// _logViewStrip
			// 
			this._logViewStrip.AllowAdvancedFilter = true;
			this._logViewStrip.Dock = System.Windows.Forms.DockStyle.Top;
			this._logViewStrip.Location = new System.Drawing.Point(3, 19);
			this._logViewStrip.LogView = this._logView;
			this._logViewStrip.MaximumSize = new System.Drawing.Size(2240, 29);
			this._logViewStrip.MinimumSize = new System.Drawing.Size(0, 29);
			this._logViewStrip.Name = "_logViewStrip";
			this._logViewStrip.Size = new System.Drawing.Size(689, 29);
			this._logViewStrip.TabIndex = 4;
			// 
			// _logView
			// 
			this._logView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._logView.AppenderName = "root";
			this._logView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._logView.Location = new System.Drawing.Point(3, 52);
			this._logView.Name = "_logView";
			this._logView.Size = new System.Drawing.Size(692, 202);
			this._logView.TabIndex = 3;
			// 
			// _btnSetup
			// 
			this._btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnSetup.Location = new System.Drawing.Point(587, 151);
			this._btnSetup.Name = "_btnSetup";
			this._btnSetup.Size = new System.Drawing.Size(108, 40);
			this._btnSetup.TabIndex = 2;
			this._btnSetup.Text = "Настроить алгоритмы";
			this._btnSetup.UseVisualStyleBackColor = true;
			this._btnSetup.Click += new System.EventHandler(this._btnSetupAlg_Click);
			// 
			// _image
			// 
			this._image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._image.CoordsFont = new System.Drawing.Font("Verdana", 8F);
			this._image.FastDraw = false;
			this._image.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._image.FooterColor = System.Drawing.Color.LimeGreen;
			this._image.FooterFont = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._image.ForeColor = System.Drawing.Color.OrangeRed;
			this._image.FPSFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._image.FPSVisible = false;
			this._image.FramePixel = Mallenom.Imaging.FramePixel.Matrix;
			this._image.FrameValidation = true;
			this._image.Location = new System.Drawing.Point(0, 0);
			this._image.MarkerSize = 1;
			this._image.MatrixRectPosition = new System.Drawing.Point(0, 0);
			this._image.MinimumZoomSize = new System.Drawing.Size(15, 15);
			this._image.Name = "_image";
			this._image.Scale = 0;
			this._image.ScrollStyle = Mallenom.Imaging.ScrollStyle.MouseWheel;
			this._image.Size = new System.Drawing.Size(581, 366);
			this._image.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._image.TabIndex = 0;
			// 
			// _btnProcessImageFromFile
			// 
			this._btnProcessImageFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnProcessImageFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnProcessImageFromFile.Location = new System.Drawing.Point(587, 298);
			this._btnProcessImageFromFile.Name = "_btnProcessImageFromFile";
			this._btnProcessImageFromFile.Size = new System.Drawing.Size(108, 40);
			this._btnProcessImageFromFile.TabIndex = 18;
			this._btnProcessImageFromFile.Text = "Распознать из файла";
			this._btnProcessImageFromFile.UseVisualStyleBackColor = true;
			this._btnProcessImageFromFile.Click += new System.EventHandler(this._btnProcessImageFromFile_Click);
			// 
			// _btnProcessImageFromMatrix
			// 
			this._btnProcessImageFromMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnProcessImageFromMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnProcessImageFromMatrix.Location = new System.Drawing.Point(587, 206);
			this._btnProcessImageFromMatrix.Name = "_btnProcessImageFromMatrix";
			this._btnProcessImageFromMatrix.Size = new System.Drawing.Size(108, 40);
			this._btnProcessImageFromMatrix.TabIndex = 19;
			this._btnProcessImageFromMatrix.Text = "Распознать из Matrix";
			this._btnProcessImageFromMatrix.UseVisualStyleBackColor = true;
			this._btnProcessImageFromMatrix.Click += new System.EventHandler(this._btnProcessImageFromMatrix_Click);
			// 
			// _btnLoadImage
			// 
			this._btnLoadImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnLoadImage.Location = new System.Drawing.Point(587, 6);
			this._btnLoadImage.Name = "_btnLoadImage";
			this._btnLoadImage.Size = new System.Drawing.Size(108, 40);
			this._btnLoadImage.TabIndex = 20;
			this._btnLoadImage.Text = "Загрузить изображение";
			this._btnLoadImage.UseVisualStyleBackColor = true;
			this._btnLoadImage.Click += new System.EventHandler(this._btnLoadImage_Click);
			// 
			// _btnProcessImageFromBitmap
			// 
			this._btnProcessImageFromBitmap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnProcessImageFromBitmap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnProcessImageFromBitmap.Location = new System.Drawing.Point(587, 252);
			this._btnProcessImageFromBitmap.Name = "_btnProcessImageFromBitmap";
			this._btnProcessImageFromBitmap.Size = new System.Drawing.Size(108, 40);
			this._btnProcessImageFromBitmap.TabIndex = 21;
			this._btnProcessImageFromBitmap.Text = "Распознать из Bitmap";
			this._btnProcessImageFromBitmap.UseVisualStyleBackColor = true;
			this._btnProcessImageFromBitmap.Click += new System.EventHandler(this._btnProcessImageFromBitmap_Click);
			// 
			// _chkAsync
			// 
			this._chkAsync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._chkAsync.Location = new System.Drawing.Point(590, 343);
			this._chkAsync.Name = "_chkAsync";
			this._chkAsync.Size = new System.Drawing.Size(100, 34);
			this._chkAsync.TabIndex = 22;
			this._chkAsync.Text = "Асинхронная обработка";
			this._chkAsync.UseVisualStyleBackColor = true;
			// 
			// _btnSetupSize
			// 
			this._btnSetupSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnSetupSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._btnSetupSize.Location = new System.Drawing.Point(587, 105);
			this._btnSetupSize.Name = "_btnSetupSize";
			this._btnSetupSize.Size = new System.Drawing.Size(108, 40);
			this._btnSetupSize.TabIndex = 23;
			this._btnSetupSize.Text = "Настроить размер номера";
			this._btnSetupSize.UseVisualStyleBackColor = true;
			this._btnSetupSize.Click += new System.EventHandler(this._btnSetupSize_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(587, 59);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(108, 40);
			this.button1.TabIndex = 24;
			this.button1.Text = "Общие настройки";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this._btnSetup_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(701, 628);
			this.Controls.Add(this.button1);
			this.Controls.Add(this._btnSetupSize);
			this.Controls.Add(this._chkAsync);
			this.Controls.Add(this._btnProcessImageFromBitmap);
			this.Controls.Add(this._btnLoadImage);
			this.Controls.Add(this._btnProcessImageFromMatrix);
			this.Controls.Add(this._btnProcessImageFromFile);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._btnSetup);
			this.Controls.Add(this._image);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Пример использования ядра распознавания ПО Автомаршал";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ScrollImage _image;
		private System.Windows.Forms.Button _btnSetup;
		private System.Windows.Forms.Button _btnLoadImage;
		private System.Windows.Forms.Button _btnProcessImageFromMatrix;
		private System.Windows.Forms.Button _btnProcessImageFromFile;
		private System.Windows.Forms.ToolTip _toolTip;
		private Mallenom.Diagnostics.Logs.LogView _logView;
		private Mallenom.Diagnostics.Logs.LogViewToolStrip _logViewStrip;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button _btnProcessImageFromBitmap;
		private System.Windows.Forms.CheckBox _chkAsync;
		private System.Windows.Forms.Button _btnSetupSize;
		private System.Windows.Forms.Button button1;
	}
}

