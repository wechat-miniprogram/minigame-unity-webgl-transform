using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "CategorySO")]
public class CategorySO : ScriptableObject
{
    public bool isNative;

    public string categoryName;

    public Sprite categorySprite;

    public List<EntrySO> entryList;

    [Tooltip("从小到大排序")]
    public int categoryOrder;
}
