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

    // �����ת����
    [SerializeField]
    private float randomXRotationRange = 0f;
    [SerializeField]
    private float randomYRotationRange = 0f;
    [SerializeField]
    private float randomZRotationRange = 0f;

    [MenuItem("Tools/�ֲ�����/��AABB�ھ��ȷֲ�")]
    static void Init()
    {
        // ��ȡ�򴴽��༭������
        DistributeInAABB window = (DistributeInAABB)EditorWindow.GetWindow(typeof(DistributeInAABB));
        window.titleContent = new GUIContent("AABB�ֲ�����");
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("���ȷֲ�ѡ������", EditorStyles.boldLabel);

        distributionScale = EditorGUILayout.Slider(
            new GUIContent("�ֲ�����", "���Ʒֲ���Χ�����ű���"),
            distributionScale,
            0.1f,
            5.0f
        );

        useCustomBounds = EditorGUILayout.Toggle("ʹ���Զ��巶Χ", useCustomBounds);
        if (useCustomBounds)
        {
            GUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("�Զ����Χ�з�Χ", EditorStyles.boldLabel);
            customBoundsMin = EditorGUILayout.Vector3Field("Min", customBoundsMin);
            customBoundsMax = EditorGUILayout.Vector3Field("Max", customBoundsMax);
            GUILayout.EndVertical();

            // �Զ�����Center��Size������Bounds���죩
            Vector3 center = (customBoundsMin + customBoundsMax) * 0.5f;
            Vector3 size = customBoundsMax - customBoundsMin;
            customBounds = new Bounds(center, size);
        }

        GUILayout.Space(10);
        GUILayout.BeginVertical("Box");
        GUILayout.Label("��ת����", EditorStyles.boldLabel);

        // ��׼��ת��ʾ
        EditorGUILayout.LabelField("��׼��ת", "X:270��, Y:0��, Z:0��");

        // �����ת��Χ����
        randomXRotationRange = EditorGUILayout.Slider(
            new GUIContent("X�������Χ", "X����ת���ƫ������Χ����������"),
            randomXRotationRange,
            0f,
            180f);

        randomYRotationRange = EditorGUILayout.Slider(
            new GUIContent("Y�������Χ", "Y����ת���ƫ������Χ����������"),
            randomYRotationRange,
            0f,
            180f);

        randomZRotationRange = EditorGUILayout.Slider(
            new GUIContent("Z�������Χ", "Z����ת���ƫ������Χ����������"),
            randomZRotationRange,
            0f,
            180f);

        GUILayout.EndVertical();

        if (GUILayout.Button("���ȷֲ�"))
        {
            DistributeSelectedObjects();
        }
    }

    void DistributeSelectedObjects()
    {
        // ��ȡѡ�е�����GameObject
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length < 2)
        {
            Debug.LogWarning("������ѡ��2��������зֲ�");
            return;
        }

        // �������ж���İ�Χ��
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

        // ����ֲ�����
        int count = selectedObjects.Length;
        Vector3 size = bounds.size * distributionScale;  // Ӧ������ϵ��
        Vector3 startPos = bounds.center - size * 0.5f;  // �������ĵ㲻��

        // ����ÿά�ȵķֲ�����
        int xCount = Mathf.CeilToInt(Mathf.Pow(count, 1f / 3f));
        int yCount = Mathf.CeilToInt(Mathf.Pow(count, 1f / 3f));
        int zCount = Mathf.CeilToInt(count / (float)(xCount * yCount));

        // ���㲽��
        Vector3 step = new Vector3(
            xCount > 1 ? size.x / (xCount - 1) : 0,
            yCount > 1 ? size.y / (yCount - 1) : 0,
            zCount > 1 ? size.z / (zCount - 1) : 0
        );

        // ��˳��ֲ�����
        int index = 0;
        for (int z = 0; z < zCount && index < count; z++)
        {
            for (int y = 0; y < yCount && index < count; y++)
            {
                for (int x = 0; x < xCount && index < count; x++)
                {
                    // �������ƫ����
                    float xOffset = Random.Range(-randomXRotationRange, randomXRotationRange);
                    float yOffset = Random.Range(-randomYRotationRange, randomYRotationRange);
                    float zOffset = Random.Range(-randomZRotationRange, randomZRotationRange);



                    Vector3 newPos = startPos + new Vector3(x * step.x, y * step.y, z * step.z);
                    selectedObjects[index].transform.position = newPos;

                    // Ӧ�û�׼��ת+���ƫ��
                    selectedObjects[index].transform.rotation = Quaternion.Euler(
                        270 + xOffset,  // ��׼X��270��
                        0 + yOffset,    // ��׼Y��0��
                        0 + zOffset     // ��׼Z��0��
                    );
                    index++;
                }
            }
        }

        Debug.Log($"�ѽ� {count} ��������ȷֲ���AABB������");
    }
}