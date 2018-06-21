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
            cmbSerialPorts.DataSource = Arduino.getComPorts();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1);   // probably shouldnt go much faster than 20ms
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            labelConnectionStatus.Text = "Status:";
            if (btnConnect.Text == "Connect")
            {
                if (cmbSerialPorts.SelectedIndex > -1)
                {
                    // MessageBox.Show(String.Format("You selected port '{0}'", cmbSerialPorts.SelectedItem));
                    bool success = Arduino.Connect(cmbSerialPorts.SelectedItem.ToString());
                    if (Arduino.isConnected() && success)    // on successful connection
                    {
                        btnConnect.Text = "Disconnect";
                        labelConnectionStatus.Text = "Status: Connected";
                        Thread.Sleep(500);
                        SetTimer();
                    }
                    else
                    {
                        labelConnectionStatus.Text = "Status: [ERROR] No response from device. Try a different COM port";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a port first");
                }
            }
            else
            {
                btnConnect.Text = "Connect";
                labelConnectionStatus.Text = "Status: Not Connected";
                Arduino.Disconnect();
            }
        }

        private void cmbSerialPorts_MouseClick(object sender, MouseEventArgs e)
        {
            cmbSerialPorts.DataSource = Arduino.getComPorts();
        }
    }
}
