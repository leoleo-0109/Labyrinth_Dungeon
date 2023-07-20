using System;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

namespace BananaClient
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        public void DisplayTime(TimeSpan timeSpan)
        {
            // TimeSpanの合計秒数が負の場合にマイナス記号を設定
            string sign = timeSpan.TotalSeconds < 0 ? "-" : "";
            // 分と秒は2桁の整数で表示
            string timeFormatted = string.Format("{0}{1:D2}:{2:D2}", sign, Math.Abs(timeSpan.Minutes), Math.Abs(timeSpan.Seconds));
            timerText.text = timeFormatted;
        }
    }
}
