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
    public class UnityEngineMathfWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.Mathf);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 54, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ClosestPowerOfTwo", _m_ClosestPowerOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPowerOfTwo", _m_IsPowerOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "NextPowerOfTwo", _m_NextPowerOfTwo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GammaToLinearSpace", _m_GammaToLinearSpace_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LinearToGammaSpace", _m_LinearToGammaSpace_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CorrelatedColorTemperatureToRGB", _m_CorrelatedColorTemperatureToRGB_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FloatToHalf", _m_FloatToHalf_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HalfToFloat", _m_HalfToFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PerlinNoise", _m_PerlinNoise_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sin", _m_Sin_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Cos", _m_Cos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Tan", _m_Tan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Asin", _m_Asin_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Acos", _m_Acos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Atan", _m_Atan_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Atan2", _m_Atan2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sqrt", _m_Sqrt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Abs", _m_Abs_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Min", _m_Min_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Max", _m_Max_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Pow", _m_Pow_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exp", _m_Exp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Log", _m_Log_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Log10", _m_Log10_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Ceil", _m_Ceil_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Floor", _m_Floor_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Round", _m_Round_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CeilToInt", _m_CeilToInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FloorToInt", _m_FloorToInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RoundToInt", _m_RoundToInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Sign", _m_Sign_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clamp", _m_Clamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Clamp01", _m_Clamp01_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Lerp", _m_Lerp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LerpUnclamped", _m_LerpUnclamped_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LerpAngle", _m_LerpAngle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MoveTowards", _m_MoveTowards_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "MoveTowardsAngle", _m_MoveTowardsAngle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SmoothStep", _m_SmoothStep_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Gamma", _m_Gamma_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Approximately", _m_Approximately_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SmoothDamp", _m_SmoothDamp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SmoothDampAngle", _m_SmoothDampAngle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Repeat", _m_Repeat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "PingPong", _m_PingPong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InverseLerp", _m_InverseLerp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DeltaAngle", _m_DeltaAngle_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PI", UnityEngine.Mathf.PI);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Infinity", UnityEngine.Mathf.Infinity);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NegativeInfinity", UnityEngine.Mathf.NegativeInfinity);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Deg2Rad", UnityEngine.Mathf.Deg2Rad);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Rad2Deg", UnityEngine.Mathf.Rad2Deg);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Epsilon", UnityEngine.Mathf.Epsilon);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(UnityEngine.Mathf));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClosestPowerOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.ClosestPowerOfTwo( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPowerOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.IsPowerOfTwo( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NextPowerOfTwo_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.NextPowerOfTwo( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GammaToLinearSpace_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.GammaToLinearSpace( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LinearToGammaSpace_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.LinearToGammaSpace( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CorrelatedColorTemperatureToRGB_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    float _kelvin = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.CorrelatedColorTemperatureToRGB( _kelvin );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloatToHalf_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _val = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.FloatToHalf( _val );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HalfToFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    ushort _val = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.HalfToFloat( _val );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PerlinNoise_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 1);
                    float _y = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.PerlinNoise( _x, _y );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sin_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Sin( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Cos_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Cos( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Tan_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Tan( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Asin_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Asin( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Acos_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Acos( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Atan_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Atan( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Atan2_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _y = (float)LuaAPI.lua_tonumber(L, 1);
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Atan2( _y, _x );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sqrt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Sqrt( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Abs_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Abs( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Abs( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Abs!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Min_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Min( _a, _b );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Min( _a, _b );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    float[] _values = translator.GetParams<float>(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Min( _values );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    int[] _values = translator.GetParams<int>(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Min( _values );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Min!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Max_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Max( _a, _b );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Max( _a, _b );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    float[] _values = translator.GetParams<float>(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Max( _values );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1))) 
                {
                    int[] _values = translator.GetParams<int>(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Max( _values );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Max!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Pow_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    float _p = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Pow( _f, _p );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _power = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Exp( _power );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Log_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Log( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    float _p = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Log( _f, _p );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Log!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Log10_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Log10( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ceil_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Ceil( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Floor_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Floor( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Round_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Round( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CeilToInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.CeilToInt( _f );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloorToInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.FloorToInt( _f );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RoundToInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.RoundToInt( _f );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sign_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _f = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Sign( _f );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    float _min = (float)LuaAPI.lua_tonumber(L, 2);
                    float _max = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.Clamp( _value, _min, _max );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    int _min = LuaAPI.xlua_tointeger(L, 2);
                    int _max = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.Clamp( _value, _min, _max );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.Clamp!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Clamp01_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.Mathf.Clamp01( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Lerp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _t = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.Lerp( _a, _b, _t );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LerpUnclamped_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _t = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.LerpUnclamped( _a, _b, _t );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LerpAngle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _t = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.LerpAngle( _a, _b, _t );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveTowards_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _maxDelta = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.MoveTowards( _current, _target, _maxDelta );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveTowardsAngle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _maxDelta = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.MoveTowardsAngle( _current, _target, _maxDelta );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothStep_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _from = (float)LuaAPI.lua_tonumber(L, 1);
                    float _to = (float)LuaAPI.lua_tonumber(L, 2);
                    float _t = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothStep( _from, _to, _t );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Gamma_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    float _absmax = (float)LuaAPI.lua_tonumber(L, 2);
                    float _gamma = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.Gamma( _value, _absmax, _gamma );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Approximately_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Approximately( _a, _b );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothDamp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDamp( _current, _target, ref _currentVelocity, _smoothTime );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDamp( _current, _target, ref _currentVelocity, _smoothTime, _maxSpeed );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 5);
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDamp( _current, _target, ref _currentVelocity, _smoothTime, _maxSpeed, _deltaTime );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.SmoothDamp!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SmoothDampAngle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDampAngle( _current, _target, ref _currentVelocity, _smoothTime );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 5&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDampAngle( _current, _target, ref _currentVelocity, _smoothTime, _maxSpeed );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6)) 
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    float _currentVelocity = (float)LuaAPI.lua_tonumber(L, 3);
                    float _smoothTime = (float)LuaAPI.lua_tonumber(L, 4);
                    float _maxSpeed = (float)LuaAPI.lua_tonumber(L, 5);
                    float _deltaTime = (float)LuaAPI.lua_tonumber(L, 6);
                    
                        var gen_ret = UnityEngine.Mathf.SmoothDampAngle( _current, _target, ref _currentVelocity, _smoothTime, _maxSpeed, _deltaTime );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _currentVelocity);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.Mathf.SmoothDampAngle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Repeat_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 1);
                    float _length = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.Repeat( _t, _length );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PingPong_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _t = (float)LuaAPI.lua_tonumber(L, 1);
                    float _length = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.PingPong( _t, _length );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InverseLerp_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _a = (float)LuaAPI.lua_tonumber(L, 1);
                    float _b = (float)LuaAPI.lua_tonumber(L, 2);
                    float _value = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = UnityEngine.Mathf.InverseLerp( _a, _b, _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeltaAngle_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _current = (float)LuaAPI.lua_tonumber(L, 1);
                    float _target = (float)LuaAPI.lua_tonumber(L, 2);
                    
                        var gen_ret = UnityEngine.Mathf.DeltaAngle( _current, _target );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
