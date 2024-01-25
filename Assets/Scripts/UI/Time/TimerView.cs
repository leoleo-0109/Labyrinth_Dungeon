using System;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// TimerViewクラス
/// </summary>
public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timerItemCountText;

    /// <summary>
    /// 時間を表示するメソッド
    /// </summary>
    /// <param name="timeSpan">表示する時間</param>
    public void DisplayTime(TimeSpan timeSpan)
    {
        // TimeSpanの合計秒数が負の場合にマイナス記号を設定
        string sign = timeSpan.TotalSeconds < 0 ? "-" : "";
        // 分と秒は2桁の整数で表示
        string timeFormatted = string.Format("{0}{1:D2}:{2:D2}", sign, Math.Abs(timeSpan.Minutes), Math.Abs(timeSpan.Seconds));
        timerText.text = timeFormatted; // 時間をテキストに設定
    }

    /// <summary>
    /// アイテム取得回数を表示するメソッド
    /// </summary>
    /// <param name="count">取得回数</param>
    /// <param name="maxCount">最大取得回数</param>
    public void DisplayTimeItemCount(int count,int maxCount)
    {
        timerItemCountText.text = count.ToString()+"/"+maxCount; // 取得回数をテキストに設定
    }
}