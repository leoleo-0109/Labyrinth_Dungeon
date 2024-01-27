using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject nameInputPanel;
    [SerializeField] private GameObject gamePausePanel;

    void Start()
    {
        nameInputPanel.SetActive(false);
        gamePausePanel.SetActive(false);
    }

    public void Update()
    {
        OnPushKey_Space();
    }

    // RankingScene
    public void OnClickNamePanelButton()
    {
        nameInputPanel.SetActive(true);
    }

    // RankingScene
    public void OnClickNamePanelOKButton()
    {
        nameInputPanel.SetActive(false);
    }

    // StoryGameSceneÅïStage1Å`3GameScene
    public void OnPushKey_Space()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gamePausePanel.SetActive(true);
        }
    }

    // StoryGameSceneÅïStage1Å`3GameScene
    public void OnClickGamePauseButton()
    {
        gamePausePanel.SetActive(true);
    }

    // StoryGameSceneÅïStage1Å`3GameScene
    public void OnClickReturnGameButton()
    {
        gamePausePanel.SetActive(false);
    }
}
