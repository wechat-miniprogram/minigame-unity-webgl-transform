using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EntrySO")]
public class EntrySO : ScriptableObject
{
    public string entryScriptTypeName;
    
    private Type _entryScriptType;
    
    public Type EntryScriptType
    {
        get
        {
            if (_entryScriptType == null && !string.IsNullOrEmpty(entryScriptTypeName))
            {
                _entryScriptType = Type.GetType(entryScriptTypeName);
            }
            return _entryScriptType;
        }
        set
        {
            _entryScriptType = value;
            entryScriptTypeName = _entryScriptType?.FullName;
            // Debug.Log($"EntryScriptType changed to: {entryScriptTypeName}");
        }
    }
    
    public string entryName;
    
    [TextArea(1, 3)]
    public string entryAPI;
    
    [TextArea(5, 15)]
    public string entryDescription;
    
    public List<OptionData> optionList;
    
    public string initialButtonText = "运行";
    public List<ButtonData> extraButtonList;
    
    public List<ResultData> initialResultList;
}