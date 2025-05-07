using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    private GameObject _titleGameObject;
    private Text _titleText;
    private GameObject _contentGameObject;
    private Text _contentText;

    private void Awake()
    {
        // 获取标题和内容的 GameObject 和 Text 组件
        _titleGameObject = transform.Find("Result Title").gameObject;
        _titleText = transform.Find("Result Title").Find("Text").GetComponent<Text>();
        _contentGameObject = transform.Find("Result Content").gameObject;
        _contentText = transform.Find("Result Content").Find("Text").GetComponent<Text>();
    }

    // 改变标题
    public void ChangeTitle(string title)
    {
        // 如果标题为空，则隐藏标题 GameObject，否则显示
        _titleGameObject.SetActive(!string.IsNullOrEmpty(title));
        // 设置标题文本
        _titleText.text = title;
    }

    // 改变内容
    public void ChangeContent(string content)
    {
        // 如果内容为空，则隐藏内容 GameObject，否则显示
        _contentGameObject.SetActive(!string.IsNullOrEmpty(content));
        // 设置内容文本
        _contentText.text = content;
    }
}
