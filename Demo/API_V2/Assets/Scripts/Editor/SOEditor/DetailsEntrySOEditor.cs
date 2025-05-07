#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DetailsEntrySO))]
public class DetailsEntrySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var entrySO = (DetailsEntrySO)target;

        if (GUILayout.Button("强制刷新"))
        {
            APIAssetPostprocessor.UpdateDetailsEntrySO(entrySO);
        }
    }
}
#endif
