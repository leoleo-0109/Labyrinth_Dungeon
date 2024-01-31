using UnityEngine;
using UniRx;
using System;
using Save;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour
{
    [SerializeField] private EventObserver eventObserver;
    private Subject<Unit> onWarpEventTrigger = new Subject<Unit>();
    public IObservable<Unit> OnWarpEventTrigger => onWarpEventTrigger;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject stage;
    private bool eventTriggered = false;
    private static int stageNumber = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            if (EventFlagHolder.eventFlag && !eventTriggered)
            {
                // ゲームモードに応じた処理
                HandleGameMode();

                eventTriggered = true;
                EventFlagHolder.eventFlag = false;
            }
        }
    }

    private void HandleGameMode()
    {
        if (GameModeManager.CurrentGameMode == GameMode.Story)
        {
            if (stageNumber == 2) // 最終ステージをクリアした場合
            {
                LoadRankingScene();
            }
            else
            {
                // ストーリーモードの処理（次のステージへ遷移）
                WarpToNextStage();
            }
        }
        else
        {
            // 個別ステージプレイの処理（ステージクリア）
            CompleteSingleStage();
        }
    }

    private void WarpToNextStage()
    {
        // 次のステージへのワープ処理
        Vector3 pos = new Vector3(0, 1.6f, 0);
        Vector3 stagePortalPosition = stage.transform.position;
        stagePortalPosition.y += pos.y;
        player.transform.position = stagePortalPosition;
        stageNumber++;
    }

    private void CompleteSingleStage()
    {
        // 個別ステージのクリア処理
        LoadRankingScene();
    }

    private void LoadRankingScene()
    {
        string rankingSceneName = "RankingScene_" + DeviceModeManager.CurrentDeviceMode.ToString();
        SceneManager.LoadScene(rankingSceneName);
    }
}