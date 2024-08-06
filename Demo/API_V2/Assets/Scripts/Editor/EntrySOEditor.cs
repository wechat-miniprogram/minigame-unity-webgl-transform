#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntrySO))]
public class EntrySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var entrySO = (EntrySO)target;

        if (GUILayout.Button("强制刷新"))
        {
            APIAssetPostprocessor.UpdateEntrySO(entrySO);
        }
    }
}
#endif