using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client
{
    internal class Program
    {
        static void Main()
        {
            //Это тренировочная консолька, более улучшенный вариант WF!!!


            //List<MyClasses.User> users = new List<MyClasses.User>
            //{
            //    new MyClasses.User { Id = 1, messages = null, Name = "Patric", Status = false},
            //    new MyClasses.User { Id = 2, messages = null, Name = "Tatyana", Status = false},
            //    new MyClasses.User { Id = 3, messages = null, Name = "Vasya", Status = false}
            //};
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 1024);
            string message = string.Empty;
            string ansver = string.Empty;

            try
            {
                s.Connect(ep);
                while (true)
                {
                    Console.WriteLine("Enter you ID");//login of corse)))
                    string ID = Console.ReadLine();
                    s.Send(Encoding.UTF8.GetBytes(ID));
                    byte[] buffer = new byte[1024];
                    var l = s.Receive(buffer);
                    ansver = Encoding.UTF8.GetString(buffer, 0, l);
                    if (ansver != "0") break;
                    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, l));
                }
             while(s.Connected)
                {

                    Task.Run(Listen);
                    
                    Task.Run(Ansver);

                   
                }
                Console.ReadKey();
              
            }
            catch
            {
                Console.WriteLine("Error");
            }
            void Listen()
            {
                byte[] buffer = new byte[1024];
                var l = s.Receive(buffer);
                ansver = Encoding.UTF8.GetString(buffer, 0, l);
                Console.WriteLine(ansver);
            }
            void Ansver()
            {
                Console.WriteLine("Enter Yuo message: ");
                message = Console.ReadLine();
                s.Send(Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
