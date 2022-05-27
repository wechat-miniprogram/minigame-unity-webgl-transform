using System.Text;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;
using System.Runtime.InteropServices;

public class WXProfileStatsScript : MonoBehaviour
{
    string statsText;
#if UNITY_2021_2_OR_NEWER
    //private ProfilerRecorder m_totalUsedMemoryRecorder;
    //private ProfilerRecorder m_totalReservedMemoryRecorder;
    //private ProfilerRecorder m_gcUsedMemoryRecorder;
    //private ProfilerRecorder m_gcReservedMemoryRecorder;
    //private ProfilerRecorder m_gfxUsedMemoryRecorder;
    //private ProfilerRecorder m_gfxReservedMemoryRecorder;

    //private ProfilerRecorder m_systemUsedMemoryRecorder;
    //private ProfilerRecorder m_textureCountRecorder;
    //private ProfilerRecorder m_textureMemoryRecorder;
    //private ProfilerRecorder m_meshCountRecorder;
    //private ProfilerRecorder m_meshMemoryRecorder;
    //private ProfilerRecorder m_materialCountRecorder;
    //private ProfilerRecorder m_materialMemoryRecorder;
    //private ProfilerRecorder m_animationClipCountRecorder;
    //private ProfilerRecorder m_animationClipMemoryRecorder;

    //private ProfilerRecorder m_assetCountRecorder;
    //private ProfilerRecorder m_gameObjectsInScenesRecorder;
    //private ProfilerRecorder m_totalObjectsInScenesRecorder;
    //private ProfilerRecorder m_totalUnityObjectCountRecorder;
    //private ProfilerRecorder m_gcAllocationInFrameCountRecorder;
    //private ProfilerRecorder m_gcAllocatedInFrameRecorder;


    ProfilerRecorder m_setPassCallsRecorder;
    ProfilerRecorder m_drawCallsRecorder;
    ProfilerRecorder m_verticesRecorder;
#endif
    private int m_fpsCount;
    private float m_fpsDeltaTime;
    private int fps;
    private GUIStyle m_bgStyle;
    private bool m_isShow = false;
    System.Collections.Generic.Dictionary<string, ProfValue> profValues = new System.Collections.Generic.Dictionary<string, ProfValue>();


    private void Awake()
    {
        m_bgStyle = new GUIStyle();
        m_bgStyle.normal.background = Texture2D.whiteTexture;
    }

    void OnEnable()
    {

#if UNITY_2021_2_OR_NEWER
        //m_totalUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
        //m_totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
        //m_gcUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Used Memory");
        //m_gcReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        //m_gfxUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Gfx Used Memory");
        //m_gfxReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Gfx Reserved Memory");
        //m_systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        //m_textureCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Texture Count");
        //m_textureMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Texture Memory");
        //m_meshCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Mesh Count");
        //m_meshMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Mesh Memory");
        //m_materialCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Material Count");
        //m_materialMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Material Memory");
        //m_animationClipCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "AnimationClip Count");
        //m_animationClipMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "AnimationClip Memory");
        //m_assetCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Asset Count");
        //m_gameObjectsInScenesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GameObject Count");
        //m_totalObjectsInScenesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Scene Object Count");
        //m_totalUnityObjectCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Object Count");
        //m_gcAllocationInFrameCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Allocation In Frame Count");
        //m_gcAllocatedInFrameRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Allocated In Frame");
        m_setPassCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "SetPass Calls Count");
        m_drawCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
        m_verticesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
#endif

    }

    void OnDisable()
    {
#if UNITY_2021_2_OR_NEWER
        //m_totalUsedMemoryRecorder.Dispose();
        //m_totalReservedMemoryRecorder.Dispose();
        //m_gcUsedMemoryRecorder.Dispose();
        //m_gcReservedMemoryRecorder.Dispose();
        //m_gfxUsedMemoryRecorder.Dispose();
        //m_gfxReservedMemoryRecorder.Dispose();
        //m_systemUsedMemoryRecorder.Dispose();
        //m_textureCountRecorder.Dispose();
        //m_textureMemoryRecorder.Dispose();
        //m_meshCountRecorder.Dispose();
        //m_meshMemoryRecorder.Dispose();
        //m_materialCountRecorder.Dispose();
        //m_materialMemoryRecorder.Dispose();
        //m_animationClipCountRecorder.Dispose();
        //m_animationClipMemoryRecorder.Dispose();
        //m_assetCountRecorder.Dispose();
        //m_gameObjectsInScenesRecorder.Dispose();
        //m_totalObjectsInScenesRecorder.Dispose();
        //m_totalUnityObjectCountRecorder.Dispose();
        //m_gcAllocationInFrameCountRecorder.Dispose();
        //m_gcAllocatedInFrameRecorder.Dispose();
        m_setPassCallsRecorder.Dispose();
        m_drawCallsRecorder.Dispose();
        m_verticesRecorder.Dispose();

#endif
    }

    class ProfValue
    {
        public long current;
        public long max = 0;
        public long min = 9999;
        // public int avrage;
    };
    private ProfValue UpdateValue(string key, long value, StringBuilder sb)
    {
        ProfValue profValue = null;
        if (!profValues.TryGetValue(key, out profValue))
        {
            profValue = new ProfValue();
            profValues.Add(key, profValue);
        }
        profValue.current = value;
        profValue.max = value > profValue.max ? value : profValue.max;
        profValue.min = value < profValue.min ? value : profValue.min;
        sb.AppendLine($"{key}:[{profValue.current}, {profValue.min}, {profValue.max}]");
        return profValue;
    }

    void Update()
    {
        UpdateFps();
        const uint toMB = 1024 * 1024;
        var sb = new StringBuilder(500);
        sb.AppendLine($"-------------FPS---------------");
        //var key = "targetFrameRate";
        UpdateValue("targetFrameRate", Application.targetFrameRate, sb);
        UpdateValue("FPS", fps, sb);

        sb.AppendLine($"-------------Profiler------------");

        UpdateValue("GetMonoUsedSize", Profiler.GetMonoUsedSizeLong() / toMB, sb);
        UpdateValue("Graphics", Profiler.GetAllocatedMemoryForGraphicsDriver() / toMB, sb);
        UpdateValue("MonoHeap", Profiler.GetMonoHeapSizeLong() / toMB, sb);
        UpdateValue("TempAllocator", Profiler.GetTempAllocatorSize() / toMB, sb);
        UpdateValue("TotalReservedMemory", Profiler.GetTotalReservedMemoryLong() / toMB, sb);
        UpdateValue("TotalUnusedReservedMemory", Profiler.GetTotalUnusedReservedMemoryLong() / toMB, sb);
        UpdateValue("TotalAllocatedMemory", Profiler.GetTotalAllocatedMemoryLong() / toMB, sb);


#if UNITY_2021_2_OR_NEWER
        sb.AppendLine("-------------Render------------");
        UpdateValue("SetPass Calls", m_setPassCallsRecorder.LastValue, sb);
        UpdateValue("Draw Calls", m_drawCallsRecorder.LastValue, sb);
        UpdateValue("Vertices", m_verticesRecorder.LastValue, sb);
#endif
        sb.AppendLine("-------------WebAssembly----------");
        UpdateValue("TotalMemorySize", WeChatWASM.WX.GetTotalMemorySize() / toMB, sb);
        UpdateValue("DynamicMemorySize", WeChatWASM.WX.GetDynamicMemorySize() / toMB, sb);


#if UNITY_2021_2_OR_NEWER
        //sb.AppendLine("-------------MemoryRecorder-----");
        //UpdateValue("Total Used Memory", m_totalUsedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Total Reserved Memory", m_totalReservedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("GC Used Memory", m_gcUsedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("GC Reserved Memory", m_gcReservedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Gfx Used Memory", m_gfxUsedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Gfx Reserved Memory", m_gfxReservedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("System Used Memory", m_systemUsedMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Texture Count", m_textureCountRecorder.LastValue, sb);
        //UpdateValue("Texture Memory", m_textureMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Mesh Count", m_meshCountRecorder.LastValue, sb);
        //UpdateValue("Mesh Memory", m_meshMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Material Count", m_materialCountRecorder.LastValue, sb);
        //UpdateValue("Material Memory", m_materialMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("AnimationClip Count", m_animationClipCountRecorder.LastValue, sb);
        //UpdateValue("AnimationClip Memory", m_animationClipMemoryRecorder.LastValue / toMB, sb);
        //UpdateValue("Asset Count", m_assetCountRecorder.LastValue, sb);
        //UpdateValue("GameObject Count", m_gameObjectsInScenesRecorder.LastValue, sb);
        //UpdateValue("Scene Object Count", m_totalObjectsInScenesRecorder.LastValue, sb);
        //UpdateValue("Object Count", m_totalUnityObjectCountRecorder.LastValue, sb);
        //UpdateValue("GC Allocation In Frame Count", m_gcAllocationInFrameCountRecorder.LastValue, sb);
        //UpdateValue("GC Allocated In Frame", m_gcAllocatedInFrameRecorder.LastValue / toMB, sb);
#endif
        statsText = sb.ToString();

    }

    void UpdateFps()
    {
        m_fpsCount++;
        m_fpsDeltaTime += Time.deltaTime;

        if (m_fpsCount % 60 == 0)
        {
            m_fpsCount = 1;
            fps = (int)Mathf.Ceil(60.0f / m_fpsDeltaTime);
            m_fpsDeltaTime = 0;
        }
    }

    void OnGUI()
    {

        GUI.backgroundColor = new Color(0, 0, 0, 0.5f);
#if UNITY_EDITOR
        GUI.skin.button.fontSize = 10;
        GUI.skin.label.fontSize = 10;
#else
        GUI.skin.button.fontSize = 30;
        GUI.skin.label.fontSize = 30;
#endif
        if (GUILayout.Button("Performence Stats", GUILayout.ExpandWidth(false))){
            m_isShow = !m_isShow;
        }
        GUILayout.BeginVertical(m_bgStyle);
        if (m_isShow){
            GUILayout.Label(statsText);
        }
        GUILayout.EndVertical();
    }
}
