using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    //�e�X�g�p�̕ϐ�������score��
    [SerializeField, Header("���l")]
    int point;
    string[] ranking = { "1��", "2��", "3��", "4��", "5��" };
    int[] rankingValue = new int[5];
    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];

    void Start()
    {
        //���̕ӂ̏�����Start���烉���L���O�\�����ɕύX
        GetRanking();
        SetRanking(point);
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    void SetRanking(int returnValue)
    {
        //�����L���O��������
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l�����ւ�
            if (returnValue > rankingValue[i])
            {
                int change = rankingValue[i];
                rankingValue[i] = returnValue;
                returnValue = change;
            }
        }
        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
