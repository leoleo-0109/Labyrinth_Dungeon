using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BananaClient
{
    public class KeyModel : MonoBehaviour
    {
        public event Action KeyCountAdd = delegate { };
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Player))
            {
                KeyCountAdd.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
