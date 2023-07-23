using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // TitleScene�Ŏg�p
    public void OnClickStartButton() // �^�C�g��(�X�^�[�g)�{�^��
    {
        SceneManager.LoadScene("IntroductionScene");
    }

    // TitleScene�Ŏg�p
    public void OnClickRankingButton() // �^�C�g��(�����L���O)�{�^��
    {
        SceneManager.LoadScene("RankingScene");
    }

    // IntroductionScene�Ŏg�p
    public void OnClickGameButton() // �Q�[���{�^��
    {
        SceneManager.LoadScene("GameScene");
    }

    // RankingScene�Ŏg�p
    public void OnClickTitleButton() // �^�C�g���{�^��
    {
        SceneManager.LoadScene("TitleScene");
    }

    // TitleScene�Ŏg�p
    public void OnClickRetryButton() // ���g���C�{�^��
    {
        SceneManager.LoadScene("GameScene");
    }
}
