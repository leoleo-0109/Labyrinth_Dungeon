using UnityEngine;
using UnityEngine.UI;
using Save;

public class Ranking : MonoBehaviour
{
    [SerializeField]
    InputText iText;
    //�e�X�g�p�̕ϐ�������score��
    [SerializeField, Header("���l")]
    float point;
    string[] ranking = { "1��", "2��", "3��", "4��", "5��" };
    float[] rankingValue = new float[5];
    //�����ɓ���Ă���������O��in
    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];
    public struct userData {
        float _ranking;
        string _name;
    }

    void Start()
    {
        point = PlayerPrefs.GetFloat("score");
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
        //�����L���O��������
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l�����ւ�
            if (returnValue > rankingValue[i])
            {
                float change = rankingValue[i];
                rankingValue[i] = returnValue;
                returnValue = change;
            }
        }
        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetFloat(ranking[i], rankingValue[i]);
        }
    }
}
