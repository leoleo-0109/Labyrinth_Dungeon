using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using UniRx;
using BananaClient;

namespace Button
{
    public class NanoObjectController : MonoBehaviour
    {
        [SerializeField] private EventObserver eventObserver;
        [SerializeField,Header("リセットボタンでワープしたい位置")] private GameObject[] stageStartPosition;

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
        private bool buttonPressed = false;
        private bool buttonPressedRequest = false;
        private bool isResetButtonPress = false; // リセットボタンが押されたかどうか
        private float holdButtonTime = 0f; // ボタンを長押ししたボタン

        private void Start()
        {
            nanoSerialHandler.OnDataReceived += OnDataReceived;
            originalSpeed = mSpeed; // mSpeedの初期値を格納する変数の初期化
        }
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag(TagName.Portal1)
            ||other.gameObject.CompareTag(TagName.Portal2)
            ||other.gameObject.CompareTag(TagName.Portal3))
            {
                buttonPressedRequest = true;
            }
        }
        // 壁との当たり判定、当たっている間は速度を落とす
        private void OnCollisionEnter(Collision other)
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
        // 壁との当たり判定、離れたら元の速度に戻す
        private void OnCollisionExit(Collision other)
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
        // シリアル通信のデータ受信関数
        public void OnDataReceived(string message)
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
                    //Debug.Log("Left");
                    _camera.transform.Rotate(new Vector3(0, -5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, -5.0f, 0));
                }

                if (data[2] == "Right")
                {
                    //Debug.Log("Right");
                    _camera.transform.Rotate(new Vector3(0, 5.0f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, 5.0f, 0));
                }
                // フロア遷移
                if(buttonPressedRequest)
                {
                    Debug.Log("ボタン入力準備完了");
                    if((data[2]=="2F"||data[2]=="3F") && !buttonPressed)
                    {
                        eventObserver.TriggerStageTransition(); // ステージが変更されたのでイベントを発行
                        Debug.Log("2F");
                        EventFlagHolder.eventFlag = true;
                        buttonPressed = true;
                    }
                    else if((data[2]!="2F"&&data[2]!="3F") && buttonPressed)
                    {
                        Debug.Log("現在ボタン入力を受け付けません");
                        buttonPressed = false;
                        buttonPressedRequest = false;
                    }
                }
                // リセットボタン
                if(data[2]=="Reset"&&!isResetButtonPress)
                {
                    holdButtonTime += Time.deltaTime;
                    Debug.Log(holdButtonTime);
                    if (holdButtonTime > 3f && !isResetButtonPress)
                    {
                        ResetPlayerPositionBasedOnCount(eventObserver.HierarchyCount.Value); // 引数は現在の階層
                        isResetButtonPress = true;
                    }
                }
                else if(data[2]!="Reset"&&isResetButtonPress)
                {
                    holdButtonTime = 0f;
                    isResetButtonPress = false;
                }
                playerObject.transform.Translate(ax * delta, 0.00f, az * delta);
                Debug.Log("ax: " + ax + ", az: " + az + ", ay: " + 0.00f + ", Camera or Reset: " + data[2]);
            }
        }
        void ResetPlayerPositionBasedOnCount(int count)
        {
            switch (count)
            {
                case 0:
                    ResetPlayerPosition(stageStartPosition[0]);
                    break;
                case 1:
                    ResetPlayerPosition(stageStartPosition[1]);
                    break;
                case 2:
                    ResetPlayerPosition(stageStartPosition[2]);
                    break;
            }
        }
        void ResetPlayerPosition(GameObject startPosition)
        {
            Vector3 pos = new Vector3(0, 1.6f, 0);
            Vector3 startPos = startPosition.transform.position;
            startPos += pos; // 座標調整
            gameObject.transform.position = startPos;
        }

    }
}
