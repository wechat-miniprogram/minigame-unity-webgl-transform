using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OptionData
{
    [TextArea(1, 2)]
    public string optionName;

    public List<string> availableOptions;
}
