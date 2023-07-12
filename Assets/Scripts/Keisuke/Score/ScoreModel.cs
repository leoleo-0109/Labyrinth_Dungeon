using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public event Action ScoreAdd = delegate { };
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            ScoreAdd.Invoke();
            gameObject.SetActive(false);
        }
    }
}
