namespace Recar2.Samples.UI
{
	partial class StencilsSampleImagesForm
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
			this._pic = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this._pic)).BeginInit();
			this.SuspendLayout();
			// 
			// _pic
			// 
			this._pic.Dock = System.Windows.Forms.DockStyle.Fill;
			this._pic.Location = new System.Drawing.Point(0, 0);
			this._pic.Name = "_pic";
			this._pic.Size = new System.Drawing.Size(620, 445);
			this._pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._pic.TabIndex = 1;
			this._pic.TabStop = false;
			// 
			// StencilsSampleImagesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(620, 445);
			this.Controls.Add(this._pic);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Name = "StencilsSampleImagesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Разрешенные номера";
			((System.ComponentModel.ISupportInitialize)(this._pic)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox _pic;
	}
}