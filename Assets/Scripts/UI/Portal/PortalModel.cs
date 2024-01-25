using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*このスクリプトは鍵のオブジェクトにアタッチしてください。*/
public class PortalModel : MonoBehaviour
{
    public event Action CountAdd = delegate { };
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagName.Player))
        {
            CountAdd.Invoke();
            gameObject.SetActive(false);
        }
    }
}

