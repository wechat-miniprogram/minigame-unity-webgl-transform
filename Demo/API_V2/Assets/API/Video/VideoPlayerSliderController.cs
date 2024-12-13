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

    // 如果启用 MonoBehaviour，则每个固定帧速率的帧都将调用此函数
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
}
