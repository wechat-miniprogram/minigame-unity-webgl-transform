using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TouchTest : MonoBehaviour, 
    IPointerDownHandler, 
    IDragHandler, 
    IPointerUpHandler,
    IBeginDragHandler,
    IEndDragHandler
{
    [SerializeField] private Canvas canvas; // 通过Inspector面板拖拽赋值
    private Dictionary<int, List<GameObject>> touchCircles = new Dictionary<int, List<GameObject>>();
    // 移除currentPointerId字段，改为完全依赖touchCircles字典管理所有触点

    void Start()
    {
        Debug.Log("TouchTest脚本初始化开始");
        
        // 确保Canvas设置正确
        if (canvas == null)
        {
            Debug.Log("未指定Canvas，尝试自动查找...");
            canvas = FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("未找到Canvas，请在场景中创建Canvas并拖拽赋值");
                enabled = false;
                return;
            }
            Debug.Log($"已自动找到Canvas: {canvas.name}");
        }
        
        // 确保Canvas有GraphicRaycaster组件
        if (!canvas.TryGetComponent<GraphicRaycaster>(out var raycaster))
        {
            Debug.Log("Canvas缺少GraphicRaycaster，正在添加...");
            raycaster = canvas.gameObject.AddComponent<GraphicRaycaster>();
            Debug.Log($"已添加GraphicRaycaster: {raycaster != null}");
        }

        // 确保EventSystem设置正确
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            Debug.Log("未找到EventSystem，正在创建...");
            eventSystem = new GameObject("EventSystem").AddComponent<EventSystem>();
            var inputModule = eventSystem.gameObject.AddComponent<StandaloneInputModule>();
            Debug.Log($"已创建EventSystem和StandaloneInputModule: {inputModule != null}");
        }
        else if (eventSystem.GetComponent<StandaloneInputModule>() == null)
        {
            Debug.Log("EventSystem缺少StandaloneInputModule，正在添加...");
            var inputModule = eventSystem.gameObject.AddComponent<StandaloneInputModule>();
            Debug.Log($"已添加StandaloneInputModule: {inputModule != null}");
        }

        // 确保脚本挂载在可接收事件的UI对象上
        if (!TryGetComponent<Graphic>(out var graphic))
        {
            Debug.Log("当前对象缺少Graphic组件，正在添加透明Image...");
            var image = gameObject.AddComponent<Image>();
            // image.color = new Color(0, 0, 0, 0.01f);
            image.raycastTarget = true; // 确保能接收事件
            Debug.Log($"已添加Image组件，raycastTarget: {image.raycastTarget}");
        }
        else
        {
            graphic.raycastTarget = true; // 确保现有Graphic能接收事件
            Debug.Log($"已确保Graphic组件raycastTarget为true: {graphic.raycastTarget}");
        }

        // 确保RectTransform覆盖整个屏幕
        var rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.sizeDelta = Vector2.zero;
            Debug.Log("已设置RectTransform为全屏覆盖");
        }

        Debug.Log("TouchTest脚本初始化完成");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"OnPointerDown - 指针ID: {eventData.pointerId}, 位置: {eventData.position}, 按下按钮: {eventData.button}");
        HandlePointerEvent(eventData, 1.0f); // 初始点使用完整大小
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 拖动开始时创建新圆点
        HandlePointerEvent(eventData, 0.5f); // 拖动点使用半大小
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 拖动过程中持续创建新圆点
        HandlePointerEvent(eventData, 0.5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 指针抬起时清除对应圆点
        HandlePointerEnd(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖动结束时清除对应圆点
        HandlePointerEnd(eventData);
    }

    void HandlePointerEvent(PointerEventData eventData, float scale)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, 
            eventData.position, 
            canvas.worldCamera, 
            out localPoint);

        // 如果是新触点，创建新颜色圆点
        if (!touchCircles.ContainsKey(eventData.pointerId))
        {
            touchCircles[eventData.pointerId] = new List<GameObject>();
            GameObject newCircle = CreateCircle(localPoint, GetRandomColor(), 1.0f);
            touchCircles[eventData.pointerId].Add(newCircle);
        }
        else
        {
            // 已有触点则使用相同颜色创建新圆点
            Color circleColor = touchCircles[eventData.pointerId][0].GetComponent<Image>().color;
            GameObject newCircle = CreateCircle(localPoint, circleColor, scale);
            touchCircles[eventData.pointerId].Add(newCircle);
        }
    }

    void HandlePointerEnd(PointerEventData eventData)
    {
        if (touchCircles.ContainsKey(eventData.pointerId))
        {
            foreach (GameObject circle in touchCircles[eventData.pointerId])
            {
                Destroy(circle);
            }
            touchCircles.Remove(eventData.pointerId);
        }
    }

    GameObject CreateCircle(Vector2 position, Color color, float scale)
    {
        GameObject circle = new GameObject("Circle");
        circle.transform.SetParent(canvas.transform, false);

        Image image = circle.AddComponent<Image>();
        image.color = color;

        RectTransform rectTransform = circle.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 100) * scale;
        rectTransform.anchoredPosition = position;

        return circle;
    }

    // 使用静态种子确保跨平台一致性
    private System.Random _random = new System.Random();
    
    Color GetRandomColor()
    {
        // 使用System.Random替代Unity的Random.value
        float h = (float)_random.NextDouble();
        float s = 0.7f + (float)_random.NextDouble() * 0.3f; // 饱和度0.7-1.0
        float v = 0.8f + (float)_random.NextDouble() * 0.2f; // 明度0.8-1.0
        
        Color color = Color.HSVToRGB(h, s, v);
        color.a = 0.8f;
        
        // WebGL下强制刷新颜色
        #if UNITY_WEBGL
        color = new Color(color.r, color.g, color.b, color.a);
        #endif
        
        return color;
    }
}
