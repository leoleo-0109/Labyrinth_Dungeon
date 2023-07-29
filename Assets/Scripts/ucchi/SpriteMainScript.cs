using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMainScript : MonoBehaviour
{
    [SerializeField] public float speed=0.01f;
    [SerializeField] public Canvas title;
    bool Moveswitch=true;
    private void start(){

    }
    private void Update()
    {
        if(Moveswitch==true){
        Transform move=this.transform;

        Vector3 MoveSpeed = move.position;
        MoveSpeed.x += speed;

        move.position=MoveSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stop")
        {
            Moveswitch=false;
            this.gameObject.SetActive(false);
            title.gameObject.SetActive(true);
        }
    }

}
