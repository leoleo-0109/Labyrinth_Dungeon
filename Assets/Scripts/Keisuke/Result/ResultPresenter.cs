using System;
using UniRx;
using UnityEngine;
using BananaClient;

namespace BananaClient
{
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

        public void StartSubscription()
        {
            if (isSubscribed) return;
            subscription = scorePresenter.itemCompleted
                .Subscribe(_ =>
                {
                    Debug.Log("Subscribe");
                    extraScore += 100;
                    isSubscribed = true;
                });
        }
        private void OnEnable()
        {
            timeResultView.CurrentTimeView(timerPresenter.keepNowTime);
            scoreResultView.CurrentScoreView(scorePresenter.score + extraScore);
            totalScoreResultView.TotalScoreView(scorePresenter.score, timerPresenter.keepNowTime);
        }
        private void OnDisable()
        {
            subscription?.Dispose();
            isSubscribed = false;
        }
    }
}
