using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BananaClient
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI scoreItemCountText;
        public void ScoreDisplay(float count)
        {
            scoreText.text = count.ToString("F1");
        }
        public void DisplayScoreItemCount(int count,int maxCount)
        {
            scoreItemCountText.text = count.ToString()+"/"+maxCount;
        }
    }
}

