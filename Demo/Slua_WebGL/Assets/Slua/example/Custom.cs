using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;
using System;

[CustomLuaClass]
public class Custom : MonoBehaviour
{

	int v = 520;
	static string vs = "xiaoming & hanmeimei";
	LuaSvr l;
	static Custom c;
	void Start()
	{
		c = this;
		l = new LuaSvr();
		l.init(null, () =>
		{
			l.start("custom");
		});
	}

	// Update is called once per frame
	void Update()
	{

	}

	// this exported function don't generate stub code if it had MonoPInvokeCallbackAttribute attribute, only register it
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int instanceCustom(IntPtr l)
	{
		Custom self = (Custom)LuaObject.checkSelf(l);
		LuaObject.pushValue(l, true);
		LuaDLL.lua_pushstring(l, "xiaoming");
		LuaDLL.lua_pushstring(l, "hanmeimei");
		LuaDLL.lua_pushinteger(l, self.v);
		return 4;
	}

	// this exported function don't generate stub code, only register it
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[StaticExport]
	static public int staticCustom(IntPtr l)
	{
		LuaObject.pushValue(l, true);
		LuaDLL.lua_pushstring(l, vs);
		LuaObject.pushObject(l, c);
		return 3;
	}
	public int this[string key]
	{
		get
		{
			if (key == "test")
				return v;
			return 0;
		}
		set
		{
			if (key == "test")
			{
				v = value;
			}
		}
	}
	public string getTypeName(Type t)
	{
		return t.Name;
	}

    [CustomLuaClass]
    public interface IFoo
    {
        int getInt();
        void setInt(int i, bool ok);
    }

    class Foo : IFoo {
        public int getInt() {
            return 10;
        }
        public void setInt(int i,bool ok) {
            
        }
    }

    public IFoo getInterface() {
        return new Foo();
    }
}

public static class IFooExt
{
	public static void setInt(this Custom.IFoo f, int i)
	{

	}
}

namespace SLua {
	
	[OverloadLuaClass(typeof(GameObject))]
	public class MyGameObject : LuaObject {
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
		public static int Find_s(IntPtr l) {
			UnityEngine.Debug.Log ("GameObject.Find overloaded my MyGameObject.Find");
			try {
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.GameObject.Find(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			catch(Exception e) {
				return error(l,e);
			}
		}
	}


    [OverloadLuaClass(typeof(UnityEngine.RenderSettings))]
    public class RenderSettingsEx : LuaObject {
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int set_fogDensity(IntPtr l) {
            return 0;
        }
    }

}