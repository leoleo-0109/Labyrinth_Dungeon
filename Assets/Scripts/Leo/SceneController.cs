using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // TitleScene
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }

    // TitleScene
    public void OnClickRankingButton()
    {
        SceneManager.LoadScene("RankingScene");
    }

    // IntroductionScene
    public void OnClickGameKeyButton()
    {
        SceneManager.LoadScene("KeyBoardMainGame");
    }
    public void OnClickGameNanoButton()
    {
        SceneManager.LoadScene("MainGameNanoVer");
    }
     public void OnClickGameESPButton()
    {
        SceneManager.LoadScene("MainGameESP32Ver");
    }

    // RankingScene
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

    // TitleScene
    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
