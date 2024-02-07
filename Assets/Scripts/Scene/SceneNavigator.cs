using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNavigator : MonoBehaviour
{
    private void LoadScene(string baseSceneName)
    {
        string sceneName = baseSceneName + "_" + DeviceModeManager.CurrentDeviceMode.ToString();
        SceneManager.LoadScene(sceneName);
    }

    // タイトルシーンに戻る
    public void OnClickReturnTitleButton()
    {
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
        GameModeManager.CurrentGameMode = GameMode.Single;
        StageManager.CurrentStage = 0; // ステージ1を設定
        LoadScene("SelectModeStage1GameScene");
    }

    // Stage2 Single
    public void OnClickStage2Button()
    {
        GameModeManager.CurrentGameMode = GameMode.Single;
        StageManager.CurrentStage = 1; // ステージ2を設定
        LoadScene("SelectModeStage2GameScene");
    }

    // Stage3 Single
    public void OnClickStage3Button()
    {
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
