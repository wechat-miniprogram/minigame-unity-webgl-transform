using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NativeAbilitySO")]
public class NativeAbilitySO : ScriptableObject
{
    public string abilityName;
    public Sprite abilitySprite;
    public List<EntrySO> entryList;
    public List<AbilitySO> abilityList;  // 新增 ability 列表
    public int abilityOrder;
}
