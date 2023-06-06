// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO.Ports;


// namespace Leo
// {
//     public class PlayerController : MonoBehaviour    
//     {
//         public SerialHandler serialHandler;
//         private Vector3 playerPos;

//         void Start()
//         {
//             serialHandler.OnDataReceived += OnDataReceived;
//         }

//         void OnDataReceived(string message)
//         {
//             try
//             {
//                 string data = serialPort.ReadLine();  // 1行読み取る
//                 string[] values = data.Split(',');  // カンマで分割する

//                 if (values.Length == 6)
//                 {
//                     float ax = float.Parse(values[0]);
//                     float ay = float.Parse(values[1]);
//                     float az = float.Parse(values[2]);
//                     float rx = float.Parse(values[3]);
//                     float ry = float.Parse(values[4]);
//                     float rz = float.Parse(values[5]);
//                     //bool ButtonFlag = bool.Parse(values[6]);
//                     // 値の確認
//                     Debug.Log("ax: " + ax + ", ay: " + ay + ", az: " + az + ", rx: " + rx + ", ry: " + ry + ", rz: " + rz);
//                 }
//             }
//             catch (System.TimeoutException)
//             {
//                 // 
//             }
//         } 
//     }
// }
