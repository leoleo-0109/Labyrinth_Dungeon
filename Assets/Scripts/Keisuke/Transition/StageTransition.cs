using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTransition : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] stages;
    private int stageChangeCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Player))
        {
            Debug.Log("tag");
            if (stageChangeCount < stages.Length)
            {
                        Vector3 stagePosition = stages[stageChangeCount].transform.position;
        Debug.Log("Teleporting to stage " + stageChangeCount + " at position " + stagePosition);
        player.transform.position = stagePosition;
        stageChangeCount++;
            }
        }
    }

}
