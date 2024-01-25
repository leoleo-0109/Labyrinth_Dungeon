using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// KeyPresenterクラスは、キーの表示を制御する
/// </summary>
public class KeyPresenter : MonoBehaviour
{
    [SerializeField] private StageTransition[] warpEvent;
    [SerializeField] private KeyModel[] keyModels;
    [SerializeField] private KeyView keyView;
    private int keyCount = 0;

    /// <summary>
    /// オブジェクトが有効になったときに呼び出される
    /// </summary>
    void Start()
    {
        RemovedKeyCountEvent();
        foreach (KeyModel keyModel in keyModels)
        {
            keyModel.KeyCountAdd += AddKeyCount;
        }
        UpdateKeyCount();
    }

    /// <summary>
    /// ワープイベントが発生したらkeyCountを0にするメソッド
    /// </summary>
    private void RemovedKeyCountEvent()
    {
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

    /// <summary>
    /// キーカウントを増やすメソッド
    /// </summary>
    private void AddKeyCount()
    {
        keyCount++;
        Debug.Log(keyCount);
        UpdateKeyCount();
    }

    /// <summary>
    /// キーカウントを更新するメソッド
    /// </summary>
    private void UpdateKeyCount()
    {
        keyView.KeyCountDisplay(keyCount);
    }
}