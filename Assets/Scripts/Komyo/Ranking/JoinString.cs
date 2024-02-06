using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinString : MonoBehaviour
{
    public string Join(string name , float score){
        string joinData = name + score.ToString();
        return joinData;
    }
}
