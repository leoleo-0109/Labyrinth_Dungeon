using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// ScoreModelクラス
/// </summary>
public class ScoreModel : MonoBehaviour
{
    // イベントトリガーのSubject
    private Subject<Unit> onEventTrigger = new Subject<Unit>();

    // イベントトリガーのObservable
    public IObservable<Unit> OnEventTrigger => onEventTrigger;

    /// <summary>
    /// 衝突時に呼ばれるメソッド
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        // 衝突したオブジェクトがプレイヤーなら
        if (other.gameObject.CompareTag(TagName.Player))
        {
            onEventTrigger.OnNext(Unit.Default); // イベント発行
            gameObject.SetActive(false); // オブジェクトを非アクティブにする
        }
    }
}