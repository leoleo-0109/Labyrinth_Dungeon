using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public int count { get; private set; }
    public event Action ScoreAdd = delegate { };

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            count++;
            ScoreAdd.Invoke();
        }
    }
}
