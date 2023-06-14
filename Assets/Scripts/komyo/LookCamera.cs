using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class LockCamera : CinemachineExtension 
{
    public bool x_islocked,y_islocked,z_islocked;
    public Vector3 lockPosition;
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var newRot = state.RawPosition;
            if (x_islocked) newRot.x = lockPosition.x;
            if (y_islocked) newRot.y = lockPosition.y;
            if (z_islocked) newRot.z = lockPosition.z;
            state.RawPosition = newRot;
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(LockCamera))]
public class LockAxisCameraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var lockAxisCamera = target as LockCamera;
        using (new EditorGUILayout.HorizontalScope())
        {
            EditorGUIUtility.labelWidth = 10;
            EditorGUILayout.LabelField("固定する軸");
            lockAxisCamera.x_islocked = EditorGUILayout.Toggle("X", lockAxisCamera.x_islocked);
            lockAxisCamera.y_islocked = EditorGUILayout.Toggle("Y", lockAxisCamera.y_islocked);
            lockAxisCamera.z_islocked = EditorGUILayout.Toggle("Z", lockAxisCamera.z_islocked);
        }
        EditorGUILayout.LabelField("固定する座標");
        using (new EditorGUILayout.HorizontalScope())
        {
            EditorGUIUtility.labelWidth = 10;
            lockAxisCamera.lockPosition.x = EditorGUILayout.FloatField("X", lockAxisCamera.lockPosition.x);
            lockAxisCamera.lockPosition.y = EditorGUILayout.FloatField("Y", lockAxisCamera.lockPosition.y);
            lockAxisCamera.lockPosition.z = EditorGUILayout.FloatField("Z", lockAxisCamera.lockPosition.z);
        }
    }
}
#endif