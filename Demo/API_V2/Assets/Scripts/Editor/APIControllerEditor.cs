#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(APIController))]
public class APIControllerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var apiController = (APIController)target;

        if (GUILayout.Button("生成API")) {
            apiController.Init();
        }
    }
}
#endif