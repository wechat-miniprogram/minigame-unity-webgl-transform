using UnityEngine;
using System.Collections;
using SLua;
public class Perf : MonoBehaviour
{

	LuaSvr l;
	bool inited=false;
	// Use this for initialization
	void Start()
	{
		var startMem = System.GC.GetTotalMemory (true);

		var start = Time.realtimeSinceStartup;
		l = new LuaSvr();
		l.init(null, () =>
		{
			Debug.Log ("start cost: " + (Time.realtimeSinceStartup - start));

			var endMem = System.GC.GetTotalMemory (true);
			Debug.Log ("startMem: " + startMem + ", endMem: " + endMem + ", " + "cost mem: " + (endMem - startMem));
			l.start("perf");
			inited=true;
		});

#if UNITY_5
		Application.logMessageReceived += this.log;
#else
		Application.RegisterLogCallback(this.log);
#endif
	}

	string logText = "";
	void log(string cond, string trace, LogType lt)
	{
		logText += cond;
		logText += "\n";
	}

	void OnGUI()
	{
		if (!inited)
			return;

		if (GUI.Button(new Rect(10, 10, 120, 50), "Test1"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test1").call();
		}

		if (GUI.Button(new Rect(10, 100, 120, 50), "Test2"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test2").call();
		}

		if (GUI.Button(new Rect(10, 200, 120, 50), "Test3"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test3").call();
		}

		if (GUI.Button(new Rect(10, 300, 120, 50), "Test4"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test4").call();
		}

		if (GUI.Button(new Rect(200, 10, 120, 50), "Test5"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test5").call();
		}

        if (GUI.Button(new Rect(200, 100, 120, 50), "Test6 jit"))
        {
            logText = "";
            LuaSvr.mainState.getFunction("test6").call();
        }

		if (GUI.Button(new Rect(200, 200, 120, 50), "Test6 non-jit"))
		{
			logText = "";
			LuaSvr.mainState.getFunction("test7").call();
		}

        if (GUI.Button(new Rect(10, 400, 300, 50), "Click here for detail(in Chinese)"))
		{
			Application.OpenURL("http://www.sineysoft.com/post/164");
		}

		GUI.Label(new Rect(400, 200, 300, 50), logText);
	}
}
