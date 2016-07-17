using DoppelBot.RTSP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoppelBot.RTSP.Services.Implementation
{
    public class RTSPServerService : IRTSPServerService
    {
        //private RtspServer _server;

        //public RTSPServerService()
        //{
        //    var ip = Media.Common.Extensions.Socket.SocketExtensions.GetFirstV4IPAddress();
        //    var port = 554;
        //    this._server = new RtspServer(ip, port);
        //}

        //public void AddMedia(string name, string url)
        //{
        //    //this._server.TryAddMedia(new Media.Rtsp.Server.MediaTypes.RtpSource(name, url));
        //    this._server.TryAddMedia(new Media.Rtsp.Server.MediaTypes.JPEGMedia(name, url));
        //}

        //public string StartServer()
        //{
        //    if (!this._server.IsRunning)
        //    {
        //        this._server.Start();
        //        return this._server.LocalEndPoint.ToString();
        //    }

        //    return string.Empty;
        //}

        //public void StopServer()
        //{
        //    if (this._server.IsRunning)
        //    {
        //        this._server.Stop();
        //    }
        //}
    }
}
