using UnityEngine;
using TMPro;

namespace BananaClient
{
    public class ResultView : MonoBehaviour
    {
        // スコアを表示するためのText
        [SerializeField] private TextMeshProUGUI scoreText;

        // タイムを表示するためのText
        [SerializeField] private TextMeshProUGUI timeText;
        // トータルスコアを表示するためのText
        [SerializeField] private TextMeshProUGUI totalScoreText;
        public void CurrentScoreView(float score)
        {
            scoreText.text = "Score: " + score.ToString("F0");
        }
        public void CurrentTimeView(int time)
        {
            timeText.text = "Time: " + time.ToString();
        }
        public void TotalScoreView(float score, int time)
        {
            int currentTime = time * 100; // 整数のタイムに×100
            int currentScore = Mathf.RoundToInt(score);  // scoreを四捨五入してintに変換
            int totalScore = currentScore + currentTime; // スコアとタイムを合わせたトータルスコアの作成
            totalScoreText.text = "TotalScore: " + totalScore.ToString();
        }
    }
}
