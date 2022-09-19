using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.Profiling;
using System;
using UnityEditor.IMGUI.Controls;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeChatWASM.Analysis
{
    public class OptimizeOverview
    {
        private EditorWindow win;
        // 单例
        private static OptimizeOverview instance;
        private static readonly object locker = new object();

        private OptimizeOverview()
        {
            win = AnalysisWindow.GetCurrentWindow();
        }

        public static OptimizeOverview GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new OptimizeOverview();
                }
            }
            return instance;
        }

        public void Show()
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("检查资源", GUILayout.Width(140), GUILayout.Height(40)))
            {
                GetOverview();
            }
            GUILayout.EndHorizontal();

            //DrawOverview();
        }

        public void GetOverview()
        {
            var textureWindow = TextureWindow.GetInstance();
            textureWindow.CollectAssets();
        }

        public void DrawOverview()
        {
            GUILayout.BeginVertical();

            var textureWindow = TextureWindow.GetInstance();


            GUILayout.EndVertical();
        }
    }
}