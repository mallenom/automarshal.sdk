using Mallenom.Diagnostics.Logs;

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
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.GroupBox groupBox4;
			System.Windows.Forms.Label label1;
			this._logView = new Mallenom.Diagnostics.Logs.LogView();
			this._ligViewToolStrip = new Mallenom.Diagnostics.Logs.LogViewToolStrip();
			this._btnStart = new System.Windows.Forms.Button();
			this._btnStop = new System.Windows.Forms.Button();
			this._cmbSaveImagesFileFormat = new System.Windows.Forms.ComboBox();
			this._chkBoxIsSaveImages = new System.Windows.Forms.CheckBox();
			this._txtSaveImagesDirectory = new System.Windows.Forms.TextBox();
			this._btnView = new System.Windows.Forms.Button();
			this._btnSetup = new System.Windows.Forms.Button();
			this._btnShowVideoForm = new System.Windows.Forms.Button();
			this._txtPlate = new System.Windows.Forms.TextBox();
			this._toolTip = new System.Windows.Forms.ToolTip(this.components);
			this._imagePlateZone = new Mallenom.Imaging.Image();
			this._imgProcessed = new Mallenom.Imaging.Image();
			this._imgVideo = new Mallenom.Imaging.Image();
			this._txtMotion = new System.Windows.Forms.Label();
			this._logNumbers = new Mallenom.Diagnostics.Logs.LogView();
			this._grpSetup = new System.Windows.Forms.GroupBox();
			this._btnShowMySetupForm = new System.Windows.Forms.Button();
			this._btnShowStencils = new System.Windows.Forms.Button();
			this._localeMenu = new System.Windows.Forms.MenuStrip();
			this._localeSelectorMenu = new System.Windows.Forms.ToolStripMenuItem();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox4.SuspendLayout();
			this._grpSetup.SuspendLayout();
			this._localeMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			groupBox1.Controls.Add(this._logView);
			groupBox1.Controls.Add(this._ligViewToolStrip);
			groupBox1.Location = new System.Drawing.Point(3, 518);
			groupBox1.Margin = new System.Windows.Forms.Padding(10);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(770, 183);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "%Log%";
			// 
			// _logView
			// 
			this._logView.AppenderName = "root";
			this._logView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._logView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._logView.ItemLimit = 100000;
			this._logView.Location = new System.Drawing.Point(3, 44);
			this._logView.Name = "_logView";
			this._logView.Size = new System.Drawing.Size(764, 136);
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
			groupBox2.Controls.Add(this._btnStart);
			groupBox2.Controls.Add(this._btnStop);
			groupBox2.Location = new System.Drawing.Point(6, 323);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(94, 80);
			groupBox2.TabIndex = 20;
			groupBox2.TabStop = false;
			groupBox2.Text = "%Capture%";
			// 
			// _btnStart
			// 
			this._btnStart.Location = new System.Drawing.Point(9, 18);
			this._btnStart.Name = "_btnStart";
			this._btnStart.Size = new System.Drawing.Size(75, 23);
			this._btnStart.TabIndex = 1;
			this._btnStart.Text = "%Start%";
			this._btnStart.UseVisualStyleBackColor = true;
			this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
			// 
			// _btnStop
			// 
			this._btnStop.Location = new System.Drawing.Point(9, 47);
			this._btnStop.Name = "_btnStop";
			this._btnStop.Size = new System.Drawing.Size(75, 23);
			this._btnStop.TabIndex = 2;
			this._btnStop.Text = "%Stop%";
			this._btnStop.UseVisualStyleBackColor = true;
			this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
			// 
			// groupBox3
			// 
			groupBox3.Location = new System.Drawing.Point(298, 409);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(180, 105);
			groupBox3.TabIndex = 21;
			groupBox3.TabStop = false;
			groupBox3.Text = "%Record%";
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(label1);
			groupBox4.Controls.Add(this._cmbSaveImagesFileFormat);
			groupBox4.Controls.Add(this._chkBoxIsSaveImages);
			groupBox4.Controls.Add(this._txtSaveImagesDirectory);
			groupBox4.Controls.Add(this._btnView);
			groupBox4.Location = new System.Drawing.Point(6, 409);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(286, 105);
			groupBox4.TabIndex = 22;
			groupBox4.TabStop = false;
			groupBox4.Text = "%Images%";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(6, 76);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(65, 15);
			label1.TabIndex = 12;
			label1.Text = "%Format%";
			// 
			// _cmbSaveImagesFileFormat
			// 
			this._cmbSaveImagesFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cmbSaveImagesFileFormat.FormattingEnabled = true;
			this._cmbSaveImagesFileFormat.Location = new System.Drawing.Point(90, 73);
			this._cmbSaveImagesFileFormat.Name = "_cmbSaveImagesFileFormat";
			this._cmbSaveImagesFileFormat.Size = new System.Drawing.Size(66, 23);
			this._cmbSaveImagesFileFormat.TabIndex = 11;
			this._cmbSaveImagesFileFormat.SelectedIndexChanged += new System.EventHandler(this._cmbSaveImagesFileFormat_SelectedIndexChanged);
			// 
			// _chkBoxIsSaveImages
			// 
			this._chkBoxIsSaveImages.AutoSize = true;
			this._chkBoxIsSaveImages.Location = new System.Drawing.Point(9, 21);
			this._chkBoxIsSaveImages.Name = "_chkBoxIsSaveImages";
			this._chkBoxIsSaveImages.Size = new System.Drawing.Size(107, 19);
			this._chkBoxIsSaveImages.TabIndex = 9;
			this._chkBoxIsSaveImages.Text = "IsSavingImages";
			this._chkBoxIsSaveImages.UseVisualStyleBackColor = true;
			this._chkBoxIsSaveImages.CheckedChanged += new System.EventHandler(this._chkBoxSaveImages_CheckedChanged);
			// 
			// _txtSaveImagesDirectory
			// 
			this._txtSaveImagesDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this._txtSaveImagesDirectory.Enabled = false;
			this._txtSaveImagesDirectory.Location = new System.Drawing.Point(6, 46);
			this._txtSaveImagesDirectory.Name = "_txtSaveImagesDirectory";
			this._txtSaveImagesDirectory.ReadOnly = true;
			this._txtSaveImagesDirectory.Size = new System.Drawing.Size(274, 23);
			this._txtSaveImagesDirectory.TabIndex = 10;
			// 
			// _btnView
			// 
			this._btnView.Enabled = false;
			this._btnView.Location = new System.Drawing.Point(228, 17);
			this._btnView.Name = "_btnView";
			this._btnView.Size = new System.Drawing.Size(52, 23);
			this._btnView.TabIndex = 0;
			this._btnView.Text = "%Browse%";
			this._btnView.UseVisualStyleBackColor = true;
			this._btnView.Click += new System.EventHandler(this._btnView_Click);
			// 
			// _btnSetup
			// 
			this._btnSetup.Location = new System.Drawing.Point(6, 18);
			this._btnSetup.Name = "_btnSetup";
			this._btnSetup.Size = new System.Drawing.Size(84, 52);
			this._btnSetup.TabIndex = 0;
			this._btnSetup.Text = "%EmbeddedSetup%";
			this._btnSetup.UseVisualStyleBackColor = true;
			this._btnSetup.Click += new System.EventHandler(this._btnSetup_Click);
			// 
			// _btnShowVideoForm
			// 
			this._btnShowVideoForm.Location = new System.Drawing.Point(293, 63);
			this._btnShowVideoForm.Name = "_btnShowVideoForm";
			this._btnShowVideoForm.Size = new System.Drawing.Size(85, 40);
			this._btnShowVideoForm.TabIndex = 11;
			this._btnShowVideoForm.Text = "%NewWindow%";
			this._btnShowVideoForm.UseVisualStyleBackColor = true;
			this._btnShowVideoForm.Click += new System.EventHandler(this._btnShowVideoForm_Click);
			// 
			// _txtPlate
			// 
			this._txtPlate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._txtPlate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._txtPlate.Location = new System.Drawing.Point(390, 331);
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
			this._imagePlateZone.Location = new System.Drawing.Point(593, 331);
			this._imagePlateZone.Name = "_imagePlateZone";
			this._imagePlateZone.Size = new System.Drawing.Size(181, 43);
			this._imagePlateZone.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imagePlateZone.TabIndex = 13;
			this._toolTip.SetToolTip(this._imagePlateZone, "Изображение обнаруженного ТС");
			// 
			// _imgProcessed
			// 
			this._imgProcessed.FooterFont = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgProcessed.ForeColor = System.Drawing.Color.GhostWhite;
			this._imgProcessed.Location = new System.Drawing.Point(390, 29);
			this._imgProcessed.Name = "_imgProcessed";
			this._imgProcessed.Size = new System.Drawing.Size(384, 288);
			this._imgProcessed.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imgProcessed.TabIndex = 0;
			this._imgProcessed.Text = "//AcceptedDicision//";
			this._toolTip.SetToolTip(this._imgProcessed, "Изображение обнаруженного ТС");
			// 
			// _imgVideo
			// 
			this._imgVideo.DoubleBuffer = true;
			this._imgVideo.FooterFont = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._imgVideo.Location = new System.Drawing.Point(3, 29);
			this._imgVideo.Name = "_imgVideo";
			this._imgVideo.Size = new System.Drawing.Size(384, 288);
			this._imgVideo.SizeMode = Mallenom.Imaging.ImageSizeMode.Zoom;
			this._imgVideo.TabIndex = 0;
			this._imgVideo.DoubleClick += new System.EventHandler(this._imgVideo_DoubleClick);
			// 
			// _txtMotion
			// 
			this._txtMotion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._txtMotion.Location = new System.Drawing.Point(293, 32);
			this._txtMotion.Name = "_txtMotion";
			this._txtMotion.Size = new System.Drawing.Size(85, 28);
			this._txtMotion.TabIndex = 17;
			this._txtMotion.Text = "%Motion%";
			this._txtMotion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// _logNumbers
			// 
			this._logNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this._logNumbers.AppenderName = "numbers";
			this._logNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._logNumbers.Location = new System.Drawing.Point(484, 380);
			this._logNumbers.Name = "_logNumbers";
			this._logNumbers.Size = new System.Drawing.Size(290, 134);
			this._logNumbers.TabIndex = 23;
			// 
			// _grpSetup
			// 
			this._grpSetup.Controls.Add(this._btnShowMySetupForm);
			this._grpSetup.Controls.Add(this._btnSetup);
			this._grpSetup.Location = new System.Drawing.Point(106, 323);
			this._grpSetup.Name = "_grpSetup";
			this._grpSetup.Size = new System.Drawing.Size(186, 80);
			this._grpSetup.TabIndex = 24;
			this._grpSetup.TabStop = false;
			this._grpSetup.Text = "%Setup%";
			// 
			// _btnShowMySetupForm
			// 
			this._btnShowMySetupForm.Location = new System.Drawing.Point(96, 18);
			this._btnShowMySetupForm.Name = "_btnShowMySetupForm";
			this._btnShowMySetupForm.Size = new System.Drawing.Size(84, 52);
			this._btnShowMySetupForm.TabIndex = 1;
			this._btnShowMySetupForm.Text = "%MySetup%";
			this._btnShowMySetupForm.UseVisualStyleBackColor = true;
			this._btnShowMySetupForm.Click += new System.EventHandler(this._btnShowMySetupForm_Click);
			// 
			// _btnShowStencils
			// 
			this._btnShowStencils.Location = new System.Drawing.Point(303, 341);
			this._btnShowStencils.Name = "_btnShowStencils";
			this._btnShowStencils.Size = new System.Drawing.Size(75, 52);
			this._btnShowStencils.TabIndex = 25;
			this._btnShowStencils.Text = "%Stencils%";
			this._btnShowStencils.UseVisualStyleBackColor = true;
			this._btnShowStencils.Click += new System.EventHandler(this._btnShowStencils_Click);
			// 
			// _localeMenu
			// 
			this._localeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this._localeSelectorMenu});
			this._localeMenu.Location = new System.Drawing.Point(3, 3);
			this._localeMenu.Name = "_localeMenu";
			this._localeMenu.Size = new System.Drawing.Size(770, 24);
			this._localeMenu.TabIndex = 26;
			this._localeMenu.Text = "//locale//";
			// 
			// _localeSelectorMenu
			// 
			this._localeSelectorMenu.Name = "_localeSelectorMenu";
			this._localeSelectorMenu.Size = new System.Drawing.Size(70, 20);
			this._localeSelectorMenu.Text = "//locale//";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(776, 702);
			this.Controls.Add(this._localeMenu);
			this.Controls.Add(this._btnShowStencils);
			this.Controls.Add(this._grpSetup);
			this.Controls.Add(this._btnShowVideoForm);
			this.Controls.Add(this._logNumbers);
			this.Controls.Add(groupBox4);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox2);
			this.Controls.Add(this._txtMotion);
			this.Controls.Add(this._imagePlateZone);
			this.Controls.Add(groupBox1);
			this.Controls.Add(this._txtPlate);
			this.Controls.Add(this._imgVideo);
			this.Controls.Add(this._imgProcessed);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this._localeMenu;
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "Пример использования ядра ПО Автомаршал";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			this._grpSetup.ResumeLayout(false);
			this._localeMenu.ResumeLayout(false);
			this._localeMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Mallenom.Imaging.Image _imgVideo;
		private Mallenom.Imaging.Image _imgProcessed;
		private Mallenom.Imaging.Image _imagePlateZone;
		private LogView _logView;
		private LogViewToolStrip _ligViewToolStrip;
		private LogView _logNumbers;
		private System.Windows.Forms.TextBox _txtPlate;
		private System.Windows.Forms.Button _btnStart;
		private System.Windows.Forms.Button _btnStop;
		private System.Windows.Forms.Button _btnSetup;
		private System.Windows.Forms.ToolTip _toolTip;
		private System.Windows.Forms.CheckBox _chkBoxIsSaveImages;
		private System.Windows.Forms.TextBox _txtSaveImagesDirectory;
		private System.Windows.Forms.Button _btnView;
		private System.Windows.Forms.Label _txtMotion;
		private System.Windows.Forms.Button _btnShowVideoForm;
		private System.Windows.Forms.ComboBox _cmbSaveImagesFileFormat;
		private System.Windows.Forms.GroupBox _grpSetup;
		private System.Windows.Forms.Button _btnShowMySetupForm;
		private System.Windows.Forms.Button _btnShowStencils;
		private System.Windows.Forms.MenuStrip _localeMenu;
		private System.Windows.Forms.ToolStripMenuItem _localeSelectorMenu;
	}
}

