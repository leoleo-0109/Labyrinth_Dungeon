using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button;

public class StageTransition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] stages;
    private int stageChangeCount = 0;
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Player))
        {
            if (stageChangeCount < stages.Length && NanoObjectController.eventFlag == true)
            {
                Vector3 pos = new Vector3(0,1,0);
                Vector3 stagePosition = stages[stageChangeCount].transform.position;
                stagePosition.y += pos.y;
                player.transform.position = stagePosition;
                stageChangeCount++;
                NanoObjectController.eventFlag = false;
            }
        }
    }

}
