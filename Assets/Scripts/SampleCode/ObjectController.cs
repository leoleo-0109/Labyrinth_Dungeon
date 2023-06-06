using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

namespace Button
{
    public class ObjectController : MonoBehaviour    
    {
        private SerialPort serialPort;
        public SerialHandler serialHandler;
        public float delta = 0.01f;
        private float deltaPos;
        private Vector3 pos;
        public Vector3 accel;
        public GameObject playerObject;

        void Start()
        {
            serialHandler.OnDataReceived += OnDataReceived;
        }

        void OnDataReceived(string message)
        {
            // Vector3 pos = transform.localPosition;
            var data = message.Split(
                new string[] { "," }, System.StringSplitOptions.None);
            // Debug.Log(message);
             
            //string data = serialPort.ReadLine();  // 1行読み取る
            //string[] values = data.Split(',');  // カンマで分割する
            

            if (data.Length == 3)
            {
                float ax = float.Parse(data[0]);
                float ay = float.Parse(data[1]);
                float az = float.Parse(data[2]);
                // float rx = float.Parse(data[3]);
                // float ry = float.Parse(data[4]);
                // float rz = float.Parse(data[5]);
                //bool ButtonFlag = bool.Parse(values[6]);
                // 値の確認
                
                //accel = new Vector3(ax, ay, az);
                playerObject.transform.Translate(ax * delta, az * delta, ay * delta);
                Debug.Log("ax: " + ax + ", az: " + az + ", ay: " + ay);
                //Debug.Log("ax: " + ax + ", ay: " + ay + ", az: " + az + ", rx: " + rx + ", ry: " + ry + ", rz: " + rz);
            }
            
            

            // switch (data[0])
            // {
            //     case "Advance":
            //         deltaPos = delta * 30;
            //         pos.z += deltaPos;
            //         break;
            //     case "Back":
            //         deltaPos = delta * -30;
            //         pos.z += deltaPos;
            //         break;
            //     case "Left":
            //         deltaPos = delta * -30;
            //         pos.x += deltaPos;
            //         break;
            //     case "Right":
            //         deltaPos = delta * 30;
            //         pos.x += deltaPos;
            //         break;
            //     default:
            //         break;
            // }
            //transform.localPosition = pos;
        }
    } 
}
