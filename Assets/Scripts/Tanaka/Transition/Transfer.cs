using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    private int transferCount = 0;
    void OnTriggerEnter(Collider other)
    {
        // TODO ステージ完成後に下記のコメントアウトを削除
        // if(other.gameObject.CompareTag(TagName.Player) && transferCount == 0)
        // {
        //     SceneTransition.Stage1();
        //     transferCount++;
        // }
        // if(other.gameObject.CompareTag(TagName.Player) && transferCount == 1)
        // {
        //     SceneTransition.Stage2();
        //     transferCount++;
        // }
        // if(other.gameObject.CompareTag(TagName.Player) && transferCount == 2)
        // {
        //     SceneTransition.Stage3();
        //     transferCount++;
        // }

    }
}
