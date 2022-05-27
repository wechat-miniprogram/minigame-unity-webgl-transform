using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

namespace SLua{
	public class MemoryProfilerWindow : EditorWindow {



		[MenuItem("SLua/MemoryProfiler")]
		public static MemoryProfilerWindow Open(){
			var window =  EditorWindow.CreateInstance<MemoryProfilerWindow>();
			window.Focus();
			window.Show();
			return window;
		}

		private List<string> _destroyedObjectNames = new List<string>();
		private List<string> _allObjectNames = new List<string>();

		private Vector2 _scrollPos;
		private Vector2 _scrollPos2;

		private bool _showDestroyedObject = false;
		private bool _showAllObject = false;
		private int cachedDelegateCount = 0;
		void OnGUI(){
			var svrGo = GameObject.FindObjectOfType<LuaSvrGameObject>();
			if(svrGo == null){
				GUILayout.Label("There is no LuaSvrGameObject in you scene. Run your game first");
				return;
			}
			if(GUILayout.Button("Capture")){
				System.GC.Collect ();
				LuaDLL.lua_gc(svrGo.state.L, LuaGCOptions.LUA_GCCOLLECT, 0);
				_destroyedObjectNames = ObjectCache.GetAlreadyDestroyedObjectNames();
				_allObjectNames = ObjectCache.GetAllManagedObjectNames();
				cachedDelegateCount = LuaState.main.cachedDelegateCount;
			}

			GUILayout.Label ("LuaDelegate count:" + cachedDelegateCount);
			_showDestroyedObject = EditorGUILayout.Foldout(_showDestroyedObject,"Already Destroyed Unity Object:"+_destroyedObjectNames.Count);
			if(_showDestroyedObject){
				_scrollPos = GUILayout.BeginScrollView(_scrollPos);
				foreach(var name in _destroyedObjectNames){
					GUILayout.Label(name);
				}
				GUILayout.EndScrollView();
			}

			_showAllObject = EditorGUILayout.Foldout(_showAllObject,"All Managed C# Object:"+_allObjectNames.Count);

			if(_showAllObject){
				_scrollPos2 = GUILayout.BeginScrollView(_scrollPos2);
				foreach(var name in _allObjectNames){
					GUILayout.Label(name);
				}
				GUILayout.EndScrollView();
			}



		}

	}

}
