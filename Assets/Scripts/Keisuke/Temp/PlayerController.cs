using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float dfjklsfkljsfkljs;
    public static bool eventFlag = false;
    private bool buttonPressed = false;
    private bool buttonPressedRequest = false;
    void Update()
    {
        Move();
        ButtonSSSSSS();
    }
    public void Move()
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
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(TagName.Stage1Warp)
        ||other.gameObject.CompareTag(TagName.Stage2Warp)
        ||other.gameObject.CompareTag(TagName.Stage3Warp))
        {
            buttonPressedRequest = true;
        }
    }

    public void ButtonSSSSSS(){
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
                    else if(Input.GetKey(KeyCode.K) && buttonPressed)
                    {
                        Debug.Log("現在ボタン入力を受け付けません");
                        buttonPressed = false;
                        buttonPressedRequest = false;
                    }
                }

    }
}
