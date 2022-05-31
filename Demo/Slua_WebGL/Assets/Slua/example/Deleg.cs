using UnityEngine;
using System.Collections;
using SLua;
using System;
using System.Collections.Generic;

[CustomLuaClassAttribute]
public class Deleg : MonoBehaviour
{


	public delegate bool GetBundleInfoDelegate(string a1,int a2,int a3,ref System.Int32 a4,out System.String a5,out System.Int32 a6);
	public delegate void SimpleDelegate(string path, GameObject g);

	static public GetBundleInfoDelegate d;
	static public SimpleDelegate s;

	static public GetBundleInfoDelegate dx
	{
		get
		{
			return d;
		}
		set
		{
			d = value;
		}
	}

	LuaSvr l;
	// Use this for initialization
	void Start()
	{
		l = new LuaSvr();
		l.init(null,()=>{
			l.start("delegate");
		});
	}

	static public void callD()
	{
		string url;
		int ver;
		int c = 3;
		if (d != null)
		{
			bool ret = d("/path", 1,2,ref c,out url, out ver);
			Debug.Log(string.Format("{0},{1},{2}", ret, url, ver));
#if UNITY_5
			Debug.Assert (c == 4);
			Debug.Assert (url == "http://www.sineysoft.com");
			Debug.Assert (ver == 1);
#endif
		}
		if (s != null)
			s("GameObject", new GameObject("SimpleDelegate"));
	}

	static public void setcallback2(Action<int> a, Action<string> b)
	{
		if(a!=null) a(1);
		if(b!=null) b("hello");
	}

	public static void testFunc(Func<int> f)
	{
		Debug.Log(string.Format("Func return {0}", f()));
	}

	public static void testAction(Action<int, string> f)
	{
		f(1024, "caoliu");
	}

	public static void testDAction(Action<int, Dictionary<int, object>> f)
	{
		f(1024, new Dictionary<int, object>());

	}

	public static void callDAction()
	{
		if (daction != null)
			daction(2048, new Dictionary<int, object>());
	}

	public static Action<int, Dictionary<int, object>> daction;

	public static Func<int, string, bool> getFunc(Func<int, string, bool> f)
	{
		return f;
	}
}
