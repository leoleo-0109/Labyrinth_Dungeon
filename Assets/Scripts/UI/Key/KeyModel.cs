using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// KeyModelクラスは、キーの動作を制御する
/// </summary>
public class KeyModel : MonoBehaviour
{
    /// <summary>
    /// キーカウントが増加したときに発生するイベント。
    /// </summary>
    public event Action KeyCountAdd = delegate { };

    /// <summary>
    /// キーカウントが増加したときに発生するイベント。
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        // プレイヤーと衝突した場合
        if (other.gameObject.CompareTag(TagName.Player))
        {
            // キーカウントを増やす
            KeyCountAdd.Invoke();
            // キーオブジェクトを非アクティブにする
            gameObject.SetActive(false);
        }
    }
}

