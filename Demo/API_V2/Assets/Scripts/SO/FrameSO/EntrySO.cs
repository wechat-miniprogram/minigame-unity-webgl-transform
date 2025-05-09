using UnityEngine;

public abstract class EntrySO : ScriptableObject
{
    public string entryName;

    [Tooltip("从小到大排序")]
    public int entryOrder;
}
