using System;
using UnityEngine;
using UniRx;

public class Timer
{
    public ReactiveProperty<TimeSpan> RemainingTime { get; private set; }
    public Timer(TimeSpan initialTime)
    {
        RemainingTime = new ReactiveProperty<TimeSpan>(initialTime);
    }
    public void DecrementTime(TimeSpan deltaTime)
    {
        RemainingTime.Value -= deltaTime;
    }
}
