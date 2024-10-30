#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CategorySO))]
public class CategorySOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var categorySO = (CategorySO)target;

        if (GUILayout.Button("强制刷新"))
        {
            APIAssetPostprocessor.UpdateCategorySO(categorySO);
        }
    }
}
#endif
