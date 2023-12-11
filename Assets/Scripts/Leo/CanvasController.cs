using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject nameInputPanel;

    void Start()
    {
        nameInputPanel.SetActive(false);
    }

    // RankingScene
    public void OnClickNamePanelButton()
    {
        nameInputPanel.SetActive(true);
    }

    public void OnClickNamePanelOKButton()
    {
        nameInputPanel.SetActive(false);
    }
}
