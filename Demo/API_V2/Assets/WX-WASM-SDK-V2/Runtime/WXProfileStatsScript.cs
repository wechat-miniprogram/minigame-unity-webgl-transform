using System.Runtime.InteropServices;
using System.Text;

using Unity.Profiling;
using LitJson;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Profiling;

#if UNITY_WEBGL || WEIXINMINIGAME || UNITY_EDITOR
using WeChatWASM;
public class WXProfileStatsScript : MonoBehaviour, WeChatWASM.WXSDKManagerHandler.WXProfileStatsScript
{
    private string statsText;
#if UNITY_2021_2_OR_NEWER
    // private ProfilerRecorder m_totalUsedMemoryRecorder;
    // private ProfilerRecorder m_totalReservedMemoryRecorder;
    // private ProfilerRecorder m_gcUsedMemoryRecorder;
    // private ProfilerRecorder m_gcReservedMemoryRecorder;
    // private ProfilerRecorder m_gfxUsedMemoryRecorder;
    // private ProfilerRecorder m_gfxReservedMemoryRecorder;

    // private ProfilerRecorder m_systemUsedMemoryRecorder;
    // private ProfilerRecorder m_textureCountRecorder;
    // private ProfilerRecorder m_textureMemoryRecorder;
    // private ProfilerRecorder m_meshCountRecorder;
    // private ProfilerRecorder m_meshMemoryRecorder;
    // private ProfilerRecorder m_materialCountRecorder;
    // private ProfilerRecorder m_materialMemoryRecorder;
    // private ProfilerRecorder m_animationClipCountRecorder;
    // private ProfilerRecorder m_animationClipMemoryRecorder;

    // private ProfilerRecorder m_assetCountRecorder;
    // private ProfilerRecorder m_gameObjectsInScenesRecorder;
    // private ProfilerRecorder m_totalObjectsInScenesRecorder;
    // private ProfilerRecorder m_totalUnityObjectCountRecorder;
    // private ProfilerRecorder m_gcAllocationInFrameCountRecorder;
    // private ProfilerRecorder m_gcAllocatedInFrameRecorder;
    private ProfilerRecorder m_setPassCallsRecorder; //切换用于渲染游戏对象的着色器通道的次数
    private ProfilerRecorder m_drawCallsRecorder; //绘制调用总数
    private ProfilerRecorder m_verticesRecorder; //顶点数
    private ProfilerRecorder m_triangleRecorder; //三角形数

    private ProfilerRecorder m_renderTexturesCount;
    private ProfilerRecorder m_RenderTexturesBytes;
    private ProfilerRecorder m_BatchesCount;
    private ProfilerRecorder m_ShadowCastersCount;
    private ProfilerRecorder m_VisibleSkinnedMeshesCount;
    private ProfilerRecorder m_RenderTexturesChangesCount;
    private ProfilerRecorder m_UsedBuffersCount;
    private ProfilerRecorder m_UsedBuffersBytes;
    private ProfilerRecorder m_VertexBufferUploadInFrameCount;
    private ProfilerRecorder m_VertexBufferUploadInFrameBytes;
    private ProfilerRecorder m_IndexBufferUploadInFrameCount;
    private ProfilerRecorder m_IndexBufferUploadInFrameBytes;


#endif
    private int m_fpsCount;
    private float m_fpsDeltaTime;
    private int fps;
    private GUIStyle m_bgStyle;
    private bool m_isShow = true;
    private System.Collections.Generic.Dictionary<string, ProfValue> profValues = new System.Collections.Generic.Dictionary<string, ProfValue>();

    public void Awake()
    {
        m_bgStyle = new GUIStyle();
        m_bgStyle.normal.background = Texture2D.whiteTexture;
    }

    public void OnEnable()
    {
#if UNITY_2021_2_OR_NEWER
        // m_totalUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
        // m_totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
        // m_gcUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Used Memory");
        // m_gcReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
        // m_gfxUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Gfx Used Memory");
        // m_gfxReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Gfx Reserved Memory");
        // m_systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
        // m_textureCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Texture Count");
        // m_textureMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Texture Memory");
        // m_meshCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Mesh Count");
        // m_meshMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Mesh Memory");
        // m_materialCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Material Count");
        // m_materialMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Material Memory");
        // m_animationClipCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "AnimationClip Count");
        // m_animationClipMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "AnimationClip Memory");
        // m_assetCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Asset Count");
        // m_gameObjectsInScenesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GameObject Count");
        // m_totalObjectsInScenesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Scene Object Count");
        // m_totalUnityObjectCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Object Count");
        // m_gcAllocationInFrameCountRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Allocation In Frame Count");
        // m_gcAllocatedInFrameRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Allocated In Frame");
        m_setPassCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "SetPass Calls Count");
        m_drawCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
        m_verticesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertices Count");
        if (WeChatWASM.WXSDKManagerHandler.Instance.IsCloudTest())
        {
            m_triangleRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");

            m_renderTexturesCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Render Textures Count");
            m_RenderTexturesBytes = ProfilerRecorder.StartNew(ProfilerCategory.Render,"Render Textures Bytes");
            m_BatchesCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Batches Count");
            m_ShadowCastersCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Shadow Casters Count");
            m_VisibleSkinnedMeshesCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Visible Skinned Meshes Count");
            m_RenderTexturesChangesCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Render Textures Changes Count");
            m_UsedBuffersCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Used Buffers Count");
            m_UsedBuffersBytes = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Used Buffers Bytes");
            m_VertexBufferUploadInFrameCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertex Buffer Upload In Frame Count");
            m_VertexBufferUploadInFrameBytes = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Vertex Buffer Upload In Frame Bytes");
            m_IndexBufferUploadInFrameCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Index Buffer Upload In Frame Count");
            m_IndexBufferUploadInFrameBytes = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Index Buffer Upload In Frame Bytes");
        }
        
#endif

    }

    public void OnDisable()
    {
#if UNITY_2021_2_OR_NEWER
        // m_totalUsedMemoryRecorder.Dispose();
        // m_totalReservedMemoryRecorder.Dispose();
        // m_gcUsedMemoryRecorder.Dispose();
        // m_gcReservedMemoryRecorder.Dispose();
        // m_gfxUsedMemoryRecorder.Dispose();
        // m_gfxReservedMemoryRecorder.Dispose();
        // m_systemUsedMemoryRecorder.Dispose();
        // m_textureCountRecorder.Dispose();
        // m_textureMemoryRecorder.Dispose();
        // m_meshCountRecorder.Dispose();
        // m_meshMemoryRecorder.Dispose();
        // m_materialCountRecorder.Dispose();
        // m_materialMemoryRecorder.Dispose();
        // m_animationClipCountRecorder.Dispose();
        // m_animationClipMemoryRecorder.Dispose();
        // m_assetCountRecorder.Dispose();
        // m_gameObjectsInScenesRecorder.Dispose();
        // m_totalObjectsInScenesRecorder.Dispose();
        // m_totalUnityObjectCountRecorder.Dispose();
        // m_gcAllocationInFrameCountRecorder.Dispose();
        // m_gcAllocatedInFrameRecorder.Dispose();
        m_setPassCallsRecorder.Dispose();
        m_drawCallsRecorder.Dispose();
        m_verticesRecorder.Dispose();
        if (WeChatWASM.WXSDKManagerHandler.Instance.IsCloudTest())
        {
            m_triangleRecorder.Dispose();
            m_renderTexturesCount.Dispose();
            m_RenderTexturesBytes.Dispose();
            m_BatchesCount.Dispose();
            m_ShadowCastersCount.Dispose();
            m_VisibleSkinnedMeshesCount.Dispose();
            m_RenderTexturesChangesCount.Dispose();
            m_UsedBuffersCount.Dispose();
            m_UsedBuffersBytes.Dispose();
            m_VertexBufferUploadInFrameCount.Dispose();
            m_VertexBufferUploadInFrameBytes.Dispose();
            m_IndexBufferUploadInFrameCount.Dispose();
            m_IndexBufferUploadInFrameBytes.Dispose();
        }
#endif
    }

    public class ProfValue
    {
        public float current;
        public float max = 0;
        public float min = 9999;

        // public int avrage;
    }

    public ProfValue UpdateValue(string key, float value, StringBuilder sb, string format = "0")
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
        sb.AppendLine($"{key}:[{profValue.current.ToString(format)}, {profValue.min.ToString(format)}, {profValue.max.ToString(format)}]");
        return profValue;
    }

    public void Update()
    {
        UpdateFps();
        const uint toMB = 1024 * 1024;
        var sb = new StringBuilder(500);
        sb.AppendLine($"-------------FPS---------------");

        // var key = "targetFrameRate";
        UpdateValue("TargetFramerate", Application.targetFrameRate, sb);
        UpdateValue("FPS", fps, sb);
        UpdateValue("FrameTime(ms)", WeChatWASM.WXSDKManagerHandler.Instance.GetEXFrameTime(), sb, "0.00");

        sb.AppendLine($"-------------Profiler------------");

        UpdateValue("MonoHeapReserved", Profiler.GetMonoHeapSizeLong() / toMB, sb);
        UpdateValue("MonoHeapUsed", Profiler.GetMonoUsedSizeLong() / toMB, sb);

        // UpdateValue("Graphics", Profiler.GetAllocatedMemoryForGraphicsDriver() / toMB, sb);

        // UpdateValue("TempAllocator", Profiler.GetTempAllocatorSize() / toMB, sb);
        UpdateValue("NativeReserved", Profiler.GetTotalReservedMemoryLong() / toMB, sb);
        UpdateValue("NativeUnused", Profiler.GetTotalUnusedReservedMemoryLong() / toMB, sb);
        UpdateValue("NativeAllocated", Profiler.GetTotalAllocatedMemoryLong() / toMB, sb);

#if UNITY_2021_2_OR_NEWER
        sb.AppendLine("-------------Render------------");
        UpdateValue("SetPass Calls", m_setPassCallsRecorder.LastValue, sb);
        UpdateValue("Draw Calls", m_drawCallsRecorder.LastValue, sb);
        UpdateValue("Vertices", m_verticesRecorder.LastValue, sb);
#endif
        sb.AppendLine("-------------WebAssembly----------");
        UpdateValue("TotalHeapMemory", WeChatWASM.WXSDKManagerHandler.Instance.GetTotalMemorySize() / toMB, sb);
        UpdateValue("DynamicMemory", WeChatWASM.WXSDKManagerHandler.Instance.GetDynamicMemorySize() / toMB, sb);
        UpdateValue("UsedHeap(ProfilingMemory only)", WeChatWASM.WXSDKManagerHandler.Instance.GetUsedMemorySize() / toMB, sb);
        UpdateValue("UnAllocatedMemory", WeChatWASM.WXSDKManagerHandler.Instance.GetUnAllocatedMemorySize() / toMB, sb);

        sb.AppendLine("-------------AssetBundle----------");
        UpdateValue("NumberInMemory", WeChatWASM.WXSDKManagerHandler.Instance.GetBundleNumberInMemory(), sb);
        UpdateValue("NumberOnDisk", WeChatWASM.WXSDKManagerHandler.Instance.GetBundleNumberOnDisk(), sb);
        UpdateValue("SizeInMemory", WeChatWASM.WXSDKManagerHandler.Instance.GetBundleSizeInMemory() / toMB, sb);
        UpdateValue("SizeOnDisk", WeChatWASM.WXSDKManagerHandler.Instance.GetBundleSizeOnDisk() / toMB, sb);

#if UNITY_2021_2_OR_NEWER
        // sb.AppendLine("-------------MemoryRecorder-----");
        // UpdateValue("Total Used Memory", m_totalUsedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Total Reserved Memory", m_totalReservedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("GC Used Memory", m_gcUsedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("GC Reserved Memory", m_gcReservedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Gfx Used Memory", m_gfxUsedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Gfx Reserved Memory", m_gfxReservedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("System Used Memory", m_systemUsedMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Texture Count", m_textureCountRecorder.LastValue, sb);
        // UpdateValue("Texture Memory", m_textureMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Mesh Count", m_meshCountRecorder.LastValue, sb);
        // UpdateValue("Mesh Memory", m_meshMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Material Count", m_materialCountRecorder.LastValue, sb);
        // UpdateValue("Material Memory", m_materialMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("AnimationClip Count", m_animationClipCountRecorder.LastValue, sb);
        // UpdateValue("AnimationClip Memory", m_animationClipMemoryRecorder.LastValue / toMB, sb);
        // UpdateValue("Asset Count", m_assetCountRecorder.LastValue, sb);
        // UpdateValue("GameObject Count", m_gameObjectsInScenesRecorder.LastValue, sb);
        // UpdateValue("Scene Object Count", m_totalObjectsInScenesRecorder.LastValue, sb);
        // UpdateValue("Object Count", m_totalUnityObjectCountRecorder.LastValue, sb);
        // UpdateValue("GC Allocation In Frame Count", m_gcAllocationInFrameCountRecorder.LastValue, sb);
        // UpdateValue("GC Allocated In Frame", m_gcAllocatedInFrameRecorder.LastValue / toMB, sb);
#endif
        statsText = sb.ToString();
    }

    public void UpdateFps()
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

    public void OnGUI()
    {   
        // 云测环境不展示profile stats的界面
        if(!WeChatWASM.WXSDKManagerHandler.Instance.IsCloudTest()) {
            GUI.backgroundColor = new Color(0, 0, 0, 0.5f);
#if UNITY_EDITOR
            GUI.skin.button.fontSize = 10;
            GUI.skin.label.fontSize = 10;
#else
            GUI.skin.button.fontSize = 30;
            GUI.skin.label.fontSize = 30;
#endif
            if (GUILayout.Button("Performance Stats", GUILayout.ExpandWidth(false)))
            {
                m_isShow = !m_isShow;
            }

            if (GUILayout.Button("ProfilingMemory Dump", GUILayout.ExpandWidth(false)))
            {
                WeChatWASM.WXSDKManagerHandler.Instance.ProfilingMemoryDump();
            }

            GUILayout.BeginVertical(m_bgStyle);
            if (m_isShow)
            {
                GUILayout.Label(statsText);
            }

            GUILayout.EndVertical();
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnGameLaunch()
    {
        WeChatWASM.WXSDKManagerHandler.SetProfileStatsScript(typeof(WXProfileStatsScript));
    }

    public string GetProfileStatsDatas()
    {
        const uint toMB = 1024 * 1024;
        Dictionary<string, long> _profileDatasDic = new Dictionary<string, long>();
        _profileDatasDic.Add("MonoHeapReserved", Profiler.GetMonoHeapSizeLong() / toMB);
        _profileDatasDic.Add("MonoHeapUsed", Profiler.GetMonoUsedSizeLong() / toMB);
        _profileDatasDic.Add("NativeReserved", Profiler.GetTotalReservedMemoryLong() / toMB);
        _profileDatasDic.Add("NativeUnused", Profiler.GetTotalUnusedReservedMemoryLong() / toMB);
        _profileDatasDic.Add("NativeAllocated", Profiler.GetTotalAllocatedMemoryLong() / toMB);

#if UNITY_2021_2_OR_NEWER
        _profileDatasDic.Add("SetPassCalls", m_setPassCallsRecorder.LastValue);
        _profileDatasDic.Add("DrawCalls",  m_drawCallsRecorder.LastValue);
        _profileDatasDic.Add("Vertices",  m_verticesRecorder.LastValue);
        if (WeChatWASM.WXSDKManagerHandler.Instance.IsCloudTest())
        {
            _profileDatasDic.Add("Triangles",  m_triangleRecorder.LastValue);
            _profileDatasDic.Add("renderTexturesCount", m_renderTexturesCount.LastValue);
            _profileDatasDic.Add("RenderTexturesBytes", m_RenderTexturesBytes.LastValue);
            _profileDatasDic.Add("BatchesCount", m_BatchesCount.LastValue);
            _profileDatasDic.Add("ShadowCastersCount", m_ShadowCastersCount.LastValue);
            _profileDatasDic.Add("VisibleSkinnedMeshesCount", m_VisibleSkinnedMeshesCount.LastValue);
            _profileDatasDic.Add("RenderTexturesChangesCount", m_RenderTexturesChangesCount.LastValue);
            _profileDatasDic.Add("UsedBuffersCount", m_UsedBuffersCount.LastValue);
            _profileDatasDic.Add("UsedBuffersBytes", m_UsedBuffersBytes.LastValue);
            _profileDatasDic.Add("VertexBufferUploadInFrameCount", m_VertexBufferUploadInFrameCount.LastValue);
            _profileDatasDic.Add("VertexBufferUploadInFrameBytes", m_VertexBufferUploadInFrameBytes.LastValue);
            _profileDatasDic.Add("IndexBufferUploadInFrameCount", m_IndexBufferUploadInFrameCount.LastValue);
            _profileDatasDic.Add("IndexBufferUploadInFrameBytes", m_IndexBufferUploadInFrameBytes.LastValue);
        }
        
#endif
        return JsonMapper.ToJson(_profileDatasDic);;
    }

}
#endif
