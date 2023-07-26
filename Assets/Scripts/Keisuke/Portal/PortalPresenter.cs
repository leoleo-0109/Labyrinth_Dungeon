using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;
using UniRx;
using System;

namespace BananaClient
{
    public class PortalPresenter : MonoBehaviour
    {
        private Subject<Unit> notifyCurrentHierarchy = new Subject<Unit>();
        public IObservable<Unit> NotifyCurrentHierarchy => notifyCurrentHierarchy;

        private int RemoveCount{ get; set; }
        [SerializeField,Header("ポータルの表示に必要な鍵を設定")] private PortalModel[] portalModels;
        [SerializeField,Header("表示させたいポータルを設定")] private PortalView[] portalViews;
        void Start()
        {
            foreach (PortalModel portalModel in portalModels)
            {
                portalModel.CountAdd += IncrementRemoveCount;
            }
            foreach (PortalView portalView in portalViews)
            {
                portalView.gameObject.SetActive(false); // 初期状態ですべてのPortalViewを非アクティブにする
            }
        }
        public void IncrementRemoveCount()
        {
            RemoveCount++;
            if (RemoveCount == 3)
            {
                portalViews[0].gameObject.SetActive(true); // ステージ1のPortalViewをアクティブにする
                notifyCurrentHierarchy.OnNext(Unit.Default);
            }
            if (RemoveCount == 6)
            {
                portalViews[1].gameObject.SetActive(true); // ステージ3のPortalViewをアクティブにする
                notifyCurrentHierarchy.OnNext(Unit.Default);
            }
            if(RemoveCount == 9)
            {
                portalViews[2].gameObject.SetActive(true); // ステージ3のPortalViewをアクティブにする
                notifyCurrentHierarchy.OnNext(Unit.Default);
            }
        }
    }
}
