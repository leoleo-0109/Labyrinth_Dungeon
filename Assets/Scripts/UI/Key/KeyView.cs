using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// KeyViewクラスは、キーカウントの表示を制御する
/// </summary>
public class KeyView : MonoBehaviour
{
    // キーカウントを表示するテキスト
    [SerializeField] private TextMeshProUGUI keyCountText;

    /// <summary>
    /// キーカウントを表示するメソッド
    /// </summary>
    /// <param name="count">表示するキーカウント</param>
    public void KeyCountDisplay(int count)
    {
        // キーカウントをテキストに設定
        keyCountText.text = count.ToString()+"/3";
    }
}