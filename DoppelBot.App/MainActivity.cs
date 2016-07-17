using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DoppelBot.App.Managers;

namespace DoppelBot.App
{
    [Activity(Label = "DoppelBot.App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            var socketManager = new SocketManager("169.254.80.80");
            var voiceManager = new VoiceManager(socketManager);


            //Testing videoview.
            //var videoView = FindViewById(Resource.Id.videoView1) as VideoView;
            //var url = "rtsp://169.254.80.80/live/test";
            //videoView.SetVideoURI(Android.Net.Uri.Parse(url));
            //videoView.Start();
        }
    }
}

