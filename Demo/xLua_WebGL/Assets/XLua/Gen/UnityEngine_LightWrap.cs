#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class UnityEngineLightWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Light);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 32, 31);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reset", _m_Reset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddCommandBuffer", _m_AddCommandBuffer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddCommandBufferAsync", _m_AddCommandBufferAsync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveCommandBuffer", _m_RemoveCommandBuffer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveCommandBuffers", _m_RemoveCommandBuffers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveAllCommandBuffers", _m_RemoveAllCommandBuffers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCommandBuffers", _m_GetCommandBuffers);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "type", _g_get_type);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shape", _g_get_shape);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spotAngle", _g_get_spotAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "innerSpotAngle", _g_get_innerSpotAngle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "color", _g_get_color);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colorTemperature", _g_get_colorTemperature);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useColorTemperature", _g_get_useColorTemperature);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "intensity", _g_get_intensity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounceIntensity", _g_get_bounceIntensity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useBoundingSphereOverride", _g_get_useBoundingSphereOverride);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "boundingSphereOverride", _g_get_boundingSphereOverride);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useViewFrustumForShadowCasterCull", _g_get_useViewFrustumForShadowCasterCull);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowCustomResolution", _g_get_shadowCustomResolution);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowBias", _g_get_shadowBias);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowNormalBias", _g_get_shadowNormalBias);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowNearPlane", _g_get_shadowNearPlane);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useShadowMatrixOverride", _g_get_useShadowMatrixOverride);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowMatrixOverride", _g_get_shadowMatrixOverride);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "range", _g_get_range);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flare", _g_get_flare);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bakingOutput", _g_get_bakingOutput);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cullingMask", _g_get_cullingMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderingLayerMask", _g_get_renderingLayerMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lightShadowCasterMode", _g_get_lightShadowCasterMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadows", _g_get_shadows);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowStrength", _g_get_shadowStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shadowResolution", _g_get_shadowResolution);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layerShadowCullDistances", _g_get_layerShadowCullDistances);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cookieSize", _g_get_cookieSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cookie", _g_get_cookie);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderMode", _g_get_renderMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "commandBufferCount", _g_get_commandBufferCount);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "type", _s_set_type);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shape", _s_set_shape);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "spotAngle", _s_set_spotAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "innerSpotAngle", _s_set_innerSpotAngle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "color", _s_set_color);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "colorTemperature", _s_set_colorTemperature);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useColorTemperature", _s_set_useColorTemperature);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "intensity", _s_set_intensity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bounceIntensity", _s_set_bounceIntensity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useBoundingSphereOverride", _s_set_useBoundingSphereOverride);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "boundingSphereOverride", _s_set_boundingSphereOverride);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useViewFrustumForShadowCasterCull", _s_set_useViewFrustumForShadowCasterCull);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowCustomResolution", _s_set_shadowCustomResolution);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowBias", _s_set_shadowBias);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowNormalBias", _s_set_shadowNormalBias);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowNearPlane", _s_set_shadowNearPlane);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useShadowMatrixOverride", _s_set_useShadowMatrixOverride);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowMatrixOverride", _s_set_shadowMatrixOverride);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "range", _s_set_range);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flare", _s_set_flare);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bakingOutput", _s_set_bakingOutput);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cullingMask", _s_set_cullingMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "renderingLayerMask", _s_set_renderingLayerMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "lightShadowCasterMode", _s_set_lightShadowCasterMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadows", _s_set_shadows);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowStrength", _s_set_shadowStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "shadowResolution", _s_set_shadowResolution);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layerShadowCullDistances", _s_set_layerShadowCullDistances);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cookieSize", _s_set_cookieSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cookie", _s_set_cookie);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "renderMode", _s_set_renderMode);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLights", _m_GetLights_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new UnityEngine.Light();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Light constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddCommandBuffer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Rendering.LightEvent>(L, 2)&& translator.Assignable<UnityEngine.Rendering.CommandBuffer>(L, 3)) 
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    UnityEngine.Rendering.CommandBuffer _buffer = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
                    
                    gen_to_be_invoked.AddCommandBuffer( _evt, _buffer );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rendering.LightEvent>(L, 2)&& translator.Assignable<UnityEngine.Rendering.CommandBuffer>(L, 3)&& translator.Assignable<UnityEngine.Rendering.ShadowMapPass>(L, 4)) 
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    UnityEngine.Rendering.CommandBuffer _buffer = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
                    UnityEngine.Rendering.ShadowMapPass _shadowPassMask;translator.Get(L, 4, out _shadowPassMask);
                    
                    gen_to_be_invoked.AddCommandBuffer( _evt, _buffer, _shadowPassMask );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Light.AddCommandBuffer!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddCommandBufferAsync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Rendering.LightEvent>(L, 2)&& translator.Assignable<UnityEngine.Rendering.CommandBuffer>(L, 3)&& translator.Assignable<UnityEngine.Rendering.ComputeQueueType>(L, 4)) 
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    UnityEngine.Rendering.CommandBuffer _buffer = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
                    UnityEngine.Rendering.ComputeQueueType _queueType;translator.Get(L, 4, out _queueType);
                    
                    gen_to_be_invoked.AddCommandBufferAsync( _evt, _buffer, _queueType );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Rendering.LightEvent>(L, 2)&& translator.Assignable<UnityEngine.Rendering.CommandBuffer>(L, 3)&& translator.Assignable<UnityEngine.Rendering.ShadowMapPass>(L, 4)&& translator.Assignable<UnityEngine.Rendering.ComputeQueueType>(L, 5)) 
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    UnityEngine.Rendering.CommandBuffer _buffer = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
                    UnityEngine.Rendering.ShadowMapPass _shadowPassMask;translator.Get(L, 4, out _shadowPassMask);
                    UnityEngine.Rendering.ComputeQueueType _queueType;translator.Get(L, 5, out _queueType);
                    
                    gen_to_be_invoked.AddCommandBufferAsync( _evt, _buffer, _shadowPassMask, _queueType );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Light.AddCommandBufferAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCommandBuffer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    UnityEngine.Rendering.CommandBuffer _buffer = (UnityEngine.Rendering.CommandBuffer)translator.GetObject(L, 3, typeof(UnityEngine.Rendering.CommandBuffer));
                    
                    gen_to_be_invoked.RemoveCommandBuffer( _evt, _buffer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveCommandBuffers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    
                    gen_to_be_invoked.RemoveCommandBuffers( _evt );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllCommandBuffers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RemoveAllCommandBuffers(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCommandBuffers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rendering.LightEvent _evt;translator.Get(L, 2, out _evt);
                    
                        var gen_ret = gen_to_be_invoked.GetCommandBuffers( _evt );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLights_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.LightType _type;translator.Get(L, 1, out _type);
                    int _layer = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = UnityEngine.Light.GetLights( _type, _layer );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shape);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spotAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.spotAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_innerSpotAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.innerSpotAngle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.color);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colorTemperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.colorTemperature);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useColorTemperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useColorTemperature);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.intensity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounceIntensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.bounceIntensity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useBoundingSphereOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useBoundingSphereOverride);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_boundingSphereOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.boundingSphereOverride);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useViewFrustumForShadowCasterCull(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useViewFrustumForShadowCasterCull);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowCustomResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.shadowCustomResolution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.shadowBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowNormalBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.shadowNormalBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowNearPlane(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.shadowNearPlane);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useShadowMatrixOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useShadowMatrixOverride);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowMatrixOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shadowMatrixOverride);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_range(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.range);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flare(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.flare);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bakingOutput(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bakingOutput);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cullingMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.cullingMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderingLayerMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.renderingLayerMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lightShadowCasterMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.lightShadowCasterMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadows(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shadows);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.shadowStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.shadowResolution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layerShadowCullDistances(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.layerShadowCullDistances);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cookieSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.cookieSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cookie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cookie);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.renderMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_commandBufferCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.commandBufferCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.type = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shape(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightShape gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.shape = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spotAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spotAngle = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_innerSpotAngle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.innerSpotAngle = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_color(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.color = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colorTemperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.colorTemperature = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useColorTemperature(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useColorTemperature = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_intensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.intensity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bounceIntensity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bounceIntensity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useBoundingSphereOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useBoundingSphereOverride = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_boundingSphereOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.boundingSphereOverride = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useViewFrustumForShadowCasterCull(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useViewFrustumForShadowCasterCull = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowCustomResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shadowCustomResolution = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shadowBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowNormalBias(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shadowNormalBias = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowNearPlane(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shadowNearPlane = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useShadowMatrixOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useShadowMatrixOverride = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowMatrixOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.Matrix4x4 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.shadowMatrixOverride = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_range(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.range = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flare(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flare = (UnityEngine.Flare)translator.GetObject(L, 2, typeof(UnityEngine.Flare));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bakingOutput(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightBakingOutput gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.bakingOutput = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cullingMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cullingMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderingLayerMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.renderingLayerMask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lightShadowCasterMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightShadowCasterMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.lightShadowCasterMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadows(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightShadows gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.shadows = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.shadowStrength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.Rendering.LightShadowResolution gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.shadowResolution = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layerShadowCullDistances(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.layerShadowCullDistances = (float[])translator.GetObject(L, 2, typeof(float[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cookieSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cookieSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cookie(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cookie = (UnityEngine.Texture)translator.GetObject(L, 2, typeof(UnityEngine.Texture));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.Light gen_to_be_invoked = (UnityEngine.Light)translator.FastGetCSObj(L, 1);
                UnityEngine.LightRenderMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.renderMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
