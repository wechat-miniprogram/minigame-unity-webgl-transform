using UnityEngine;
using LuaInterface;
using System.Collections;

[LuaInterface.NoToLua]
public class TestInjection : MonoBehaviour
{
    string tips = "";
    bool m_isMouseDown;
    int m_fontSize = 28;
    int m_logFontSize = 0;
    float scaleThreshold;
    LuaState luaState = null;
    Color m_normalColor;
    GUIStyle m_fontStyle;
    GUIStyle m_windowStyle;
    Rect m_windowRect;
    Vector2 m_scrollViewPos;
    Vector2 m_distance;

    // Use this for initialization
    void Start()
    {
        InitGUI();
#if UNITY_5 || UNITY_2017_1_OR_NEWER
        Application.logMessageReceived += ShowTips;
#else
        Application.RegisterLogCallback(ShowTips);
#endif
        new LuaResLoader();
        luaState = new LuaState();
        luaState.Start();
        LuaBinder.Bind(luaState);
        //For InjectByModule
        //////////////////////////////////////////////////////
        luaState.BeginModule(null);
        BaseTestWrap.Register(luaState);
        ToLuaInjectionTestWrap.Register(luaState);
        luaState.EndModule();
        //////////////////////////////////////////////////////

#if ENABLE_LUA_INJECTION
#if UNITY_EDITOR
        if (UnityEditor.EditorPrefs.GetInt(Application.dataPath + "InjectStatus") == 1)
        {
#else
        if (true)
        {
#endif
            ///此处Require是示例专用，暖更新的lua代码都要放到LuaInjectionBus.lua中统一require
            luaState.Require("ToLuaInjectionTestInjector");
            int counter = 0;
            bool state = true;
            ToLuaInjectionTest test = new ToLuaInjectionTest(true);
            test = new ToLuaInjectionTest();
            StartCoroutine(test.TestCoroutine(0.3f));

            test.TestOverload(1, state);
            test.TestOverload(1, ref state);
            Debug.Log("TestOverload ref result:" + state);
            test.TestOverload(state, 1);
            int refResult = test.TestRef(ref counter);
            Debug.Log(string.Format("TestRef return result:{0}; ref result:{1}", refResult, counter));

            Debug.Log("Property Get Test:" + test.PropertyTest);
            test.PropertyTest = 2;
            Debug.Log("Property Set Test:" + test.PropertyTest);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000000; ++i)
            {
                test.NoInject(true, 1);
            }
            sw.Stop();
            long noInjectMethodCostTime = sw.ElapsedMilliseconds;
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000000; ++i)
            {
                test.Inject(true, 1);
            }
            sw.Stop();
            Debug.Log("time cost ratio:" + (double)sw.ElapsedMilliseconds / noInjectMethodCostTime);
        }
        else
#endif
        {
            Debug.LogError("查看是否开启了宏ENABLE_LUA_INJECTION并执行了菜单命令——\"Lua=>Inject All\"");
        }
    }

    void InitGUI()
    {
        m_windowRect.x = 0;
        m_windowRect.y = 0;
        m_windowRect.width = Screen.width;
        m_windowRect.height = Screen.height;

        m_logFontSize = (int)(m_fontSize * Screen.width * Screen.height / (1280 * 720));
        m_normalColor = Color.white;
        m_fontStyle = new GUIStyle();
        m_fontStyle.normal.textColor = m_normalColor;
        m_fontStyle.fontSize = m_logFontSize;

        //设置窗口颜色
        m_windowStyle = new GUIStyle();
        Texture2D windowTexture = new Texture2D(1, 1);
        windowTexture.SetPixel(0, 0, Color.black);
        windowTexture.Apply();
        m_windowStyle.normal.background = windowTexture;

        scaleThreshold = Screen.width / 1100.0f;
    }

    void OnApplicationQuit()
    {
#if UNITY_5 || UNITY_2017_1_OR_NEWER
        Application.logMessageReceived -= ShowTips;
#else
        Application.RegisterLogCallback(null);
#endif
        luaState.Dispose();
        luaState = null;
    }

    Vector2 MousePoisition { get { return new Vector2(-Input.mousePosition.x, Input.mousePosition.y); } }
    //鼠标拖拽控制
    private void MouseDragView(ref Vector2 viewPos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_distance = viewPos - MousePoisition;
            m_isMouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_isMouseDown = false;
        }

        if (m_isMouseDown)
        {
            viewPos = MousePoisition + m_distance;
        }
    }

    /// <summary>
    /// 非常简陋的一个log窗口，不要用到项目中，仅用来示例
    /// </summary>
    /// <param name="id"></param>
    void LogWindow(int id)
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("+", GUILayout.MinHeight(50 * scaleThreshold)))
        {
            m_logFontSize = Mathf.Min(64, ++m_logFontSize);
            m_fontStyle.fontSize = m_logFontSize;
        }
        if (GUILayout.Button("-", GUILayout.MinHeight(50 * scaleThreshold)))
        {
            m_logFontSize = Mathf.Max(1, --m_logFontSize);
            m_fontStyle.fontSize = m_logFontSize;
        }
        GUILayout.EndHorizontal();

        m_scrollViewPos = GUILayout.BeginScrollView(m_scrollViewPos, false, false);

        MouseDragView(ref m_scrollViewPos);

        GUILayout.Label(tips, m_fontStyle);
        GUILayout.Space(2);
        GUILayout.EndScrollView();

        GUILayout.BeginHorizontal();
        GUILayout.Label(string.Format("Font Size ({0})", m_logFontSize));
        GUILayout.EndHorizontal();
    }

    void OnGUI()
    {
        m_windowRect = GUI.Window(0, m_windowRect, LogWindow, "Log Window", m_windowStyle);
    }

    void ShowTips(string msg, string stackTrace, LogType type)
    {
        tips += msg;
        tips += "\r\n";

        if (type == LogType.Error || type == LogType.Exception)
        {
            tips += stackTrace;
        }
    }
}
