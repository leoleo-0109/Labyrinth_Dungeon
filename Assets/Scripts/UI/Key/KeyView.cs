using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyCountText;
    public void KeyCountDisplay(int count)
    {
        keyCountText.text = count.ToString()+"/3";
    }
}
