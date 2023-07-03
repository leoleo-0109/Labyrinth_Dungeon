using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

namespace Button
{
    public class ESPSerialHandler : MonoBehaviour
    {
        public delegate void SerialDataReceivedEventHandler(string message);
        public event SerialDataReceivedEventHandler OnDataReceived;

        [SerializeField, Header("dsESP:COM9, leoESP:COM10, nano:COM6")] private string portName = "ESP32";
        //public string portName = "COM6";
        public int baudRate = 115200;

        private SerialPort serialPort_;
        private Thread thread_;
        private bool isRunning_ = false;

        private string message_;
        private bool isNewMessageReceived_ = false;

        void Awake()
        {
            Debug.Log(portName);
            Open();
        }

        void Update()
        {
            if (isNewMessageReceived_)
            {
                OnDataReceived(message_);
            }
        }

        void OnDestroy()
        {
            Close();
        }

        private void Open()
        {
            serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            serialPort_.Open();

            isRunning_ = true;

            thread_ = new Thread(Read);
            thread_.Start();
        }

        private void Close()
        {
            isRunning_ = false;

            if (thread_ != null && thread_.IsAlive)
            {
                thread_.Join();
            }

            if (serialPort_ != null && serialPort_.IsOpen)
            {
                serialPort_.Close();
                serialPort_.Dispose();
            }
        }

        private void Read()
        {
            while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
            {
                try
                {
                    // if (serialPort_.BytesToRead > 0) {
                    message_ = serialPort_.ReadLine();
                    isNewMessageReceived_ = true;
                    // }
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning(e.Message);
                }
            }
        }

        public void Write(string message)
        {
            try
            {
                serialPort_.Write(message);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
}
