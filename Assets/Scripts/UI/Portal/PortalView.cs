using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PortalViewクラス
/// </summary>
public class PortalView : MonoBehaviour
{
    /// <summary>
    /// ポータルを表示するメソッド
    /// </summary>
    private void View()
    {
        gameObject.SetActive(true); // ポータルをアクティブにする
    }
}