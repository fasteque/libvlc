using Android.App;
using Android.OS;
using Org.Videolan.Libvlc;
using Android.Views;
using Android.Util;

namespace libvlcTest
{
	[Activity (Label = "libvlcTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IMediaPlayerEventCallback
	{
		const string TAG = "libVLCTest";

		MonoLibVLC libVLC;
		MediaPlayer mediaPlayer;
		SurfaceView surfaceView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			surfaceView = FindViewById<SurfaceView> (Resource.Id.surfaceView);

			if (libVLC == null) {
				libVLC = new MonoLibVLC ();
				mediaPlayer = new MediaPlayer (libVLC);
				mediaPlayer.SetMediaPlayerEventCallback (this);
			}

			IVLCVout vout = mediaPlayer.VLCVout;
			vout.SetVideoView (surfaceView);
			vout.AttachViews ();

			var m = new MonoMedia (libVLC, Android.Net.Uri.Parse ("https://www.monobox.ch/assets/Honey_Bees_24fps_4K.mp4"));
			mediaPlayer.Media = m;
			mediaPlayer.Rate = 1.0f;
			mediaPlayer.Play ();
		}

		public void OnMediaPlayerEvent (int p0)
		{
			switch (p0) {
			case MediaPlayer.Event.Buffering:
				Log.Debug (TAG, "Media player: Buffering");
				break;
			case MediaPlayer.Event.ESAdded:
				Log.Debug (TAG, "Media player: ESAdded");
				break;
			case MediaPlayer.Event.ESDeleted:
				Log.Debug (TAG, "Media player: ESDeleted");
				break;
			case MediaPlayer.Event.EncounteredError:
				Log.Debug (TAG, "Media player: EncounteredError");
				break;
			case MediaPlayer.Event.EndReached:
				Log.Debug (TAG, "Media player: EndReached");
				break;
			case MediaPlayer.Event.MediaChanged:
				Log.Debug (TAG, "Media player: MediaChanged");
				break;
			case MediaPlayer.Event.Opening:
				Log.Debug (TAG, "Media player: Opening");
				break;
			case MediaPlayer.Event.PausableChanged:
				Log.Debug (TAG, "Media player: PausableChanged");
				break;
			case MediaPlayer.Event.Paused:
				Log.Debug (TAG, "Media player: Paused");
				break;
			case MediaPlayer.Event.Playing:
				Log.Debug (TAG, "Media player: Playing");
				break;
			case MediaPlayer.Event.PositionChanged:
				Log.Debug (TAG, "Media player: PositionChanged");
				break;
			case MediaPlayer.Event.SeekableChanged:
				Log.Debug (TAG, "Media player: SeekableChanged");
				break;
			case MediaPlayer.Event.Stopped:
				Log.Debug (TAG, "Media player: Stopped");
				break;
			case MediaPlayer.Event.TimeChanged:
				Log.Debug (TAG, "Media player: TimeChanged");
				break;
			case MediaPlayer.Event.Vout:
				Log.Debug (TAG, "Media player: Vout");
				break;
			default:
				Log.Debug (TAG, "Media player: unknown event " + p0);
				break;
			}
		}
	}
}
