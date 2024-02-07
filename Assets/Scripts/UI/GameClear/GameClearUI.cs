using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using TMPro;
public class GameClearUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // スコアを表示するUI
    [SerializeField] private TextMeshProUGUI timeText; // タイムを表示するUI

    private void Start()
    {
        DisplayResults();
    }

    private void DisplayResults()
    {
        scoreText.text = $"{GameData.Score}";

        // TimeSpanを使用してタイムをフォーマット
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameData.TimeInSeconds);
        string sign = timeSpan.TotalSeconds < 0 ? "-" : "";
        string timeFormatted = string.Format("{0}{1:D2}:{2:D2}", sign, Math.Abs(timeSpan.Minutes), Math.Abs(timeSpan.Seconds));
        timeText.text = $"{timeFormatted}";
    }
}
