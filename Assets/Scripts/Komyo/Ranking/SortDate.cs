using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using RankingData;

public class SortDate : MonoBehaviour
{
    public struct Ranking
    {
        public string fastText;
        public string secondText;
        public string thirdText;
        public string fourthText;
        public string fifthText;
        public int fastScore;
        public int secondScore;
        public int thirdScore;
        public int fourthScore;
        public int fifthScore;
    }
    [SerializeField] private PlayersDate playersDate;
    private string joinData;
    public Ranking ranking = new Ranking();
    public void SortPlayersDate(){
        joinData = playersDate.playersDate1 + "," + playersDate.playersDate2 + "," + playersDate.playersDate3 + "," + playersDate.playersDate4 + "," + playersDate.playersDate5;
        string[] parts = joinData.Split(',');
        Array.Sort(parts, (a, b) => 
        {
            int aValue = int.Parse(new string(a.Where(char.IsDigit).ToArray()));
            int bValue = int.Parse(new string(b.Where(char.IsDigit).ToArray()));

            return aValue.CompareTo(bValue);
        });
        ranking.fastScore = int.Parse(new string(parts[0].Where(char.IsDigit).ToArray()));
        ranking.secondScore = int.Parse(new string(parts[1].Where(char.IsDigit).ToArray()));
        ranking.thirdScore = int.Parse(new string(parts[2].Where(char.IsDigit).ToArray()));
        ranking.fourthScore = int.Parse(new string(parts[3].Where(char.IsDigit).ToArray()));
        ranking.fifthScore = int.Parse(new string(parts[4].Where(char.IsDigit).ToArray()));
        ranking.fastText = (new string(parts[0].Where(char.IsLetter).ToArray()).ToString());
        ranking.secondText = (new string(parts[1].Where(char.IsLetter).ToArray()).ToString());
        ranking.thirdText = (new string(parts[2].Where(char.IsLetter).ToArray()).ToString());
        ranking.fourthText = (new string(parts[3].Where(char.IsLetter).ToArray()).ToString());
        ranking.fifthText =  (new string(parts[4].Where(char.IsLetter).ToArray()).ToString());
    }
    public (string name, int score) ReturnRanking(int number){
        switch (number)
        {
            case 1:
                return (ranking.fastText, ranking.fastScore);
            case 2:
                return (ranking.secondText, ranking.secondScore);
            case 3:
                return (ranking.thirdText, ranking.thirdScore);
            case 4:
                return (ranking.fourthText, ranking.fourthScore);
            case 5:
                return (ranking.fifthText, ranking.fifthScore);
            default:
                return ("error",404);
        }
    }
}
