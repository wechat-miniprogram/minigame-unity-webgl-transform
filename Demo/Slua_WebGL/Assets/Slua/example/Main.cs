using UnityEngine;
using System.Collections;
using SLua;
using UnityEngine.UI;
using System.Collections.Generic;

public class Main : MonoBehaviour
{

	LuaSvr l;
	public Text logText;
	int progress=0;
	// Use this for initialization
	void Start()
	{
#if UNITY_5
		Application.logMessageReceived += this.log;
#else
		Application.RegisterLogCallback(this.log);
#endif

		l = new LuaSvr();
		l.init(tick,complete,LuaSvrFlag.LSF_BASIC|LuaSvrFlag.LSF_EXTLIB);
	}

	void log(string cond, string trace, LogType lt)
	{
		string txt = logText.text + (cond + "\n");
		if(txt.Length>1000)
			txt = txt.Substring (txt.Length - 1000);
		logText.text = txt;
	}

	void tick(int p)
	{
		progress = p;
	}

	void complete()
	{
		l.start("main");
		object o = LuaSvr.mainState.getFunction("foo").call(1, 2, 3);
		object[] array = (object[])o;
		for (int n = 0; n < array.Length; n++)
			Debug.Log(array[n]);

		string s = (string)LuaSvr.mainState.getFunction("str").call(new object[0]);
		Debug.Log(s);
	}

	void OnGUI()
	{
		if(progress!=100)
			GUI.Label(new Rect(0, 0, 100, 50), string.Format("Loading {0}%", progress));
	}

}
