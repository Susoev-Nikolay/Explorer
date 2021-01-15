using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Explorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            //timer1.Tick += timer1_Tick;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.path = textBoxPath.Text;
            Properties.Settings.Default.fileName = textBoxFile.Text;
            Properties.Settings.Default.Save();

        }
        public int timeStart;
        private void button2_Click(object sender, EventArgs e)//btnPath; УБРАТЬ ВЫБОР ФАЙЛА
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string directoryPath = Path.GetDirectoryName(sFileName);
                textBoxPath.Text = directoryPath;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tempDate = DateTime.Now;
            int hourStart = tempDate.Hour;
            int minStart = tempDate.Minute;
            int secondsStart = tempDate.Second;
            int time = ( secondsStart + minStart * 60 + hourStart * 3600 - timeStart);
            int timeH = time / 3600;
            int timeM = time / 60;
            int timeS = time % 60;
            string H,M,S;
            if (timeH < 10)
                H = "0"+(timeH).ToString();
            else 
                H = (timeH).ToString();
            if (timeM < 10)
            {
                M = "0" + (timeM).ToString();
            }
            else
                M = (timeM).ToString();
            if (timeS < 10)
            {
                S = "0" + (timeS).ToString();
            }
            else
                S = (timeS).ToString();
            labelTimer.Text = H+":"+ M + ":" + S;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            int hourStart = localDate.Hour;
            int minStart = localDate.Minute;
            int secondsStart = localDate.Second;
            timeStart = secondsStart + minStart*60 + hourStart*3600;
            timer1.Enabled = true;
            timer1.Start();








           

        }
    }
}
