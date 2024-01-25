using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PortalModelクラスはポータルの動作を制御する
/// </summary>
public class PortalModel : MonoBehaviour
{
    /// <summary>
    /// カウントが増加したときに発生するイベント。
    /// </summary>
    public event Action CountAdd = delegate { };

    /// <summary>
    /// オブジェクトが他のオブジェクトと衝突したときに呼び出される
    /// </summary>
    /// <param name="other">衝突した他のオブジェクト。</param>
    void OnCollisionEnter(Collision other)
    {
        // プレイヤーと衝突した場合
        if (other.gameObject.CompareTag(TagName.Player))
        {
            // カウントを増やす
            CountAdd.Invoke();

            // ポータルオブジェクトを非アクティブにする
            gameObject.SetActive(false);
        }
    }
}