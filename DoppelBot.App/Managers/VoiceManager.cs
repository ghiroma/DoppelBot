using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

namespace DoppelBot.App.Managers
{
    public class VoiceManager
    {
        private SocketManager _socketManager;
        private AudioRecord _audioRecorder;

        public VoiceManager(SocketManager socketManager)
        {
            this._socketManager = socketManager;
            var minBufferSize = AudioRecord.GetMinBufferSize(160000, ChannelIn.Mono, Android.Media.Encoding.Pcm16bit);
            this._audioRecorder = new AudioRecord(AudioSource.Mic, 16000, ChannelIn.Mono, Android.Media.Encoding.Pcm16bit, minBufferSize * 10);
        }

        public void StartRecording()
        {
            this._audioRecorder.StartRecording();
            while (this._audioRecorder.RecordingState == RecordState.Recording)
            {
                this._audioRecorder.Read(this._socketManager.Buffer, 0, this._socketManager.Buffer.Length);
                this._socketManager.SentPacket();
            }
        }

        public void StopRecording()
        {
            if (this._audioRecorder.RecordingState == RecordState.Recording)
            {
                this._audioRecorder.Stop();
                this._audioRecorder.Release();
            }
        }
    }
}