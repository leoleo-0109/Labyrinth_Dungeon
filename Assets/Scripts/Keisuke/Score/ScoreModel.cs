using System;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class ScoreModel : MonoBehaviour
{
    private Subject<Unit> onEventTrigger = new Subject<Unit>();
    public IObservable<Unit> OnEventTrigger => onEventTrigger;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            onEventTrigger.OnNext(Unit.Default);
            gameObject.SetActive(false);
        }
    }
}
