﻿namespace WebApiServer
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}