using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class ClearManager : MonoBehaviour
    {
        public int clearCounts = 0;
        [SerializeField]
        Canvas canvas;
        private void Awake()
        {
            canvas.gameObject.SetActive(false);
        }
        public void Clear()
        {
            clearCounts++;
            if (clearCounts == 3)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }
}
