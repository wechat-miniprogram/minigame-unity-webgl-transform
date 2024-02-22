using System;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [Header("Ability Data")]
    [SerializeField] private AbilitySO abilitySO;
    
    [Header("References")]
    [SerializeField] private Text abilityText;
    [SerializeField] private Image abilityImage;
    
    [Header("Button")]
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    // 初始化 Ability，设置对应的 AbilitySO 和文本、图片
    public void Init(AbilitySO so)
    {
        abilitySO = so;
        
        gameObject.name = abilitySO.abilityName;
        abilityText.text = abilitySO.abilityName;
        abilityImage.sprite = abilitySO.abilitySprite;
    }

    // 点击事件处理
    public void OnClick()
    {
        // 加载对应的场景
        GameManager.Instance.LoadScene(abilitySO.AbilitySceneName);
    }
}