// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SLua
{
    using System.Collections.Generic;
    using System;
    using UnityEngine.Rendering;
    using UnityEngine;

    public class CustomExport
    {
        public static void OnGetAssemblyToGenerateExtensionMethod(out List<string> list) {
            list = new List<string> {
                "Assembly-CSharp",
            };
        }

        public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
        {
			// below lines only used for demostrate how to add custom class to export, can be delete on your app

            add(typeof(System.Func<int>), null);
            add(typeof(System.Action<int, string>), null);
            add(typeof(System.Action<int, Dictionary<int, object>>), null);
            add(typeof(List<int>), "ListInt");
            // .net 4.6 export class not match used class on runtime, so skip it
            //add(typeof(Dictionary<int, string>), "DictIntStr");
            add(typeof(string), "String");
            add(typeof(List<UnityEngine.UICharInfo>), null);
            add(typeof(List<String>), null);


            // 新增

            add(typeof(UnityEngine.Networking.UnityWebRequest), null);
            add(typeof(UnityEngine.AI.NavMeshAgent), null);


            add(typeof(UnityEngine.AI.NavMeshPath), null);
            add(typeof(UnityEngine.AI.NavMeshHit), null);
            add(typeof(UnityEngine.AI.NavMesh), null);

            // add your custom class here
            // add( type, typename)
            // type is what you want to export
            // typename used for simplify generic type name or rename, like List<int> named to "ListInt", if not a generic type keep typename as null or rename as new type name
        }


        public static void OnAddCustomURPClass(LuaCodeGen.ExportGenericDelegate add)
        {
            //add(typeof(UnityEngine.Rendering.VolumeParameter), null);
            //add(typeof(VolumeParameter<bool>), null);
            //add(typeof(VolumeParameter<Color>), null);
            //add(typeof(ClampedIntParameter), null);
            //add(typeof(ClampedFloatParameter), null);
            //add(typeof(Vector2Parameter), null);
            //add(typeof(Vector3Parameter), null);
            //add(typeof(Vector4Parameter), null);
            //add(typeof(MinFloatParameter), null);
            //add(typeof(ColorParameter), null);
            //add(typeof(BoolParameter), null);

            //add(typeof(UnityEngine.Rendering.Universal.UniversalAdditionalCameraData), null);
            //add(typeof(UnityEngine.Rendering.Volume), null);
            //add(typeof(UnityEngine.Rendering.VolumeProfile), null);

            ////add(typeof(UnityEngine.Experiemntal.Rendering.Universal.Flip), null);
            ////add(typeof(UnityEngine.Experiemntal.Rendering.Universal.RadialBlur), null);
            //add(typeof(UnityEngine.Rendering.Universal.Bloom), null);
            
            //add(typeof(UnityEngine.Rendering.Universal.UniversalRenderPipeline), null);
            //add(typeof(UnityEngine.Rendering.Universal.UniversalRenderPipelineAsset), null);
        }


        public static void OnAddCustomAssembly(ref List<string> list)
        {
            // add your custom assembly here
            // you can build a dll for 3rd library like ngui titled assembly name "NGUI", put it in Assets folder
            // add its name into list, slua will generate all exported interface automatically for you

            //list.Add("NGUI");
        }

        public static HashSet<string> OnGetRenderPipelinesList()
        {
            return new HashSet<string>
            {
                "UnityEngine.Rendering.Universal.UniversalAdditionalCameraData",
            };
        }


        public static HashSet<string> OnAddCustomNamespace()
        {
            return new HashSet<string>
            {
                //"NLuaTest.Mock"
            };
        }

        // if uselist return a white list, don't check noUseList(black list) again
        public static void OnGetUseList(out List<string> list)
        {
            list = new List<string>
            {
                // "UnityEngine.Font",
            };
        }

        public static List<string> UnsafeParameter = new List<string>()
        {
            "ReadOnlySpan`1",
        };

        public static List<string> FunctionFilterList = new List<string>()
        {
            "UIWidget.showHandles",
            "UIWidget.showHandlesWithMoveTool",
            "UnityEngine.QualitySettings.get_streamingMipmapsRenderersPerFrame",
            "UnityEngine.QualitySettings.set_streamingMipmapsRenderersPerFrame",
            "UnityEngine.QualitySettings.streamingMipmapsRenderersPerFrame",
            "UnityEngine.Texture.get_imageContentsHash",
            "UnityEngine.Texture.set_imageContentsHash",
            "UnityEngine.Texture.imageContentsHash",
            "UnityEngine.MeshRenderer.scaleInLightmap",
            "UnityEngine.MeshRenderer.receiveGI",
            "UnityEngine.MeshRenderer.stitchLightmapSeams",
            "UnityEngine.ParticleSystemRenderer.supportsMeshInstancing",
            "UnityEngine.ParticleSystem.SetParticles",
            "UnityEngine.ParticleSystem.GetParticles",
            "UnityEngine.ParticleSystemForceField.FindAll",
            "UnityEngine.AudioSource.PlayOnGamepad",
            "UnityEngine.AudioSource.DisableGamepadOutput",
            "UnityEngine.AudioSource.SetGamepadSpeakerMixLevel",
            "UnityEngine.AudioSource.SetGamepadSpeakerMixLevelDefault",
            "UnityEngine.AudioSource.SetGamepadSpeakerRestrictedAudio",
            "UnityEngine.AudioSource.GamepadSpeakerSupportsOutputType",

        };

        // black list if white list not given
        public static void OnGetNoUseList(out List<string> list)
        {
            list = new List<string>
            {      
                "HideInInspector",
                "ExecuteInEditMode",
                "AddComponentMenu",
                "ContextMenu",
                "RequireComponent",
                "DisallowMultipleComponent",
                "SerializeField",
                "AssemblyIsEditorAssembly",
                "Attribute", 
                "Types",
                "UnitySurrogateSelector",
                "TrackedReference",
                "TypeInferenceRules",
                "FFTWindow",
                "RPC",
                "Network",
                "MasterServer",
                "BitStream",
                "HostData",
                "ConnectionTesterStatus",
                "GUI",
                "EventType",
                "EventModifiers",
                "FontStyle",
                "TextAlignment",
                "TextEditor",
                "TextEditorDblClickSnapping",
                "TextGenerator",
                "TextClipping",
                "Gizmos",
                "ADBannerView",
                "ADInterstitialAd",            
                "Android",
                "Tizen",
                "jvalue",
                "iPhone",
                "iOS",
                "Windows",
                "CalendarIdentifier",
                "CalendarUnit",
                "CalendarUnit",
                "ClusterInput",
                "FullScreenMovieControlMode",
                "FullScreenMovieScalingMode",
                "Handheld",
                "LocalNotification",
                "NotificationServices",
                "RemoteNotificationType",      
                "RemoteNotification",
                "SamsungTV",
                "TextureCompressionQuality",
                "TouchScreenKeyboardType",
                "TouchScreenKeyboard",
                "MovieTexture",
                "UnityEngineInternal",
                "Terrain",                            
                "Tree",
                "SplatPrototype",
                "DetailPrototype",
                "DetailRenderMode",
                "MeshSubsetCombineUtility",
                "AOT",
                "Social",
                "Enumerator",       
                "SendMouseEvents",               
                "Cursor",
                "Flash",
                "ActionScript",
                "OnRequestRebuild",
                "Ping",
                "ShaderVariantCollection",
                "SimpleJson.Reflection",
                "CoroutineTween",
                "GraphicRebuildTracker",
                "Advertisements",
                "UnityEditor",
			    "WSA",
			    "EventProvider",
			    "Apple",
			    "ClusterInput",
				"Motion",
                "UnityEngine.UI.ReflectionMethodsCache",
				"NativeLeakDetection",
				"NativeLeakDetectionMode",
				"WWWAudioExtensions",
                "UnityEngine.Experimental",
                "Unity.Jobs",
                "Unity.Collections",
                "Unity.IO.LowLevel",
                "UnityEngine.AudioSettings",
                "UnityEngine.DrivenRectTransformTracker",
                "UnityEngine.tvOS",
                "UnityEngine.Light",
                "UnityEngine.LightProbeGroup",
                "UnityEngine.Playables",
                "UnityEngine.Rendering",

                "AI",
                "VR",
                "AdvertisingIdentifierCallback",
                "LowMemoryCallback",
                "UnityEngine.UserAuthorization",
                "UnityEngine.ApplicationInstallMode",
                "UnityEngine.ApplicationSandboxType",
                "UnityEngine.BillboardAsset",
                "UnityEngine.CacheIndex",
                "UnityEngine.Caching",
                "UnityEngine.ComputeShader",
                "UnityEngine.ComputeBuffer",
                "UnityEngine.CrashReport",
                "UnityEngine.BoundingSphere",
                "UnityEngine.CullingGroupEvent",
                "UnityEngine.CullingGroup",
                "UnityEngine.CullingGroup+StateChanged",
                "UnityEngine.Display",
                "UnityEngine.Display+DisplaysUpdatedDelegate",
                "UnityEngine.ExposedPropertyResolver",
                "UnityEngine.FlareLayer",
                "UnityEngine.GradientColorKey",
                "UnityEngine.GradientAlphaKey",
                "UnityEngine.GradientMode",
                "UnityEngine.Gradient",
                "UnityEngine.OcclusionArea",
                "UnityEngine.OcclusionPortal",
                "UnityEngine.Flare",
                "UnityEngine.LensFlare",
                "UnityEngine.ImageEffectAllowedInSceneView",
                "UnityEngine.ImageEffectOpaque",
                "UnityEngine.IMECompositionMode",
                "UnityEngine.LODFadeMode",
                "UnityEngine.LOD",
                "UnityEngine.LODGroup",
                "UnityEngine.Diagnostics.PlayerConnection",
                "UnityEngine.ReflectionProbe",
                "UnityEngine.Security",
                "UnityEngine.Rendering.SphericalHarmonicsL2",
                "UnityEngine.Rendering.SplashScreen",
                "UnityEngine.ProceduralProcessorUsage",
                "UnityEngine.ProceduralCacheSize",
                "UnityEngine.ProceduralLoadingBehavior",
                "UnityEngine.ProceduralPropertyType",
                "UnityEngine.ProceduralOutputType",
                "UnityEngine.ProceduralPropertyDescription",
                "UnityEngine.ProceduralMaterial",
                "UnityEngine.ProceduralTexture",
                "UnityEngine.Hash128",
                "UnityEngine.DynamicGI",
                "UnityEngine.WindZoneMode",
                "UnityEngine.WindZone",
                "UnityEngine.Rendering.UVChannelFlags",
                "UnityEngine.ParticleSystemRenderMode",
                "UnityEngine.ParticleSystemSortMode",
                "UnityEngine.ParticleSystemCollisionQuality",
                "UnityEngine.ParticleSystemRenderSpace",
                "UnityEngine.ParticleSystemEmissionType",
                "UnityEngine.ParticleSystemCurveMode",
                "UnityEngine.ParticleSystemGradientMode",
                "UnityEngine.ParticleSystemShapeType",
                "UnityEngine.ParticleSystemMeshShapeType",
                "UnityEngine.ParticleSystemAnimationType",
                "UnityEngine.ParticleSystemCollisionType",
                "UnityEngine.ParticleSystemCollisionMode",
                "UnityEngine.ParticleSystemOverlapAction",
                "UnityEngine.ParticleSystemSimulationSpace",
                "UnityEngine.ParticleSystemStopBehavior",
                "UnityEngine.ParticleSystemScalingMode",
                "UnityEngine.ParticleSystemInheritVelocityMode",
                "UnityEngine.ParticleSystemVertexStreams",
                "UnityEngine.ParticleSystemVertexStream",
                "UnityEngine.ParticleSystemCustomData",
                "UnityEngine.ParticleSystemCustomDataMode",
                "UnityEngine.ParticleSystemNoiseQuality",
                "UnityEngine.ParticleSystemSubEmitterType",
                "UnityEngine.ParticleSystemSubEmitterProperties",
                "UnityEngine.ParticleSystemTrailTextureMode",
                "UnityEngine.ParticleSystemShapeMultiModeValue",
                "UnityEngine.ParticleCollisionEvent",
                "UnityEngine.ParticlePhysicsExtensions",
                "UnityEngine.RigidbodyConstraints",
                "UnityEngine.ForceMode",
                "UnityEngine.JointDriveMode",
                "UnityEngine.JointProjectionMode",
                "UnityEngine.WheelFrictionCurve",
                "UnityEngine.SoftJointLimit",
                "UnityEngine.SoftJointLimitSpring",
                "UnityEngine.JointDrive",
                "UnityEngine.RigidbodyInterpolation",
                "UnityEngine.JointMotor",
                "UnityEngine.JointSpring",
                "UnityEngine.JointLimits",
                "UnityEngine.ControllerColliderHit",
                "UnityEngine.PhysicMaterialCombine",
                "UnityEngine.QueryTriggerInteraction",
                "UnityEngine.ContactPoint",
                "UnityEngine.Joint",
                "UnityEngine.HingeJoint",
                "UnityEngine.SpringJoint",
                "UnityEngine.FixedJoint",
                "UnityEngine.CharacterJoint",
                "UnityEngine.RotationDriveMode",
                "UnityEngine.ConfigurableJoint",
                "UnityEngine.ConstantForce",
                "UnityEngine.CollisionDetectionMode",
                "UnityEngine.RaycastHit2D",
                "UnityEngine.CircleCollider2D",
                "UnityEngine.BoxCollider2D",
                "UnityEngine.Joint2D",
                "UnityEngine.AreaEffector2D",
                "UnityEngine.PlatformEffector2D",
                "UnityEngine.Physics2D",
                "UnityEngine.RigidbodyInterpolation2D",
                "UnityEngine.RigidbodySleepMode2D",
                "UnityEngine.CollisionDetectionMode2D",
                "UnityEngine.ForceMode2D",
                "UnityEngine.RigidbodyConstraints2D",
                "UnityEngine.RigidbodyType2D",
                "UnityEngine.ContactFilter2D",
                "UnityEngine.Rigidbody2D",
                "UnityEngine.Collider2D",
                "UnityEngine.EdgeCollider2D",
                "UnityEngine.CapsuleDirection2D",
                "UnityEngine.CapsuleCollider2D",
                "UnityEngine.CompositeCollider2D",
                "UnityEngine.CompositeCollider2D+GeometryType",
                "UnityEngine.CompositeCollider2D+GenerationType",
                "UnityEngine.PolygonCollider2D",
                "UnityEngine.ColliderDistance2D",
                "UnityEngine.ContactPoint2D",
                "UnityEngine.Collision2D",
                "UnityEngine.JointLimitState2D",
                "UnityEngine.JointAngleLimits2D",
                "UnityEngine.JointTranslationLimits2D",
                "UnityEngine.JointMotor2D",
                "UnityEngine.JointSuspension2D",
                "UnityEngine.AnchoredJoint2D",
                "UnityEngine.SpringJoint2D",
                "UnityEngine.DistanceJoint2D",
                "UnityEngine.FrictionJoint2D",
                "UnityEngine.HingeJoint2D",
                "UnityEngine.RelativeJoint2D",
                "UnityEngine.SliderJoint2D",
                "UnityEngine.TargetJoint2D",
                "UnityEngine.FixedJoint2D",
                "UnityEngine.WheelJoint2D",
                "UnityEngine.PhysicsMaterial2D",
                "UnityEngine.PhysicsUpdateBehaviour2D",
                "UnityEngine.ConstantForce2D",
                "UnityEngine.EffectorSelection2D",
                "UnityEngine.EffectorForceMode2D",
                "UnityEngine.Effector2D",
                "UnityEngine.BuoyancyEffector2D",
                "UnityEngine.PointEffector2D",
                "UnityEngine.SurfaceEffector2D",
                "UnityEngine.WheelHit",
                "UnityEngine.WheelCollider",
                "UnityEngine.ClothSkinningCoefficient",
                "UnityEngine.ClothSphereColliderPair",
                "UnityEngine.Cloth",
                "UnityEngine.StateMachineBehaviour",
                "UnityEngine.SkeletonBone",
                "UnityEngine.HumanLimit",
                "UnityEngine.HumanBone",
                "UnityEngine.HumanDescription",
                "UnityEngine.AvatarBuilder",
                "UnityEngine.RuntimeAnimatorController",
                "UnityEngine.HumanBodyBones",
                "UnityEngine.Avatar",
                "UnityEngine.HumanTrait",
                "UnityEngine.AvatarMaskBodyPart",
                "UnityEngine.AvatarMask",
                "UnityEngine.HumanPose",
                "UnityEngine.HumanPoseHandler",
                "UnityEngine.FocusType",
                "UnityEngine.ImagePosition",
                "UnityEngine.JsonUtility",
                "UnityEngine.Analytics.Gender",
                "UnityEngine.Analytics.AnalyticsResult",
                "UnityEngine.Analytics.Analytics",
                "UnityEngine.CrashReportHandler.CrashReportHandler",
                "UnityEngine.Analytics.PerformanceReporting",
                "UnityEngine.RemoteSettings",
                "UnityEngine.RemoteSettings+UpdatedEventHandler",
                "UnityEngine.SystemLanguage",
                "UnityEngine.LogType",
                "UnityEngine.DeviceType",
                "UnityEngine.BatteryStatus",
                "UnityEngine.ThreadPriority",
                "UnityEngine.ExposedReference`1",
                "UnityEngine.RenderBuffer",
                "UnityEngine.RenderTargetSetup",
                "UnityEngine.Rendering.ShaderHardwareTier",
                "UnityEngine.RenderingPath",
                "UnityEngine.TransparencySortMode",
                "UnityEngine.StereoTargetEyeMask",
                "UnityEngine.CameraType",
                "UnityEngine.ComputeBufferType",
                "UnityEngine.LightType",
                "UnityEngine.LightRenderMode",
                "UnityEngine.LightShadows",
                "UnityEngine.FogMode",
                "UnityEngine.LightmapBakeType",
                "UnityEngine.QualityLevel",
                "UnityEngine.ShadowProjection",
                "UnityEngine.ShadowQuality",
                "UnityEngine.ShadowResolution",
                "UnityEngine.CameraClearFlags",
                "UnityEngine.DepthTextureMode",
                "UnityEngine.TexGenMode",
                "UnityEngine.MeshTopology",
                "UnityEngine.SkinQuality",
                "UnityEngine.ColorSpace",
                "UnityEngine.ScreenOrientation",
                "UnityEngine.FilterMode",
                "UnityEngine.TextureWrapMode",
                "UnityEngine.NPOTSupport",
                "UnityEngine.TextureFormat",
                "UnityEngine.CubemapFace",
                "UnityEngine.LightmapsMode",
                "UnityEngine.MaterialGlobalIlluminationFlags",
                "UnityEngine.CustomRenderTextureInitializationSource",
                "UnityEngine.CustomRenderTextureUpdateMode",
                "UnityEngine.CustomRenderTextureUpdateZoneSpace",
                "UnityEngine.Rendering.OpaqueSortMode",
                "UnityEngine.Rendering.RenderQueue",
                "UnityEngine.Rendering.RenderBufferLoadAction",
                "UnityEngine.Rendering.RenderBufferStoreAction",
                "UnityEngine.Rendering.BlendMode",
                "UnityEngine.Rendering.BlendOp",
                "UnityEngine.Rendering.CompareFunction",
                "UnityEngine.Rendering.ColorWriteMask",
                "UnityEngine.Rendering.StencilOp",
                "UnityEngine.Rendering.DefaultReflectionMode",
                "UnityEngine.Rendering.ReflectionCubemapCompression",
                "UnityEngine.Rendering.CameraEvent",
                "UnityEngine.Rendering.LightEvent",
                "UnityEngine.Rendering.ShadowMapPass",
                "UnityEngine.Rendering.BuiltinRenderTextureType",
                "UnityEngine.Rendering.PassType",
                "UnityEngine.Rendering.ShadowCastingMode",
                "UnityEngine.Rendering.LightShadowResolution",
                "UnityEngine.Rendering.GraphicsDeviceType",
                "UnityEngine.Rendering.GraphicsTier",
                "UnityEngine.Rendering.RenderTargetIdentifier",
                "UnityEngine.Rendering.ReflectionProbeUsage",
                "UnityEngine.Rendering.ReflectionProbeType",
                "UnityEngine.Rendering.ReflectionProbeClearFlags",
                "UnityEngine.Rendering.ReflectionProbeMode",
                "UnityEngine.Rendering.ReflectionProbeBlendInfo",
                "UnityEngine.Rendering.ReflectionProbeRefreshMode",
                "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode",
                "UnityEngine.Rendering.ShadowSamplingMode",
                "UnityEngine.Rendering.LightProbeUsage",
                "UnityEngine.Rendering.BuiltinShaderType",
                "UnityEngine.Rendering.BuiltinShaderMode",
                "UnityEngine.Rendering.TextureDimension",
                "UnityEngine.Rendering.CopyTextureSupport",
                "UnityEngine.Rendering.CameraHDRMode",
                "UnityEngine.Rendering.RealtimeGICPUUsage",
                "UnityEngine.LightmappingMode",
                "UnityEngine.BoneWeight",
                "UnityEngine.CombineInstance",
                "UnityEngine.Plane",
                "UnityEngine.PropertyName",
                "UnityEngine.RangeInt",
                "UnityEngine.RuntimeInitializeLoadType",
                "UnityEngine.SerializePrivateVariables",
                "UnityEngine.PreferBinarySerialization",
                "UnityEngine.ISerializationCallbackReceiver",
                "UnityEngine.StackTraceUtility",
                "UnityEngine.UnityException",
                "UnityEngine.MissingComponentException",
                "UnityEngine.UnassignedReferenceException",
                "UnityEngine.MissingReferenceException",
                "UnityEngine.Assertions.Assert",
                "UnityEngine.Assertions.AssertionException",
                "UnityEngine.Assertions.Comparers.FloatComparer",
                "UnityEngine.Assertions.Must.MustExtensions",
                "UnityEngine.ILogger",
                "UnityEngine.ILogHandler",
                "UnityEngine.AnimationCurve",
                "UnityEngine.AudioSettings",
                "UnityEngine.UI.DefaultControls",
                "Unity.Profiling.LowLevel.Unsafe",
                "UnityEngine.Microphone",
            };
        }
    }
}
