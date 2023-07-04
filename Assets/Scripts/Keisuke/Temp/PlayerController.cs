using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;
        if(Input.GetKey(KeyCode.W))
        {
            pos.z += 0.05f;
        }
                if(Input.GetKey(KeyCode.A))
        {
            pos.x -= 0.05f;
        }
                if(Input.GetKey(KeyCode.S))
        {
            pos.z -= 0.05f;
        }
                if(Input.GetKey(KeyCode.D))
        {
            pos.x += 0.05f;
        }
        transform.position = pos;
    }
}
