using System;
using UniRx;
using UnityEngine;

/// <summary>
/// ResultPresenterクラス
/// </summary>
public class ResultPresenter : MonoBehaviour
{
    [SerializeField] private ResultView timeResultView;
    [SerializeField] private ResultView scoreResultView;
    [SerializeField] private ResultView totalScoreResultView;
    [SerializeField] private ScorePresenter scorePresenter;
    [SerializeField] private TimerPresenter timerPresenter;
    private int extraScore = 0;
    private IDisposable subscription;
    private bool isSubscribed = false;

    /// <summary>
    /// 購読を開始するメソッド
    /// </summary>
    public void StartSubscription()
    {
        if (isSubscribed) return;
        subscription = scorePresenter.itemCompleted
            .Subscribe(_ =>
            {
                Debug.Log("Subscribe");
                extraScore += 100; // extraScoreに100を加算
                isSubscribed = true; // 購読状態をtrueに設定
            });
    }

    /// <summary>
    /// オブジェクトが有効になったときに呼び出されるメソッド
    /// </summary>
    private void OnEnable()
    {
        timeResultView.CurrentTimeView(timerPresenter.keepNowTime); // 現在の時間を表示
        scoreResultView.CurrentScoreView(scorePresenter.score + extraScore); // 現在のスコアを表示
        totalScoreResultView.TotalScoreView(scorePresenter.score, timerPresenter.keepNowTime); // 合計スコアを表示
    }

    /// <summary>
    /// オブジェクトが無効になったときに呼び出されるメソッド
    /// </summary>
    private void OnDisable()
    {
        subscription?.Dispose(); // 購読を解除
        isSubscribed = false; // 購読状態をfalseに設定
    }
}