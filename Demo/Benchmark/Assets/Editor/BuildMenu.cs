using System.Collections;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildMenu
{
    [MenuItem("Build/Build Web")]
    public static void BuildWeb()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[]
        {
            "Assets/Scenes/Results.unity",

            "Assets/Scenes/2D Physics Boxes.unity",
            "Assets/Scenes/2D Physics Polygons.unity",
            "Assets/Scenes/2D Physics Spheres.unity",
            "Assets/Scenes/AI Agents.unity",
            "Assets/Scenes/Animation & Skinning.unity",
            "Assets/Scenes/Asteroid Field.unity",
            "Assets/Scenes/CryptoHash Script.unity",
            "Assets/Scenes/Cubes.unity",
            "Assets/Scenes/Instantiate & Destroy.unity",
            "Assets/Scenes/Mandelbrot Script.unity",
            "Assets/Scenes/Particles.unity",
            "Assets/Scenes/Physics Cubes.unity",
            "Assets/Scenes/Physics Meshes.unity",
            "Assets/Scenes/Physics Spheres.unity"
            
//            "Assets/Scenes/Mandelbrot GPU.unity",
        };
        buildPlayerOptions.locationPathName = PlayerSettings.WebGL.threadsSupport ? "builds/WebMT" : "builds/Web";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }

    [MenuItem("Build/Build Web With Threads")]
    public static void BuildWebWithThreads()
    {
        var threadsSupport = PlayerSettings.WebGL.threadsSupport;
        PlayerSettings.WebGL.threadsSupport = true;

        BuildWeb();
        
        PlayerSettings.WebGL.threadsSupport = threadsSupport;
    }
}
