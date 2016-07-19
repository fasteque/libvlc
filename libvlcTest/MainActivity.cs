using System;

using Android.App;
using Android.OS;
using Org.Videolan.Libvlc;
using Android.Views;
using Android.Util;

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

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			surfaceView = FindViewById<SurfaceView> (Resource.Id.surfaceView);

			if (libVLC == null) {
				libVLC = new MonoLibVLC ();
				mediaPlayer = new VlcMediaPlayer (libVLC);
			}

			IVLCVout vout = mediaPlayer.VLCVout;
			vout.SetVideoView (surfaceView);
			vout.AttachViews ();

			var m = new MonoMedia (libVLC, Android.Net.Uri.Parse ("https://www.monobox.ch/assets/Honey_Bees_24fps_4K.mp4"));
			mediaPlayer.Media = m;
			mediaPlayer.Rate = 1.0f;
			mediaPlayer.Play ();

            mediaPlayer.Opening += OnOpening;
            mediaPlayer.Playing += OnPlaying;
            mediaPlayer.Paused += OnPause;
            mediaPlayer.Buffering += OnBuffering;
		}

        private void OnOpening(object sender, EventArgs args)
        {
            Console.Write("Opening");
        }

        private void OnPlaying(object sender, EventArgs args)
        {
            Console.Write("Playing");
        }

        private void OnPause(object sender, EventArgs args)
        {
            Console.Write("Pause");
        }

        private void OnBuffering(object sender, EventArgs args)
        {
            Console.Write("Buffering");
        }
	}
}
