using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BananaClient;

namespace BananaClient
{
    public class ResultModel : MonoBehaviour
    {
        [SerializeField]
        Canvas canvas;
        private void Awake()
        {
            canvas.enabled = false;
        }
        public void ShowResult()
        {
            canvas.enabled = true;
        }
    }
}
