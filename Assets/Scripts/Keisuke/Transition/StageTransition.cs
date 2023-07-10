using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button;

public class StageTransition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject stage;
    private bool eventTriggered = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Player))
        {
            if (NanoObjectController.eventFlag && !eventTriggered)
            {
                Vector3 pos = new Vector3(0,1.6f,0);
                Vector3 stagePosition = stage.transform.position;
                stagePosition.y += pos.y;
                player.transform.position = stagePosition;
                eventTriggered = true;
                NanoObjectController.eventFlag = false;
            }
        }
    }
}
