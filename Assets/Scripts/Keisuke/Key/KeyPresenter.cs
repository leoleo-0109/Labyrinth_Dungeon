using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPresenter : MonoBehaviour
{
    [SerializeField] private KeyModel[] keyModels;
    [SerializeField] private KeyView keyView;
    private int keyCount = 0;
    void Start()
    {
        foreach (KeyModel keyModel in keyModels)
        {
            keyModel.KeyCountAdd += AddKeyCount;
        }
        UpdateKeyCount();
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
