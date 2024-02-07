using System;
using System.Collections;
using UnityEngine;

namespace RankingData
{   
    public class SetPlayersDate : MonoBehaviour
    {
        [SerializeField] private JoinString joinString;
        [SerializeField] private PlayersDate playersDate;
        public string rank;
        public string name;
        public float score;


        public void AddPlayerDate(string _name, float _score,int No){
            switch(No){
                case 0:
                    playersDate.playersDate1 = joinString.Join(_name,_score);
                    break;
                case 1:
                    playersDate.playersDate2 = joinString.Join(_name,_score);
                    break;
                case 2: 
                    playersDate.playersDate3 = joinString.Join(_name,_score);
                    break;
                case 3: 
                    playersDate.playersDate4 = joinString.Join(_name,_score);
                    break;
                case 4: 
                    joinString.Join(_name,_score);
                    break;
                default:
                    break;
            }
        }
    }
}