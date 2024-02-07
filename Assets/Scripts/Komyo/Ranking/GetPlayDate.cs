using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RankingData;
using UnityEngine.UI;
using TMPro;

public class GetPlayDate : MonoBehaviour
{
    //プレイ時のスコアを取得する
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayersDate playersDate;
    [SerializeField] private JoinString joinString;
    [SerializeField] private SortDate sortDate;
    //仮のスコア
    internal int hoge = 110;
    public void InputText()
    {
        string name = inputField.text;
        int score = ScoreManager.Instance.Score;
        string joinData = joinString.Join(name, score);
        playersDate.playersDate5 = joinData;
        sortDate.SortPlayersDate();
        inputField.gameObject.SetActive(false);
    }

}
