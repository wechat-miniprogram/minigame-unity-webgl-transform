using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson; //LisJson支持vector3等 https://www.cnblogs.com/msxh/p/12541159.html
using System.Runtime.InteropServices;
#if UNITY_UI_FAIRYGUI
using FairyGUI;
#endif
namespace WeChatWASM
{

    public class UnityDumper : MonoBehaviour {

        public class CObjectData
        {
            public string url;
            public string format;
            public string name;
            public long cpuMemory;
        }
    #if UNITY_WEBGL
        [DllImport("__Internal")]
    #endif
        private static extern void DumpUICallback(string str);

    #if UNITY_WEBGL
        [DllImport("__Internal")]
     #endif
        private static extern void GetScreenSizeCallback(int width, int height);

    #if UNITY_WEBGL
        [DllImport("__Internal")]
    #endif
        private static extern void GetUnityVersionCallback(string version);

    #if UNITY_WEBGL
        [DllImport("__Internal")]
    #endif
        private static extern void GetUnityFrameRateCallback(int rate);

    #if UNITY_WEBGL
        [DllImport("__Internal")]
    #endif
        private static extern void GetUnityCacheDetailCallback(string str);

        public static int index = 1;
        private static string sceneName = "";
        private static Camera cam;
        private static long allMemory = 0;

    #if UNITY_UI_UGUI
        public static string platform = "ugui";
    #elif UNITY_UI_NGUI
        public static string platform = "ngui";
    #elif UNITY_UI_FAIRYGUI
        public static string platform = "fairygui";
    #else
        public static string platform = "undefined";
    #endif

        public void getNowScenesComponents() {
            if(platform == "undefined") {
                DumpUICallback("");
            }

            Debug.Log("getNowScenesComponents");
            cam = Camera.main;
            List<Node> forest = new List<Node>();
            Scene scene = SceneManager.GetActiveScene();
            sceneName = scene.name;
            if(sceneName.Length == 0) {
                sceneName = "default";
            }
            index = 1;
            foreach (GameObject rootObj in scene.GetRootGameObjects()) {
                if (rootObj.transform.parent == null) {
                    // Debug.Log(rootObj.name + ":" + rootObj.GetType().Name);
                     Node node = new Node(rootObj, "0");
                     forest.Add(node);
                }
            }

            Node rootNode = new Node("root", forest);
            // WriteFileByLine (Application.persistentDataPath,String.Format("tree_{0}.txt", 0), JsonMapper.ToJson(rootNode));

            // var countI = 0;
            // Debug.Log(Application.persistentDataPath);
            // foreach(string str in forest) {
            //     WriteFileByLine (Application.persistentDataPath,String.Format("tree_{0}.txt", countI), str);
            //     countI++;
            // }
            // Debug.Log(JsonMapper.ToJson(rootNode));
            DumpUICallback(JsonMapper.ToJson(rootNode));
        }

        private static Canvas GetRootCanvas(GameObject gameObject){
            Canvas canvas = gameObject.GetComponentInParent<Canvas>();
            // 如果unity版本小于unity5.5，就用递归的方式取吧，没法直接取rootCanvas
            // 如果有用到4.6以下版本的话就自己手动在这里添加条件吧
    #if UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4
            if (canvas && canvas.isRootCanvas) {
                return canvas;
            } else {
                if (gameObject.transform.parent.gameObject != null) {
                    return GetRootCanvas(gameObject.transform.parent.gameObject);
                } else {
                    return null;
                }
            }
    #else
            if (canvas && canvas.isRootCanvas){
                return canvas;
            }
            else if (canvas) {
                return canvas.rootCanvas;
            }
            else {
                return null;
            }
    #endif
        }

        private void WriteFileByLine(string file_path,string file_name,string str_info)  {
            StreamWriter sw;
            if(!File.Exists(file_path+"//"+file_name)) {
                sw=File.CreateText(file_path+"//"+file_name);//创建一个用于写入 UTF-8 编码的文本
                Debug.Log("文件创建成功！");
            }  else  {
                sw=File.AppendText(file_path+"//"+file_name);//打开现有 UTF-8 编码文本文件以进行读取
            }
            sw.WriteLine(str_info);//以行为单位写入字符串
            sw.Close ();
            sw.Dispose ();//文件流释放
        }


        private class Node {
            public string id;
            public string name;
            public Feature feature;
            public Rect originalPosition;
            public int childrenCount;
            public Rect position;
            public int z;
            public string zPath = "";

            public List<Node> children = new List<Node>();
            public bool show = false;
            public bool enable = false;
            public bool useless = true;
            public bool visible = false;
            public List<string> components = new List<string>();

            //根节点的构造函数
            public Node(string name, List<Node> children){
                this.name = name;
                this.zPath = "0";
                this.children = children;
                this.childrenCount = children.Count;
                this.z = 0;
                this.id = "root";
            }

    #if UNITY_UI_FAIRYGUI
            public Dictionary<string, Dictionary<string, bool>> actionInfo = new Dictionary<string, Dictionary<string, bool>>();
    #else
            public string action_info = "#todo";
    #endif

    #if UNITY_UI_FAIRYGUI
            public Node(GObject obj, string zPath) {
                List<string> GComponentList = new List<string>{"GComponent", "GButton", "GComboBox", "GLabel", "GList", "GProgressBar", "GRoot", "GScrollBar", "GSlider", "Window"};
                this.feature = new Feature(obj);
                this.z = index;
                index++;
                this.zPath = zPath.Length > 0 ? zPath + "_" + this.z.ToString(): this.z.ToString();
                this.id = sceneName + ":" + feature.className + ":" + feature.tag + ":" + obj.id;
                name = obj.name;
                childrenCount = 0;
                enable = obj.enabled;
                visible = obj.visible;
                originalPosition = feature.rect;
                actionInfo = new Dictionary<string, Dictionary<string, bool>>();
                var eventList = new Dictionary<string, bool>();
                bool hasEvent = false;
                if(!obj.onClick.isEmpty) {
                    eventList.Add("onClick", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onClick", false);
                }

                if(!obj.onDragMove.isEmpty){
                    eventList.Add("onDragMove", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onDragMove", false);
                }

                if(!obj.onDragEnd.isEmpty){
                    eventList.Add("onDragEnd", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onDragEnd", false);
                }

                if(!obj.onDragStart.isEmpty){
                    eventList.Add("onDragStart", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onDragStart", false);
                }

                if(!obj.onKeyDown.isEmpty){
                    eventList.Add("onKeyDown", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onKeyDown", false);
                }

                if(!obj.onRightClick.isEmpty){
                    eventList.Add("onRightClick", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onRightClick", false);
                }

                if(!obj.onTouchBegin.isEmpty){
                    eventList.Add("onTouchBegin", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onTouchBegin", false);
                }

                if(!obj.onTouchEnd.isEmpty){
                    eventList.Add("onTouchEnd", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onTouchEnd", false);
                }

                if(!obj.onTouchMove.isEmpty){
                    eventList.Add("onTouchMove", true);
                    hasEvent = true;
                } else {
                    eventList.Add("onTouchMove", false);
                }
                actionInfo.Add("eventList", eventList);

                if(hasEvent && visible && enable){
                    enable = true;
                }else{
                    enable = false;
                }
                useless = !enable;

                //fairygui坐标系以左上角为(0,0)，往右为x正方向，往下位y正方向
                position = new Rect(feature.rect.x, feature.rect.y, feature.rect.width, feature.rect.height);

                //只有特定几类的ui才有children，其他的没有
                if(GComponentList.Contains(feature.originalClassName)) {
                    GComponent tmpObj = (GComponent)obj;
                    childrenCount = tmpObj.numChildren;
                    foreach(GObject child in tmpObj.GetChildren()) {
                        Node childNode = new Node(child, this.zPath);
                        children.Add(childNode);
                    }
                }
            }
    #endif
            public Node(GameObject obj, string zPath) {
                if(platform == "undefined") {
                    Debug.Log("unsupport undefined platform");
                }
                this.feature = new Feature(obj);
                this.z = index;
                index++;
                this.zPath = zPath.Length > 0 ? zPath + "_" + this.z.ToString(): this.z.ToString();
                id =  sceneName + ":" + feature.className + ":" + feature.tag;
                name = obj.name;
                childrenCount = obj.transform.childCount;
                // unity坐标系转换为手机屏幕的坐标系
                position = new Rect(feature.rect.x, UnityEngine.Screen.height - feature.rect.y, feature.rect.width, feature.rect.height);
                show = (position.width > 0 && position.height > 0);
    #if UNITY_UI_UGUI
                Renderer render = obj.GetComponent<Renderer>();
                if (render != null) {
                    visible = render.enabled;
                } else {
                    visible = false;
                }

                Button button = obj.GetComponent<Button>();
                // useless = button ? button.Interactable : false;
                if (button != null) {
                    // ugui
                    useless = (button.interactable && button.isActiveAndEnabled) ? false : true; //isActiveAndEnabled=True 等同于 (activeInHierarchy=True and enabled=True)
                }

                if (!useless) {
                    //todo ugui的获取方法
                    this.enable = !button.IsDestroyed();
                } else{
                    this.enable = false;
                }

    #elif UNITY_UI_NGUI
                useless = true;
                if(feature.elementType == 1) {
                    visible = true;
                    this.enable = false;
                    UIToggle uitoggle = obj.GetComponent<UIToggle>();
                    if(uitoggle != null) {
                        useless = uitoggle.onChange.Count > 0 ? false : true;
                        this.enable = true;
                    }
                    UIButton uibutton = obj.GetComponent<UIButton>();
                    if(uibutton != null) {
                        useless = (uibutton.isEnabled) ? false : true;
                        this.enable = uibutton.isEnabled;
                    }
                }else if (feature.elementType == 0){
                    Renderer render = obj.GetComponent<Renderer>();
                    if (render != null) {
                        visible = render.enabled;
                    } else {
                        visible = false;
                    }
                    Button button = obj.GetComponent<Button>();
                    if (button != null) {
                        useless = (button.interactable && button.isActiveAndEnabled) ? false : true; //isActiveAndEnabled=True 等同于 (activeInHierarchy=True and enabled=True)
                    }
                    if(!useless){
                        this.enable = !button.IsDestroyed();
                    } else {
                        this.enable = false;
                    }
                } else{
                    visible = true;
                    EasyButton easyButton = obj.GetComponent<EasyButton>();
                    EasyJoystick easyJoystick = obj.GetComponent<EasyJoystick>();
                    if(easyButton != null) {
                        useless = (easyButton.isActivated) ? false : true;
                        enable = easyButton.enable;
                    }else if(easyJoystick != null){
                        visible = easyJoystick.visible;
                        enable = easyJoystick.enable;
                        useless = (easyJoystick.isActivated) ? false : true;
                    }else{
                        enable = false;
                    }

                }
    #endif

                Component[] allComponents = obj.GetComponents<Component>();
                if (allComponents != null)
                {
                    foreach (Component ac in allComponents)
                    {
                        if (ac != null)
                        {
                            string value = ac.ToString();
                            if(value.Length <= 1000){
                                components.Add(ac.ToString());
                            }
                        }
                    }
                }

    #if UNITY_UI_FAIRYGUI
                // 不再重复添加UIPanel的子节点，用fairygui的类能获取到的信息会更多
                if(name != "UIPanel") {
                    // 添加uigui的child node
                    Transform transforms = obj.transform;
                    for(int i = 0; i < childrenCount; i++) {
                        Transform childTransform = transforms.GetChild(i);
                        GameObject childGameObj = childTransform.gameObject;
                        Node childNode = new Node(childGameObj, this.zPath);
                        children.Add(childNode);
                    }
                } else {
                    // 添加fairygui的child node
                    UIPanel uiPanel = obj.GetComponent<UIPanel>();
                    if(uiPanel != null) {
                        GComponent ui = uiPanel.ui;
                        //更新childCount
                        childrenCount = ui.numChildren;
                        foreach(GObject child in ui.GetChildren()) {
                            Node childNode = new Node(child, this.zPath);
                            children.Add(childNode);
                        }
                    }
                }
    #else
                Transform transforms = obj.transform;
                for(int i = 0; i < childrenCount; i++) {
                    Transform childTransform = transforms.GetChild(i);
                    GameObject childGameObj = childTransform.gameObject;
                    Node childNode = new Node(childGameObj, this.zPath);
                    children.Add(childNode);
                }
    #endif
            }
        }

        private class Feature {
            public string className;
            public string tag;
            public Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
            public float scaleX = 1.0f, scaleY = 1.0f, scaleZ = 1.0f;
            public Vector3 rotation;
            public float rotationX, rotationY, rotationZ;
            public Rect rect;
            public Vector2 size = new Vector2(0.0f, 0.0f);
            public Vector2 anchorPoint = Vector2.zero; //(用pivot代替锚点)锚点介绍，暂时不适配stretch状态 https://www.cnblogs.com/Fflyqaq/p/12714387.html
            public Rect box;
            public float centerX = 0.0f;
            public float centerY = 0.0f;
            public float anchorX = 0.0f;
            public float anchorY = 0.0f;
            public string originalClassName;
            public float width  = 0.0f;
            public float height  = 0.0f;
            public bool activeInHierarchy;
            public bool activeSelf;
            public bool isStatic;

    #if UNITY_UI_FAIRYGUI
            public int blendMode = 1;
            public bool pivotAsAnchor = false;
            public bool grayed = false;
            public float alpha = 1.0f;
            public string text = "";
            public bool touchable = false;
    #endif

    #if UNITY_UI_NGUI
            public int elementType = 0; //0:ugui 1:ngui 2:EasyButton/EasyJoystick
    #endif

    #if UNITY_UI_FAIRYGUI
            public Feature(GObject obj) {
                tag = "untag";
                originalClassName = obj.GetType().Name;
                className = obj.GetType().Name + ":" + obj.name;
                text = obj.text != null ? obj.text : "";
                scale = new Vector3(obj.scaleX, obj.scaleY, 1);
                scaleX = obj.scaleX;
                scaleY = obj.scaleY;
                scaleZ = 1;
                touchable = obj.touchable;
                // width = obj.actualWidth; //actualHeight = height * scaleY
                // height = obj.actualHeight;

                blendMode = (int)obj.blendMode;
                pivotAsAnchor = obj.pivotAsAnchor;
                //与ugui对齐，所以要add2次
                anchorPoint = obj.pivot;
                anchorX = obj.pivotX;
                anchorY = obj.pivotY;
                rotation = new Vector3(obj.rotationX, obj.rotationY, obj.rotation);
                grayed = obj.grayed;
                Vector3 localPosition = obj.position;

                var position = Vector2.zero;
                width = obj.actualWidth;
                height = obj.actualHeight;
                // GGroup使用LocalToGlobal会报错System.NullReferenceException，暂时不知道怎么解决，做个保护
                if(originalClassName != "GGroup") {
                    position = obj.LocalToGlobal(Vector2.zero);
                    Rect tmpRect = obj.TransformRect(new Rect(0, 0, obj.actualWidth, obj.actualHeight), null);
                    width = tmpRect.width;
                    height = tmpRect.height;
                }
                centerX = position.x + (0.5f - anchorX) * width;
                centerY = position.y + (0.5f - anchorX) * height;

                float topX = position.x + (0.0f - anchorX) * width;
                float topY = position.y + (0.0f - anchorY) * height;

                rect = new Rect(topX, topY, width, height);
                box = rect;

                alpha = obj.alpha;
            }
    #endif

            public Feature(GameObject obj) {
                className = obj.GetType().Name + ":" + obj.name;
                tag = obj.tag;
                originalClassName = obj.GetType().Name;
                activeInHierarchy = obj.activeInHierarchy; //表示在场景中的active状态
                activeSelf = obj.activeSelf; //仅代表当前gameobject的active状态
                isStatic = obj.isStatic;
                Transform transform = obj.transform;
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                if (rectTransform != null) {
                    scale = rectTransform.lossyScale; //The global scale of the object (Read Only).
                    scaleX = scale.x;
                    scaleY = scale.y;
                    scaleZ = scale.z;
                    Vector2 size = Vector2.Scale(rectTransform.rect.size, scale);
                    width = size.x;
                    height = size.y;
                    anchorPoint = rectTransform.pivot;
                    anchorX = anchorPoint.x;
                    anchorY = anchorPoint.y;
                } else{
                    // Debug.Log("RectTransform is null");
                    anchorPoint = new Vector2(0.5f, 0.5f);
                }
                rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                rotationX = rotation.x;
                rotationY = rotation.y;
                rotationZ = rotation.z;

    #if UNITY_UI_UGUI

                //localPosition 本地坐标 position世界坐标
                //https://zhuanlan.zhihu.com/p/93813556

                Canvas rootCanvas = GetRootCanvas(obj);
                RenderMode renderMode = rootCanvas != null ? rootCanvas.renderMode : new RenderMode();

                float topX = 0.0f;
                float topY = 0.0f;
                if (renderMode == RenderMode.ScreenSpaceCamera) {
                    // 计算世界坐标右上角的点
                    float top_right_X = transform.position.x + (1.0f - anchorX) * width;
                    float top_right_Y = transform.position.y + (1.0f - anchorY) * height;
                    // 把右上角转为屏幕坐标
                    var screenPosition_top_right = RectTransformUtility.WorldToScreenPoint(cam, new Vector3(top_right_X, top_right_Y, transform.position.z));

                    // 计算世界坐标做下角的点
                    float bottom_left_X = transform.position.x + (0.0f - anchorX) * width;
                    float bottom_right_Y = transform.position.y + (0.0f - anchorY) * height;
                    // 把左下角转为屏幕坐标
                    var screenPosition_left_bottom = RectTransformUtility.WorldToScreenPoint(cam, new Vector3(bottom_left_X, bottom_right_Y, transform.position.z));

                    width = screenPosition_top_right.x - screenPosition_left_bottom.x;
                    height = screenPosition_top_right.y - screenPosition_left_bottom.y;

                    centerX = (screenPosition_top_right.x + screenPosition_left_bottom.x)/2;
                    centerY = (screenPosition_top_right.y + screenPosition_left_bottom.y)/2;

                    topX = screenPosition_left_bottom.x;
                    topY = screenPosition_top_right.y;
                } else if(renderMode == RenderMode.WorldSpace) {
                    topX = transform.position.x + (0.0f - anchorX) * width;
                    topY = UnityEngine.Screen.height - transform.position.y + (1.0f - anchorY) * height;
                } else {
                    topX = transform.position.x + (0.0f - anchorX) * width;
                    topY = transform.position.y + (1.0f - anchorY) * height;
                }

                rect = new Rect(topX, topY, width, height);
                // if(obj.name == "RestartButton"){
                //     switch(renderMode){
                //         case RenderMode.ScreenSpaceCamera:
                //             Debug.Log("RenderMode.ScreenSpaceCamera");
                //             break;
                //         case RenderMode.WorldSpace:
                //              Debug.Log("RenderMode.WorldSpace");
                //              break;
                //         default:
                //             Debug.Log("default");
                //             break;
                //     }
                //     Debug.Log(rect);
                // }

    #elif UNITY_UI_NGUI
                elementType = 0;
                UIRoot root = obj.GetComponentInParent(typeof(UIRoot)) as UIRoot;
                if(root == null) {
                    EasyButton tmpEasyButton = obj.GetComponentInParent(typeof(EasyButton)) as EasyButton;
                    EasyJoystick tmpEasyJoystick = obj.GetComponentInParent(typeof(EasyJoystick)) as EasyJoystick;
                    elementType = (tmpEasyButton != null || tmpEasyJoystick != null) ? 2 : elementType;
                } else {
                    elementType = (NGUITools.FindCameraForLayer(obj.layer) != null) ? 1 : elementType;
                }
                if(elementType == 0){
                    centerX = transform.position.x + (0.5f - anchorX) * width;
                    centerY = transform.position.y + (0.5f - anchorY) * height;

                    float topX = transform.position.x + (0.0f - anchorX) * width;
                    float topY = transform.position.y + (1.0f - anchorY) * height;

                    rect = new Rect(topX, topY, width, height);
                } else if (elementType == 1){
                    Camera camera = NGUITools.FindCameraForLayer(obj.layer);
                    Bounds bounds = NGUIMath.CalculateAbsoluteWidgetBounds(obj.transform);
                    Vector3 min = camera.WorldToScreenPoint(bounds.min);
                    Vector3 max = camera.WorldToScreenPoint(bounds.max);
                    width = max.x - min.x;
                    height = max.y - min.y;
                    centerX = min.x + width /2.0f;
                    centerY = min.y + height /2.0f;
                    rect = new Rect(min.x, min.y + height, width, height);
                } else {
                    EasyButton easyButton = obj.GetComponent(typeof(EasyButton)) as EasyButton;
                    EasyJoystick easyJoystick = obj.GetComponent(typeof(EasyJoystick)) as EasyJoystick;
                    if(easyButton != null) {
                        Rect tmpButtonRect = ComputeButtonAnchor(easyButton);
                        Rect buttonRect = VirtualScreen.GetRealRect(tmpButtonRect);
                        width = buttonRect.width;
                        height = buttonRect.height;
                        var topX = buttonRect.x;
                        //easyButton坐标系为左上角为0，0
                        var topY = UnityEngine.Screen.height - buttonRect.y;
                        rect = new Rect(topX, topY, width, height);
                    }else if(easyJoystick != null) {
                        Rect tmpAreaRect = ComputeJoystickAnchor(easyJoystick);
                        Rect areaRect = VirtualScreen.GetRealRect(tmpAreaRect);
                        width = areaRect.width;
                        height = areaRect.height;
                        var topX = areaRect.x;
                         //easyButton坐标系为左上角为0，0
                        var topY = UnityEngine.Screen.height - areaRect.y;
                        rect = new Rect(topX, topY, width, height);
                    }else {
                        rect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
                    }
                }
    #endif
                box = rect;
            }

    #if UNITY_UI_NGUI
            private Rect ComputeJoystickAnchor(EasyJoystick easyJoystick) {
                Rect areaRect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
                float touch=0;
                string anchor = string.Format("JoystickAnchor.{0}", easyJoystick.JoyAnchor.ToString());
                bool restrictArea = easyJoystick.RestrictArea;
                float touchSize = easyJoystick.TouchSize;
                float zoneRadius = easyJoystick.ZoneRadius;
                //joystickCenter先设为zero，看看是否有问题，有些实现会修改joystickCenter但先不做适配
                Vector2 joystickCenter = Vector2.zero;
                Vector2 anchorPosition = Vector2.zero;
                if (!restrictArea){
                    touch = touchSize;
                }
                // Anchor position
                switch (anchor){
                    case "JoystickAnchor.UpperLeft":
                        anchorPosition = new Vector2( zoneRadius+touch, zoneRadius+touch);
                        break;
                    case "JoystickAnchor.UpperCenter":
                        anchorPosition = new Vector2( VirtualScreen.width/2, zoneRadius+touch);
                        break;
                    case "JoystickAnchor.UpperRight":
                        anchorPosition = new Vector2( VirtualScreen.width-zoneRadius-touch,zoneRadius+touch);
                        break;

                    case "JoystickAnchor.MiddleLeft":
                        anchorPosition = new Vector2( zoneRadius+touch, VirtualScreen.height/2);
                        break;
                    case "JoystickAnchor.MiddleCenter":
                        anchorPosition = new Vector2( VirtualScreen.width/2, VirtualScreen.height/2);
                        break;
                    case "JoystickAnchor.MiddleRight":
                        anchorPosition = new Vector2( VirtualScreen.width-zoneRadius-touch,VirtualScreen.height/2);
                        break;

                    case "JoystickAnchor.LowerLeft":
                        anchorPosition = new Vector2( zoneRadius+touch, VirtualScreen.height-zoneRadius-touch);
                        break;
                    case "JoystickAnchor.LowerCenter":
                        anchorPosition = new Vector2( VirtualScreen.width/2, VirtualScreen.height-zoneRadius-touch);
                        break;
                    case "JoystickAnchor.LowerRight":
                        anchorPosition = new Vector2( VirtualScreen.width-zoneRadius-touch,VirtualScreen.height-zoneRadius-touch);
                        break;

                    case "JoystickAnchor.None":
                        anchorPosition = Vector2.zero;
                        break;
                }
                //joystick rect
                areaRect = new Rect(anchorPosition.x + joystickCenter.x -zoneRadius , anchorPosition.y+joystickCenter.y-zoneRadius,zoneRadius*2,zoneRadius*2);
                return areaRect;
            }


            private Rect ComputeButtonAnchor(EasyButton easyButton){
                Rect buttonRect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
                Texture2D normalTexture = easyButton.NormalTexture;
                Vector2 scale = easyButton.Scale;
                Vector2 offset = easyButton.Offset;
                string anchor = string.Format("ButtonAnchor.{0}", easyButton.Anchor.ToString());
                if (normalTexture!=null){
                    Vector2 buttonSize = new Vector2(normalTexture.width*scale.x, normalTexture.height*scale.y);
                    Vector2 anchorPosition = Vector2.zero;
                    // Anchor position
                    switch (anchor){
                        case "ButtonAnchor.UpperLeft":
                            anchorPosition = new Vector2( 0, 0);
                            break;
                        case "ButtonAnchor.UpperCenter":
                            anchorPosition = new Vector2( VirtualScreen.width/2- buttonSize.x/2, offset.y);
                            break;
                        case "ButtonAnchor.UpperRight":
                            anchorPosition = new Vector2( VirtualScreen.width-buttonSize.x ,0);
                            break;
                        case "ButtonAnchor.MiddleLeft":
                            anchorPosition = new Vector2( 0, VirtualScreen.height/2- buttonSize.y/2);
                            break;
                        case "ButtonAnchor.MiddleCenter":
                            anchorPosition = new Vector2( VirtualScreen.width/2- buttonSize.x/2, VirtualScreen.height/2- buttonSize.y/2);
                            break;

                        case "ButtonAnchor.MiddleRight":
                            anchorPosition = new Vector2( VirtualScreen.width-buttonSize.x,VirtualScreen.height/2- buttonSize.y/2);
                            break;

                        case "ButtonAnchor.LowerLeft":
                            anchorPosition = new Vector2( 0, VirtualScreen.height- buttonSize.y);
                            break;
                        case "ButtonAnchor.LowerCenter":
                            anchorPosition = new Vector2( VirtualScreen.width/2- buttonSize.x/2, VirtualScreen.height- buttonSize.y);
                            break;
                        case "ButtonAnchor.LowerRight":
                            anchorPosition = new Vector2( VirtualScreen.width-buttonSize.x,VirtualScreen.height- buttonSize.y);
                            break;
                    }

                    //button rect
                    buttonRect = new Rect(anchorPosition.x + offset.x, anchorPosition.y + offset.y ,buttonSize.x,buttonSize.y);
                }
                return buttonRect;
            }
    #endif
        }

        public void getScreenSize(){
            int width = UnityEngine.Screen.width;
            int height = UnityEngine.Screen.height;
            GetScreenSizeCallback(width, height);
        }

        public void unityVersion(){
            GetUnityVersionCallback(Application.unityVersion);
        }

        public void frameRate() {
            GetUnityFrameRateCallback(Application.targetFrameRate);
        }


        public void GetObjectInfo(UnityEngine.Object obj, ref List<CObjectData> objList){
            // Debug.Log("GameObject:" + obj.name + "|type: " + obj.GetType() + " using: " + UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(obj) + "Bytes");
            CObjectData stObject = new CObjectData();
            stObject.url = obj.name;
            stObject.format = obj.GetType().Name;
            stObject.name = obj.name;
            stObject.cpuMemory = UnityEngine.Profiling.Profiler.GetRuntimeMemorySizeLong(obj);
            objList.Add(stObject);
            allMemory += stObject.cpuMemory;
        }

        //http://km.oa.com/articles/show/208879?kmref=search&from_page=1&no=1
        public void getCacheDetail() {
            allMemory = 0;
            UnityEngine.Object[] objList = FindObjectsOfType(typeof(UnityEngine.Object));
            List<CObjectData> curObjList = new List<CObjectData>();
            for(int i=0; i < objList.Length;i++) {
                UnityEngine.Object obj = objList[i];
                if(obj != null)
                {
                    GetObjectInfo(obj, ref curObjList);
                }
            }
            // Debug.Log(JsonMapper.ToJson(curObjList));
            Debug.Log(allMemory);
            // GetUnityCacheDetailCallback("hello");
            GetUnityCacheDetailCallback(JsonMapper.ToJson(curObjList));
            curObjList.Clear();
        }

        public void test_func() {
            Debug.Log("test_func");
            Debug.Log(Application.targetFrameRate);
            // Debug.Log("Mono used size" + UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong()/(1024*1024) + "MBytes");
        }

        void Start() {
            // Debug.Log("unity dumper start");
            // Application.targetFrameRate = 30;
            // Invoke("getNowScenesCompoments", 2.0f);
        }

    }
}
