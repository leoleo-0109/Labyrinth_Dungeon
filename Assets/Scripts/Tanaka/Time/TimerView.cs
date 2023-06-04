using System;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;  // UI Text component to display the time

    public void DisplayTime(TimeSpan timeSpan)
    {
        string sign = timeSpan.TotalSeconds < 0 ? "-" : "";
        string timeFormatted = string.Format("{0}{1:D2}:{2:D2}", sign, Math.Abs(timeSpan.Minutes), Math.Abs(timeSpan.Seconds));
        timerText.text = timeFormatted;
    }
}
