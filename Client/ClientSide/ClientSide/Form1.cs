using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace ClientSide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 0;
        int y = 0;

        public void send()
        {
            UdpClient s = new UdpClient("192.168.0.112", 1120);

            string n = x + "," + y;
            byte[] data = Encoding.Unicode.GetBytes(n);
            s.Send(data, data.Length);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            x += 10;
            Thread n = new Thread(send);
            n.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            y += 10;
            Thread n = new Thread(send);
            n.Start();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            x -= 10;
            Thread n = new Thread(send);
            n.Start();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            y -= 10;
            Thread n = new Thread(send);
            n.Start();
        }
    }
}