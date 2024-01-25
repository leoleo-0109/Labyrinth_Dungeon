using System;
using UnityEngine;
using UniRx;

/// <summary>
/// TimerModelクラス
/// </summary>
public class TimerModel : MonoBehaviour
{
    // タイマーアイテムのSubject
    private Subject<Unit> timerItem = new Subject<Unit>();

    // タイマーアイテムのObservable
    public IObservable<Unit> TimerItemObserver => timerItem;

    /// <summary>
    /// 衝突時に呼ばれるメソッド
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {
        // 衝突したオブジェクトがプレイヤーなら
        if(other.gameObject.CompareTag(TagName.Player)){
            timerItem.OnNext(Unit.Default); // タイマーアイテムのイベントを発行
            gameObject.SetActive(false); // オブジェクトを非アクティブにする
        }
    }
}