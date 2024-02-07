using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RankingData;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class GetPlayDate : MonoBehaviour
{
    //プレイ時のスコアを取得する
    [SerializeField] private InputField inputField;
    [SerializeField] private PlayersDate playersDate;
    [SerializeField] private JoinString joinString;
    [SerializeField] private SortDate sortDate;
    //仮のスコア
    internal int hoge = 110;
    public void InputText()
    {
        string name = inputField.text;
        name = Regex.Replace(name, @"\d", "");
        int score = GameData.Score;
        string joinData = joinString.Join(name, score);
        playersDate.playersDate5 = joinData;
        sortDate.SortPlayersDate();
        inputField.gameObject.SetActive(false);
    }

}
