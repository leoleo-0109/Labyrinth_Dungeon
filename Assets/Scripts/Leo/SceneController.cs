using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // TitleSceneで使用
    public void OnClickStartButton() // タイトル(スタート)ボタン
    {
        SceneManager.LoadScene("IntroductionScene");
    }

    // TitleSceneで使用
    public void OnClickRankingButton() // タイトル(ランキング)ボタン
    {
        SceneManager.LoadScene("RankingScene");
    }

    // IntroductionSceneで使用
    public void OnClickGameButton() // ゲームボタン
    {
        SceneManager.LoadScene("GameScene");
    }

    // RankingSceneで使用
    public void OnClickTitleButton() // タイトルボタン
    {
        SceneManager.LoadScene("TitleScene");
    }

    // TitleSceneで使用
    public void OnClickRetryButton() // リトライボタン
    {
        SceneManager.LoadScene("GameScene");
    }
}
