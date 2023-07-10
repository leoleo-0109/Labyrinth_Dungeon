using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Button;

public class StageTransition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] stages;
    private int stageChangeCount = 0;
    void Update(){
        Debug.Log("eventFlag: " + NanoObjectController.eventFlag);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Player))
        {
            if (stageChangeCount < stages.Length && NanoObjectController.eventFlag == true)
            {
                Vector3 stagePosition = stages[stageChangeCount].transform.position;
                player.transform.position = stagePosition;
                stageChangeCount++;
                NanoObjectController.eventFlag = false;
            }
        }
    }

}
