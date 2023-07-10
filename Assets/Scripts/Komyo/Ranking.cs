using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    //テスト用の変数ここをscoreに
    [SerializeField, Header("数値")]
    int point;
    string[] ranking = { "1位", "2位", "3位", "4位", "5位" };
    int[] rankingValue = new int[5];
    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];

    void Start()
    {
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
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    void SetRanking(int returnValue)
    {
        //ランキング書き込み
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を入れ替え
            if (returnValue > rankingValue[i])
            {
                int change = rankingValue[i];
                rankingValue[i] = returnValue;
                returnValue = change;
            }
        }
        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
