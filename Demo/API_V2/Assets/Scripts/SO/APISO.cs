using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "APISO")]
public class APISO : ScriptableObject
{
    public List<CategorySO> categoryList;

    public List<AbilitySO> abilityList;
}