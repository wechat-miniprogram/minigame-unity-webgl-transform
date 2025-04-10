// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net / jiangzhhhh  jiangzhhhh@gmail.com
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

using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SLua
{
#if UNITY_2017_2_OR_NEWER
    public class ModuleSelector : EditorWindow
    {
        Vector2 scrollPosition = Vector2.zero;
        public Action<string[]> onExport;

        void OnGUI()
        {
            List<string> modules = new List<string>();

            scrollPosition = GUILayout.BeginScrollView(
                scrollPosition,
                GUILayout.Width(Screen.width),
                GUILayout.ExpandHeight(true)
            );
            foreach (string module in LuaCodeGen.unityModule)
            {
                if (GUILayout.Toggle(true, module, GUILayout.ExpandWidth(false)))
                    modules.Add(module);
            }
            GUILayout.EndScrollView();
            if (GUILayout.Button("Export", GUILayout.ExpandWidth(true)))
            {
                if (onExport != null)
                    onExport(modules.ToArray());
                this.Close();
            }
        }
    }
#endif
}
