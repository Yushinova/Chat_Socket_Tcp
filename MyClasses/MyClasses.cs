using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Socket socket { get; set; }
       // public List<Message> messages = new List<Message>();
    }
    public class Message
    {
       // public int Id { get; set; } это для базы данных
        public int Id_Sender { get; set; }
        public int Id_Receiver { get; set; }
        public byte[] Data { get; set; }
    }

}
