using System;
using System.Collections;
using UnityEngine;
using UniRx;

/// <summary>
/// TimerPresenterクラス
/// </summary>
public class TimerPresenter : MonoBehaviour
{
    [SerializeField,Header("ワープする回数分長さを変えて")] private EventObserver[] eventObserver; // テレポートイベントを呼びたい回数だけインスペクターで配列の長さを変えて
    [SerializeField] private TimerView timerView; // 制限時間のテキスト
    [SerializeField] private TimerView itemView; // タイムアイテムのカウントテキスト
    [SerializeField] private TimerModel[] timerModels;
    [SerializeField,Header("全てのステージに配置しているタイムアイテムの数")] private int allTimeItemMaxCount = 0; // ステージ全体に存在するタイムアイテムの数
    private int itemCurrentMaxCount = 0; // 現在のステージに存在するタイムアイテムの数
    [SerializeField,Header("ステージ1に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage1; // ステージ1に存在するタイムアイテムの数
    [SerializeField,Header("ステージ2に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage2; // ステージ2に存在するタイムアイテムの数
    [SerializeField,Header("ステージ3に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage3; // ステージ3に存在するタイムアイテムの数
    private int stageChangeCount = 0; // ステージが変化した回数を記録する
    private Timer timer;
    private int timeItemRemovedCount = 0; // タイムアイテムが消えた回数を保持する変数
    private int timeItemCount = 0; // タイムアイテムのテキストに反映させるための変数
    private float magnification = 100; // タイムに掛けたい倍率
    [SerializeField,Header("初期時間")] private float initialTime = 60; // 初期時間
    [SerializeField,Header("アイテムを取った時に追加するタイム")] private float addTimeElement = 0;
    public int keepNowTime;
    CompositeDisposable disposables = new CompositeDisposable();

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        InitializeItemCountBasedOnStage();
        UpdateTimeItemCount();// DisplayTimeItemCountの第二引数の更新
        // 初期時間を秒数からTimeSpan型に変換
        TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
        timer = new Timer(initialTimeSpan);
        WarpEventObserver();
        TimeLimit();
        AddTime();
    }
    private void InitializeItemCountBasedOnStage()
    {
        // ゲームモードがシングルステージプレイの場合、現在のステージに基づいてitemCurrentMaxCountを設定
        if (GameModeManager.CurrentGameMode == GameMode.Single)
        {
            // StageManagerで設定された現在のステージ番号に基づき、itemCurrentMaxCountを初期化
            switch (StageManager.CurrentStage)
            {
                case 0: // ステージ1
                    itemCurrentMaxCount = itemCurrentMaxCountStage1;
                    break;
                case 1: // ステージ2
                    itemCurrentMaxCount = itemCurrentMaxCountStage2;
                    break;
                case 2: // ステージ3
                    itemCurrentMaxCount = itemCurrentMaxCountStage3;
                    break;
                default:
                    Debug.LogError("Undefined stage number: " + StageManager.CurrentStage);
                    break;
            }
        }
        else
        {
            ChangeMaxCount(0);
        }
    }
    /// <summary>
    /// 時間制限処理
    /// </summary>
    private void TimeLimit()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                // ModelとViewの処理
                // Timerの残り時間を現在の経過時間分減算
                // DecrementTimeの引数にTime.deltaTimeを入れることで1秒ずつカウントダウンされる
                timer.DecrementTime(TimeSpan.FromSeconds(Time.deltaTime));
                // TimerViewにタイマーの残り時間を表示
                timerView.DisplayTime(timer.RemainingTime.Value);
            }).AddTo(disposables);
    }

    /// <summary>
    /// 時間追加処理
    /// </summary>
    public void AddTime()
    {
        // モデル回数分だけ処理:Model1
        foreach (TimerModel timerModel in timerModels)
        {
            // アイテム取得時に購読
            timerModel.TimerItemObserver.Subscribe(_ =>
            {
                // タイム追加処理
                timer.IncrementTime(TimeSpan.FromSeconds(addTimeElement));
                timeItemRemovedCount++; // 消えた回数をインクリメント
                AddTimeItemCount(); // タイムアイテムが取られた回数を記録するためのメソッド
                //AppendTime(); // アイテムを取るたびに関数が呼ばれる
            }).AddTo(disposables);
        }
    }

    /// <summary>
    /// ランキング表示時の追加タイムスコアの処理
    /// </summary>
    public void AppendTime()
    {
        // アイテムが消えた回数と最大アイテム数をif条件で監視して特定する
        if(timeItemRemovedCount == allTimeItemMaxCount){
            // remainingTimeinSecondsに整数型の現在のTimeが入ってる
            int remainingTimeInSeconds = Mathf.RoundToInt((float)timer.RemainingTime.Value.TotalSeconds);
            keepNowTime = remainingTimeInSeconds;
            timer.IncrementTime(TimeSpan.FromSeconds(remainingTimeInSeconds * magnification));
        }
    }

    /// <summary>
    /// ワープイベント監視処理
    /// </summary>
    private void WarpEventObserver()
    {
        // ワープイベントが発生したらtimeItemCountを0にする
        // ワープポイントの数だけ処理する
        foreach (EventObserver eventInstance in eventObserver)
        {
            eventInstance.OnTimeItemCountResetEvent
                .Subscribe(_ =>
                {
                    stageChangeCount++; // ステージが変わるたびにインクリメント
                    timeItemCount = 0;
                    if(GameModeManager.CurrentGameMode == GameMode.Story)
                    {
                        ChangeMaxCount(stageChangeCount); // stageChangeCountはステージが変化した回数の値を持っているので引数に返す
                    }
                    UpdateTimeItemCount();
                })
                .AddTo(disposables);
        }
    }

    /// <summary>
    /// アイテム取得回数記録処理
    /// </summary>
    private void AddTimeItemCount()
    {
        timeItemCount++;
        UpdateTimeItemCount();
    }

    /// <summary>
    /// stageChangeCountの値を受け取る処理
    /// </summary>
    private void ChangeMaxCount(int stageNum)
    {
        switch(stageNum)
        {
            case 0:
                itemCurrentMaxCount = itemCurrentMaxCountStage1;
                break;
            case 1:
                itemCurrentMaxCount = itemCurrentMaxCountStage2;
                break;
            case 2:
                itemCurrentMaxCount = itemCurrentMaxCountStage3;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// テキストにアイテム取得回数を反映する処理
    /// </summary>
    private void UpdateTimeItemCount()
    {
        itemView.DisplayTimeItemCount(timeItemCount,itemCurrentMaxCount);// 引数1:アイテムの取得数,引数2:現在のステージのアイテム取得上限
    }

    /// <summary>
    /// カウントダウン開始処理
    /// </summary>
    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    /// <summary>
    /// カウントダウンコルーチン
    /// </summary>
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

    /// <summary>
    /// 残り時間を保持する処理
    /// </summary>
    public void OnKeepTime()
    {
        int remainingTimeInSeconds = Mathf.RoundToInt((float)timer.RemainingTime.Value.TotalSeconds);
        keepNowTime = remainingTimeInSeconds;
    }

    /// <summary>
    /// オブジェクトが非アクティブになったときの処理
    /// </summary>
    void OnDisable()
    {
        disposables.Dispose();
    }
}
