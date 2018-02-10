namespace Recar2.Samples
{
	partial class GeneralSettingsMyForm
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
			if(disposing && (components != null))
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label6;
			this._txtChannelNum = new System.Windows.Forms.NumericUpDown();
			this._btnSetDefaults = new System.Windows.Forms.Button();
			this._btnApply = new System.Windows.Forms.Button();
			this._btnOK = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._txtProcessAreaLeft = new System.Windows.Forms.NumericUpDown();
			this._txtProcessAreaTop = new System.Windows.Forms.NumericUpDown();
			this._txtProcessAreaBottom = new System.Windows.Forms.NumericUpDown();
			this._txtProcessAreaRight = new System.Windows.Forms.NumericUpDown();
			this._txtMinPlateWidth = new System.Windows.Forms.NumericUpDown();
			this._txtMinPlateHeight = new System.Windows.Forms.NumericUpDown();
			this._txtMaxPlateWidth = new System.Windows.Forms.NumericUpDown();
			this._txtMaxPlateHeight = new System.Windows.Forms.NumericUpDown();
			this._grpProcessArea = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this._txtDecisionTimeout = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._txtChannelNum)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaTop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaBottom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMinPlateWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMinPlateHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMaxPlateWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMaxPlateHeight)).BeginInit();
			this._grpProcessArea.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._txtDecisionTimeout)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(18, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(118, 15);
			label1.TabIndex = 13;
			label1.Text = "Номер видеоканала";
			// 
			// _txtChannelNum
			// 
			this._txtChannelNum.Location = new System.Drawing.Point(142, 23);
			this._txtChannelNum.Name = "_txtChannelNum";
			this._txtChannelNum.Size = new System.Drawing.Size(50, 23);
			this._txtChannelNum.TabIndex = 0;
			this._txtChannelNum.ValueChanged += new System.EventHandler(this._txtChannelNum_ValueChanged);
			// 
			// _btnSetDefaults
			// 
			this._btnSetDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._btnSetDefaults.Location = new System.Drawing.Point(12, 236);
			this._btnSetDefaults.Name = "_btnSetDefaults";
			this._btnSetDefaults.Size = new System.Drawing.Size(103, 23);
			this._btnSetDefaults.TabIndex = 1;
			this._btnSetDefaults.Text = "По умолчанию";
			this._btnSetDefaults.UseVisualStyleBackColor = true;
			this._btnSetDefaults.Click += new System.EventHandler(this._btnSetDefaults_Click);
			// 
			// _btnApply
			// 
			this._btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnApply.Location = new System.Drawing.Point(166, 236);
			this._btnApply.Name = "_btnApply";
			this._btnApply.Size = new System.Drawing.Size(80, 23);
			this._btnApply.TabIndex = 2;
			this._btnApply.Text = "Применить";
			this._btnApply.UseVisualStyleBackColor = true;
			this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
			// 
			// _btnOK
			// 
			this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOK.Location = new System.Drawing.Point(252, 236);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(80, 23);
			this._btnOK.TabIndex = 3;
			this._btnOK.Text = "OK";
			this._btnOK.UseVisualStyleBackColor = true;
			this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(338, 236);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(80, 23);
			this._btnCancel.TabIndex = 4;
			this._btnCancel.Text = "Отмена";
			this._btnCancel.UseVisualStyleBackColor = true;
			this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
			// 
			// _txtProcessAreaLeft
			// 
			this._txtProcessAreaLeft.Location = new System.Drawing.Point(15, 58);
			this._txtProcessAreaLeft.Name = "_txtProcessAreaLeft";
			this._txtProcessAreaLeft.Size = new System.Drawing.Size(63, 23);
			this._txtProcessAreaLeft.TabIndex = 5;
			// 
			// _txtProcessAreaTop
			// 
			this._txtProcessAreaTop.Location = new System.Drawing.Point(71, 25);
			this._txtProcessAreaTop.Name = "_txtProcessAreaTop";
			this._txtProcessAreaTop.Size = new System.Drawing.Size(63, 23);
			this._txtProcessAreaTop.TabIndex = 6;
			// 
			// _txtProcessAreaBottom
			// 
			this._txtProcessAreaBottom.Location = new System.Drawing.Point(71, 94);
			this._txtProcessAreaBottom.Name = "_txtProcessAreaBottom";
			this._txtProcessAreaBottom.Size = new System.Drawing.Size(63, 23);
			this._txtProcessAreaBottom.TabIndex = 7;
			// 
			// _txtProcessAreaRight
			// 
			this._txtProcessAreaRight.Location = new System.Drawing.Point(123, 58);
			this._txtProcessAreaRight.Name = "_txtProcessAreaRight";
			this._txtProcessAreaRight.Size = new System.Drawing.Size(63, 23);
			this._txtProcessAreaRight.TabIndex = 8;
			// 
			// _txtMinPlateWidth
			// 
			this._txtMinPlateWidth.Location = new System.Drawing.Point(114, 22);
			this._txtMinPlateWidth.Name = "_txtMinPlateWidth";
			this._txtMinPlateWidth.Size = new System.Drawing.Size(63, 23);
			this._txtMinPlateWidth.TabIndex = 9;
			// 
			// _txtMinPlateHeight
			// 
			this._txtMinPlateHeight.Location = new System.Drawing.Point(114, 51);
			this._txtMinPlateHeight.Name = "_txtMinPlateHeight";
			this._txtMinPlateHeight.Size = new System.Drawing.Size(63, 23);
			this._txtMinPlateHeight.TabIndex = 10;
			// 
			// _txtMaxPlateWidth
			// 
			this._txtMaxPlateWidth.Location = new System.Drawing.Point(114, 22);
			this._txtMaxPlateWidth.Name = "_txtMaxPlateWidth";
			this._txtMaxPlateWidth.Size = new System.Drawing.Size(63, 23);
			this._txtMaxPlateWidth.TabIndex = 11;
			// 
			// _txtMaxPlateHeight
			// 
			this._txtMaxPlateHeight.Location = new System.Drawing.Point(114, 51);
			this._txtMaxPlateHeight.Name = "_txtMaxPlateHeight";
			this._txtMaxPlateHeight.Size = new System.Drawing.Size(63, 23);
			this._txtMaxPlateHeight.TabIndex = 12;
			// 
			// _grpProcessArea
			// 
			this._grpProcessArea.Controls.Add(this._txtProcessAreaTop);
			this._grpProcessArea.Controls.Add(this._txtProcessAreaLeft);
			this._grpProcessArea.Controls.Add(this._txtProcessAreaBottom);
			this._grpProcessArea.Controls.Add(this._txtProcessAreaRight);
			this._grpProcessArea.Location = new System.Drawing.Point(10, 59);
			this._grpProcessArea.Name = "_grpProcessArea";
			this._grpProcessArea.Size = new System.Drawing.Size(205, 131);
			this._grpProcessArea.TabIndex = 14;
			this._grpProcessArea.TabStop = false;
			this._grpProcessArea.Text = "Зона обработки, отсутпы в %";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this._txtMinPlateWidth);
			this.groupBox1.Controls.Add(this._txtMinPlateHeight);
			this.groupBox1.Location = new System.Drawing.Point(222, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 85);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Минимальный размер номера";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 15);
			this.label3.TabIndex = 12;
			this.label3.Text = "Высота, %";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Ширина, %";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this._txtMaxPlateWidth);
			this.groupBox2.Controls.Add(this._txtMaxPlateHeight);
			this.groupBox2.Location = new System.Drawing.Point(222, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 85);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Максимальный размер номера";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 53);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 15);
			this.label4.TabIndex = 14;
			this.label4.Text = "Высота, %";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 15);
			this.label5.TabIndex = 13;
			this.label5.Text = "Ширина, %";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(7, 198);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(182, 15);
			label6.TabIndex = 18;
			label6.Text = "Таймаут принятия решения, мс";
			// 
			// _txtDecisionTimeout
			// 
			this._txtDecisionTimeout.Location = new System.Drawing.Point(195, 196);
			this._txtDecisionTimeout.Name = "_txtDecisionTimeout";
			this._txtDecisionTimeout.Size = new System.Drawing.Size(63, 23);
			this._txtDecisionTimeout.TabIndex = 17;
			// 
			// GeneralSettingsMyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(430, 271);
			this.Controls.Add(label6);
			this.Controls.Add(this._txtDecisionTimeout);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._grpProcessArea);
			this.Controls.Add(label1);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._btnApply);
			this.Controls.Add(this._btnSetDefaults);
			this.Controls.Add(this._txtChannelNum);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GeneralSettingsMyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Настрока параметров алгоритма";
			((System.ComponentModel.ISupportInitialize)(this._txtChannelNum)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaTop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaBottom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtProcessAreaRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMinPlateWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMinPlateHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMaxPlateWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._txtMaxPlateHeight)).EndInit();
			this._grpProcessArea.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._txtDecisionTimeout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown _txtChannelNum;
		private System.Windows.Forms.Button _btnSetDefaults;
		private System.Windows.Forms.Button _btnApply;
		private System.Windows.Forms.Button _btnOK;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.NumericUpDown _txtProcessAreaLeft;
		private System.Windows.Forms.NumericUpDown _txtProcessAreaTop;
		private System.Windows.Forms.NumericUpDown _txtProcessAreaBottom;
		private System.Windows.Forms.NumericUpDown _txtProcessAreaRight;
		private System.Windows.Forms.NumericUpDown _txtMinPlateWidth;
		private System.Windows.Forms.NumericUpDown _txtMinPlateHeight;
		private System.Windows.Forms.NumericUpDown _txtMaxPlateWidth;
		private System.Windows.Forms.NumericUpDown _txtMaxPlateHeight;
		private System.Windows.Forms.GroupBox _grpProcessArea;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown _txtDecisionTimeout;
	}
}