using System;
using UnityEngine;
using UniRx;

public class TimerPresenter : MonoBehaviour
{
    [SerializeField] private TimerView timerView;
    [SerializeField] private float initialTime = 60;

    private Timer timer;

    private void Start()
    {
        TimeSpan initialTimeSpan = TimeSpan.FromSeconds(initialTime);
        timer = new Timer(initialTimeSpan);

        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                timer.DecrementTime(TimeSpan.FromSeconds(Time.deltaTime));
                timerView.DisplayTime(timer.RemainingTime.Value);
            }).AddTo(this);
    }
}
