using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/FireTrapData")]
public class FireTrapData : ScriptableObject
{
    [field: SerializeField,Header("")] public float rotationSpeed { get; private set; } // 90f
    [field: SerializeField,Header("パーティクルの表示時間")] public float particleDisplayTime { get; private set;} // パーティクルの表示時間
    [field: SerializeField,Header("パーティクルの非表示時間")] public float particleHideTime { get; private set; } // パーティクルの非表示時間
    [field: SerializeField,Header("パーティクルの表示/非表示を切り替える時間")] public float particleToggleTime { get; private set; } // パーティクルの表示/非表示を切り替える時間
    [field: SerializeField,Header("回転を停止する時間")] public float rotationPauseTime { get; private set; } // 回転を停止する時間
}
