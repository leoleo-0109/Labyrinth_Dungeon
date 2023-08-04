using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class ClearManager : MonoBehaviour
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
