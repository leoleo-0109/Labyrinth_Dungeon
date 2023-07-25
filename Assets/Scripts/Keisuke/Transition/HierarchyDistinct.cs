using UnityEngine;
using UniRx;
using System;

public class HierarchyDistinct : MonoBehaviour
{
    private Subject<int> hierarchyNumNotice = new Subject<int>();
    public IObservable<int> HierarchyNumNotice => hierarchyNumNotice;
    private int hierarchyCount = 0;
    void Start(){
        hierarchyCount++;
    }
    public void Distinct()
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