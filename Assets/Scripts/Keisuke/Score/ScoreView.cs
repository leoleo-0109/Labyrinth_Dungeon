using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void ScoreDisplay(float count)
    {
        scoreText.text = "ScoreCount: " + count.ToString();
    }
}
