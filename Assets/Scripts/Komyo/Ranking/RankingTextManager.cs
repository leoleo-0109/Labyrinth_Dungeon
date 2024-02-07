using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RankingTextManager : MonoBehaviour
{
    [SerializeField] private SaveToCSV saveToCSV;
    [SerializeField] private SortDate sortDate;
    [SerializeField] private TextMeshProUGUI firstName;
    [SerializeField] private TextMeshProUGUI secondName;
    [SerializeField] private TextMeshProUGUI thirdName;
    [SerializeField] private TextMeshProUGUI fourthName;
    [SerializeField] private TextMeshProUGUI fifthName;
    [SerializeField] private TextMeshProUGUI firstScore;
    [SerializeField] private TextMeshProUGUI secondScore;
    [SerializeField] private TextMeshProUGUI thirdScore;
    [SerializeField] private TextMeshProUGUI fourthScore;
    [SerializeField] private TextMeshProUGUI fifthScore;
    public string first;
    public string second;
    public string third;
    public string fourth;
    public string fifth;
    
    public void SetText()
    {
        fifthName.text = sortDate.ReturnRanking(1).name;
        fifthScore.text = sortDate.ReturnRanking(1).score.ToString();
        fourthName.text = sortDate.ReturnRanking(2).name;
        fourthScore.text = sortDate.ReturnRanking(2).score.ToString();
        thirdName.text = sortDate.ReturnRanking(3).name;
        thirdScore.text = sortDate.ReturnRanking(3).score.ToString();
        secondName.text = sortDate.ReturnRanking(4).name;
        secondScore.text = sortDate.ReturnRanking(4).score.ToString();
        firstName.text = sortDate.ReturnRanking(5).name;
        firstScore.text = sortDate.ReturnRanking(5).score.ToString();
        /*first.text = sortDate.ReturnRanking(1);
        second.text = sortDate.ReturnRanking(2);
        third.text = sortDate.ReturnRanking(3);
        fourth.text = sortDate.ReturnRanking(4);
        fifth.text = sortDate.ReturnRanking(5);
        saveToCSV.PunctuateDate(first.text, second.text, third.text, fourth.text, fifth.text);*/
        saveToCSV.PunctuateDate(fifthName.text + "," + fifthScore.text, fourthName.text + "," + fourthScore.text, thirdName.text + "," + thirdScore.text, secondName.text + "," + secondScore.text, firstName.text + "," + firstScore.text);
    }
}
