using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCotlloler : MonoBehaviour
{
    [SerializeField] public Canvas result;
    [SerializeField] public Canvas retitle;
    [SerializeField] public Canvas gameUI;
    public void ResultActive(){
        result.gameObject.SetActive(false);
    }
    public void ReTitleActive(){
        retitle.gameObject.SetActive(true);
    }
    public void GameUIActive(){
        gameUI.gameObject.SetActive(false);
    }
}
