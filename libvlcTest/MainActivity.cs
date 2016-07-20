using Android.App;
using Android.OS;
using VideoLAN.LibVLC;
using Android.Views;
using Android.Util;
using System;

namespace libvlcTest
{
	[Activity (Label = "libvlcTest", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		const string TAG = "libVLCTest";

		MonoLibVLC libVLC;
		VlcMediaPlayer mediaPlayer;
		SurfaceView surfaceView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			surfaceView = FindViewById<SurfaceView> (Resource.Id.surfaceView);

			if (libVLC == null) {
				libVLC = new MonoLibVLC ();
				mediaPlayer = new VlcMediaPlayer (libVLC);
				setMediaPlayerEvents ();
			}

			IVLCVout vout = mediaPlayer.VLCVout;
			vout.SetVideoView (surfaceView);
			vout.AttachViews ();

			var m = new MonoMedia (libVLC, Android.Net.Uri.Parse ("https://www.monobox.ch/assets/Honey_Bees_24fps_4K.mp4"));
			mediaPlayer.Media = m;
			mediaPlayer.Rate = 1.0f;
			mediaPlayer.Play ();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			releaseMediaPlayer ();
		}

		private void setMediaPlayerEvents ()
		{
			mediaPlayer.MediaChanged += OnMediaPlayerMediaChanged;
			mediaPlayer.Opening += OnMediaPlayerOpening;
			mediaPlayer.Buffering += OnMediaPlayerBuffering;
			mediaPlayer.Playing += OnMediaPlayerPlaying;
			mediaPlayer.Paused += OnMediaPlayerPaused;
			mediaPlayer.Stopped += OnMediaPlayerStopped;
			mediaPlayer.EndReached += OnMediaPlayerEndReached;
			mediaPlayer.EncouteredError += OnMediaPlayerEncouteredError;
			mediaPlayer.TimeChanged += OnMediaPlayerTimeChanged;
			mediaPlayer.PositionChanged += OnMediaPlayerPositionChanged;
			mediaPlayer.SeekableChanged += OnMediaPlayerSeekableChanged;
			mediaPlayer.PausableChanged += OnMediaPlayerPausableChanged;
			mediaPlayer.ESAdded += OnMediaPlayerESAdded;
			mediaPlayer.ESDeleted += OnMediaPlayerESDeleted;
			mediaPlayer.Vout += OnMediaPlayerVout;
		}

		void releaseMediaPlayer ()
		{
			if (libVLC == null)
				return;

			if (mediaPlayer != null) {
				mediaPlayer.Stop ();
				IVLCVout vout = mediaPlayer.VLCVout;
				vout.DetachViews ();
				libVLC.Release ();
				libVLC = null;
			}
		}

		private void OnMediaPlayerMediaChanged (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: MediaChanged");
		}

		private void OnMediaPlayerOpening (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Opening");
		}

		private void OnMediaPlayerBuffering (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Buffering");
		}

		private void OnMediaPlayerPlaying (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Playing");
		}

		private void OnMediaPlayerPaused (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Paused");
		}

		private void OnMediaPlayerStopped (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Stopped");
		}
		private void OnMediaPlayerEndReached (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: EndReached");
		}
		private void OnMediaPlayerEncouteredError (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: EncounteredError");
		}

		private void OnMediaPlayerTimeChanged (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: TimeChanged");
		}

		private void OnMediaPlayerPositionChanged (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: PositionChanged");
		}

		private void OnMediaPlayerSeekableChanged (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: SeekableChanged");
		}

		private void OnMediaPlayerPausableChanged (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: PausableChanged");
		}

		private void OnMediaPlayerESAdded (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: ESAdded");
		}

		private void OnMediaPlayerESDeleted (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: ESDeleted");
		}

		private void OnMediaPlayerVout (object sender, EventArgs args)
		{
			Log.Debug (TAG, "Media player: Vout");
		}
	}
}
