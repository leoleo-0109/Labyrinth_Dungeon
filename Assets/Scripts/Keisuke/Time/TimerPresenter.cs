using System;
using System.Collections;
using UnityEngine;
using UniRx;
using BananaClient;

namespace BananaClient
{
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] private TimerView timerView;
        [SerializeField] private float initialTime = 60; // 初期時間を設定するためのSerializedField

        private Timer timer;

        private void Start()
        {
            // 初期時間を秒数からTimeSpan型に変換
            TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
            timer = new Timer(initialTimeSpan);

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    // ModelとViewの処理
                    // Timerの残り時間を現在の経過時間分減算
                    // DecrementTimeの引数にTime.deltaTimeを入れることで1秒ずつカウントダウンされる
                    timer.DecrementTime(TimeSpan.FromSeconds(Time.deltaTime));
                    // TimerViewにタイマーの残り時間を表示
                    timerView.DisplayTime(timer.RemainingTime.Value);
                }).AddTo(this);
        }
        // 必要な場所で呼び出す
        public void StartCountdown()
        {
            StartCoroutine(CountdownCoroutine());
        }

        private IEnumerator CountdownCoroutine()
        {
            // 3,2,1のカウントダウン処理
            float countdownTime = 3.0f;
            while (countdownTime > 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownTime -= 1.0f;
            }
            Debug.Log("カウントダウン終了");
        }
    }
}
