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
        public IObservable<Unit> OnStageTransitionTriggered => onStageTransitionTriggered; // ステージが変更されたかどうかを監視するオブザーバー

        private Subject<Unit> onTimeItemCountResetEvent = new Subject<Unit>();
        public IObservable<Unit> OnTimeItemCountResetEvent => onScoreItemCountResetEvent;

        private Subject<Unit> onScoreItemCountResetEvent = new Subject<Unit>();
        public IObservable<Unit> OnScoreItemCountResetEvent => onScoreItemCountResetEvent;

        [HideInInspector] public ReactiveProperty<int> hierarchyCount = new ReactiveProperty<int>(-1);
        public IReadOnlyReactiveProperty<int> HierarchyCount => hierarchyCount; // 現在のステージの階層を保持する

        public void TriggerStageTransition()
        {
            onStageTransitionTriggered.OnNext(Unit.Default); // ステージが切り替わったタイミングでイベントを発行
        }
        public void OnTimeItemCountResetTrigger()
        {
            onTimeItemCountResetEvent.OnNext(Unit.Default);
        }
        public void OnScoreItemCountResetTrigger()
        {
            onScoreItemCountResetEvent.OnNext(Unit.Default);
        }
    }
}
