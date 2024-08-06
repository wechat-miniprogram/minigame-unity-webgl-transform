using UnityEngine;
using WeChatWASM;

public class PlayerPrefsManager : MonoBehaviour
{
    public void RunPlayerPrefs()
    {
        // 注意！！！ PlayerPrefs为同步接口，iOS高性能模式下为"跨进程"同步调用，会阻塞游戏线程，请避免频繁调用
        PlayerPrefs.SetString("mystringkey", "mystringvalue");
        PlayerPrefs.SetInt("myintkey", 123);
        PlayerPrefs.SetFloat("myfloatkey", 1.23f);

        var res = $"PlayerPrefs mystringkey:{PlayerPrefs.GetString("mystringkey")}"
                  + $"\nPlayerPrefs myintkey:{PlayerPrefs.GetInt("myintkey")}"
                  + $"\nPlayerPrefs myfloatkey:{PlayerPrefs.GetFloat("myfloatkey")}";

        WX.ShowModal(new ShowModalOption()
        {
            content = res
        });
    }
}