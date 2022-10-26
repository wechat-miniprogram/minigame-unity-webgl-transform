using WeChatWASM;


#if UNITY_WEBGL && !UNITY_EDITOR
/// <summary>
/// 覆盖unity的PlayerPrefs
/// 注意：调用均为同步调用， 容易阻塞游戏主线程造成卡顿，不建议频繁调用
/// </summary>
public static class PlayerPrefs
{
    public static void SetInt(string key, int value) {
        WX.StorageSetIntSync(key, value);
    }
    public static int GetInt(string key , int defaultValue = 0) {
        return WX.StorageGetIntSync(key, defaultValue);
    }
    public static void SetString(string key,string value) {
        WX.StorageSetStringSync(key,value);
    }
    public static string GetString(string key,string defaultValue = "") {
        return WX.StorageGetStringSync(key,defaultValue);
    }
    public static void SetFloat(string key,float value) {
        WX.StorageSetFloatSync(key,value);
    }
    public static float GetFloat(string key,float defaultValue = 0) {
        return WX.StorageGetFloatSync(key, defaultValue);
    }
    public static void DeleteAll() {
        WX.StorageDeleteAllSync();
    }
    public static void DeleteKey(string key) {
        WX.StorageDeleteKeySync(key);
    }
    public static bool HasKey(string key)
    {
        return WX.StorageHasKeySync(key);
    }
    public static void Save(){}
}
#else
public static class PlayerPrefs
{
    public static void SetInt(string key, int value)
    {
        UnityEngine.PlayerPrefs.SetInt(key, value);
    }
    public static int GetInt(string key, int defaultValue = 0)
    {
        return UnityEngine.PlayerPrefs.GetInt(key, defaultValue);
    }
    public static void SetString(string key, string value)
    {
        UnityEngine.PlayerPrefs.SetString(key, value);
    }
    public static string GetString(string key, string defaultValue = "")
    {
        return UnityEngine.PlayerPrefs.GetString(key, defaultValue);
    }
    public static void SetFloat(string key, float value)
    {
        UnityEngine.PlayerPrefs.SetFloat(key, value);
    }
    public static float GetFloat(string key, float defaultValue = 0)
    {
        return UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);
    }
    public static void DeleteAll()
    {
        UnityEngine.PlayerPrefs.DeleteAll();
    }
    public static void DeleteKey(string key)
    {
        UnityEngine.PlayerPrefs.DeleteKey(key);
    }
    public static bool HasKey(string key)
    {
        return UnityEngine.PlayerPrefs.HasKey(key);
    }
    public static void Save()
    {
        UnityEngine.PlayerPrefs.Save();
    }
}

#endif
