using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;

namespace Save
{
    public class KeepScore : MonoBehaviour
    {
        [SerializeField]
        TimerPresenter timerPresenter;
        [SerializeField]
        ScorePresenter scorePresenter;
        public float confirmScore = 0;
        private float confirmTime = 0;
        //keyにスコア合計を追加する。
        public void KeepKey()
        {
            //timerPresenterの小数点を切り捨て
            confirmTime = timerPresenter.keepNowTime;
            Mathf.Floor(confirmTime);
            //-だったら0に
            if (confirmTime <= 0)
            {
                confirmTime = 0;
            }
            confirmTime *= 100;
            //スコアと加算してkeyに保存
            confirmScore = scorePresenter.score += confirmTime;
            PlayerPrefs.SetFloat("score", scorePresenter.score);
        }
    }
}