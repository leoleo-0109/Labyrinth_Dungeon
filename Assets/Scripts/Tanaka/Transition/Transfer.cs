using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transfer : MonoBehaviour
{
    private int itemRemoveCount{ get; set; }
    private int transferCount = 0;
    [SerializeField] private ScoreModel[] scoreModels;
    void Start()
    {
        foreach (ScoreModel scoreModel in scoreModels)
        {
            scoreModel.ScoreAdd += IncrementRemoveCount;
        }
        gameObject.SetActive(false);
    }
    public void IncrementRemoveCount()
    {
        itemRemoveCount++;
        Debug.Log(itemRemoveCount);
        ItemView();
    }
    private void ItemView()
    {
        if(itemRemoveCount == 3)
        {
            gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Player))
        {
            SceneTransition.Stage1();
        }
        // TODO 全ステージ完成後に下記のコメントアウトを削除
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
