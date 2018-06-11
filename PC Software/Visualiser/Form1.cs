using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace Visualiser
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        SerialDeviceManager Arduino = new SerialDeviceManager();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetTimer();
            Arduino.Connect("COM3");
            Thread.Sleep(1000);
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(30);   // probably shouldnt go much faster than 20ms
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            float level = device.AudioMeterInformation.MasterPeakValue;
            float level_L = device.AudioMeterInformation.PeakValues[0];
            float level_R = device.AudioMeterInformation.PeakValues[1];
            updateUI(level, level_L, level_R);
        }

        private void updateUI(float master, float left, float right)
        {
            Invoke((MethodInvoker)delegate  // run on UI thread
            {
                progressBarM.Width = (int)((Width * master));
                progressBarL.Width = (int)((Width * left));
                progressBarR.Width = (int)((Width * right));
                Arduino.sendLevel((int)(left * 255), (int)(right * 255));
            });

            
        }
    }
}
