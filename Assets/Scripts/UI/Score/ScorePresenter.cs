using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField,Header("ワープする回数分長さを変えて")] private EventObserver[] eventObserver;
    [SerializeField,Header("全てのステージに配置しているアイテムの数")] private int allScoreItemMaxCount = 0;
    private int itemCurrentMaxCount = 0; // 現在のステージに存在するタイムアイテムの数
    private int stageChangeCount = 0; // ステージが変化した回数を記録する
    private int scoreItemRemoveCount = 0; // スコアアイテムが消えた回数を記録
    private int currentItemGetCount = 0; // 現在アイテムを取得した回数、上の変数と役割かぶってるけど上の変数は値をリセットするからこの変数が必要になってくる
    [SerializeField,Header("ステージ1に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage1; // ステージ1に存在するタイムアイテムの数
    [SerializeField,Header("ステージ2に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage2; // ステージ2に存在するタイムアイテムの数
    [SerializeField,Header("ステージ3に存在するタイムアイテムの数")] private int itemCurrentMaxCountStage3; // ステージ3に存在するタイムアイテムの数
    [SerializeField,Header("Type1アイテムを設定")] private ScoreModel[] scoreModelsType1;
    [SerializeField,Header("Type2アイテムを設定")] private ScoreModel[] scoreModelsType2;
    [SerializeField,Header("Type3アイテムを設定")] private ScoreModel[] scoreModelsType3;
    private int scoreCountType1 = 0;
    private int scoreCountType2 = 0;
    private int scoreCountType3 = 0;
    [SerializeField] private ScoreView scoreView; // スコア
    [SerializeField] private ScoreView scoreItemView; // スコアアイテム
    [SerializeField] private ScoreView comboView; // コンボ表示用のScoreView
    public float score = 0; // スコアがこいつに保存されてる
    public ReplaySubject<Unit> itemCompleted = new ReplaySubject<Unit>(1);
    CompositeDisposable disposables = new CompositeDisposable();
    void Start()
    {
        // TimerModelのインスタンスをすべて取得し、それぞれのイベントを購読
        foreach (var timerModel in FindObjectsOfType<TimerModel>())
        {
            timerModel.TimerItemObserver.Subscribe(_ => {
                ResetCombo();
            }).AddTo(disposables);
        }

        // KeyModelのインスタンスをすべて取得し、それぞれのイベントを購読
        foreach (var keyModel in FindObjectsOfType<KeyModel>())
        {
            keyModel.KeyCountAdd += () => {
                ResetCombo();
            };
        }
        InitializeItemCountBasedOnStage();
        UpdateScoreItemCount();
        StageChangeObserver();
        AddScoreEventTrigger();
        UpdateScore();
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
    // コンボをリセットするメソッド
    private void ResetCombo()
    {
        // コンボ関連のカウントをリセット
        scoreCountType1 = 0;
        scoreCountType2 = 0;
        scoreCountType3 = 0;
        UpdateComboUI();
    }
    private void UpdateComboUI()
    {
        int totalCombo = scoreCountType1 + scoreCountType2 + scoreCountType3; // 総コンボ数を計算
        comboView.DisplayCombo(totalCombo); // コンボ数を表示
    }

    /// <summary>
    /// スコアイベントトリガーを追加
    /// </summary>
    private void AddScoreEventTrigger()
    {
        // Type1のスコアモデルに対してイベントトリガーを追加
        foreach (ScoreModel scoreModelType1 in scoreModelsType1)
        {
            scoreModelType1.OnEventTrigger.Subscribe(_ => {
                AddScore(1);
            }).AddTo(disposables);
        }
        // Type2のスコアモデルに対してイベントトリガーを追加
        foreach (ScoreModel scoreModelType2 in scoreModelsType2)
        {
            scoreModelType2.OnEventTrigger.Subscribe(_ => {
                AddScore(2);
            }).AddTo(disposables);
        }
        // Type3のスコアモデルに対してイベントトリガーを追加
        foreach (ScoreModel scoreModelType3 in scoreModelsType3)
        {
            scoreModelType3.OnEventTrigger.Subscribe(_ => {
                AddScore(3);
            }).AddTo(disposables);
        }
    }

    /// <summary>
    /// スコアを追加
    /// </summary>
    /// <param name="scoreType">スコアのタイプ</param>
    private void AddScore(int scoreType)
    {
        float addedScore = 1000f; // スコア加算量を固定
        switch(scoreType){
            case 1:
                scoreCountType1++;
                if(scoreCountType1==2){
                    addedScore *= 1.2f;
                }
                else if(scoreCountType1==3){
                    score *= 1.5f; // ここで総スコアに1.5倍を適用
                    addedScore = 0; // このアイテムによる追加スコアは0にする
                    addedScore *= 1.5f;
                    scoreCountType1 = 0; //リセット
                }
                break;
            case 2:
                scoreCountType2++;
                if(scoreCountType2==2){
                    addedScore *= 1.2f;
                }
                else if(scoreCountType2==3){
                    score *= 1.5f; // ここで総スコアに1.5倍を適用
                    addedScore = 0; // このアイテムによる追加スコアは0にする
                    addedScore *= 1.5f;
                    scoreCountType2 = 0; //リセット
                }
                break;
            case 3:
                scoreCountType3++;
                if(scoreCountType3==2){
                    addedScore *= 1.2f;
                }
                else if(scoreCountType3==3){
                    score *= 1.5f; // ここで総スコアに1.5倍を適用
                    addedScore = 0; // このアイテムによる追加スコアは0にする
                    addedScore *= 1.5f;
                    scoreCountType3 = 0; //リセット
                }
                break;
            default:
                break;
        }
        scoreItemRemoveCount++;
        currentItemGetCount++;// 合計取得回数を記録
        score += addedScore; // ここで倍率計算する
        // TODO:クリア時のイベントを作る？
        // TODO:ゲームが終了した際にscoreを保存する処理が必要
        Debug.Log(score);
        ExtraScore(); // TODO:クリア時に呼び出すほうがいいかも
        UpdateScoreItemCount();
        UpdateScore();
        UpdateComboUI();
    }
    private void StageChangeObserver()
    {
        // ワープイベントが発生したらtimeItemCountを0にする
        // ワープポイントの数だけ処理する
        foreach (EventObserver eventInstance in eventObserver)
        {
            eventInstance.OnScoreItemCountResetEvent
                .Subscribe(_ =>
                {
                    stageChangeCount++; // ステージが変わるたびにインクリメント
                    scoreItemRemoveCount = 0;
                    ChangeMaxCount(stageChangeCount); // stageChangeCountはステージが変化した回数の値を持っているので引数に返す
                    UpdateScoreItemCount();
                })
                .AddTo(disposables);
        }

    }
    // stageChangeCountの値を受け取るメソッド
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
    // スコアアイテムコンプリート時の追加スコア処理
    private void ExtraScore()
    {
        // スコアアイテムの合計取得取得数とステージ1,2,3にある全てのスコアアイテムの数が等しかったら処理を行う
        if(currentItemGetCount==allScoreItemMaxCount)
        {
            itemCompleted.OnNext(Unit.Default);
            Debug.Log("Comleted");
        }
    }
    private void UpdateScore()
    {
        scoreView.ScoreDisplay(score);
    }
    private void UpdateScoreItemCount()
    {
        scoreItemView.DisplayScoreItemCount(scoreItemRemoveCount,itemCurrentMaxCount);
    }
    void OnDisable()
    {
        disposables.Dispose();
    }
}
