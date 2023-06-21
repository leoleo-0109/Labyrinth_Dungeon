using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

namespace Button
{
    public class ObjectController : MonoBehaviour    
    {
        [SerializeField]
        GameObject _camera;
        private int counts;
        private SerialPort serialPort;
        public SerialHandler serialHandler;
        public float delta = 0.01f;
        [SerializeField, Header("左＆後の移動に使用")] private float minusSpeed = 4.00f; // 固定で4倍すること
        [SerializeField, Header("速度変更")] private float speed = 1.00f;

        [SerializeField] private float cameraSpeed = 1.00f;
        private float deltaPos;
        private Vector3 pos;
        public Vector3 accel;
        public GameObject playerObject;

        private bool isLeftPressed = false;
        private bool isRightPressed = false;

        void Start()
        {
            serialHandler.OnDataReceived += OnDataReceived;
        }

        void OnDataReceived(string message)
        {
            // Vector3 pos = transform.localPosition;
            var data = message.Split(
                new string[] { "," }, System.StringSplitOptions.None); // カンマで分割する
            // Debug.Log(message);
             
            //string data = serialPort.ReadLine();  // 1行読み取る
            //string[] values = data.Split(',');  // カンマで分割する
            

            if (data.Length == 3)
            {
                float ax = float.Parse(data[0]);
                //float ay = float.Parse(data[1]);
                float az = float.Parse(data[1]);
                //float rx = float.Parse(data[2]);
                //float ry = float.Parse(data[2]);
                // float rz = float.Parse(data[5]);
                //bool ButtonFlag = bool.Parse(values[6]);
                
                // 感度調整
                if(ax < 10.00f)
                {
                    ax = ax * (-1) * minusSpeed; // left
                    //ax = ax * (-1) * minusSpeed * speed; // left
                }
                if(az < 10.00f)
                {
                    az = az * (-1) * minusSpeed; // back
                    //az = az * (-1) * minusSpeed * speed; // back
                }
                 //ax = ax * speed; // right
                 //az = az * speed; // front

                //playerObject.transform.Translate(ax * delta, 0.00f, az * delta);
                //playerObject.transform.Rotate(new Vector3(0.00f, ry * delta, 0.00f));
                //Debug.Log("ax: " + ax + ", az: " + az + ", ay: " + 0.00f);

                // カメラの挙動
                if (data[2] == "Left")
                {
                    Debug.Log("Left");
                    /*isLeftPressed = true;
                    isRightPressed = false;*/
                    //if (isLeftPressed){
                    // メインカメラを半時計回りに回転させる処理を追加
                    //playerObject.transform.Rotate(new Vector3(0.0f, -cameraSpeed * Time.deltaTime, 0.0f));
                    _camera.transform.Rotate(new Vector3(0, -5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, -5.0f, 0));
                    //}
                }
                
                if (data[2] == "Right")
                {
                    Debug.Log("Right");
                    /*isLeftPressed = false;
                    isRightPressed = true;*/
                    //if (isRightPressed){
                    _camera.transform.Rotate(new Vector3(0, 5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, 5.0f, 0));
                    // メインカメラを時計回りに回転させる処理を追加
                    //playerObject.transform.Rotate(new Vector3(0.0f, cameraSpeed * Time.deltaTime, 0.0f));
                    //}
                }
                
                playerObject.transform.Translate(ax * delta, 0.00f, az * delta);
                Debug.Log("ax: " + ax + ", az: " + az + ", ay: " + 0.00f + ", camera: " + data[2]);
            }
        }            
    } 
}
