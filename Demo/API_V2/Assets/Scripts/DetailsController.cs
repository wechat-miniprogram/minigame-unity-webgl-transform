using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DetailsController : MonoBehaviour
{
    [Header("Entry Data")]
    [SerializeField] private EntrySO entrySO;
    
    [Header("Elements")]
    [SerializeField] private GameObject optionPrefab;
    [SerializeField] private Transform optionsTransform;
    
    [Header("Text")]
    [SerializeField] private Text titleText;
    [SerializeField] private Text APIText;
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text startButtonText;
    
    [Header("Button")]
    [SerializeField] private Button initialButton;
    [SerializeField] private GameObject buttonBlockPrefab;
    [SerializeField] private Transform buttonsTransform;
    [HideInInspector] public List<GameObject> extraButtonBlockObjects;
    
    [Header("Result")]
    [SerializeField] private GameObject resultPrefab;
    [SerializeField] private Transform resultsTransform;
    [HideInInspector] public List<GameObject> resultObjects;
    
    [Header("Title Transform")] 
    [SerializeField] private RectTransform titleTransform;
    [SerializeField] private RectTransform backButtonTransform;
    
    private Details _details;

    private void Start()
    {
        // 根据系统安全区域调整标题和返回按钮的位置
        titleTransform.anchoredPosition = new Vector2(titleTransform.anchoredPosition.x,  -125f - (float)GameManager.Instance.systemInfo.safeArea.top);
        backButtonTransform.anchoredPosition = new Vector2(backButtonTransform.anchoredPosition.x, -125f - (float)GameManager.Instance.systemInfo.safeArea.top);
    }

    // 清除详情信息
    private void ClearDetails()
    {
        // 销毁详情信息
        Destroy(_details);
        
        // 清除选项
        for (var i = optionsTransform.childCount - 1; i >= 0; i--)
        {
            var child = optionsTransform.GetChild(i);
            Destroy(child.gameObject);
        }
        
        // 清除按钮
        initialButton.onClick.RemoveAllListeners();
        foreach (var i in extraButtonBlockObjects)
        {
            Destroy(i);
        }
        extraButtonBlockObjects = new List<GameObject>();

        // 清除结果
        RemoveAllResult();
    }
    
    // 初始化详情信息
    public void Init(EntrySO so)
    {
        ClearDetails();
        
        entrySO = so;

        titleText.text = so.entryName;
        APIText.text = so.entryAPI;
        descriptionText.text = so.entryDescription;

        _details = (Details)gameObject.AddComponent(entrySO.EntryScriptType);
        _details.Init(entrySO);
        
        // 生成选项
        for(var i = 0; i < entrySO.optionList.Count; i++)
        {
            var optionObj = Instantiate(optionPrefab, optionsTransform);
            optionObj.name = entrySO.optionList[i].optionName;
            optionObj.GetComponentInChildren<OptionDropdownHandler>().Init(_details, i);
        }
        
        // 设置初始按钮
        ChangeInitialButtonText(entrySO.initialButtonText);
        initialButton.onClick.AddListener(() =>
        {
            _details.Run();
        });
        // 生成额外的按钮
        foreach (var button in entrySO.extraButtonList)
        {
            var extraButtonBlock = Instantiate(buttonBlockPrefab, buttonsTransform);
            extraButtonBlockObjects.Add(extraButtonBlock);
            extraButtonBlock.GetComponentInChildren<Text>().text = button.buttonText;
        }
        
        // 生成结果
        foreach (var result in entrySO.initialResultList)
        {
            AddResult(result);
        }
    }
    
    // 更改初始按钮的文本
    public void ChangeInitialButtonText(string text)
    {
        startButtonText.text = text;
    }
    
    // 更改额外按钮的文本
    public void ChangeExtraButtonText(int index, string text)
    {
        extraButtonBlockObjects[index].GetComponent<ButtonController>().ChangeButtonText(text);
    }
    
    // 绑定额外按钮的操作
    public void BindExtraButtonAction(int index, UnityAction action)
    {
        extraButtonBlockObjects[index].GetComponent<ButtonController>()
            .AddButtonListener(action);
    }
    
    // 添加结果信息
    public GameObject AddResult(ResultData resultData)
    {
        var resultObj = Instantiate(resultPrefab, resultsTransform);
        resultObjects.Add(resultObj);
        
        ChangeResultTitle(resultObjects.Count - 1, resultData.initialTitleText);
        ChangeResultContent(resultObjects.Count - 1, resultData.initialContentText);
        if (resultData.isDisableInitially)
        {
            resultObj.SetActive(false);
        }
        return resultObj;
    }
    
    // 移除所有结果信息
    public void RemoveAllResult()
    {
        foreach (var obj in resultObjects)
        {
            Destroy(obj);
        }

        resultObjects = new List<GameObject>();
    }

    // 保留前N个结果
    public void KeepFirstNResults(int n)
    {
        for (var i = n; i < resultObjects.Count; i++)
        {
            Destroy(resultObjects[i]);
        }
        
        resultObjects.RemoveRange(n, resultObjects.Count - n);
    }
    
    // 设置结果的活跃状态
    public void SetResultActive(int index, bool isActive)
    {
        resultObjects[index].SetActive(isActive);
    }

    // 更改结果的标题
    public void ChangeResultTitle(int index, string title)
    {
        resultObjects[index].GetComponent<ResultController>().ChangeTitle(title);
    }
    
    // 更改结果的内容
    public void ChangeResultContent(int index, string content)
    {
        resultObjects[index].GetComponent<ResultController>().ChangeContent(content);
    }
}