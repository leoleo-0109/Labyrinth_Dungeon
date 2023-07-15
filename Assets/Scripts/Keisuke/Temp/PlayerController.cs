using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using BananaClient;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    public float moveSpeed = 5f; // プレイヤーの移動速度
    private Rigidbody rb;
    private bool buttonPressed = false;
    private bool buttonPressedRequest = false;
    private CompositeDisposable disposable = new CompositeDisposable();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Move();
        WarpButton();
    }
    public void Move()
    {
        this.UpdateAsObservable()
        .Subscribe(_ =>
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            // 移動方向をカメラの方向に合わせる
            Vector3 cameraForward = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 movement = (moveHorizontal * _camera.transform.right + moveVertical * cameraForward).normalized;

            rb.velocity = movement * moveSpeed;
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                _camera.transform.Rotate(new Vector3(0, -0.5f, 0));
                this.gameObject.transform.Rotate(new Vector3(0, -0.5f, 0));
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                _camera.transform.Rotate(new Vector3(0, 0.5f, 0));
                this.gameObject.transform.Rotate(new Vector3(0, 0.5f, 0));
            }
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
                    EventFlagHolder.eventFlag = true;
                    buttonPressed = true;
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
