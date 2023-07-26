using UnityEngine;
using UniRx;
using System;
using BananaClient;

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
        eventObserver.OnStageTransitionTriggered
        .Subscribe(_ =>
        {
            count++;
            Debug.Log("UpdateHierarchyCount");
            eventObserver.hierarchyCount.Value = count;
        }).AddTo(this);
    }
}
