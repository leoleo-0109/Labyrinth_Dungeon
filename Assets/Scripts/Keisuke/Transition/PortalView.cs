using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalView : MonoBehaviour
{
    private int itemRemoveCount{ get; set; }
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
        View();
    }
    private void View()
    {
        if(itemRemoveCount == 3)
        {
            gameObject.SetActive(true);
        }
    }
}
