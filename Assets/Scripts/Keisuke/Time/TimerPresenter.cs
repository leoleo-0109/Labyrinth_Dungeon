using System;
using System.Collections;
using UnityEngine;
using UniRx;
using BananaClient;

namespace BananaClient
{
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] private EventObserver eventObserver;
        [SerializeField] private TimerView timerView;
        [SerializeField] private TimerModel[] timerModels;
        private Timer timer;
        private int timeItemRemoved = 0; // タイムアイテムが消えた回数を保持する変数
        private int timeItemCount = 0;
        private float magnification = 100; // タイムに掛けたい倍率
        [SerializeField,Header("全てのステージに配置しているタイムアイテムの数")] private int timeItemMaxCount = 0; // ステージ全体に存在するタイムアイテムの数
        [SerializeField] private float initialTime = 60; // 初期時間を設定するためのSerializedField
        [SerializeField,Header("アイテムを取った時に追加するタイム")] private float addTimeElement = 0;
        private void Start()
        {
            // 初期時間を秒数からTimeSpan型に変換
            TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
            timer = new Timer(initialTimeSpan);
            TimeItemRemovedCount();
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
            AddTime();
        }
        public void AddTime()
        {
            foreach (TimerModel timerModel in timerModels)
            {
                // アイテム取得時に購読
                timerModel.TimerItemObserver.Subscribe(_ =>
                {
                    // タイム追加処理
                    timer.IncrementTime(TimeSpan.FromSeconds(addTimeElement));
                    timeItemRemovedCount++; // 消えた回数をインクリメント
                    AppendTime(); // アイテムを取るたびに関数が呼ばれる
                }).AddTo(this);
            }
        }
        public void AppendTime()
        {
            Debug.Log("mae");
            // アイテムが消えた回数と最大アイテム数をif条件で監視して特定する
            if(timeItemRemovedCount == timeItemMaxCount){
                Debug.Log("appendTime");
                // remainingTimeinSecondsに整数型の現在のTimeが入ってる
                int remainingTimeInSeconds = Mathf.RoundToInt((float)timer.RemainingTime.Value.TotalSeconds);
                timer.IncrementTime(TimeSpan.FromSeconds(remainingTimeInSeconds * magnification));
            }
        }
        private void TimeItemRemovedCount()
        {
            // ワープイベントが発生したらtimeItemCountを0にする
            // ワープポイントの数だけ処理する
            foreach (EventObserver eventInstance in eventObserver)
            {
                eventInstance.OnTimeItemCountResetEvent
                    .Subscribe(_ =>
                    {
                        timeItemCount = 0;
                        UpdateTimeItemCount();
                    })
                    .AddTo(this);
            }
        }
        private void AddTimeItemCount()
        {
            timeItemCount++;
            Debug.Log(timeItemCount);
            UpdateTimeItemCount();
        }
        private void UpdateTimeItemCount()
        {
            timerView.DisplayTimeItemCount(timeItemCount);
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
