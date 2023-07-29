using UnityEngine;
using UnityEngine.UI;
using Save;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    InputText iText;
    //テスト用の変数ここをscoreに
    [SerializeField, Header("数値")]
    float point;
    string[] ranking = { "1位", "2位", "3位", "4位", "5位" };
    float[] rankingValue = new float[5];
    //ここに入れてもらった名前をin
    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];
    public struct userData {
        float _ranking;
        string _name;
    }

    void Start()
    {
        point = PlayerPrefs.GetFloat("score");
        //この辺の処理をStartからランキング表示時に変更
        GetRanking();
        SetRanking(point);
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }
    void GetRanking()
    {
        //ランキング呼び出し
        /*for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }*/
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    void SetRanking(float returnValue)
    {
        //ランキング書き込み
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を入れ替え
            if (returnValue > rankingValue[i])
            {
                float change = rankingValue[i];
                rankingValue[i] = returnValue;
                returnValue = change;
            }
        }
        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetFloat(ranking[i], rankingValue[i]);
        }
    }
}
