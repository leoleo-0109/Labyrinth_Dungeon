using UnityEngine;
using UniRx;
using System;
using BananaClient;
using Save;
namespace BananaClient
{
    public class StageTransition : MonoBehaviour
    {
        [SerializeField]
        ClearManager clearManager;
        private int warpCounte;
        [SerializeField] private EventObserver eventObserver;
        private Subject<Unit> onWarpEventTrigger = new Subject<Unit>();
        public IObservable<Unit> OnWarpEventTrigger => onWarpEventTrigger;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject stage;
        private bool eventTriggered = false;
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag(TagName.Player))
            {
                // ワープ処理
                if (EventFlagHolder.eventFlag && !eventTriggered)
                {
                    Debug.Log("発火");
                    onWarpEventTrigger.OnNext(Unit.Default);
                    eventObserver.OnTimeItemCountResetTrigger();
                    eventObserver.OnScoreItemCountResetTrigger();
                    Warp();
                    clearManager.Clear();
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
        }
    }
}
