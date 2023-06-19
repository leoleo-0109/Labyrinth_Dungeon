using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField] private ScoreModel[] scoreModels;
    [SerializeField] private ScoreView scoreView;
    private int score = 0;
    void Start()
    {
        foreach (ScoreModel scoreModel in scoreModels)
        {
            scoreModel.ScoreAdd += AddScore;
        }

        UpdateScore();
    }
    private void AddScore()
    {
        score++;
        UpdateScore();
    }
    // private void Presentation()
    // {
    //     scoreView.ScoreDisplay(scoreModel.count);
    // }
    private void UpdateScore()
    {
        scoreView.ScoreDisplay(score);
    }
}