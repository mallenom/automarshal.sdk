using System;

using Mallenom.Setup;
using Mallenom.Video;

namespace Recar2.Samples
{
	sealed class ImageVideoSourceProvider : IVideoSourceProvider
	{
		public Type SourceType
		{
			get { return typeof(ImageVideoSource); }
		}

		public string Name 
		{
			get { return "ImageVideoSource"; }
		}

		public string Description
		{
			get { return "ImageVideoSource"; }
		}

		public IVideoSource CreateVideoSource()
		{
			return new ImageVideoSource();
		}

		public ISetupControl CreateSetupControl(IVideoSource source)
		{
			throw new NotImplementedException();
		}
	}
}
