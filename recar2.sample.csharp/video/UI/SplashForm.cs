using System;
using System.Windows.Forms;

using Mallenom.Localization;
using Mallenom.Localization.WinForms;

namespace Recar2.Samples
{
	public partial class SplashForm : Form
	{
		private static readonly LocalizationScope LocalizationScope = new LocalizationScope(@"Recar2.SplashForm");

		public SplashForm()
		{
			InitializeComponent();

			this.Localize(LocalizationScope);
		}
	}
}
