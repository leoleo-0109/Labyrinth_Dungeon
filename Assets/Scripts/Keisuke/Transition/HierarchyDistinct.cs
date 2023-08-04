using UnityEngine;
using UniRx;
using System;
using BananaClient;

// 現在の階層を記録するシステム
public class HierarchyDistinct : MonoBehaviour
{
    [SerializeField] private EventObserver eventObserver;
    private int count = 0;
    void Start()
    {
        eventObserver.hierarchyCount.Value = count;
        UpdateHierarchyCount();
    }

    public void UpdateHierarchyCount()
    {
        // ステージが変更されるたびに購読
        eventObserver.OnStageTransitionTriggered
        .Subscribe(_ =>
        {
            count++;
            eventObserver.hierarchyCount.Value = count;
        }).AddTo(this);
    }
}
