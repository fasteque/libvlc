using System;
using VideoLAN.LibVLC;

namespace libvlcTest
{
	public class VlcMediaPlayer : MediaPlayer
	{
		public VlcMediaPlayer (IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		public VlcMediaPlayer (MonoLibVLC libVlc) : base (libVlc)
		{
		}

		public VlcMediaPlayer (MonoMedia media) : base (media)
		{
		}

		public event EventHandler MediaChanged;

		public event EventHandler Opening;

		public event EventHandler Buffering;

		public event EventHandler Playing;

		public event EventHandler Paused;

		public event EventHandler Stopped;

		public event EventHandler EndReached;

		public event EventHandler EncouteredError;

		public event EventHandler TimeChanged;

		public event EventHandler PositionChanged;

		public event EventHandler SeekableChanged;

		public event EventHandler PausableChanged;

		public event EventHandler ESAdded;

		public event EventHandler ESDeleted;

		public event EventHandler Vout;


		protected override Event OnEventNative (int eventType, long p1, float p2)
		{
			switch (eventType) {
			case Event.MediaChanged:
				MediaChanged?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Opening:
				Opening?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Buffering:
				Buffering?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Playing:
				Playing?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Paused:
				Paused?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Stopped:
				Stopped?.Invoke (this, EventArgs.Empty);
				break;
			case Event.EndReached:
				EndReached?.Invoke (this, EventArgs.Empty);
				break;
			case Event.EncounteredError:
				EncouteredError?.Invoke (this, EventArgs.Empty);
				break;
			case Event.TimeChanged:
				TimeChanged?.Invoke (this, EventArgs.Empty);
				break;
			case Event.PositionChanged:
				PositionChanged?.Invoke (this, EventArgs.Empty);
				break;
			case Event.SeekableChanged:
				SeekableChanged?.Invoke (this, EventArgs.Empty);
				break;
			case Event.PausableChanged:
				PausableChanged?.Invoke (this, EventArgs.Empty);
				break;
			case Event.ESAdded:
				ESAdded?.Invoke (this, EventArgs.Empty);
				break;
			case Event.ESDeleted:
				ESDeleted?.Invoke (this, EventArgs.Empty);
				break;
			case Event.Vout:
				Vout?.Invoke (this, EventArgs.Empty);
				break;
			}

			return base.OnEventNative (eventType, p1, p2);
		}
	}
}
