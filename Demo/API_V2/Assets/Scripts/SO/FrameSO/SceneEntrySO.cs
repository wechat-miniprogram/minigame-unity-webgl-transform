using UnityEngine;

[CreateAssetMenu(menuName = "SceneEntrySO")]
public class SceneEntrySO: EntrySO
{
    // 运行时强制设置为name + "Scene"
    public string AbilitySceneName => name.Replace("SO", "Scene");
}
