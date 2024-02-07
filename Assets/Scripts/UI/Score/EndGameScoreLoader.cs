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
            int currentTime = timerPresenter.keepNowTime * 10; // タイムを100倍にする
            Debug.Log("currentTime" + currentTime);
            int currentScore = Mathf.RoundToInt(scorePresenter.score);  // スコアを四捨五入して整数に変換
            int totalScore = currentScore + currentTime; // スコアとタイムを合計してトータルスコアを作成
            Debug.Log("totalScore" + totalScore);
            ScoreManager.Instance.Score = totalScore;
        }).AddTo(disposables);

        gameState.GameOverObserver.Subscribe(_ =>
        {
            timerPresenter.OnKeepTime();
            Debug.Log("namati" + timerPresenter.keepNowTime);
            int currentTime = timerPresenter.keepNowTime * 10; // タイムを100倍にする
            Debug.Log("currentTime" + currentTime);
            int currentScore = Mathf.RoundToInt(scorePresenter.score);  // スコアを四捨五入して整数に変換
            int totalScore = currentScore + currentTime; // スコアとタイムを合計してトータルスコアを作成
            Debug.Log("totalScore" + totalScore);
            ScoreManager.Instance.Score = totalScore;
        }).AddTo(disposables);
    }
}