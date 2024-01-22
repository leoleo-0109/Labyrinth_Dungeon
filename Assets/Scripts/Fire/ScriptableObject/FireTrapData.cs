using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/FireGimmickData")]
public class FireTrapData : ScriptableObject 
{
    [field: SerializeField,Header("")] public float rotationSpeed { get; private set; }
    [field: SerializeField,Header("")] public float rotationDirection { get; private set; }
    [field: SerializeField,Header("")] public float stopAngle { get; private set; }
}
