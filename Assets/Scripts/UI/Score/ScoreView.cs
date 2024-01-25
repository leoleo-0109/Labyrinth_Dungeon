using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ScoreViewクラス
/// </summary>
public class ScoreView : MonoBehaviour
{
    // スコア表示用テキスト
    [SerializeField] private TextMeshProUGUI scoreText;

    // スコアアイテムカウント表示用テキスト
    [SerializeField] private TextMeshProUGUI scoreItemCountText;

    /// <summary>
    /// スコア表示メソッド
    /// </summary>
    /// <param name="count">表示するスコア</param>
    public void ScoreDisplay(float count)
    {
        scoreText.text = count.ToString("F0"); // スコアをテキストに設定
    }

    /// <summary>
    /// スコアアイテムカウント表示メソッド
    /// </summary>
    /// <param name="count">現在のカウント</param>
    /// <param name="maxCount">最大カウント</param>
    public void DisplayScoreItemCount(int count, int maxCount)
    {
        scoreItemCountText.text = count.ToString() + "/" + maxCount; // 現在のカウントと最大カウントをテキストに設定
    }
}