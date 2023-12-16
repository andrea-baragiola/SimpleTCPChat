using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient
{
    public class Message
    {
        public string MessageSender { get; set; }
        public string Content { get; set; }

        public Message(string messageSender, string content)
        {
            MessageSender = messageSender;
            Content = content;
        }
    }
}
