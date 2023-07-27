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
        [HideInInspector] public ReactiveProperty<int> hierarchyCount = new ReactiveProperty<int>(-1);
        public IReadOnlyReactiveProperty<int> HierarchyCount => hierarchyCount;

        // ステージが切り替わったタイミングで呼び出す
        public void TriggerStageTransition()
        {
            onStageTransitionTriggered.OnNext(Unit.Default);
        }
    }
}
