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
                    MethodInfo onDestroyMethod = component.GetType().GetMethod("Destroy", BindingFlags.Public | BindingFlags.Instance);

                    if (onDestroyMethod != null)
                    {
                        onDestroyMethod.Invoke(component, null);
                    }
                }
                break;
            }
        }
        // 加载主场景
        GameManager.Instance.SwitchCanvas();
    }
}