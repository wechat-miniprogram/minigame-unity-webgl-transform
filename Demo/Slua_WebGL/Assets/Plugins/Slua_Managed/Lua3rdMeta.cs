// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;
#if !SLUA_STANDALONE
using UnityEngine;
#endif
using System.IO;

namespace SLua{

	public class Lua3rdMeta
	#if !SLUA_STANDALONE
		:ScriptableObject
	#endif
	{
		/// <summary>
		///Cache class types here those contain 3rd dll attribute.
		/// </summary>
		public List<string> typesWithAttribtues = new List<string>();

		void OnEnable(){
			#if !SLUA_STANDALONE
			this.hideFlags = HideFlags.NotEditable;
			#endif
		}
		#if UNITY_EDITOR

		public void ReBuildTypes(){
			typesWithAttribtues.Clear();
			Assembly assembly = null;
			foreach(var assem in AppDomain.CurrentDomain.GetAssemblies()){
				if(assem.GetName().Name == "Assembly-CSharp"){
					assembly = assem;
					break;
				}
			}
			if(assembly != null){
				var types = assembly.GetExportedTypes();
				foreach(var type in types){
					var methods = type.GetMethods(BindingFlags.Public|BindingFlags.Static);
					foreach(var method in methods){
						if(method.IsDefined(typeof(Lua3rdDLL.LualibRegAttribute),false)){
							typesWithAttribtues.Add(type.FullName);
							break;
						}
					} 
				}
			}
		}

		#endif
		private static Lua3rdMeta _instance=null;
		public static Lua3rdMeta Instance{
			get{
				#if !SLUA_STANDALONE
				if(_instance == null){
					_instance = Resources.Load<Lua3rdMeta>("lua3rdmeta");
				}

				#if UNITY_EDITOR
				if(_instance == null){
					_instance = ScriptableObject.CreateInstance<Lua3rdMeta>();
					string path = "Assets/Slua/Resources";
					if(!Directory.Exists(path)){
						Directory.CreateDirectory(path);
					}
					UnityEditor.AssetDatabase.CreateAsset(_instance,Path.Combine(path,"lua3rdmeta.asset"));
				}

				#endif
				#endif
				return _instance;
			}
		}
	}
}
