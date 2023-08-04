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
        private void OnEnable()
        {
            Debug.Log("OnEnable");
            timeResultView.CurrentTimeView(timerPresenter.keepNowTime);
            scoreResultView.CurrentScoreView(scorePresenter.score);
            totalScoreResultView.TotalScoreView(scorePresenter.score,timerPresenter.keepNowTime);
        }
    }
}
