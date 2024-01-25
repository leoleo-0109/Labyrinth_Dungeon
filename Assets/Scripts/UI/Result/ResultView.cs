using UnityEngine;
using TMPro;

/// <summary>
/// ResultViewクラス
/// </summary>
public class ResultView : MonoBehaviour
{
    // スコア表示用テキスト
    [SerializeField] private TextMeshProUGUI scoreText;

    // タイム表示用テキスト
    [SerializeField] private TextMeshProUGUI timeText;

    // トータルスコア表示用テキスト
    [SerializeField] private TextMeshProUGUI totalScoreText;

    /// <summary>
    /// スコア表示メソッド
    /// </summary>
    public void CurrentScoreView(float score)
    {
        scoreText.text = "Score: " + score.ToString("F0"); // スコアをテキストに設定
    }

    /// <summary>
    /// タイム表示メソッド
    /// </summary>
    public void CurrentTimeView(int time)
    {
        timeText.text = "Time: " + time.ToString(); // タイムをテキストに設定
    }

    /// <summary>
    /// トータルスコア表示メソッド
    /// </summary>
    public void TotalScoreView(float score, int time)
    {
        int currentTime = time * 100; // タイムを100倍にする
        int currentScore = Mathf.RoundToInt(score);  // スコアを四捨五入して整数に変換
        int totalScore = currentScore + currentTime; // スコアとタイムを合計してトータルスコアを作成
        totalScoreText.text = "TotalScore: " + totalScore.ToString(); // トータルスコアをテキストに設定
    }
}