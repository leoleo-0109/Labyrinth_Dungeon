using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;

namespace BananaClient
{
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
}
