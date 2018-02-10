using System;
using System.Collections.Generic;
using System.Drawing;

using Mallenom.Imaging;
using Mallenom.Video;

namespace Recar2.Samples
{
	/// <summary>Видеоисточник, в который можно помещать изображения.</summary>
	sealed class ImageVideoSource : VideoSource
	{
		public override IEnumerable<Type> SupportedMatrixTypes
		{
			get { return new[] {typeof(ColorMatrix), typeof(Matrix)}; }
		}

		public override VideoSourceState State
		{
			get { return VideoSourceState.Running; }
		}

		public void PushFrame(IImageMatrix frame, DateTime timeStamp)
		{
			DistributeMatrix(frame);
			RaiseMatrixUpdated(new MatrixUpdatedEventArgs(timeStamp));
		}

		public void PushFrame(Bitmap frame, DateTime timeStamp)
		{
			DistributeMatrix(new Matrix(frame));
			RaiseMatrixUpdated(new MatrixUpdatedEventArgs(timeStamp));
		}
	}
}
