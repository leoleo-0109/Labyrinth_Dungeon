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
        [SerializeField] private float initialTime = 60;

        private Timer timer;

        private void Start()
        {
            TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
            timer = new Timer(initialTimeSpan);

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    // ModelとViewの処理
                    timer.DecrementTime(TimeSpan.FromSeconds(Time.deltaTime));
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
