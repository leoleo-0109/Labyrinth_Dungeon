using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialPortScript : MonoBehaviour
{
    SerialPort serialPort;

    [SerializeField] private string portName = "COM10";
    private int baudRate = 115200;

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        //serialPort.ReadTimeout = 500;
        serialPort.Open();
    }

    void Update()
    {
        try
        {
            string data = serialPort.ReadLine();  // 1行読み取る
            string[] values = data.Split(',');  // カンマで分割する

            if (values.Length == 6)
            {
                float ax = float.Parse(values[0]);
                float ay = float.Parse(values[1]);
                float az = float.Parse(values[2]);
                float rx = float.Parse(values[3]);
                float ry = float.Parse(values[4]);
                float rz = float.Parse(values[5]);
                //bool ButtonFlag = bool.Parse(values[6]);
                // 値の確認
                Debug.Log("ax: " + ax + ", ay: " + ay + ", az: " + az + ", rx: " + rx + ", ry: " + ry + ", rz: " + rz);
            }
        }
        catch (System.TimeoutException)
        {
            // 
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}
