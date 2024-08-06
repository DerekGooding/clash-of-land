﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClashLand.Core.API
{
    internal class WebApi
    {
        internal HttpListener Listener;

        public WebApi()
        {
            Task.Run(() =>
            {
                this.Listener = new HttpListener();
                this.Listener.Prefixes.Add("http://127.0.0.1:8080/");
                this.Listener.Start();
                this.AcceptRequest();
            });
        }

        internal void AcceptRequest()
        {
            var k = HandleRequestAsync();
        }

        internal async Task HandleRequestAsync()
        {
            var context = await this.Listener.GetContextAsync();
            this.AcceptRequest();
            await this.Process(context);
        }

        public async Task Process(object _Param)
        {
            HttpListenerContext _Context = (HttpListenerContext)_Param;
            _Context.Response.StatusCode = 403;
            _Context.Response.StatusDescription = "PROCESSED";
            _Context.Response.ContentType = "text/plain";
            _Context.Response.ContentLength64 = "UNAUTHORIZED".Length;
            _Context.Response.KeepAlive = false;
            _Context.Response.AddHeader("Content-Type", "text/plain");
            _Context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
            await _Context.Response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes("UNAUTHORIZED"), 0, "UNAUTHORIZED".Length);

            _Context.Response.Close();
        }
    }
}