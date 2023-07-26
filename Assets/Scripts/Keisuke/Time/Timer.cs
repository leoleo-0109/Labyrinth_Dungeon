using System;
using UnityEngine;
using UniRx;

namespace BananaClient
{
    public class Timer
    {
        // ReactivePropertyを用いてタイマーの残り時間を格納するプロパティ
        public ReactiveProperty<TimeSpan> RemainingTime { get; private set; }
        // コンストラクタ: 初期時間を受け取り、タイマーを初期化する
        public Timer(TimeSpan initialTime)
        {
            RemainingTime = new ReactiveProperty<TimeSpan>(initialTime);
        }
        // 残り時間を指定した時間分減算するメソッド
        public void DecrementTime(TimeSpan deltaTime)
        {
            RemainingTime.Value -= deltaTime;
        }
    }
}