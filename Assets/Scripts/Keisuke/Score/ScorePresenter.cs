using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreModel[] scoreModelsType1;
    [SerializeField] private ScoreModel[] scoreModelsType2;
    [SerializeField] private ScoreModel[] scoreModelsType3;
    private int scoreCountType1 = 0;
    private int scoreCountType2 = 0;
    private int scoreCountType3 = 0;

    //[SerializeField] private ScoreModel[] scoreModels;
    [SerializeField] private ScoreView scoreView;
    private float score = 0;
    async void Start()
    {
        // foreach (ScoreModel scoreModel in scoreModels)
        // {
        //     scoreModel.ScoreAdd += AddScore;
        // }
        // TODO:scoreCountTypeをステージが変わったらすべて値をリセットしてあげる必要がある。
        foreach (ScoreModel scoreModelType1 in scoreModelsType1)
        {
            await scoreModelType1.ScoreAdd += AddScore;
            Debug.Log("Type1");
            scoreCountType1++;
        }
        foreach (ScoreModel scoreModelType2 in scoreModelsType2)
        {
            await scoreModelType2.ScoreAdd += AddScore;
            Debug.Log("Type2");
            scoreCountType2++;
        }
        foreach (ScoreModel scoreModelType3 in scoreModelsType3)
        {
            await scoreModelType3.ScoreAdd += AddScore;
            Debug.Log("Type3");
            scoreCountType3++;
        }
        UpdateScore();
    }
    private void AddScore()
    {
        // TODO:これどうにかする。
        if(scoreCountType1==2){
            score *= 1.2f;
        }
        if(scoreCountType1==3){
            score *= 1.5f;
        }
        if(scoreCountType2==2){
            score *= 1.2f;
        }
        if(scoreCountType3==3){
            score *= 1.5f;
        }
        if(scoreCountType2==2){
            score *= 1.2f;
        }
        if(scoreCountType3==3){
            score *= 1.5f;
        }
        score++;
        Debug.Log(score);
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreView.ScoreDisplay(score);
    }
}
