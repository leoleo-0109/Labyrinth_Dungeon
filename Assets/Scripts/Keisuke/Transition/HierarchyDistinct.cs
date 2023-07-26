using UnityEngine;
using UniRx;
using System;
using BananaClient;

public class HierarchyDistinct : MonoBehaviour
{
    private Subject<int> hierarchyNumNotice = new Subject<int>();
    public IObservable<int> HierarchyNumNotice => hierarchyNumNotice;
    private StageTransition warpEvent = new StageTransition();
    private int hierarchyCount = 0;
    CompositeDisposable disposable = new CompositeDisposable();
    void Start()
    {
        // TODO:イベント発行タイミングを調整
        DistinctCount();
        UpdateHierarchyCount();
    }
    public void UpdateHierarchyCount()
    {
        warpEvent.OnWarpEventTrigger.Subscribe(_ =>
        {
            Debug.Log("Subscribe");
            hierarchyCount++;
            DistinctCount();
        }).AddTo(disposable);
    }
    private void DistinctCount()
    {
        if(hierarchyCount==0){
            hierarchyNumNotice.OnNext(0);
        }
        if(hierarchyCount==1){
            hierarchyNumNotice.OnNext(1);
        }
        if(hierarchyCount==2){
            hierarchyNumNotice.OnNext(2);
        }
    }
}