using System;
using UniRx;
using UnityEngine;


public class EndGameScoreLoader : MonoBehaviour
{
    [SerializeField] private ScorePresenter scorePresenter;
    [SerializeField] private TimerPresenter timerPresenter;
    [SerializeField] private GameState gameState;
    CompositeDisposable disposables = new CompositeDisposable();

    private void Start()
    {
        gameState.GameClearObserver.Subscribe(_ =>
        {
            timerPresenter.OnKeepTime();
            Debug.Log("namati" + timerPresenter.keepNowTime);
            int currentTime = timerPresenter.keepNowTime * 10; // タイムを計算
            Debug.Log("currentTime" + currentTime);
            int currentScore = Mathf.RoundToInt(scorePresenter.score); // スコアを計算
            int totalScore = currentScore + currentTime; // トータルスコアを計算
            Debug.Log("totalScore" + totalScore);

            // GameDataにスコアとタイムを設定
            GameData.Score = totalScore;
            GameData.TimeInSeconds = timerPresenter.keepNowTime;
        }).AddTo(disposables);

        gameState.GameOverObserver.Subscribe(_ =>
        {
            timerPresenter.OnKeepTime();
            Debug.Log("namati" + timerPresenter.keepNowTime);
            int currentTime = timerPresenter.keepNowTime * 10; // タイムを計算
            Debug.Log("currentTime" + currentTime);
            int currentScore = Mathf.RoundToInt(scorePresenter.score); // スコアを計算
            int totalScore = currentScore + currentTime; // トータルスコアを計算
            Debug.Log("totalScore" + totalScore);

            // GameDataにスコアとタイムを設定
            GameData.Score = totalScore;
            GameData.TimeInSeconds = timerPresenter.keepNowTime;
        }).AddTo(disposables);
    }
}