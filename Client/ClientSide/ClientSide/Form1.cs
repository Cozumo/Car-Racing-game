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
        int x = 250;
        int y = 280;
        UdpClient s = null;

        public Form1()
        {
            InitializeComponent();
            Font LargeFont = new Font("Arial", 42);
            label1.Text = "\u21D1";
            label2.Text = "\u21D2";
            label3.Text = "\u21D3";
            label4.Text = "\u21D0";
            label1.Font = LargeFont;
            label2.Font = LargeFont;
            label3.Font = LargeFont;
            label4.Font = LargeFont;

            s = new UdpClient("192.168.0.112", 1120);
        }

        public void send()
        {
            string n = x + "," + y;
            byte[] data = Encoding.Unicode.GetBytes(n);
            s.Send(data, data.Length);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                y -= 10;
            }
            else if (e.KeyCode == Keys.Left)
            {
                x -= 10;
            }
            else if (e.KeyCode == Keys.Down)
            {
                y += 10;
            }
            else if (e.KeyCode == Keys.Right)
            {
                x += 10;
            }

            Thread n = new Thread(send);
            n.Start();
        }
    }
}