using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNavigator : MonoBehaviour
{
    [SerializeField] private BGMController bgmController;
    private void LoadScene(string baseSceneName)
    {
        string sceneName = baseSceneName + "_" + DeviceModeManager.CurrentDeviceMode.ToString();
        SceneManager.LoadScene(sceneName);
    }

    // タイトルシーンに戻る
    public void OnClickReturnTitleButton()
    {
        bgmController.StopBGM();
        bgmController.ChangeTitleBGM();
        LoadScene("TitleScene");
    }

    // モード選択シーンに移動
    public void OnClickReturnModeSelectButton()
    {
        LoadScene("ModeSelectScene");
    }

    // ストーリーモードを開始
    public void OnClickStoryModeGameButton()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Story;
        LoadScene("StoryModeGameScene");
    }

    // ステージ選択シーンに移動
    public void OnClickStageSelectButton()
    {
        LoadScene("StageSelectScene");
    }

    // ステージ1を開始
    public void OnClickStage1Button()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        StageManager.CurrentStage = 0; // ステージ1を設定
        LoadScene("SelectModeStage1GameScene");
    }

    // Stage2 Single
    public void OnClickStage2Button()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        StageManager.CurrentStage = 1; // ステージ2を設定
        LoadScene("SelectModeStage2GameScene");
    }

    // Stage3 Single
    public void OnClickStage3Button()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        StageManager.CurrentStage = 2; // ステージ3を設定
        LoadScene("SelectModeStage3GameScene");
    }

    // RankingScene
    public void OnClickRankingButton()
    {
        LoadScene("RankingScene");
    }
}
