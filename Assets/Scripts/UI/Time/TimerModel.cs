using System;
using UnityEngine;
using UniRx;


public class TimerModel : MonoBehaviour
{
    private Subject<Unit> timerItem = new Subject<Unit>();
    public IObservable<Unit> TimerItemObserver => timerItem;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag(TagName.Player)){
            timerItem.OnNext(Unit.Default);
            gameObject.SetActive(false);
        }
    }
}
