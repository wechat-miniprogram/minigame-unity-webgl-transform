using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstantiateDestroy : ScriptingTest {

	public UnityEngine.UI.Text output;
	public GameObject go;

	public override void UpdateTest () 
	{
		var instance = Instantiate (go);
		Destroy (instance);
	}

	public override void UpdateFrame ()
	{
		var progress = totalTime / maxTime;
		var str = "Instantating and Destroying a lot of Teddy bears\n[";
		for (var i=0; i<20; i++)
			str += (i/20.0f) > progress? "-" : "=";
		str += "]";

		output.text = str;
	}
}
