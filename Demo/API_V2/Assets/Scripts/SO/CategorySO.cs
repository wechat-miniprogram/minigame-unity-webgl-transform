using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CategorySO")]
public class CategorySO : ScriptableObject
{
    public string categoryName;

    public Sprite categorySprite;

    public List<EntrySO> entryList;
}
