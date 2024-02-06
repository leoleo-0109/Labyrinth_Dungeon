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
        public string fast;
        public string second;
        public string third;
        public string fourth;
        public string fifth;
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
        ranking.fast = parts[4];
        ranking.second = parts[3];
        ranking.third = parts[2];
        ranking.fourth = parts[1];
        ranking.fifth = parts[0];
        Debug.Log(ranking.fast + " " + ranking.second + " " + ranking.third + " " + ranking.fourth + " " + ranking.fifth);
    }
    public string ReturnRanking(int number){
        switch (number)
        {
            case 1:
                return ranking.fast;
            case 2:
                return ranking.second;
            case 3:
                return ranking.third;
            case 4:
                return ranking.fourth;
            case 5:
                return ranking.fifth;
            default:
                return "error";
        }
    }
}
