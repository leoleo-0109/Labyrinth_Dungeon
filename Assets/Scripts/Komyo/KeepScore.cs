using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;

namespace Save
{
    public class KeepScore : MonoBehaviour
    {
        [SerializeField]
        TimerPresenter timerPresenter;
        [SerializeField]
        ScorePresenter scorePresenter;
        public float confirmScore = 0;
        private float confirmTime = 0;
        //key�ɃX�R�A���v��ǉ�����B
        public void KeepKey()
        {
            //timerPresenter�̏����_��؂�̂�
            confirmTime = timerPresenter.keepNowTime;
            Mathf.Floor(confirmTime);
            //-��������0��
            if (confirmTime <= 0)
            {
                confirmTime = 0;
            }
            confirmTime *= 100;
            //�X�R�A�Ɖ��Z����key�ɕۑ�
            confirmScore = scorePresenter.score += confirmTime;
            PlayerPrefs.SetFloat("score", scorePresenter.score);
        }
        //�e�X�g�p
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeepKey();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log(confirmScore);
            }
        }
    }
}