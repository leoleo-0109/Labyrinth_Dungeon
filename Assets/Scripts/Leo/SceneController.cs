using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private BGMController bgmController;
    // KeyBoard—p

    // TitleScene
    public void OnClickReturnTitleButton_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeTitleBGM();
        SceneManager.LoadScene("TitleScene_KeyBoard");
    }

    // ModeSelectScene
    public void OnClickReturnModeSelectButton_KeyBoard()
    {
        SceneManager.LoadScene("ModeSelectScene_KeyBoard");
    }

    // StoryMode
    public void OnClickStoryModeGameButton_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Story;
        SceneManager.LoadScene("StoryModeGameScene_KeyBoard");
    }

    // StageSelectScene
    public void OnClickStageSelectButton_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        SceneManager.LoadScene("StageSelectScene_KeyBoard");
    }

    // Stage1 Single
    public void OnClickStage1Button_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage1GameScene_KeyBoard");
    }

    // Stage2 Single
    public void OnClickStage2Button_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage2GameScene_KeyBoard");
    }

    // Stage3 Single
    public void OnClickStage3Button_KeyBoard()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage3GameScene_KeyBoard");
    }

    // RankingScene
    public void OnClickRankingButton_KeyBoard()
    {
        SceneManager.LoadScene("RankingScene_KeyBoard");
    }

    ///////////////////////////////////////////////////////////

    // Nano—p
    // TitleScene
    public void OnClickReturnTitleButton_Nano()
    {
        bgmController.StopBGM();
        bgmController.ChangeTitleBGM();
        SceneManager.LoadScene("TitleScene_Nano");
    }

    // ModeSelectScene
    public void OnClickReturnModeSelectButton_Nano()
    {
        SceneManager.LoadScene("ModeSelectScene_Nano");
    }

    // StoryMode
    public void OnClickStoryModeGameButton_Nano()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Story;
        SceneManager.LoadScene("StoryModeGameScene_Nano");
    }

    // StageSelectScene
    public void OnClickStageSelectButton_Nano()
    {
        SceneManager.LoadScene("StageSelectScene_Nano");
    }

    // Stage1 Single
    public void OnClickStage1Button_Nano()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage1GameScene_Nano");
    }

    // Stage2 Single
    public void OnClickStage2Button_Nano()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage2GameScene_Nano");
    }

    // Stage3 Single
    public void OnClickStage3Button_Nano()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage3GameScene_Nano");
    }

    // RankingScene
    public void OnClickRankingButton_Nano()
    {
        SceneManager.LoadScene("RankingScene_Nano");
    }

    ///////////////////////////////////////////////////////////

    // ESP32—p
    // TitleScene
    public void OnClickReturnTitleButton_ESP32()
    {
        bgmController.StopBGM();
        bgmController.ChangeTitleBGM();
        SceneManager.LoadScene("TitleScene_ESP32");
    }

    // ModeSelectScene
    public void OnClickReturnModeSelectButton_ESP32()
    {
        SceneManager.LoadScene("ModeSelectScene_ESP32");
    }

    // StoryMode
    public void OnClickStoryModeGameButton_ESP32()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Story;
        SceneManager.LoadScene("StoryModeGameScene_ESP32");
    }

    // StageSelectScene
    public void OnClickStageSelectButton_ESP32()
    {
        SceneManager.LoadScene("StageSelectScene_ESP32");
    }

    // Stage1 Single
    public void OnClickStage1Button_ESP32()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage1GameScene_ESP32");
    }

    // Stage2 Single
    public void OnClickStage2Button_ESP32()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage2GameScene_ESP32");
    }

    // Stage3 Single
    public void OnClickStage3Button_ESP32()
    {
        bgmController.StopBGM();
        bgmController.ChangeGameBGM();
        GameModeManager.CurrentGameMode = GameMode.Single;
        SceneManager.LoadScene("SelectModeStage3GameScene_ESP32");
    }

    // RankingScene
    public void OnClickRankingButton_ESP32()
    {
        SceneManager.LoadScene("RankingScene_ESP32");
    }
}
