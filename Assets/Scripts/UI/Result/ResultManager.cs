using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ResultManagerクラス
/// </summary>
public class ResultManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas; // 結果を表示するキャンバス

    [SerializeField]
    ResultPresenter resultPresenter; // 結果を表示するプレゼンター

    /// <summary>
    /// 結果を表示するメソッド
    /// </summary>
    public void ShowResult()
    {
        resultPresenter.StartSubscription(); // プレゼンターの購読を開始
        canvas.gameObject.SetActive(true); // キャンバスをアクティブにする
    }
}