using UnityEngine;
using UniRx;
using System;

public class HierarchyDistinct : MonoBehaviour
{
    private Subject<int> hierarchyDistinct = new Subject<int>();
    public IObservable<int> HierarchyDistinct => hierarchyDistinct;
    private int hierarchyCount = 0;
    void Start(){
        hierarchyCount++;
    }
    public void Distinct()
    {
        if(hierarchyCount==0){
            hierarchyDistinct.OnNext(0);
        }
        if(hierarchyCount==1){
            hierarchyDistinct.OnNext(1);
        }
        if(hierarchyCount==2){
            hierarchyDistinct.OnNext(2);
        }
    }
}