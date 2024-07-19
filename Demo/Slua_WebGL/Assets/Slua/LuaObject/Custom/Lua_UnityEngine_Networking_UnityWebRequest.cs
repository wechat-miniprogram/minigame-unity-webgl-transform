using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Networking_UnityWebRequest : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Networking.UnityWebRequest o;
			if(argc==1){
				o=new UnityEngine.Networking.UnityWebRequest();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string))){
				System.String a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Networking.UnityWebRequest(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(System.Uri))){
				System.Uri a1;
				checkType(l,2,out a1);
				o=new UnityEngine.Networking.UnityWebRequest(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(string))){
				System.String a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Networking.UnityWebRequest(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(System.Uri),typeof(string))){
				System.Uri a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				o=new UnityEngine.Networking.UnityWebRequest(a1,a2);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(string),typeof(string),typeof(UnityEngine.Networking.DownloadHandler),typeof(UnityEngine.Networking.UploadHandler))){
				System.String a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				UnityEngine.Networking.DownloadHandler a3;
				checkType(l,4,out a3);
				UnityEngine.Networking.UploadHandler a4;
				checkType(l,5,out a4);
				o=new UnityEngine.Networking.UnityWebRequest(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(System.Uri),typeof(string),typeof(UnityEngine.Networking.DownloadHandler),typeof(UnityEngine.Networking.UploadHandler))){
				System.Uri a1;
				checkType(l,2,out a1);
				System.String a2;
				checkType(l,3,out a2);
				UnityEngine.Networking.DownloadHandler a3;
				checkType(l,4,out a3);
				UnityEngine.Networking.UploadHandler a4;
				checkType(l,5,out a4);
				o=new UnityEngine.Networking.UnityWebRequest(a1,a2,a3,a4);
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
	static public int Dispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			self.Dispose();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SendWebRequest(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			var ret=self.SendWebRequest();
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
	static public int Abort(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			self.Abort();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetRequestHeader(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetRequestHeader(a1);
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
	static public int SetRequestHeader(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			self.SetRequestHeader(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetResponseHeader(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetResponseHeader(a1);
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
	static public int GetResponseHeaders(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			var ret=self.GetResponseHeaders();
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
	static public int ClearCookieCache_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==0){
				UnityEngine.Networking.UnityWebRequest.ClearCookieCache();
				pushValue(l,true);
				return 1;
			}
			else if(argc==1){
				System.Uri a1;
				checkType(l,1,out a1);
				UnityEngine.Networking.UnityWebRequest.ClearCookieCache(a1);
				pushValue(l,true);
				return 1;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function ClearCookieCache to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Get_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Get(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri))){
				System.Uri a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Get(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Get to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Delete_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Delete(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri))){
				System.Uri a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Delete(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Delete to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Head_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Head(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri))){
				System.Uri a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.Head(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Head to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Put_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(System.Byte[]))){
				System.String a1;
				checkType(l,1,out a1);
				System.Byte[] a2;
				checkArray(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Put(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(System.Byte[]))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.Byte[] a2;
				checkArray(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Put(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Put(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(string))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Put(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Put to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Post_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(string),typeof(string))){
				System.String a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(string))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.String a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(UnityEngine.WWWForm))){
				System.String a1;
				checkType(l,1,out a1);
				UnityEngine.WWWForm a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(UnityEngine.WWWForm))){
				System.Uri a1;
				checkType(l,1,out a1);
				UnityEngine.WWWForm a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Networking.IMultipartFormSection>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(List<UnityEngine.Networking.IMultipartFormSection>))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(Dictionary<System.String,System.String>))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.Dictionary<System.String,System.String> a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(Dictionary<System.String,System.String>))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.Collections.Generic.Dictionary<System.String,System.String> a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(string),typeof(List<UnityEngine.Networking.IMultipartFormSection>),typeof(System.Byte[]))){
				System.String a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a2;
				checkType(l,2,out a2);
				System.Byte[] a3;
				checkArray(l,3,out a3);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(System.Uri),typeof(List<UnityEngine.Networking.IMultipartFormSection>),typeof(System.Byte[]))){
				System.Uri a1;
				checkType(l,1,out a1);
				System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a2;
				checkType(l,2,out a2);
				System.Byte[] a3;
				checkArray(l,3,out a3);
				var ret=UnityEngine.Networking.UnityWebRequest.Post(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Post to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int EscapeURL_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.EscapeURL(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Text.Encoding a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.EscapeURL(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function EscapeURL to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int UnEscapeURL_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.String a1;
				checkType(l,1,out a1);
				var ret=UnityEngine.Networking.UnityWebRequest.UnEscapeURL(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Text.Encoding a2;
				checkType(l,2,out a2);
				var ret=UnityEngine.Networking.UnityWebRequest.UnEscapeURL(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function UnEscapeURL to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SerializeFormSections_s(IntPtr l) {
		try {
			System.Collections.Generic.List<UnityEngine.Networking.IMultipartFormSection> a1;
			checkType(l,1,out a1);
			System.Byte[] a2;
			checkArray(l,2,out a2);
			var ret=UnityEngine.Networking.UnityWebRequest.SerializeFormSections(a1,a2);
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
	static public int GenerateBoundary_s(IntPtr l) {
		try {
			var ret=UnityEngine.Networking.UnityWebRequest.GenerateBoundary();
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
	static public int SerializeSimpleForm_s(IntPtr l) {
		try {
			System.Collections.Generic.Dictionary<System.String,System.String> a1;
			checkType(l,1,out a1);
			var ret=UnityEngine.Networking.UnityWebRequest.SerializeSimpleForm(a1);
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
	static public int get_kHttpVerbGET(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbGET);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kHttpVerbHEAD(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbHEAD);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kHttpVerbPOST(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbPOST);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kHttpVerbPUT(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbPUT);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kHttpVerbCREATE(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbCREATE);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_kHttpVerbDELETE(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,UnityEngine.Networking.UnityWebRequest.kHttpVerbDELETE);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disposeCertificateHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.disposeCertificateHandlerOnDispose);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disposeCertificateHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.disposeCertificateHandlerOnDispose=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disposeDownloadHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.disposeDownloadHandlerOnDispose);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disposeDownloadHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.disposeDownloadHandlerOnDispose=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_disposeUploadHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.disposeUploadHandlerOnDispose);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_disposeUploadHandlerOnDispose(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.disposeUploadHandlerOnDispose=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_method(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.method);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_method(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.method=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_error(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.error);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_useHttpContinue(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useHttpContinue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_useHttpContinue(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.useHttpContinue=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_url(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.url);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_url(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.url=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uri(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uri);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uri(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			System.Uri v;
			checkType(l,2,out v);
			self.uri=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_responseCode(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.responseCode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uploadProgress(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uploadProgress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isModifiable(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isModifiable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_isDone(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isDone);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_result(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.result);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_downloadProgress(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.downloadProgress);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uploadedBytes(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uploadedBytes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_downloadedBytes(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.downloadedBytes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_redirectLimit(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.redirectLimit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_redirectLimit(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.redirectLimit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_uploadHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.uploadHandler);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_uploadHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			UnityEngine.Networking.UploadHandler v;
			checkType(l,2,out v);
			self.uploadHandler=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_downloadHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.downloadHandler);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_downloadHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			UnityEngine.Networking.DownloadHandler v;
			checkType(l,2,out v);
			self.downloadHandler=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_certificateHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.certificateHandler);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_certificateHandler(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			UnityEngine.Networking.CertificateHandler v;
			checkType(l,2,out v);
			self.certificateHandler=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int get_timeout(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.timeout);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int set_timeout(IntPtr l) {
		try {
			UnityEngine.Networking.UnityWebRequest self=(UnityEngine.Networking.UnityWebRequest)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.timeout=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Networking.UnityWebRequest");
		addMember(l,Dispose);
		addMember(l,SendWebRequest);
		addMember(l,Abort);
		addMember(l,GetRequestHeader);
		addMember(l,SetRequestHeader);
		addMember(l,GetResponseHeader);
		addMember(l,GetResponseHeaders);
		addMember(l,ClearCookieCache_s);
		addMember(l,Get_s);
		addMember(l,Delete_s);
		addMember(l,Head_s);
		addMember(l,Put_s);
		addMember(l,Post_s);
		addMember(l,EscapeURL_s);
		addMember(l,UnEscapeURL_s);
		addMember(l,SerializeFormSections_s);
		addMember(l,GenerateBoundary_s);
		addMember(l,SerializeSimpleForm_s);
		addMember(l,"kHttpVerbGET",get_kHttpVerbGET,null,false);
		addMember(l,"kHttpVerbHEAD",get_kHttpVerbHEAD,null,false);
		addMember(l,"kHttpVerbPOST",get_kHttpVerbPOST,null,false);
		addMember(l,"kHttpVerbPUT",get_kHttpVerbPUT,null,false);
		addMember(l,"kHttpVerbCREATE",get_kHttpVerbCREATE,null,false);
		addMember(l,"kHttpVerbDELETE",get_kHttpVerbDELETE,null,false);
		addMember(l,"disposeCertificateHandlerOnDispose",get_disposeCertificateHandlerOnDispose,set_disposeCertificateHandlerOnDispose,true);
		addMember(l,"disposeDownloadHandlerOnDispose",get_disposeDownloadHandlerOnDispose,set_disposeDownloadHandlerOnDispose,true);
		addMember(l,"disposeUploadHandlerOnDispose",get_disposeUploadHandlerOnDispose,set_disposeUploadHandlerOnDispose,true);
		addMember(l,"method",get_method,set_method,true);
		addMember(l,"error",get_error,null,true);
		addMember(l,"useHttpContinue",get_useHttpContinue,set_useHttpContinue,true);
		addMember(l,"url",get_url,set_url,true);
		addMember(l,"uri",get_uri,set_uri,true);
		addMember(l,"responseCode",get_responseCode,null,true);
		addMember(l,"uploadProgress",get_uploadProgress,null,true);
		addMember(l,"isModifiable",get_isModifiable,null,true);
		addMember(l,"isDone",get_isDone,null,true);
		addMember(l,"result",get_result,null,true);
		addMember(l,"downloadProgress",get_downloadProgress,null,true);
		addMember(l,"uploadedBytes",get_uploadedBytes,null,true);
		addMember(l,"downloadedBytes",get_downloadedBytes,null,true);
		addMember(l,"redirectLimit",get_redirectLimit,set_redirectLimit,true);
		addMember(l,"uploadHandler",get_uploadHandler,set_uploadHandler,true);
		addMember(l,"downloadHandler",get_downloadHandler,set_downloadHandler,true);
		addMember(l,"certificateHandler",get_certificateHandler,set_certificateHandler,true);
		addMember(l,"timeout",get_timeout,set_timeout,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Networking.UnityWebRequest));
	}
}
