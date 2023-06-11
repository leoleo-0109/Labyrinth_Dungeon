using System;
using System.Collections;
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
    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        float countdownTime = 3.0f;
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            countdownTime -= 1.0f;
        }
        Debug.Log("かうんとだうんおわり");
    }
}
