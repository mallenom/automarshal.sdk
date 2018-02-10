using System;
using System.Windows.Forms;

namespace Recar2.Samples
{
	/// <summary>Кастомизированная форма настройки основных параметров.</summary>
	partial class GeneralSettingsMyForm : Form
	{
		#region Data

		private readonly VideoCore _core;

		#endregion

		#region Create

		public GeneralSettingsMyForm(VideoCore core)
		{
			_core = core;
			InitializeComponent();

			_txtChannelNum.Maximum = 0;
			_txtChannelNum.Maximum = _core.ChannelCount - 1;
			_txtChannelNum.Value = 0;

			var settings = _core.Settings.Channel((int)_txtChannelNum.Value);

			//			_txtProcessAreaLeft.Minimum   = settings.Roi.Minimum.Left.ToPercent();	// TODO: ROI
			//			_txtProcessAreaTop.Minimum    = settings.ProcessArea.Minimum.Top.ToPercent();
			//			_txtProcessAreaRight.Minimum  = settings.ProcessArea.Minimum.Right.ToPercent();
			//			_txtProcessAreaBottom.Minimum = settings.ProcessArea.Minimum.Bottom.ToPercent();
			//			_txtProcessAreaLeft.Maximum   = settings.ProcessArea.Maximum.Left.ToPercent();
			//			_txtProcessAreaTop.Maximum    = settings.ProcessArea.Maximum.Top.ToPercent();
			//			_txtProcessAreaRight.Maximum  = settings.ProcessArea.Maximum.Right.ToPercent();
			//			_txtProcessAreaBottom.Maximum = settings.ProcessArea.Maximum.Bottom.ToPercent();

			_txtDecisionTimeout.Maximum = (decimal)settings.DecisionTimeout.Maximum.TotalMilliseconds;
			_txtDecisionTimeout.Maximum = (decimal)settings.DecisionTimeout.Maximum.TotalMilliseconds;

			UpdateChannelUI();
		}

		#endregion

		#region Methods

		private void UpdateChannelUI()
		{
			var settings = _core.Settings.Channel((int)_txtChannelNum.Value);

//			var area = settings.Roi.Value; // TODO: ROI
//			_txtProcessAreaLeft.Value = area.Left.ToPercent();
//			_txtProcessAreaTop.Value = area.Top.ToPercent();
//			_txtProcessAreaRight.Value = area.Right.ToPercent();
//			_txtProcessAreaBottom.Value = area.Bottom.ToPercent();

			_txtMinPlateWidth.Value = settings.MinPlateSize.Value.Width.ToPercent();
			_txtMinPlateHeight.Value = settings.MinPlateSize.Value.Height.ToPercent();
			_txtMaxPlateWidth.Value = settings.MaxPlateSize.Value.Width.ToPercent();
			_txtMaxPlateHeight.Value = settings.MaxPlateSize.Value.Height.ToPercent();

			_txtDecisionTimeout.Value = (decimal)settings.DecisionTimeout.Value.TotalMilliseconds;
		}

		private void Apply()
		{
			var settings = _core.Settings.Channel((int)_txtChannelNum.Value);
//			settings.Roi.Value = new Cropping( // TODO: ROI
//				_txtProcessAreaLeft.Value.FromPercent(),
//				_txtProcessAreaTop.Value.FromPercent(),
//				_txtProcessAreaRight.Value.FromPercent(),
//				_txtProcessAreaBottom.Value.FromPercent()
//				);
			settings.MinPlateSize.Value = new Mallenom.Primitives.SizeF(
				(float)_txtMinPlateWidth.Value.FromPercent(),
				(float)_txtMinPlateHeight.Value.FromPercent()
				);
			settings.MaxPlateSize.Value = new Mallenom.Primitives.SizeF(
				(float)_txtMaxPlateWidth.Value.FromPercent(),
				(float)_txtMaxPlateHeight.Value.FromPercent()
				);

			settings.DecisionTimeout.Value = TimeSpan.FromMilliseconds((double)_txtDecisionTimeout.Value);

			_core.Settings.Channel((int)_txtChannelNum.Value).Apply();
		}

		#endregion

		#region Control event handlers

		private void _txtChannelNum_ValueChanged(object sender, EventArgs args)
		{
			UpdateChannelUI();
		}

		private void _btnSetDefaults_Click(object sender, EventArgs args)
		{
			_core.Settings.Channel((int)_txtChannelNum.Value).SetDefaults();
			UpdateChannelUI();
		}

		private void _btnApply_Click(object sender, EventArgs args)
		{
			Apply();
		}

		private void _btnOK_Click(object sender, EventArgs args)
		{
			Apply();
			Close();
		}

		private void _btnCancel_Click(object sender, EventArgs args)
		{
			Close();
		}

		#endregion
	}
}
