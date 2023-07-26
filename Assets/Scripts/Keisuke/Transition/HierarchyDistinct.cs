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
        UpdateHierarchyCount();
    }

    public void UpdateHierarchyCount()
    {
        eventObserver.OnStageTransitionTriggered
        .Subscribe(_ =>
        {
            if(count==0){
                eventObserver.hierarchyCount.OnNext(0);
            }
            if(count==1){
                eventObserver.hierarchyCount.OnNext(1);
            }
            if(count==2){
                eventObserver.hierarchyCount.OnNext(2);
            }
            count++;
            Debug.Log("Subscribe");  // Add debug log
            previousHierarchyCount = hierarchyCount;
            hierarchyCount++;
        }).AddTo(this);
    }
}
