using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Recar2.Samples.UI
{
	public partial class StencilsSampleImagesForm : Form
	{
		private const int PlateWidth = 100;

		public StencilsSampleImagesForm(VideoCore core)
		{
			InitializeComponent();

			ShowImages(core);
		}

		private void ShowImages(VideoCore core)
		{
			var plateHeight = (int)(PlateWidth / 4.5);
			var totalWidth = core.Settings.Models.Count * (PlateWidth + 20);
			var totalHeight = 30 + core.Settings.Models.Max(m => m.Stencils.Count()) * (plateHeight + 34);
			_pic.Image = new Bitmap(totalWidth, totalHeight);
			using(var g = Graphics.FromImage(_pic.Image))
			{
				int x = 0;
				foreach(var model in core.Settings.Models)
				{
					int y = 0;
					TextRenderer.DrawText(g, model.Name, SystemFonts.MessageBoxFont, new Point(x, y), Color.Black);
					y += 30;
					foreach(var stencil in model.Stencils)
					{
						TextRenderer.DrawText(g, stencil.Id, SystemFonts.MessageBoxFont, new Point(x, y), Color.DarkSlateGray);
						var image = stencil.GetSampleImage(PlateWidth, plateHeight);
						g.DrawImage(image, new Point(x, y + 20));
						y += plateHeight + 34;
					}
					x += PlateWidth + 20;
				}
			}
		}
	}
}
