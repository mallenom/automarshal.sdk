using System;
using System.Collections.Generic;
using System.Threading;

using Mallenom.Imaging;
using Mallenom.Video;

namespace Recar2.Samples
{
	/// <summary>Видеоисточник, в который можно помещать изображения.</summary>
	sealed class ImageVideoSource : VideoSource
	{
		private VideoSourceState _state = VideoSourceState.Closed;

		private IImageMatrix _matrix;

		private Thread _thread;

		private CancellationTokenSource _cancellationTokenSource;
		public override IEnumerable<Type> SupportedMatrixTypes
		{
			get { return new[] {typeof(ColorMatrix), typeof(Matrix)}; }
		}

		public override VideoSourceState State
		{
			get { return _state; }
		}

		public void SetImage(IImageMatrix matrix)
		{
			_matrix = matrix;
		}

		public override void Open()
		{
			base.Open();
			_state = VideoSourceState.Opened;
		}

		public override void Close()
		{
			if(_state == VideoSourceState.Closed) return;

			_state = VideoSourceState.Closed;
			base.Close();
		}

		public override void Start()
		{
			if(_state == VideoSourceState.Running) throw new InvalidOperationException("Already running.");

			_cancellationTokenSource = new CancellationTokenSource();
			_thread = new Thread(() => ThreadProc(_cancellationTokenSource.Token));
			_thread.Start();

			_state = VideoSourceState.Running;
			base.Start();
		}

		public override void Stop()
		{
			if(_state != VideoSourceState.Running) return;

			_cancellationTokenSource.Cancel();
			_state = VideoSourceState.Opened;
			base.Stop();
		}

		private void ThreadProc(CancellationToken token)
		{
			while(!token.WaitHandle.WaitOne(100))
			{
				DistributeMatrix(_matrix);
				RaiseMatrixUpdated(new MatrixUpdatedEventArgs(DateTime.Now));
			}
		}
	}
}
