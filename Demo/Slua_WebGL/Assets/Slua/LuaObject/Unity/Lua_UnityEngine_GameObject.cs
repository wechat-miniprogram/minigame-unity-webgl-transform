using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_GameObject : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.GameObject o;
			if(argc==2){
				System.String a1;
				checkType(l,2,out a1);
				o=new UnityEngine.GameObject(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==1){
				o=new UnityEngine.GameObject();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==3){
				System.String a1;
				checkType(l,2,out a1);
				System.Type[] a2;
				checkParams(l,3,out a2);
				o=new UnityEngine.GameObject(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponent(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(System.Type))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponent(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				var ret=self.GetComponent(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponent to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponentInChildren(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponentInChildren(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetComponentInChildren(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponentInChildren to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponentInParent(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponentInParent(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetComponentInParent(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponentInParent to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponents(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponents(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Collections.Generic.List<UnityEngine.Component> a2;
				checkType(l,3,out a2);
				self.GetComponents(a1,a2);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponents to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponentsInChildren(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponentsInChildren(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetComponentsInChildren(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponentsInChildren to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetComponentsInParent(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.GetComponentsInParent(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.GetComponentsInParent(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function GetComponentsInParent to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int TryGetComponent(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			UnityEngine.Component a2;
			var ret=self.TryGetComponent(a1,out a2);
			pushValue(l,true);
			pushValue(l,ret);
			pushValue(l,a2);
			return 3;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SendMessageUpwards(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.SendMessageUpwards(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.SendMessageOptions))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.SendMessageOptions a2;
				a2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 3);
				self.SendMessageUpwards(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(System.Object))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.SendMessageUpwards(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.SendMessageOptions a3;
				a3 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 4);
				self.SendMessageUpwards(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SendMessageUpwards to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SendMessage(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.SendMessage(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.SendMessageOptions))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.SendMessageOptions a2;
				a2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 3);
				self.SendMessage(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(System.Object))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.SendMessage(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.SendMessageOptions a3;
				a3 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 4);
				self.SendMessage(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function SendMessage to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int BroadcastMessage(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				self.BroadcastMessage(a1);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(UnityEngine.SendMessageOptions))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				UnityEngine.SendMessageOptions a2;
				a2 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 3);
				self.BroadcastMessage(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(System.Object))){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				self.BroadcastMessage(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==4){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.String a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				UnityEngine.SendMessageOptions a3;
				a3 = (UnityEngine.SendMessageOptions)LuaDLL.luaL_checkinteger(l, 4);
				self.BroadcastMessage(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function BroadcastMessage to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddComponent(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				var ret=self.AddComponent<UnityEngine.Component>();
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				var ret=self.AddComponent(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function AddComponent to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetActive(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			self.SetActive(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CompareTag(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.CompareTag(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int CreatePrimitive_s(IntPtr l) {
		try {
			UnityEngine.PrimitiveType a1;
			a1 = (UnityEngine.PrimitiveType)LuaDLL.luaL_checkinteger(l, 1);
			var ret=UnityEngine.GameObject.CreatePrimitive(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindWithTag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.GameObject.FindWithTag(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindGameObjectWithTag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.GameObject.FindGameObjectWithTag(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int FindGameObjectsWithTag_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.GameObject.FindGameObjectsWithTag(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Find_s(IntPtr l) {
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
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_transform(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.transform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_layer(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.layer);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_layer(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.layer=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeSelf(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activeSelf);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_activeInHierarchy(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.activeInHierarchy);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isStatic(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isStatic);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_isStatic(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.isStatic=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_tag(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.tag);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_tag(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.tag=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_scene(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scene);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_sceneCullingMask(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sceneCullingMask);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_gameObject(IntPtr l) {
		try {
			UnityEngine.GameObject self=(UnityEngine.GameObject)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.gameObject);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.GameObject");
		addMember(l,GetComponent);
		addMember(l,GetComponentInChildren);
		addMember(l,GetComponentInParent);
		addMember(l,GetComponents);
		addMember(l,GetComponentsInChildren);
		addMember(l,GetComponentsInParent);
		addMember(l,TryGetComponent);
		addMember(l,SendMessageUpwards);
		addMember(l,SendMessage);
		addMember(l,BroadcastMessage);
		addMember(l,AddComponent);
		addMember(l,SetActive);
		addMember(l,CompareTag);
		addMember(l,CreatePrimitive_s);
		addMember(l,FindWithTag_s);
		addMember(l,FindGameObjectWithTag_s);
		addMember(l,FindGameObjectsWithTag_s);
		addMember(l,SLua.MyGameObject.Find_s);
		addMember(l,"transform",get_transform,null,true);
		addMember(l,"layer",get_layer,set_layer,true);
		addMember(l,"activeSelf",get_activeSelf,null,true);
		addMember(l,"activeInHierarchy",get_activeInHierarchy,null,true);
		addMember(l,"isStatic",get_isStatic,set_isStatic,true);
		addMember(l,"tag",get_tag,set_tag,true);
		addMember(l,"scene",get_scene,null,true);
		addMember(l,"sceneCullingMask",get_sceneCullingMask,null,true);
		addMember(l,"gameObject",get_gameObject,null,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.GameObject),typeof(UnityEngine.Object));
	}
}
