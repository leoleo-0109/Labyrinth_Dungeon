using UnityEngine;
using UniRx;
using System;
using BananaClient;

public class HierarchyDistinct : MonoBehaviour
{
    [SerializeField] private EventObserver eventObserver;
    public BehaviorSubject<int> HierarchyNumNotice = new BehaviorSubject<int>(0);
    [SerializeField] private PortalPresenter stageTransition;
    private int hierarchyCount = 0;
    private int previousHierarchyCount = 0;
    void Start()
    {
        DistinctCount();
        UpdateHierarchyCount();
    }

    public void UpdateHierarchyCount()
    {
        eventObserver.OnStageTransitionTriggered
        .Subscribe(_ =>
        {
            Debug.Log("Subscribe");  // Add debug log
            previousHierarchyCount = hierarchyCount;
            hierarchyCount++;
            DistinctCount();
        }).AddTo(this);
    }

    private void DistinctCount()
    {
        HierarchyNumNotice.OnNext(previousHierarchyCount);
    }
}
