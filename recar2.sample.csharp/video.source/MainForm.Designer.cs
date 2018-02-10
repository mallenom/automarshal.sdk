using Mallenom.Diagnostics.Logs;
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
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.GroupBox groupBox2;
			this._logView = new Mallenom.Diagnostics.Logs.LogView();
			this._ligViewToolStrip = new Mallenom.Diagnostics.Logs.LogViewToolStrip();
			this._btnRecognize = new System.Windows.Forms.Button();
			this._txtImageFilename = new System.Windows.Forms.TextBox();
			this._btnSetup = new System.Windows.Forms.Button();
			this._txtPlate = new System.Windows.Forms.TextBox();
			this._toolTip = new System.Windows.Forms.ToolTip(this.components);
			this._imagePlateZone = new Mallenom.Imaging.Image();
			this._imgVideo = new Mallenom.Imaging.ScrollImage();
			this._imgProcessed = new Mallenom.Imaging.ScrollImage();
			this._txtMotion = new System.Windows.Forms.Label();
			this._logNumbers = new Mallenom.Diagnostics.Logs.LogView();
			this._btnShowVideoForm = new System.Windows.Forms.Button();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			groupBox1.Controls.Add(this._logView);
			groupBox1.Controls.Add(this._ligViewToolStrip);
			groupBox1.Location = new System.Drawing.Point(3, 466);
			groupBox1.Margin = new System.Windows.Forms.Padding(10);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(770, 193);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Лог";
			// 
			// _logView
			// 
			this._logView.AppenderName = "root";
			this._logView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._logView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._logView.ItemLimit = 100000;
			this._logView.Location = new System.Drawing.Point(3, 44);
			this._logView.Name = "_logView";
			this._logView.Size = new System.Drawing.Size(764, 146);
			this._logView.TabIndex = 3;
			// 
			// _ligViewToolStrip
			// 
			this._ligViewToolStrip.AllowAdvancedFilter = true;
			this._ligViewToolStrip.Dock = System.Windows.Forms.DockStyle.Top;
			this._ligViewToolStrip.Location = new System.Drawing.Point(3, 19);
			this._ligViewToolStrip.LogView = this._logView;
			this._ligViewToolStrip.MaximumSize = new System.Drawing.Size(1920, 25);
			this._ligViewToolStrip.MinimumSize = new System.Drawing.Size(0, 25);
			this._ligViewToolStrip.Name = "_ligViewToolStrip";
			this._ligViewToolStrip.Size = new System.Drawing.Size(764, 25);
			this._ligViewToolStrip.TabIndex = 0;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this._btnShowVideoForm);
			groupBox2.Controls.Add(this._btnRecognize);
			groupBox2.Controls.Add(this._txtImageFilename);
			groupBox2.Controls.Add(this._btnSetup);
			groupBox2.Location = new System.Drawing.Point(6, 294);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(378, 169);
			groupBox2.TabIndex = 20;
			groupBox2.TabStop = false;
			groupBox2.Text = "Видеоввод";
			// 
			// _btnRecognize
			// 
			this._btnRecognize.Location = new System.Drawing.Point(6, 51);
			this._btnRecognize.Name = "_btnRecognize";
			this._btnRecognize.Size = new System.Drawing.Size(97, 40);
			this._btnRecognize.TabIndex = 4;
			this._btnRecognize.Text = "Отправить изображение";
			this._btnRecognize.UseVisualStyleBackColor = true;
			this._btnRecognize.Click += new System.EventHandler(this._btnPushFrame_Click);
			// 
			// _txtImageFilename
			// 
			this._txtImageFilename.Location = new System.Drawing.Point(6, 22);
			this._txtImageFilename.Name = "_txtImageFilename";
			this._txtImageFilename.Size = new System.Drawing.Size(366, 23);
			this._txtImageFilename.TabIndex = 3;
			// 
			// _btnSetup
			// 
			this._btnSetup.Location = new System.Drawing.Point(109, 51);
			this._btnSetup.Name = "_btnSetup";
			this._btnSetup.Size = new System.Drawing.Size(97, 40);
			this._btnSetup.TabIndex = 0;
			this._btnSetup.Text = "Настройка";
			this._btnSetup.UseVisualStyleBackColor = true;
			this._btnSetup.Click += new System.EventHandler(this._btnSetup_Click);
			// 
			// _txtPlate
			// 
			this._txtPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtPlate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._txtPlate.Location = new System.Drawing.Point(390, 302);
			this._txtPlate.Name = "_txtPlate";
			this._txtPlate.ReadOnly = true;
			this._txtPlate.Size = new System.Drawing.Size(197, 43);
			this._txtPlate.TabIndex = 1;
			this._txtPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this._toolTip.SetToolTip(this._txtPlate, "ГРЗ обнаруженного ТС");
			// 
			// _imagePlateZone
			// 
			this._imagePlateZone.FooterFont = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imagePlateZone.Location = new System.Drawing.Point(593, 302);
			this._imagePlateZone.Name = "_imagePlateZone";
			this._imagePlateZone.Size = new System.Drawing.Size(181, 43);
			this._imagePlateZone.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imagePlateZone.TabIndex = 13;
			this._toolTip.SetToolTip(this._imagePlateZone, "Изображение обнаруженного ТС");
			// 
			// _imgVideo
			// 
			this._imgVideo.CoordsFont = new System.Drawing.Font("Verdana", 8F);
			this._imgVideo.FastDraw = false;
			this._imgVideo.FooterFont = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgVideo.FPSFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgVideo.FramePixel = Mallenom.Imaging.FramePixel.Matrix;
			this._imgVideo.FrameUpdate = false;
			this._imgVideo.FrameValidation = true;
			this._imgVideo.Location = new System.Drawing.Point(0, 0);
			this._imgVideo.MarkerSize = 1;
			this._imgVideo.MatrixRectPosition = new System.Drawing.Point(0, 0);
			this._imgVideo.MinimumZoomSize = new System.Drawing.Size(15, 15);
			this._imgVideo.Name = "_imgVideo";
			this._imgVideo.Scale = 0;
			this._imgVideo.ScrollStyle = Mallenom.Imaging.ScrollStyle.MouseWheel;
			this._imgVideo.Size = new System.Drawing.Size(384, 288);
			this._imgVideo.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imgVideo.TabIndex = 0;
			this._imgVideo.TextRedraw = false;
			this._toolTip.SetToolTip(this._imgVideo, "Видео с канала 1");
			this._imgVideo.DoubleClick += new System.EventHandler(this._imgVideo_DoubleClick);
			// 
			// _imgProcessed
			// 
			this._imgProcessed.CoordsFont = new System.Drawing.Font("Verdana", 8F);
			this._imgProcessed.FooterFont = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgProcessed.FPSFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgProcessed.FPSVisible = false;
			this._imgProcessed.FramePixel = Mallenom.Imaging.FramePixel.Matrix;
			this._imgProcessed.Location = new System.Drawing.Point(390, 0);
			this._imgProcessed.MatrixRectPosition = new System.Drawing.Point(0, 0);
			this._imgProcessed.MinimumZoomSize = new System.Drawing.Size(15, 15);
			this._imgProcessed.Name = "_imgProcessed";
			this._imgProcessed.Scale = 0;
			this._imgProcessed.ScrollStyle = Mallenom.Imaging.ScrollStyle.MouseWheel;
			this._imgProcessed.Size = new System.Drawing.Size(384, 288);
			this._imgProcessed.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imgProcessed.TabIndex = 0;
			this._imgProcessed.Text = "Принятое решение";
			this._toolTip.SetToolTip(this._imgProcessed, "Изображение обнаруженного ТС");
			// 
			// _txtMotion
			// 
			this._txtMotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._txtMotion.Location = new System.Drawing.Point(307, 6);
			this._txtMotion.Name = "_txtMotion";
			this._txtMotion.Size = new System.Drawing.Size(71, 28);
			this._txtMotion.TabIndex = 17;
			this._txtMotion.Text = "Движение";
			this._txtMotion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// _logNumbers
			// 
			this._logNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this._logNumbers.AppenderName = "numbers";
			this._logNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._logNumbers.Location = new System.Drawing.Point(390, 351);
			this._logNumbers.Name = "_logNumbers";
			this._logNumbers.Size = new System.Drawing.Size(384, 112);
			this._logNumbers.TabIndex = 23;
			// 
			// _btnShowVideoForm
			// 
			this._btnShowVideoForm.Location = new System.Drawing.Point(212, 51);
			this._btnShowVideoForm.Name = "_btnShowVideoForm";
			this._btnShowVideoForm.Size = new System.Drawing.Size(97, 40);
			this._btnShowVideoForm.TabIndex = 5;
			this._btnShowVideoForm.Text = "Видеоформа";
			this._btnShowVideoForm.UseVisualStyleBackColor = true;
			this._btnShowVideoForm.Click += new System.EventHandler(this._btnShowVideoForm_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(776, 662);
			this.Controls.Add(this._logNumbers);
			this.Controls.Add(groupBox2);
			this.Controls.Add(this._txtMotion);
			this.Controls.Add(this._imagePlateZone);
			this.Controls.Add(groupBox1);
			this.Controls.Add(this._txtPlate);
			this.Controls.Add(this._imgVideo);
			this.Controls.Add(this._imgProcessed);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Пример использования ядра ПО Автомаршал";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ScrollImage _imgVideo;
		private ScrollImage _imgProcessed;
		private Image _imagePlateZone;
		private LogView _logView;
		private LogViewToolStrip _ligViewToolStrip;
		private LogView _logNumbers;
		private System.Windows.Forms.TextBox _txtPlate;
		private System.Windows.Forms.Button _btnSetup;
		private System.Windows.Forms.ToolTip _toolTip;
		private System.Windows.Forms.Label _txtMotion;
		private System.Windows.Forms.TextBox _txtImageFilename;
		private System.Windows.Forms.Button _btnRecognize;
		private System.Windows.Forms.Button _btnShowVideoForm;
	}
}

