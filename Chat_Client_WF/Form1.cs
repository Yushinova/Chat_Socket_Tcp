using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClasses;

namespace Chat_Client_WF
{
    public partial class Form1 : Form
    {
        public Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static IPAddress ip = IPAddress.Parse("127.0.0.1");
        public IPEndPoint ep = new IPEndPoint(ip, 1024);
        public string message = string.Empty;
        public string ansver = string.Empty;

        public List<MyClasses.User> users = new List<MyClasses.User>//лист нужно добыть из сохраненного в базе данных
        {
            new MyClasses.User { Id = 1, Name = "Patric", Status = false},
            new MyClasses.User { Id = 2, Name = "Tatyana", Status = false},
            new MyClasses.User { Id = 3, Name = "Vasya", Status = false}
        };
        public Form1()
        {
            InitializeComponent();

            Task.Run(Connect);//пытаемся подключится к серверу

        }

        private void button1_Click(object sender, EventArgs e)//авторизация на минималках
        {

            int id;//мы для учебных целе используем ID
            if (int.TryParse(LoginBox.Text, out id))
            {
                if (s.Connected)
                {
                    string ID = LoginBox.Text;//вмесло логина пишем ID из существующих юзеров. см выше)))
                    s.Send(Encoding.UTF8.GetBytes(ID));
                    byte[] buffer = new byte[1024];
                    var l = s.Receive(buffer);
                    ansver = Encoding.UTF8.GetString(buffer, 0, l);
                    if (ansver != "0")//если от сервера приходит вменяемый ответ
                    {
                        User temp = users.First(p => p.Id == int.Parse(ID));
                        this.Text = $"Сервер подключен! Пользователь [{temp.Name}]";
                        MessageBox.Show($"Добро пожаловать! {Encoding.UTF8.GetString(buffer, 0, l)}");
                        label1.Visible = false;
                        LoginBox.Visible = false;
                        AutorButton.Visible = false;
                        Users.Visible = true;
                        Messages.Visible = true;
                        SendButton.Visible = true;
                        MessageSend.Visible = true;
                        NameLab.Visible = true;
                        NameLab.Visible = true;
                        foreach (var u in users)
                        {
                            if (u.Id != int.Parse(LoginBox.Text))
                                Users.Items.Add(u.Name);
                        }
                        Task.Run(Listen);//слушаем все входящие
                    }
                    else
                    {
                        MessageBox.Show("Error!!!");//такого юзера нет
                    }
                }

            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void Selected(object sender, EventArgs e)
        {
            Invoke(new Action(() => NameLab.Text = Users.SelectedItem.ToString()));
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (MessageSend.Text != "")
            {
                User temp = users.Find(p => p.Name == NameLab.Text);
                message = MessageSend.Text;
                s.Send(Encoding.UTF8.GetBytes($"[{(temp.Id).ToString()}]{message}"));
                Invoke(new Action(() => Messages.Items.Add("[My ansver]" + message)));
                MessageSend.Text = "";
            }
        }
        private void Listen()//слушем и если нам приходит что то, оно добавляетс в лист сообщений
        {
            while (s.Connected)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    var l = s.Receive(buffer);
                    ansver = Encoding.UTF8.GetString(buffer, 0, l);
                    Invoke(new Action(() => Messages.Items.Add(ansver)));
                }
                catch 
                {
                    Invoke(new Action(() => this.Text = "Отсутствует подключение к серверу!"));
                }

            }

        }
        private void Connect()//проверка подключения.
        {
            while (!s.Connected)
            {
                try
                {
                    s.Connect(ep);
                    MessageBox.Show("Сервер подключен!");
                    Invoke(new Action(() => this.Text = "Сервер подключен!"));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => this.Text = "Отсутствует подключение к серверу!"));
                }
                Task.Delay(3000);
            }
        }
    }
}
