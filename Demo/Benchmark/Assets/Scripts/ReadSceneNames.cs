using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//taken from http://answers.unity3d.com/questions/33263/how-to-get-names-of-all-available-levels.html
public class ReadSceneNames : MonoBehaviour
{
    public List<string> testSceneNames;
    #if UNITY_EDITOR
    private static List<string> ReadNames()
    {
		List<string> temp = new List<string>();
		foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
		{
			if (S.enabled)
			{
				string name = S.path.Substring(S.path.LastIndexOf('/')+1);
				name = name.Substring(0,name.Length-6);
				temp.Add(name);
			}
		}
		return temp;
    }
    [UnityEditor.MenuItem("CONTEXT/ReadSceneNames/Update Scene Names")]
    private static void UpdateNames(UnityEditor.MenuCommand command)
    {
		ReadSceneNames context = (ReadSceneNames)command.context;
		var allSceneNames = ReadNames();
		var testSceneNames = allSceneNames.GetRange(1, allSceneNames.Count-1);
		context.testSceneNames = testSceneNames;
    }
     
    private void Reset()
    {
	//	testSceneNames = ReadNames();	
    }
    #endif
}
