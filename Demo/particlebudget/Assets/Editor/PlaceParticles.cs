using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DistributeInAABB : EditorWindow
{
    private float distributionScale = 1.0f;

    [SerializeField]
    private bool useCustomBounds = false;
    private Bounds customBounds = new Bounds(Vector3.zero, Vector3.one);

    [SerializeField]
    private Vector3 customBoundsMin = Vector3.zero;
    [SerializeField]
    private Vector3 customBoundsMax = Vector3.one;

    // 随机旋转参数
    [SerializeField]
    private float randomXRotationRange = 0f;
    [SerializeField]
    private float randomYRotationRange = 0f;
    [SerializeField]
    private float randomZRotationRange = 0f;

    [MenuItem("Tools/分布工具/在AABB内均匀分布")]
    static void Init()
    {
        // 获取或创建编辑器窗口
        DistributeInAABB window = (DistributeInAABB)EditorWindow.GetWindow(typeof(DistributeInAABB));
        window.titleContent = new GUIContent("AABB分布工具");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("均匀分布选定对象", EditorStyles.boldLabel);

        distributionScale = EditorGUILayout.Slider(
            new GUIContent("分布缩放", "控制分布范围的缩放比例"),
            distributionScale,
            0.1f,
            5.0f
        );

        useCustomBounds = EditorGUILayout.Toggle("使用自定义范围", useCustomBounds);
        if (useCustomBounds)
        {
            GUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("自定义包围盒范围", EditorStyles.boldLabel);
            customBoundsMin = EditorGUILayout.Vector3Field("Min", customBoundsMin);
            customBoundsMax = EditorGUILayout.Vector3Field("Max", customBoundsMax);
            GUILayout.EndVertical();

            // 自动计算Center和Size（用于Bounds构造）
            Vector3 center = (customBoundsMin + customBoundsMax) * 0.5f;
            Vector3 size = customBoundsMax - customBoundsMin;
            customBounds = new Bounds(center, size);
        }

        GUILayout.Space(10);
        GUILayout.BeginVertical("Box");
        GUILayout.Label("旋转设置", EditorStyles.boldLabel);

        // 基准旋转显示
        EditorGUILayout.LabelField("基准旋转", "X:270°, Y:0°, Z:0°");

        // 随机旋转范围输入
        randomXRotationRange = EditorGUILayout.Slider(
            new GUIContent("X轴随机范围", "X轴旋转随机偏移量范围（±度数）"),
            randomXRotationRange,
            0f,
            180f);

        randomYRotationRange = EditorGUILayout.Slider(
            new GUIContent("Y轴随机范围", "Y轴旋转随机偏移量范围（±度数）"),
            randomYRotationRange,
            0f,
            180f);

        randomZRotationRange = EditorGUILayout.Slider(
            new GUIContent("Z轴随机范围", "Z轴旋转随机偏移量范围（±度数）"),
            randomZRotationRange,
            0f,
            180f);

        GUILayout.EndVertical();

        if (GUILayout.Button("均匀分布"))
        {
            DistributeSelectedObjects();
        }
    }

    void DistributeSelectedObjects()
    {
        // 获取选中的所有GameObject
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length < 2)
        {
            Debug.LogWarning("请至少选择2个对象进行分布");
            return;
        }

        // 计算所有对象的包围盒
        Bounds bounds;

        if (useCustomBounds)
        {
            bounds = customBounds;
        }
        else
        {
            bounds = new Bounds(selectedObjects[0].transform.position, Vector3.zero);
            foreach (var obj in selectedObjects)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    bounds.Encapsulate(renderer.bounds);
                }
                else
                {
                    bounds.Encapsulate(obj.transform.position);
                }
            }
        }

        // 计算分布参数
        int count = selectedObjects.Length;
        Vector3 size = bounds.size * distributionScale;  // 应用缩放系数
        Vector3 startPos = bounds.center - size * 0.5f;  // 保持中心点不变

        // 计算每维度的分布数量
        int xCount = Mathf.CeilToInt(Mathf.Pow(count, 1f / 3f));
        int yCount = Mathf.CeilToInt(Mathf.Pow(count, 1f / 3f));
        int zCount = Mathf.CeilToInt(count / (float)(xCount * yCount));

        // 计算步长
        Vector3 step = new Vector3(
            xCount > 1 ? size.x / (xCount - 1) : 0,
            yCount > 1 ? size.y / (yCount - 1) : 0,
            zCount > 1 ? size.z / (zCount - 1) : 0
        );

        // 按顺序分布对象
        int index = 0;
        for (int z = 0; z < zCount && index < count; z++)
        {
            for (int y = 0; y < yCount && index < count; y++)
            {
                for (int x = 0; x < xCount && index < count; x++)
                {
                    // 生成随机偏移量
                    float xOffset = Random.Range(-randomXRotationRange, randomXRotationRange);
                    float yOffset = Random.Range(-randomYRotationRange, randomYRotationRange);
                    float zOffset = Random.Range(-randomZRotationRange, randomZRotationRange);



                    Vector3 newPos = startPos + new Vector3(x * step.x, y * step.y, z * step.z);
                    selectedObjects[index].transform.position = newPos;

                    // 应用基准旋转+随机偏移
                    selectedObjects[index].transform.rotation = Quaternion.Euler(
                        270 + xOffset,  // 基准X轴270度
                        0 + yOffset,    // 基准Y轴0度
                        0 + zOffset     // 基准Z轴0度
                    );
                    index++;
                }
            }
        }

        Debug.Log($"已将 {count} 个对象均匀分布在AABB区域内");
    }
}