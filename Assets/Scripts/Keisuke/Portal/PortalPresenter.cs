using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;

namespace BananaClient
{
    public class PortalPresenter : MonoBehaviour
    {
        private int RemoveCount{ get; set; }
        [SerializeField] private PortalModel[] portalModels;
        [SerializeField] private PortalView[] portalViews;
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
            }
            if (RemoveCount == 6)
            {
                portalViews[1].gameObject.SetActive(true); // ステージ3のPortalViewをアクティブにする
            }
            if(RemoveCount == 9)
            {
                portalViews[2].gameObject.SetActive(true); // ステージ3のPortalViewをアクティブにする
            }
        }
    }
}
