using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour
{
    public float dfjklsfkljsfkljs;
    public static bool eventFlag = false;
    private bool buttonPressed = false;
    private bool buttonPressedRequest = false;
    private CompositeDisposable disposable = new CompositeDisposable();
    void Start()
    {
        Move();
        WarpButton();
    }
    public void Move()
    {
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            Vector3 pos = transform.position;
            if(Input.GetKey(KeyCode.W))
            {
                pos.z += dfjklsfkljsfkljs * Time.deltaTime;
            }
                    if(Input.GetKey(KeyCode.A))
            {
                pos.x -= dfjklsfkljsfkljs * Time.deltaTime;
            }
                    if(Input.GetKey(KeyCode.S))
            {
                pos.z -= dfjklsfkljsfkljs * Time.deltaTime;
            }
                    if(Input.GetKey(KeyCode.D))
            {
                pos.x += dfjklsfkljsfkljs * Time.deltaTime;
            }
            transform.position = pos;
        }).AddTo(disposable);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Portal1)
        ||other.gameObject.CompareTag(TagName.Portal2)
        ||other.gameObject.CompareTag(TagName.Portal3))
        {
            buttonPressedRequest = true;
        }
    }

    public void WarpButton()
    {
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            if(buttonPressedRequest)
            {
                Debug.Log("ボタン入力準備完了");
                if(Input.GetKey(KeyCode.K) && !buttonPressed)
                {
                    Debug.Log("2F");
                    eventFlag = true;
                    buttonPressed = true;
                    Debug.Log(eventFlag);
                }
                else if(!Input.GetKey(KeyCode.K) && buttonPressed)
                {
                    Debug.Log("現在ボタン入力を受け付けません");
                    buttonPressed = false;
                    buttonPressedRequest = false;
                }
            }
        }).AddTo(disposable);
    }
}
