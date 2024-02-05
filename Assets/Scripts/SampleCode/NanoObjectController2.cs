using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine.UIElements;

namespace Button
{
    public class NanoObjectController2 : MonoBehaviour
    {
        [SerializeField] private EventObserver eventObserver;
        [SerializeField, Header("リセットボタンでワープしたい位置")] private GameObject[] stageStartPosition;

        [SerializeField]
        GameObject _camera;
        private int counts;
        private SerialPort serialPort;
        public NanoSerialHandler nanoSerialHandler;
        private float delta = 0.002f;  //0.002f
        [SerializeField, Header("left＆back移動に使用")] private float minusSpeed = 4.00f; // 固定で4倍すること
        [SerializeField, Header("ステータの壁に当たった際のスロー効果")] private float slowSpeed;
        private float maxSpeed = 32.0f;//30.0f // 加速度センサーの実値スピード上限値
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
        private float resister = 0.7f;

        void Start()
        {
            nanoSerialHandler.OnDataReceived += OnDataReceived;
            originalSpeed = minusSpeed; // mSpeedの初期値を格納する変数の初期化
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag(TagName.Portal1)
            || other.gameObject.CompareTag(TagName.Portal2)
            || other.gameObject.CompareTag(TagName.Portal3))
            {
                buttonPressedRequest = true;
            }
        }
        // 壁との当たり判定、当たっている間は速度を落とす
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Stage1)
            || other.gameObject.CompareTag(TagName.Stage2)
            || other.gameObject.CompareTag(TagName.Stage3))
            {
                Debug.Log("Wall");
                minusSpeed -= slowSpeed;
                Debug.Log(minusSpeed);
            }
        }
        // 壁との当たり判定、離れたら元の速度に戻す
        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Stage1)
            || other.gameObject.CompareTag(TagName.Stage2)
            || other.gameObject.CompareTag(TagName.Stage3))
            {
                Debug.Log("Wall");
                minusSpeed = originalSpeed;
                Debug.Log("離れた" + minusSpeed);
            }
        }
        void OnDataReceived(string message)
        {
            var data = message.Split(
                new string[] { "," }, System.StringSplitOptions.None); // カンマで分割する

            //Debug.Log(data.Length);
            if (data.Length == 3)
            {
                float ax = float.Parse(data[0]);
                float az = float.Parse(data[1]);

                // 感度調整
                if (ax < 10.00f)
                {
                    ax = ax * (-1) * minusSpeed; // left
                }
                // ax正数値の調整
                /*if (ax > 0)
                {
                    ax = ax * resister;
                }*/

                // 手振れ修正
                if (-2.0f < ax && ax < 2.0f)
                {
                    ax = 0;
                }

                // axの上限速度
                if (ax > maxSpeed)
                {
                    ax = maxSpeed; // right上限速度
                }
                if (ax < -maxSpeed)
                {
                    ax = -maxSpeed; // left上限速度
                }

                // 感度調整
                // 後ろに下がる処理
                if (az < 10.00f)
                {
                    az = az * (-1) * minusSpeed; // back
                }

                // 手振れ修正
                if (-2.0f < az && az < 2.0f)
                {
                    az = 0;
                }

                // azの上限速度
                if (az > maxSpeed)
                {
                    az = maxSpeed; // front上限速度
                }
                if (az < -maxSpeed)
                {
                    az = -maxSpeed; // back上限速度
                }

                // カメラの挙動
                if (data[2] == "Left")
                {
                    Debug.Log("Left");
                    _camera.transform.Rotate(new Vector3(0, -0.5f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, -0.5f, 0));
                }

                if (data[2] == "Right")
                {
                    Debug.Log("Right");
                    _camera.transform.Rotate(new Vector3(0, 0.5f, 0));
                    this.gameObject.transform.Rotate(new Vector3(0, 0.5f, 0));
                }
                // フロア遷移
                if (buttonPressedRequest)
                {
                    Debug.Log("ボタン入力準備完了");
                    if ((data[2] == "2F" || data[2] == "3F") && !buttonPressed)
                    {
                        eventObserver.TriggerStageTransition(); // ステージが変更されたのでイベントを発行
                        Debug.Log("2F");
                        EventFlagHolder.eventFlag = true;
                        buttonPressed = true;
                    }
                    else if ((data[2] != "2F" && data[2] != "3F") && buttonPressed)
                    {
                        Debug.Log("現在ボタン入力を受け付けません");
                        buttonPressed = false;
                        buttonPressedRequest = false;
                    }
                }
                // リセットボタン
                if (data[2] == "Reset" && !isResetButtonPress)
                {
                    holdButtonTime += Time.deltaTime;
                    Debug.Log(holdButtonTime);
                    if (holdButtonTime > 3f && !isResetButtonPress)
                    {
                        ResetPlayerPositionBasedOnCount(eventObserver.HierarchyCount.Value);
                        isResetButtonPress = true;
                    }
                }
                else if (data[2] != "Reset" && isResetButtonPress)
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
