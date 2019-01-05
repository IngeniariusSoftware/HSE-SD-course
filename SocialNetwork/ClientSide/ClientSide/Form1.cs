using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSide
{
    using System.Drawing.Configuration;
    using System.IO;
    using System.Net.Sockets;
    using System.Xml;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 904);
            string message = new string('a', 1024000);
            var buffer = Encoding.ASCII.GetBytes(message);
            socket.Send(buffer);

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }
    }
}
