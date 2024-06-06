using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Server
{
    internal class Program
    {

        static void Main()
        {
            List<MyClasses.User> users = new List<MyClasses.User>
            {
                new MyClasses.User { Id = 1, Name = "Patric", Status = false},
                new MyClasses.User { Id = 2, Name = "Tatyana", Status = false},
                new MyClasses.User { Id = 3, Name = "Vasya", Status = false}
            };
            // List<MyClasses.Message> messages = new List<MyClasses.Message>();

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 1024);

            s.Bind(ep);
            s.Listen(10);

            Console.WriteLine("Waiting for the client.......");
            try
            {

                while (true)
                {
                    Socket ns = s.Accept();
                    Task.Run(() => ReceiveSend(ns));


                }
            }
            catch (Exception)
            {
                Console.WriteLine("Connect Error");
            }
            finally
            {
                s.Close();
            }
            void ReceiveSend(Socket client)
            {
                bool isCorrect = false;
                MyClasses.User temp = new MyClasses.User();
                int ind;
                while (!isCorrect)
                {
                    isCorrect = false;
                    var byffer = new byte[1024];
                    var l = client.Receive(byffer);
                    int ansver = Convert.ToInt32(Encoding.UTF8.GetString(byffer, 0, l));
                    Console.WriteLine(Encoding.UTF8.GetString(byffer, 0, l));
                    if (users.Any(p => p.Id == ansver))
                    {

                        temp = users.First(p => p.Id == ansver);
                        temp.socket = client;
                        temp.Status = true;
                        client.Send(Encoding.UTF8.GetBytes($"Hello {temp.Name}"));
                        ind = users.FindIndex(p => p.Id == ansver);
                        users[ind] = temp;
                        isCorrect = true; break;
                    }
                    else
                    {
                        client.Send(Encoding.UTF8.GetBytes("0"));
                    }
                }

                while (client.Connected)
                {
                    var byffer = new byte[1024];
                    var l = client.Receive(byffer);
                    var ansver = (Encoding.UTF8.GetString(byffer, 0, l));
                    Console.WriteLine(ansver);
                    string[] mas = ansver.Split(']');
                    mas[0] = mas[0].Trim('[');
                    //foreach (var item in mas)
                    //{
                    //    Console.WriteLine(item);
                    //}
                    if (int.TryParse(mas[0], out ind))
                    {
                        ind = int.Parse(mas[0]);
                    }
                    ind = users.FindIndex(p => p.Id == ind);
                    if (users[ind].socket!=null)
                    {
                        try
                        {
                            users[ind].socket.Send(Encoding.UTF8.GetBytes($"[{temp.Name}] {mas[1]}"));
                            
                        }
                        catch
                        { 
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        }
                    }
                    else client.Send(Encoding.UTF8.GetBytes("Юзер оффлайн!"));
                }

            }
        }
    }
}
