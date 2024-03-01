using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;

// 添加 Button 组件的依赖
[RequireComponent(typeof(Button))]
public class BackToMainCanvasButton : MonoBehaviour
{
    private void Awake()
    {
        // 为按钮添加点击事件监听器
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    
    // 点击事件处理
    private static void OnClick()
    {
        Debug.Log("click backbutton");
        // 销毁活跃对象
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] rootGameObjects = currentScene.GetRootGameObjects();

        foreach (GameObject rootGameObject in rootGameObjects)
        {
            if (rootGameObject.name == "Details Canvas")
            {
                Component[] components = rootGameObject.GetComponents<Component>();

                foreach (Component component in components)
                {
                    // Debug.Log("Component: " + component.GetType().Name);

                    if (component.GetType().Name == "SystemButton") {
                        MethodInfo[] methods = component.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

                        foreach (MethodInfo method in methods)
                        {
                            MethodInfo destroyMethod = component.GetType().GetMethod("OnDestroy", BindingFlags.Public | BindingFlags.Instance);

                            if (destroyMethod != null)
                            {
                                Debug.Log("destory");
                                destroyMethod.Invoke(component, null);
                            }
                        }
                    }
                }

                // Destroy(rootGameObject);
                break;
            }
            Debug.Log(rootGameObject);
        }
        // 加载主场景
        GameManager.Instance.SwitchCanvas();
    }
}