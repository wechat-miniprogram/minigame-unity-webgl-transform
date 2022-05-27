using WeChatWASM;


#if UNITY_WEBGL
/// <summary>
/// 覆盖unity的PlayerPrefs
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

#endif
