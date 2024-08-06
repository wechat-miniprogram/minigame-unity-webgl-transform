#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(APISO))]
public class APISOEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var apiSO = (APISO)target;

        if (GUILayout.Button("强制刷新")) {
            APIAssetPostprocessor.UpdateAPISO(apiSO);
        }
    }
}
#endif