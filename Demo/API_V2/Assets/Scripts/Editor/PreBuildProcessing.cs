#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using System.Runtime.InteropServices;

public class PreBuildProcessing : IPreprocessBuildWithReport {
    public int callbackOrder => 1;

    // 依据不同的操作系统，设置不同的环境变量
    // 请填写为本机实际路径
    public void OnPreprocessBuild(BuildReport report) {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
            // macOS
            System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "/Library/Frameworks/Python.framework/Versions/2.7/bin/python");
        } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            // Windows
            System.Environment.SetEnvironmentVariable("EMSDK_PYTHON", "C:/Python27/python.exe");
        }
        // 如果需要，还可以添加对其他操作系统的支持，例如Linux
    }
}
#endif