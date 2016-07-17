using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EZ_B;
using DoppelBot.EZRobot.Services.Interfaces;
using NAudio.Wave;

namespace DoppelBot.EZRobot.Services
{
    public class SoundService : ISoundService
    {
        private EZB _robot;
        private WaveIn _listeningDevice;

        public SoundService(EZB _robot)
        {
            this._robot = _robot;
            this._listeningDevice = new WaveIn();
            this._listeningDevice.DeviceNumber = 0;
            this._listeningDevice.DataAvailable += _listeningDevice_DataAvailable;
            var sampleRate = 18000;
            var channels = 1;
            this._listeningDevice.WaveFormat = new WaveFormat(sampleRate, channels);
            this._listeningDevice.BufferMilliseconds = 100;
        }

        public void StartListening()
        {
            this._listeningDevice.StartRecording();
        }

        private void _listeningDevice_DataAvailable(object sender, WaveInEventArgs e)
        {
            var sound = e.Buffer;
            this.PlayData(sound, 200);
        }

        public void PlayData(byte[] sound, decimal volume)
        {
            this._robot.SoundV4.PlayData(sound, volume);
        }

        public void PlayData(Stream stream, decimal volume)
        {
            throw new NotImplementedException();
        }

        public void StopListening()
        {
            this._listeningDevice.StopRecording();
        }

        public void StopPlaying()
        {
            throw new NotImplementedException();
        }
    }
}
