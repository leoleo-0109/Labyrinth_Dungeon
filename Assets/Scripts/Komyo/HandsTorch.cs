using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsTorch : MonoBehaviour
{
    Vector3 pastV3 = Vector3.zero;
    private Animator animator;
    public bool blfalse = false;
    [SerializeField, Header("player")]
    public GameObject player;
    private void Start() { 
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (!(pastV3.x == player.transform.position.x && pastV3.y == player.transform.position.y)) {
            blfalse = false;
            animator.SetBool("bltrans", true);
        }
        else if(pastV3.x == player.transform.position.x && pastV3.y == player.transform.position.y) {
            blfalse = true;
        }
        if (blfalse)
        {
            animator.SetBool("bltrans", false);
            blfalse = false;
        }
        pastV3 = player.transform.position;
    }
}
