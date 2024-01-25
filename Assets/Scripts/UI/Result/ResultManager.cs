using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResultManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    ResultPresenter resultPresenter;
    public void ShowResult()
    {
        resultPresenter.StartSubscription();
        canvas.gameObject.SetActive(true);
    }
}

