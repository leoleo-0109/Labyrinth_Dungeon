using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace BananaClient
{
    public class EventObserver : MonoBehaviour
    {
        private Subject<Unit> onStageTransitionTriggered = new Subject<Unit>();
        public IObservable<Unit> OnStageTransitionTriggered => onStageTransitionTriggered;

        public void TriggerStageTransition()
        {
            onStageTransitionTriggered.OnNext(Unit.Default);
        }
    }
}
