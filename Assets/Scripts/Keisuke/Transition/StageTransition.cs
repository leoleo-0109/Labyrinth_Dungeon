using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button;
using BananaClient;
using UniRx;
using System;

namespace BananaClient
{
    public class StageTransition : MonoBehaviour
    {
        private Subject<Unit> onWarpEventTrigger = new Subject<Unit>();
        public IObservable<Unit> OnWarpEventTrigger => onWarpEventTrigger;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject stage;
        private bool eventTriggered = false;
        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag(TagName.Player))
            {
                if (EventFlagHolder.eventFlag && !eventTriggered)
                {
                    onWarpEventTrigger.OnNext(Unit.Default);
                    Vector3 pos = new Vector3(0,1.6f,0);
                    Vector3 stagePosition = stage.transform.position;
                    stagePosition.y += pos.y;
                    player.transform.position = stagePosition;
                    eventTriggered = true;
                    EventFlagHolder.eventFlag = false;
                    Debug.Log(eventTriggered);
                }
            }
        }
    }
}
