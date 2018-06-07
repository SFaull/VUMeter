using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Visualiser
{
    class SerialDeviceManager
    {
        SerialPort port;

        public SerialDeviceManager()
        {

        }

        ~SerialDeviceManager()
        {
            port.Close();
        }

        public bool Connect(string portName)
        {
            bool success = false;
            if (!isConnected())
            {
                port = new SerialPort(portName);
                if (!port.IsOpen)
                {
                    port.BaudRate = 115200;
                    port.DataBits = 8;
                    port.StopBits = StopBits.One;
                    port.Parity = Parity.None;
                    port.Handshake = Handshake.None;
                    port.DtrEnable = true;
                    port.ReadTimeout = 5000;
                    port.WriteTimeout = 5000;
                    port.Open();
                    Thread.Sleep(500);  // wait a little bit for device to become responsive

                    success = true; //isArduino();

                    if (!success)
                    {
                        port.Close();
                    }
                }
            }
            return success;
        }

        public void Disconnect()
        {
            port.Close();
        }

        public string[] getComPorts()
        {
            return SerialPort.GetPortNames();
        }

        public bool isConnected()
        {
            if (port != null && port.IsOpen)
                return true;
            return false;
        }

        private bool isArduino()
        {
            serialWrite("*IDN?");
            string result = serialRead();
            return result.Equals("Arduino");
        }

        private string serialRead()
        {
            String str = "";

            if (isConnected())
            {
                try
                {
                    str = port.ReadLine();
                    str = str.TrimEnd('\r', '\n');
                }
                catch   // timeout
                {
                    str = "Error";
                }
            }

            return str;
        }

        private void serialWrite(string str)
        {
            str = str + "\r";   // add a CR
            if (isConnected())
            {
                try
                {
                    port.DiscardOutBuffer();
                    port.DiscardInBuffer();
                    port.WriteLine(str);
                }
                catch   // timeout
                {
                    // write error/timeout
                }
            }
        }

        private void serialWriteBytes(byte[] data)
        {
            if (isConnected())
            {
                try
                {
                    //port.DiscardOutBuffer();
                    //port.DiscardInBuffer();
                    port.Write(data, 0, data.Length);
                }
                catch   // timeout
                {
                    // write error/timeout
                    Console.WriteLine("ERROR");
                }
            }
        }

        public void sendLevel(int left, int right)
        {
            // left & right levels are in range 0-100
            var level = new byte[3];
            level[0] = Convert.ToByte(left);
            level[1] = Convert.ToByte(right);
            level[2] = Encoding.UTF8.GetBytes("\r")[0];
            serialWriteBytes(level);
        }
    }
}
