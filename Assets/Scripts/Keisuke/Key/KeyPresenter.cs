using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;
using UniRx;

namespace BananaClient
{
    public class KeyPresenter : MonoBehaviour
    {
        [SerializeField] private StageTransition[] warpEvent;
        [SerializeField] private KeyModel[] keyModels;
        [SerializeField] private KeyView keyView;
        private int keyCount = 0;
        void Start()
        {
            RemovedKeyCountEvent();
            foreach (KeyModel keyModel in keyModels)
            {
                keyModel.KeyCountAdd += AddKeyCount;
            }
            UpdateKeyCount();
        }
        private void RemovedKeyCountEvent()
        {
            // ワープイベントが発生したらkeyCountを0にする
            // ワープポイントの数だけ処理する
            foreach (StageTransition eventInstance in warpEvent)
            {
                eventInstance.OnWarpEventTrigger
                    .Subscribe(_ =>
                    {
                        keyCount = 0;
                        UpdateKeyCount();
                    })
                    .AddTo(this);
            }
        }
        private void AddKeyCount()
        {
            keyCount++;
            Debug.Log(keyCount);
            UpdateKeyCount();
        }
        private void UpdateKeyCount()
        {
            keyView.KeyCountDisplay(keyCount);
        }
    }
}