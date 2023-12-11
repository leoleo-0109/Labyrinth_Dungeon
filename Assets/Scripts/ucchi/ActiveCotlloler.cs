using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCotlloler : MonoBehaviour
{
    [SerializeField] private Canvas result;
    [SerializeField] private Canvas reTitle;
    [SerializeField] private Canvas gameUI;

    public void ResultActive()
    {
        result.gameObject.SetActive(false);
    }

    public void ReTitleActive()
    {
        reTitle.gameObject.SetActive(true);
    }

    public void GameUIActive()
    {
        gameUI.gameObject.SetActive(false);
    }
}
