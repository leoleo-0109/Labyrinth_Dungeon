using UnityEngine;
using UniRx;
using System;
using BananaClient;

public class HierarchyDistinct : MonoBehaviour
{
    [SerializeField] private EventObserver eventObserver;
    private int hierarchyCount = 0;
    private int previousHierarchyCount = 0;
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
            previousHierarchyCount = hierarchyCount;
            hierarchyCount++;
            eventObserver.hierarchyCount.Value = count;
        }).AddTo(this);
    }
}
