using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RankingTextManager : MonoBehaviour
{
    [SerializeField] private SaveToCSV saveToCSV;
    [SerializeField] private SortDate sortDate;
    [SerializeField] private TextMeshProUGUI first;
    [SerializeField] private TextMeshProUGUI second;
    [SerializeField] private TextMeshProUGUI third;
    [SerializeField] private TextMeshProUGUI fourth;
    [SerializeField] private TextMeshProUGUI fifth;
    public void SetText()
    {
        first.text = sortDate.ReturnRanking(1);
        second.text = sortDate.ReturnRanking(2);
        third.text = sortDate.ReturnRanking(3);
        fourth.text = sortDate.ReturnRanking(4);
        fifth.text = sortDate.ReturnRanking(5);
        saveToCSV.PunctuateDate(first.text, second.text, third.text, fourth.text, fifth.text);
    }
}
