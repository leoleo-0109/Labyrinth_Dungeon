using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;


public class ScoreModel : MonoBehaviour
{
    private Subject<Unit> onEventTrigger = new Subject<Unit>();
    public IObservable<Unit> OnEventTrigger => onEventTrigger; // onEventTriggerで値を発行しOnEventTriggerでその値を受け取りSubscribeでOnEventTriggerの値を購読する、今回はUnitなので値なし
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            onEventTrigger.OnNext(Unit.Default); // イベント発行
            gameObject.SetActive(false);
        }
    }
}

