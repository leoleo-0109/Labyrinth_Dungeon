using System;
using System.Collections;
using UnityEngine;
using UniRx;
using BananaClient;

namespace BananaClient
{
    public class TimerPresenter : MonoBehaviour
    {
        [SerializeField] private EventObserver[] eventObserver; // テレポートイベントを呼びたい回数だけインスペクターで配列の長さを変えて
        [SerializeField] private TimerView timerView; // 制限時間のテキスト
        [SerializeField] private TimerView itemView; // タイムアイテムのカウントテキスト
        [SerializeField] private TimerModel[] timerModelsType1;
        [SerializeField] private TimerModel[] timerModelsType2;
        [SerializeField] private TimerModel[] timerModelsType3;
        [SerializeField,Header("全てのステージに配置しているタイムアイテムの数")] private int AllTimeItemMaxCount = 0; // ステージ全体に存在するタイムアイテムの数
        private int itemCurrentMaxCountStage1; // 現在のステージに存在するタイムアイテムの数
        private int itemCurrentMaxCountStage2; // 現在のステージに存在するタイムアイテムの数
        private int itemCurrentMaxCountStage3; // 現在のステージに存在するタイムアイテムの数
        private int modelCountType1; // 配列の要素数を取得する変数
        private int modelCountType2; // 配列の要素数を取得する変数
        private int modelCountType3; // 配列の要素数を取得する変数
        private Timer timer;
        private int timeItemRemovedCount = 0; // タイムアイテムが消えた回数を保持する変数
        private int timeItemRemovedCountType1 = 0;
        private int timeItemRemovedCountType2 = 0;
        private int timeItemRemovedCountType3 = 0;
        private int timeItemCount = 0;
        private float magnification = 100; // タイムに掛けたい倍率
        [SerializeField] private float initialTime = 60; // 初期時間を設定するためのSerializedField
        [SerializeField,Header("アイテムを取った時に追加するタイム")] private float addTimeElement = 0;
        private void Start()
        {
            // 初期時間を秒数からTimeSpan型に変換
            TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
            timer = new Timer(initialTimeSpan);
            GetTimeItemRemovedCount();
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
            // モデル回数分だけ処理:Model1
            foreach (TimerModel timerModel in timerModelsType1)
            {
                modelCountType1++; // ここでモデルの配列の長さを調べる
                // アイテム取得時に購読
                timerModel.TimerItemObserver.Subscribe(_ =>
                {
                    // タイム追加処理
                    timer.IncrementTime(TimeSpan.FromSeconds(addTimeElement));
                    timeItemRemovedCountType1++;
                    timeItemRemovedCount++; // 消えた回数をインクリメント
                    AddTimeItemCount(); // タイムアイテムが取られた回数を記録するためのメソッド
                    AppendTime(); // アイテムを取るたびに関数が呼ばれる
                }).AddTo(this);
            }
            // モデル回数分だけ処理:Model2
            foreach (TimerModel timerModel in timerModelsType2)
            {
                modelCountType2++; // ここでモデルの配列の長さを調べる
                // アイテム取得時に購読
                timerModel.TimerItemObserver.Subscribe(_ =>
                {
                    // タイム追加処理
                    timer.IncrementTime(TimeSpan.FromSeconds(addTimeElement));
                    timeItemRemovedCountType2++;
                    timeItemRemovedCount++; // 消えた回数をインクリメント
                    AddTimeItemCount(); // タイムアイテムが取られた回数を記録するためのメソッド
                    AppendTime(); // アイテムを取るたびに関数が呼ばれる
                }).AddTo(this);
            }
            // モデル回数分だけ処理:Model3
            foreach (TimerModel timerModel in timerModelsType3)
            {
                modelCountType3++; // ここでモデルの配列の長さを調べる
                // アイテム取得時に購読
                timerModel.TimerItemObserver.Subscribe(_ =>
                {
                    // タイム追加処理
                    timer.IncrementTime(TimeSpan.FromSeconds(addTimeElement));
                    timeItemRemovedCountType3++;
                    timeItemRemovedCount++; // 消えた回数をインクリメント
                    AddTimeItemCount(); // タイムアイテムが取られた回数を記録するためのメソッド
                    AppendTime(); // アイテムを取るたびに関数が呼ばれる
                }).AddTo(this);
            }
        }
        // ランキング表示時の追加タイムスコアの処理
        public void AppendTime()
        {
            Debug.Log("mae");
            // アイテムが消えた回数と最大アイテム数をif条件で監視して特定する
            if(timeItemRemovedCount == AllTimeItemMaxCount){
                Debug.Log("appendTime");
                // remainingTimeinSecondsに整数型の現在のTimeが入ってる
                int remainingTimeInSeconds = Mathf.RoundToInt((float)timer.RemainingTime.Value.TotalSeconds);
                timer.IncrementTime(TimeSpan.FromSeconds(remainingTimeInSeconds * magnification));
            }
        }
        private void GetTimeItemRemovedCount()
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
        // アイテムを取得した回数を記録するメソッド
        private void AddTimeItemCount()
        {
            timeItemCount++;
            UpdateTimeItemCount();
        }
        // テキストにアイテムを取得した回数を反映
        private void UpdateTimeItemCount()
        {
            itemView.DisplayTimeItemCount(timeItemCount,itemCurrentMaxCountStage1);// 引数1:アイテムの取得数,引数2:現在のステージのアイテム取得上限
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
