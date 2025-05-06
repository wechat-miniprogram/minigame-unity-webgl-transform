using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerSliderController : MonoBehaviour
{
    public VideoPlayer m_player;
    public Slider m_slider;
    public bool m_bMouseUp = true;
    void Start()
    {
        m_slider.onValueChanged.AddListener((float value) =>
        {
            if (!m_bMouseUp)
            {
                SliderEvent(value);
            }
        });
    }
    
    private void FixedUpdate()
    {
        if (m_bMouseUp)
        {
            m_slider.value = m_player.frame / (m_player.frameCount * 1.0f);
        }
    }

    public void PointerDown()
    {
        m_player.Pause();
        m_bMouseUp = false;
    }

    public void PointerUp()
    {
        m_player.Play();
        m_bMouseUp = true;
    }

    public void SliderEvent(float value)
    {
        m_player.frame = long.Parse((value * m_player.frameCount).ToString("0."));
    }

    public void PointerClick()
    {
        // 暂停视频
        m_player.Pause();
        
        // 获取点击位置相对于滑动条的比例
        RectTransform rt = m_slider.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Input.mousePosition, null, out localPoint);

        // 计算点击位置对应的值
        float percentage = (localPoint.x - rt.rect.xMin) / rt.rect.width;
        percentage = Mathf.Clamp01(percentage);

        // 设置视频帧
        m_player.frame = long.Parse((percentage * m_player.frameCount).ToString("0."));
        // 更新滑动条值
        m_slider.value = percentage;

        // 继续播放视频
        m_player.Play();
    }
}
