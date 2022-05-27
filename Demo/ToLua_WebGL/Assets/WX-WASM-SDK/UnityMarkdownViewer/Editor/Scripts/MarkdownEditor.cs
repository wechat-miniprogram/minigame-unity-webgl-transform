using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace WeChatWASM.MDV
{
    [CustomEditor( typeof( TextAsset ) )]
    public class MarkdownEditor : Editor
    {
        public GUISkin SkinLight;
        public GUISkin SkinDark;

        MarkdownViewer mViewer;

        private static List<string> mExtensions = new List<string> { ".md", ".markdown" };

        protected void OnEnable()
        {
            var content = ( target as TextAsset ).text;
            var path    = AssetDatabase.GetAssetPath( target );

            var ext = Path.GetExtension( path ).ToLower();

            // 未知原因可能导致丢失样式，手动赋值下
            SkinLight = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/WX-WASM-SDK/UnityMarkdownViewer/Editor/Skin/MarkdownViewerSkin.guiskin");
            SkinDark = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/WX-WASM-SDK/UnityMarkdownViewer/Editor/Skin/MarkdownSkinQS.guiskin");
            if( mExtensions.Contains( ext ) )
            {
                mViewer = new MarkdownViewer( Preferences.DarkSkin ? SkinDark : SkinLight, path, content );
                EditorApplication.update += UpdateRequests;
            }
        }

        protected void OnDisable()
        {
            if( mViewer != null )
            {
                EditorApplication.update -= UpdateRequests;
                mViewer = null;
            }
        }

        void UpdateRequests()
        {
            if( mViewer != null && mViewer.Update() )
            {
                Repaint();
            }
        }


        //------------------------------------------------------------------------------

        public override bool UseDefaultMargins()
        {
            return false;
        }

#if UNITY_2020_1_OR_NEWER
        public override void OnInspectorGUI()
        {
            DrawEditor();
        }

        protected override void OnHeaderGUI()
        {
            // DrawEditor();
        }
#elif UNITY_2019_2_OR_NEWER
        // TODO: workaround for bug in 2019.2
        // https://forum.unity.com/threads/oninspectorgui-not-being-called-on-defaultasset-in-2019-2-0f1.724328/
        protected override void OnHeaderGUI()
        {
            DrawEditor();
        }
#else
        public override void OnInspectorGUI()
        {
            DrawEditor();
        }
#endif


        //------------------------------------------------------------------------------

        private Editor mDefaultEditor;

        void DrawEditor()
        {
            if( mViewer != null )
            {
                mViewer.Draw();
            }
            else
            {
                DrawDefaultEditor();
            }
        }

        void DrawDefaultEditor()
        {
            mDefaultEditor = mDefaultEditor ?? CreateEditor( target, Type.GetType( "UnityEditor.TextAssetInspector, UnityEditor" ) );

            if( mDefaultEditor != null )
            {
                mDefaultEditor.OnInspectorGUI();
            }
        }
    }
}
