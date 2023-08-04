using UnityEngine;
using UniRx;
using System;
using BananaClient;
using Save;
namespace BananaClient
{
    public class StageTransition : MonoBehaviour
    {
        [SerializeField] private TimerPresenter timerPresenter;
        [SerializeField] private ResultManager resultManager;
        [SerializeField] private EventObserver eventObserver;
        private Subject<Unit> onWarpEventTrigger = new Subject<Unit>();
        public IObservable<Unit> OnWarpEventTrigger => onWarpEventTrigger;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject stage;
        private bool eventTriggered = false;
        private static int stageNumber = 0; // stageNumberは全てのStageTransitionインスタンス間で共有される
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag(TagName.Player))
            {
                // ステージ3のワープポイントに接触しているときにリザルトのキャンバスを表示する
                if (stageNumber == 2)
                {
                    timerPresenter.OnKeepTime();
                    resultManager.ShowResult();
                    return; // ワープ処理をスキップするためにここでメソッドを終了
                }
                // ワープ処理
                if (EventFlagHolder.eventFlag && !eventTriggered)
                {
                    onWarpEventTrigger.OnNext(Unit.Default);
                    eventObserver.OnTimeItemCountResetTrigger(); // ワープ発生時にタイムアイテムのカウントをリセットするイベントを発行
                    eventObserver.OnScoreItemCountResetTrigger(); // ワープ発生時にタイムアイテムのカウントをリセットするイベントを発行
                    Warp();
                    eventTriggered = true;
                    EventFlagHolder.eventFlag = false;
                }
            }
        }
        public void Warp()
        {
            Vector3 pos = new Vector3(0,1.6f,0);
            Vector3 stagePortalPosition = stage.transform.position;
            stagePortalPosition.y += pos.y;
            player.transform.position = stagePortalPosition;
            stageNumber++;
        }
    }
}
