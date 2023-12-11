using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMainScript : MonoBehaviour
{
    [SerializeField] private GameObject titleCharacter;
    [Header("移動速度"), SerializeField] private float speed = default;
    private bool isMoveflag = true;

    private void start()
    {
        titleCharacter.SetActive(false);
    }

    private void Update()
    {
        if (isMoveflag)
        {
            Transform move = this.transform;
            Vector3 moveSpeed = move.position;
            moveSpeed.x += speed;
            move.position = moveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stop")
        {
            isMoveflag = false;
            Animator anim = this.GetComponent<Animator>();
            // アニメーション停止
            anim.enabled = false;
            this.gameObject.SetActive(false);
            // キャラクター差し替え
            titleCharacter.gameObject.SetActive(true);
        }
    }
}
