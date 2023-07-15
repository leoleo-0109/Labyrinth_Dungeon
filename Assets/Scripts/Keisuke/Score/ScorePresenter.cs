using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using BananaClient;

namespace BananaClient
{
    public class ScorePresenter : MonoBehaviour
    {
        [SerializeField,Header("Type1アイテムを設定")] private ScoreModel[] scoreModelsType1;
        [SerializeField,Header("Type2アイテムを設定")] private ScoreModel[] scoreModelsType2;
        [SerializeField,Header("Type3アイテムを設定")] private ScoreModel[] scoreModelsType3;
        private int scoreCountType1 = 0;
        private int scoreCountType2 = 0;
        private int scoreCountType3 = 0;
        [SerializeField] private ScoreView scoreView;
        private float score = 0;
        void Start()
        {
            AddScoreEventTrigger();
            UpdateScore();
        }

        private void AddScoreEventTrigger()
        {
            foreach (ScoreModel scoreModelType1 in scoreModelsType1)
            {
                scoreModelType1.OnEventTrigger.Subscribe(_ => {
                    AddScore(1);
                }).AddTo(this);
            }
            foreach (ScoreModel scoreModelType2 in scoreModelsType2)
            {
                scoreModelType2.OnEventTrigger.Subscribe(_ => {
                    AddScore(2);
                }).AddTo(this);
            }
            foreach (ScoreModel scoreModelType3 in scoreModelsType3)
            {
                scoreModelType3.OnEventTrigger.Subscribe(_ => {
                    AddScore(3);
                }).AddTo(this);
            }
        }
        private void AddScore(int scoreType)
        {
            float addedScore = 1f; // スコア加算量を固定
            switch(scoreType){
                case 1:
                    scoreCountType1++;
                    if(scoreCountType1==2){
                        addedScore *= 1.2f;
                    }
                    else if(scoreCountType1==3){
                        score *= 1.5f; // ここで総スコアに1.5倍を適用
                        addedScore = 0; // このアイテムによる追加スコアは0にする
                        scoreCountType1 = 0; //リセット
                    }
                    break;
                case 2:
                    scoreCountType2++;
                    if(scoreCountType2==2){
                        addedScore *= 1.2f;
                    }
                    else if(scoreCountType2==3){
                        score *= 1.5f; // ここで総スコアに1.5倍を適用
                        addedScore = 0; // このアイテムによる追加スコアは0にする
                        scoreCountType2 = 0; //リセット
                    }
                    break;
                case 3:
                    scoreCountType3++;
                    if(scoreCountType3==2){
                        addedScore *= 1.2f;
                    }
                    else if(scoreCountType3==3){
                        score *= 1.5f; // ここで総スコアに1.5倍を適用
                        addedScore = 0; // このアイテムによる追加スコアは0にする
                        scoreCountType3 = 0; //リセット
                    }
                    break;
                default:
                    break;
            }
            score += addedScore; // ここで倍率計算する
            Debug.Log(score);
            UpdateScore();
        }
        private void UpdateScore()
        {
            scoreView.ScoreDisplay(score);
        }
    }
}
