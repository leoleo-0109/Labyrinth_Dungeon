using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using UniRx;

namespace Button
{
    public class NanoObjectController : MonoBehaviour
    {
        [SerializeField]
        GameObject _camera;
        private int counts;
        private SerialPort serialPort;
        public NanoSerialHandler nanoSerialHandler;
        public float delta = 0.01f;
        [SerializeField, Header("左＆後の移動に使用")] private float mSpeed = 8.00f; // 固定で8倍すること
        [SerializeField, Header("ステータの壁に当たった際のスロー効果")] private float slowSpeed;
        private float originalSpeed;

        [SerializeField] private float cameraSpeed = 1.00f;
        private float deltaPos;
        private Vector3 pos;
        public Vector3 accel;
        public GameObject playerObject;
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        public static bool eventFlag = false;
        void Start()
        {
            nanoSerialHandler.OnDataReceived += OnDataReceived;
            originalSpeed = mSpeed;
        }
        void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag(TagName.Stage1)
            ||other.gameObject.CompareTag(TagName.Stage2)
            ||other.gameObject.CompareTag(TagName.Stage3))
            {
                Debug.Log("Wall");
                mSpeed -= slowSpeed;
                Debug.Log(mSpeed);
            }
        }
        void OnCollisionExit(Collision other)
        {
            if(other.gameObject.CompareTag(TagName.Stage1)
            ||other.gameObject.CompareTag(TagName.Stage2)
            ||other.gameObject.CompareTag(TagName.Stage3))
            {
                Debug.Log("Wall");
                mSpeed = originalSpeed;
                Debug.Log("離れた"+mSpeed);
            }
        }
        void OnDataReceived(string message)
        {
            var data = message.Split(
                new string[] { "," }, System.StringSplitOptions.None); // カンマで分割する
            if (data.Length == 3)
            {
                float ax = float.Parse(data[0]);
                float az = float.Parse(data[1]);
                // 感度調整 Nano用
                if(ax < 10.00f)
                {
                    ax = ax * (-1) * mSpeed; // left
                }

                // axの上限速度
                if (ax > 32.00f)
                {
                    ax = 32.00f; // right上限速度
                }
                if (ax < -32.00f)
                {
                    ax = -32.00f; // left上限速度
                }

                if (az < 10.00f)
                {
                    az = az * (-1) * mSpeed; // back
                }

                // azの上限速度
                if (az > 32.00f)
                {
                    az = 32.00f; // front上限速度
                }
                if (az < -32.00f)
                {
                    az = -32.00f; // back上限速度
                }

                // カメラの挙動
                if (data[2] == "Left")
                {
                    Debug.Log("Left");
                    _camera.transform.Rotate(new Vector3(0, -5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, -5.0f, 0));
                }

                if (data[2] == "Right")
                {
                    Debug.Log("Right");
                    _camera.transform.Rotate(new Vector3(0, 5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, 5.0f, 0));
                }
                // フロア遷移
                if(data[2]=="2F"||data[2]=="3F")
                {
                    Debug.Log("2F");
                    eventFlag = true;
                    Debug.Log(eventFlag);
                }
                playerObject.transform.Translate(ax * delta, 0.00f, az * delta);
                //Debug.Log("ax: " + ax + ", az: " + az + ", ay: " + 0.00f + ", camera: " + data[2]);
            }
        }
    }
}
