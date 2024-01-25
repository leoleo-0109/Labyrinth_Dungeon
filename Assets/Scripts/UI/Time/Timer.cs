using System;
using UnityEngine;
using UniRx;

/// <summary>
/// Timerクラス
/// </summary>
public class Timer
{
    // タイマーの残り時間を格納するプロパティ
    public ReactiveProperty<TimeSpan> RemainingTime { get; private set; }

    /// <summary>
    /// Timerクラスのコンストラクタ
    /// </summary>
    /// <param name="initialTime">初期時間</param>
    public Timer(TimeSpan initialTime)
    {
        // 初期時間を設定
        RemainingTime = new ReactiveProperty<TimeSpan>(initialTime);
    }

    /// <summary>
    /// 残り時間を減算するメソッド
    /// </summary>
    /// <param name="deltaTime">減算する時間</param>
    public void DecrementTime(TimeSpan deltaTime)
    {
        // 残り時間からdeltaTimeを引く
        RemainingTime.Value -= deltaTime;
    }

    /// <summary>
    /// 残り時間を増加するメソッド
    /// </summary>
    /// <param name="deltaTime">増加する時間</param>
    public void IncrementTime(TimeSpan deltaTime)
    {
        // 残り時間にdeltaTimeを足す
        RemainingTime.Value += deltaTime;
    }
}