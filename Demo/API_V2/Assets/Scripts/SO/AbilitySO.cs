using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public string abilityName;

    public Sprite abilitySprite;

    // 运行时强制设置为name + "Scene"
    public string AbilitySceneName => name.Replace("SO", "Scene");

    [Tooltip("从小到大排序")]
    public int abilityOrder;
}
