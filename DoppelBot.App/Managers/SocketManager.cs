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
using Java.Net;

namespace DoppelBot.App.Managers
{
    public class SocketManager
    {
        private DatagramSocket _socket;
        private byte[] _buffer;
        private InetAddress _destinationAddress;

        public byte[] Buffer { get; set; }

        public SocketManager(string ip)
        {
            this._socket = new DatagramSocket();
            this._buffer = new byte[2048];
            this._destinationAddress = InetAddress.GetByName(ip);
        }

        public void SentPacket()
        {
            var packet = new DatagramPacket(this._buffer, this._buffer.Length, this._destinationAddress, 50005);
            this._socket.Send(packet);
        }
    }
}