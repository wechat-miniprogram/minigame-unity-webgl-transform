using Puerts;
using Puerts.TypeMapping;

namespace PuertsStaticWrap
{
#if ENABLE_IL2CPP
    [UnityEngine.Scripting.Preserve]
#endif
    public static class PuerRegisterInfo_Gen
    {
        public static RegisterInfo GetRegisterInfo_JsMonoBehaviour_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = JsMonoBehaviour_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "JSClassName",
                        new MemberRegisterInfo
                        {
                            Name = "JSClassName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JsMonoBehaviour_Wrap.G_JSClassName,
                            PropertySetter = JsMonoBehaviour_Wrap.S_JSClassName
#endif
                        }
                    },
                    {
                        "JsStart",
                        new MemberRegisterInfo
                        {
                            Name = "JsStart",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JsMonoBehaviour_Wrap.G_JsStart,
                            PropertySetter = JsMonoBehaviour_Wrap.S_JsStart
#endif
                        }
                    },
                    {
                        "JsUpdate",
                        new MemberRegisterInfo
                        {
                            Name = "JsUpdate",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JsMonoBehaviour_Wrap.G_JsUpdate,
                            PropertySetter = JsMonoBehaviour_Wrap.S_JsUpdate
#endif
                        }
                    },
                    {
                        "JsOnTriggerEnter",
                        new MemberRegisterInfo
                        {
                            Name = "JsOnTriggerEnter",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JsMonoBehaviour_Wrap.G_JsOnTriggerEnter,
                            PropertySetter = JsMonoBehaviour_Wrap.S_JsOnTriggerEnter
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_System_Type_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        "IsEnumDefined",
                        new MemberRegisterInfo
                        {
                            Name = "IsEnumDefined",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_IsEnumDefined
#endif
                        }
                    },
                    {
                        "GetEnumName",
                        new MemberRegisterInfo
                        {
                            Name = "GetEnumName",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEnumName
#endif
                        }
                    },
                    {
                        "GetEnumNames",
                        new MemberRegisterInfo
                        {
                            Name = "GetEnumNames",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEnumNames
#endif
                        }
                    },
                    {
                        "FindInterfaces",
                        new MemberRegisterInfo
                        {
                            Name = "FindInterfaces",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_FindInterfaces
#endif
                        }
                    },
                    {
                        "FindMembers",
                        new MemberRegisterInfo
                        {
                            Name = "FindMembers",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_FindMembers
#endif
                        }
                    },
                    {
                        "IsSubclassOf",
                        new MemberRegisterInfo
                        {
                            Name = "IsSubclassOf",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_IsSubclassOf
#endif
                        }
                    },
                    {
                        "IsAssignableFrom",
                        new MemberRegisterInfo
                        {
                            Name = "IsAssignableFrom",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_IsAssignableFrom
#endif
                        }
                    },
                    {
                        "GetType",
                        new MemberRegisterInfo
                        {
                            Name = "GetType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetType
#endif
                        }
                    },
                    {
                        "GetElementType",
                        new MemberRegisterInfo
                        {
                            Name = "GetElementType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetElementType
#endif
                        }
                    },
                    {
                        "GetArrayRank",
                        new MemberRegisterInfo
                        {
                            Name = "GetArrayRank",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetArrayRank
#endif
                        }
                    },
                    {
                        "GetGenericTypeDefinition",
                        new MemberRegisterInfo
                        {
                            Name = "GetGenericTypeDefinition",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetGenericTypeDefinition
#endif
                        }
                    },
                    {
                        "GetGenericArguments",
                        new MemberRegisterInfo
                        {
                            Name = "GetGenericArguments",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetGenericArguments
#endif
                        }
                    },
                    {
                        "GetGenericParameterConstraints",
                        new MemberRegisterInfo
                        {
                            Name = "GetGenericParameterConstraints",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetGenericParameterConstraints
#endif
                        }
                    },
                    {
                        "GetConstructor",
                        new MemberRegisterInfo
                        {
                            Name = "GetConstructor",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetConstructor
#endif
                        }
                    },
                    {
                        "GetConstructors",
                        new MemberRegisterInfo
                        {
                            Name = "GetConstructors",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetConstructors
#endif
                        }
                    },
                    {
                        "GetEvent",
                        new MemberRegisterInfo
                        {
                            Name = "GetEvent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEvent
#endif
                        }
                    },
                    {
                        "GetEvents",
                        new MemberRegisterInfo
                        {
                            Name = "GetEvents",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEvents
#endif
                        }
                    },
                    {
                        "GetField",
                        new MemberRegisterInfo
                        {
                            Name = "GetField",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetField
#endif
                        }
                    },
                    {
                        "GetFields",
                        new MemberRegisterInfo
                        {
                            Name = "GetFields",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetFields
#endif
                        }
                    },
                    {
                        "GetMember",
                        new MemberRegisterInfo
                        {
                            Name = "GetMember",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetMember
#endif
                        }
                    },
                    {
                        "GetMembers",
                        new MemberRegisterInfo
                        {
                            Name = "GetMembers",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetMembers
#endif
                        }
                    },
                    {
                        "GetMethod",
                        new MemberRegisterInfo
                        {
                            Name = "GetMethod",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetMethod
#endif
                        }
                    },
                    {
                        "GetMethods",
                        new MemberRegisterInfo
                        {
                            Name = "GetMethods",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetMethods
#endif
                        }
                    },
                    {
                        "GetNestedType",
                        new MemberRegisterInfo
                        {
                            Name = "GetNestedType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetNestedType
#endif
                        }
                    },
                    {
                        "GetNestedTypes",
                        new MemberRegisterInfo
                        {
                            Name = "GetNestedTypes",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetNestedTypes
#endif
                        }
                    },
                    {
                        "GetProperty",
                        new MemberRegisterInfo
                        {
                            Name = "GetProperty",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetProperty
#endif
                        }
                    },
                    {
                        "GetProperties",
                        new MemberRegisterInfo
                        {
                            Name = "GetProperties",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetProperties
#endif
                        }
                    },
                    {
                        "GetDefaultMembers",
                        new MemberRegisterInfo
                        {
                            Name = "GetDefaultMembers",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetDefaultMembers
#endif
                        }
                    },
                    {
                        "InvokeMember",
                        new MemberRegisterInfo
                        {
                            Name = "InvokeMember",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_InvokeMember
#endif
                        }
                    },
                    {
                        "GetInterface",
                        new MemberRegisterInfo
                        {
                            Name = "GetInterface",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetInterface
#endif
                        }
                    },
                    {
                        "GetInterfaces",
                        new MemberRegisterInfo
                        {
                            Name = "GetInterfaces",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetInterfaces
#endif
                        }
                    },
                    {
                        "GetInterfaceMap",
                        new MemberRegisterInfo
                        {
                            Name = "GetInterfaceMap",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetInterfaceMap
#endif
                        }
                    },
                    {
                        "IsInstanceOfType",
                        new MemberRegisterInfo
                        {
                            Name = "IsInstanceOfType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_IsInstanceOfType
#endif
                        }
                    },
                    {
                        "IsEquivalentTo",
                        new MemberRegisterInfo
                        {
                            Name = "IsEquivalentTo",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_IsEquivalentTo
#endif
                        }
                    },
                    {
                        "GetEnumUnderlyingType",
                        new MemberRegisterInfo
                        {
                            Name = "GetEnumUnderlyingType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEnumUnderlyingType
#endif
                        }
                    },
                    {
                        "GetEnumValues",
                        new MemberRegisterInfo
                        {
                            Name = "GetEnumValues",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetEnumValues
#endif
                        }
                    },
                    {
                        "MakeArrayType",
                        new MemberRegisterInfo
                        {
                            Name = "MakeArrayType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_MakeArrayType
#endif
                        }
                    },
                    {
                        "MakeByRefType",
                        new MemberRegisterInfo
                        {
                            Name = "MakeByRefType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_MakeByRefType
#endif
                        }
                    },
                    {
                        "MakeGenericType",
                        new MemberRegisterInfo
                        {
                            Name = "MakeGenericType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_MakeGenericType
#endif
                        }
                    },
                    {
                        "MakePointerType",
                        new MemberRegisterInfo
                        {
                            Name = "MakePointerType",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_MakePointerType
#endif
                        }
                    },
                    {
                        "ToString",
                        new MemberRegisterInfo
                        {
                            Name = "ToString",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_ToString
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "IsSerializable",
                        new MemberRegisterInfo
                        {
                            Name = "IsSerializable",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSerializable
#endif
                        }
                    },
                    {
                        "ContainsGenericParameters",
                        new MemberRegisterInfo
                        {
                            Name = "ContainsGenericParameters",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_ContainsGenericParameters
#endif
                        }
                    },
                    {
                        "IsVisible",
                        new MemberRegisterInfo
                        {
                            Name = "IsVisible",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsVisible
#endif
                        }
                    },
                    {
                        "MemberType",
                        new MemberRegisterInfo
                        {
                            Name = "MemberType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_MemberType
#endif
                        }
                    },
                    {
                        "Namespace",
                        new MemberRegisterInfo
                        {
                            Name = "Namespace",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Namespace
#endif
                        }
                    },
                    {
                        "AssemblyQualifiedName",
                        new MemberRegisterInfo
                        {
                            Name = "AssemblyQualifiedName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_AssemblyQualifiedName
#endif
                        }
                    },
                    {
                        "FullName",
                        new MemberRegisterInfo
                        {
                            Name = "FullName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_FullName
#endif
                        }
                    },
                    {
                        "Assembly",
                        new MemberRegisterInfo
                        {
                            Name = "Assembly",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Assembly
#endif
                        }
                    },
                    {
                        "Module",
                        new MemberRegisterInfo
                        {
                            Name = "Module",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Module
#endif
                        }
                    },
                    {
                        "IsNested",
                        new MemberRegisterInfo
                        {
                            Name = "IsNested",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNested
#endif
                        }
                    },
                    {
                        "DeclaringType",
                        new MemberRegisterInfo
                        {
                            Name = "DeclaringType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_DeclaringType
#endif
                        }
                    },
                    {
                        "DeclaringMethod",
                        new MemberRegisterInfo
                        {
                            Name = "DeclaringMethod",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_DeclaringMethod
#endif
                        }
                    },
                    {
                        "ReflectedType",
                        new MemberRegisterInfo
                        {
                            Name = "ReflectedType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_ReflectedType
#endif
                        }
                    },
                    {
                        "UnderlyingSystemType",
                        new MemberRegisterInfo
                        {
                            Name = "UnderlyingSystemType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_UnderlyingSystemType
#endif
                        }
                    },
                    {
                        "IsTypeDefinition",
                        new MemberRegisterInfo
                        {
                            Name = "IsTypeDefinition",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsTypeDefinition
#endif
                        }
                    },
                    {
                        "IsArray",
                        new MemberRegisterInfo
                        {
                            Name = "IsArray",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsArray
#endif
                        }
                    },
                    {
                        "IsByRef",
                        new MemberRegisterInfo
                        {
                            Name = "IsByRef",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsByRef
#endif
                        }
                    },
                    {
                        "IsPointer",
                        new MemberRegisterInfo
                        {
                            Name = "IsPointer",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsPointer
#endif
                        }
                    },
                    {
                        "IsConstructedGenericType",
                        new MemberRegisterInfo
                        {
                            Name = "IsConstructedGenericType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsConstructedGenericType
#endif
                        }
                    },
                    {
                        "IsGenericParameter",
                        new MemberRegisterInfo
                        {
                            Name = "IsGenericParameter",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsGenericParameter
#endif
                        }
                    },
                    {
                        "IsGenericTypeParameter",
                        new MemberRegisterInfo
                        {
                            Name = "IsGenericTypeParameter",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsGenericTypeParameter
#endif
                        }
                    },
                    {
                        "IsGenericMethodParameter",
                        new MemberRegisterInfo
                        {
                            Name = "IsGenericMethodParameter",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsGenericMethodParameter
#endif
                        }
                    },
                    {
                        "IsGenericType",
                        new MemberRegisterInfo
                        {
                            Name = "IsGenericType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsGenericType
#endif
                        }
                    },
                    {
                        "IsGenericTypeDefinition",
                        new MemberRegisterInfo
                        {
                            Name = "IsGenericTypeDefinition",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsGenericTypeDefinition
#endif
                        }
                    },
                    {
                        "IsSZArray",
                        new MemberRegisterInfo
                        {
                            Name = "IsSZArray",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.DontBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "IsVariableBoundArray",
                        new MemberRegisterInfo
                        {
                            Name = "IsVariableBoundArray",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsVariableBoundArray
#endif
                        }
                    },
                    {
                        "IsByRefLike",
                        new MemberRegisterInfo
                        {
                            Name = "IsByRefLike",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsByRefLike
#endif
                        }
                    },
                    {
                        "HasElementType",
                        new MemberRegisterInfo
                        {
                            Name = "HasElementType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_HasElementType
#endif
                        }
                    },
                    {
                        "GenericTypeArguments",
                        new MemberRegisterInfo
                        {
                            Name = "GenericTypeArguments",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_GenericTypeArguments
#endif
                        }
                    },
                    {
                        "GenericParameterPosition",
                        new MemberRegisterInfo
                        {
                            Name = "GenericParameterPosition",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_GenericParameterPosition
#endif
                        }
                    },
                    {
                        "GenericParameterAttributes",
                        new MemberRegisterInfo
                        {
                            Name = "GenericParameterAttributes",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_GenericParameterAttributes
#endif
                        }
                    },
                    {
                        "Attributes",
                        new MemberRegisterInfo
                        {
                            Name = "Attributes",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Attributes
#endif
                        }
                    },
                    {
                        "IsAbstract",
                        new MemberRegisterInfo
                        {
                            Name = "IsAbstract",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsAbstract
#endif
                        }
                    },
                    {
                        "IsImport",
                        new MemberRegisterInfo
                        {
                            Name = "IsImport",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsImport
#endif
                        }
                    },
                    {
                        "IsSealed",
                        new MemberRegisterInfo
                        {
                            Name = "IsSealed",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSealed
#endif
                        }
                    },
                    {
                        "IsSpecialName",
                        new MemberRegisterInfo
                        {
                            Name = "IsSpecialName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSpecialName
#endif
                        }
                    },
                    {
                        "IsClass",
                        new MemberRegisterInfo
                        {
                            Name = "IsClass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsClass
#endif
                        }
                    },
                    {
                        "IsNestedAssembly",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedAssembly",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedAssembly
#endif
                        }
                    },
                    {
                        "IsNestedFamANDAssem",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedFamANDAssem",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedFamANDAssem
#endif
                        }
                    },
                    {
                        "IsNestedFamily",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedFamily",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedFamily
#endif
                        }
                    },
                    {
                        "IsNestedFamORAssem",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedFamORAssem",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedFamORAssem
#endif
                        }
                    },
                    {
                        "IsNestedPrivate",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedPrivate",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedPrivate
#endif
                        }
                    },
                    {
                        "IsNestedPublic",
                        new MemberRegisterInfo
                        {
                            Name = "IsNestedPublic",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNestedPublic
#endif
                        }
                    },
                    {
                        "IsNotPublic",
                        new MemberRegisterInfo
                        {
                            Name = "IsNotPublic",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsNotPublic
#endif
                        }
                    },
                    {
                        "IsPublic",
                        new MemberRegisterInfo
                        {
                            Name = "IsPublic",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsPublic
#endif
                        }
                    },
                    {
                        "IsAutoLayout",
                        new MemberRegisterInfo
                        {
                            Name = "IsAutoLayout",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsAutoLayout
#endif
                        }
                    },
                    {
                        "IsExplicitLayout",
                        new MemberRegisterInfo
                        {
                            Name = "IsExplicitLayout",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsExplicitLayout
#endif
                        }
                    },
                    {
                        "IsLayoutSequential",
                        new MemberRegisterInfo
                        {
                            Name = "IsLayoutSequential",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsLayoutSequential
#endif
                        }
                    },
                    {
                        "IsAnsiClass",
                        new MemberRegisterInfo
                        {
                            Name = "IsAnsiClass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsAnsiClass
#endif
                        }
                    },
                    {
                        "IsAutoClass",
                        new MemberRegisterInfo
                        {
                            Name = "IsAutoClass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsAutoClass
#endif
                        }
                    },
                    {
                        "IsUnicodeClass",
                        new MemberRegisterInfo
                        {
                            Name = "IsUnicodeClass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsUnicodeClass
#endif
                        }
                    },
                    {
                        "IsCOMObject",
                        new MemberRegisterInfo
                        {
                            Name = "IsCOMObject",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsCOMObject
#endif
                        }
                    },
                    {
                        "IsContextful",
                        new MemberRegisterInfo
                        {
                            Name = "IsContextful",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsContextful
#endif
                        }
                    },
                    {
                        "IsCollectible",
                        new MemberRegisterInfo
                        {
                            Name = "IsCollectible",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.SlowBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "IsEnum",
                        new MemberRegisterInfo
                        {
                            Name = "IsEnum",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsEnum
#endif
                        }
                    },
                    {
                        "IsMarshalByRef",
                        new MemberRegisterInfo
                        {
                            Name = "IsMarshalByRef",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsMarshalByRef
#endif
                        }
                    },
                    {
                        "IsPrimitive",
                        new MemberRegisterInfo
                        {
                            Name = "IsPrimitive",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsPrimitive
#endif
                        }
                    },
                    {
                        "IsValueType",
                        new MemberRegisterInfo
                        {
                            Name = "IsValueType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsValueType
#endif
                        }
                    },
                    {
                        "IsSignatureType",
                        new MemberRegisterInfo
                        {
                            Name = "IsSignatureType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSignatureType
#endif
                        }
                    },
                    {
                        "IsSecurityCritical",
                        new MemberRegisterInfo
                        {
                            Name = "IsSecurityCritical",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSecurityCritical
#endif
                        }
                    },
                    {
                        "IsSecuritySafeCritical",
                        new MemberRegisterInfo
                        {
                            Name = "IsSecuritySafeCritical",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSecuritySafeCritical
#endif
                        }
                    },
                    {
                        "IsSecurityTransparent",
                        new MemberRegisterInfo
                        {
                            Name = "IsSecurityTransparent",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsSecurityTransparent
#endif
                        }
                    },
                    {
                        "StructLayoutAttribute",
                        new MemberRegisterInfo
                        {
                            Name = "StructLayoutAttribute",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_StructLayoutAttribute
#endif
                        }
                    },
                    {
                        "TypeInitializer",
                        new MemberRegisterInfo
                        {
                            Name = "TypeInitializer",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_TypeInitializer
#endif
                        }
                    },
                    {
                        "TypeHandle",
                        new MemberRegisterInfo
                        {
                            Name = "TypeHandle",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_TypeHandle
#endif
                        }
                    },
                    {
                        "GUID",
                        new MemberRegisterInfo
                        {
                            Name = "GUID",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_GUID
#endif
                        }
                    },
                    {
                        "BaseType",
                        new MemberRegisterInfo
                        {
                            Name = "BaseType",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_BaseType
#endif
                        }
                    },
                    {
                        "IsInterface",
                        new MemberRegisterInfo
                        {
                            Name = "IsInterface",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_IsInterface
#endif
                        }
                    },
                    {
                        "GetTypeHandle_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeHandle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeHandle
#endif
                        }
                    },
                    {
                        "GetTypeArray_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeArray",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeArray
#endif
                        }
                    },
                    {
                        "GetTypeCode_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeCode",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeCode
#endif
                        }
                    },
                    {
                        "GetTypeFromCLSID_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeFromCLSID",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeFromCLSID
#endif
                        }
                    },
                    {
                        "GetTypeFromProgID_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeFromProgID",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeFromProgID
#endif
                        }
                    },
                    {
                        "MakeGenericSignatureType_static",
                        new MemberRegisterInfo
                        {
                            Name = "MakeGenericSignatureType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.SlowBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "MakeGenericMethodParameter_static",
                        new MemberRegisterInfo
                        {
                            Name = "MakeGenericMethodParameter",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_MakeGenericMethodParameter
#endif
                        }
                    },
                    {
                        "GetTypeFromHandle_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTypeFromHandle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetTypeFromHandle
#endif
                        }
                    },
                    {
                        "GetType_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_GetType
#endif
                        }
                    },
                    {
                        "ReflectionOnlyGetType_static",
                        new MemberRegisterInfo
                        {
                            Name = "ReflectionOnlyGetType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Type_Wrap.F_ReflectionOnlyGetType
#endif
                        }
                    },
                    {
                        "DefaultBinder_static",
                        new MemberRegisterInfo
                        {
                            Name = "DefaultBinder",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_DefaultBinder
#endif
                        }
                    },
                    {
                        "Delimiter_static",
                        new MemberRegisterInfo
                        {
                            Name = "Delimiter",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Delimiter
#endif
                        }
                    },
                    {
                        "EmptyTypes_static",
                        new MemberRegisterInfo
                        {
                            Name = "EmptyTypes",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_EmptyTypes
#endif
                        }
                    },
                    {
                        "Missing_static",
                        new MemberRegisterInfo
                        {
                            Name = "Missing",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_Missing
#endif
                        }
                    },
                    {
                        "FilterAttribute_static",
                        new MemberRegisterInfo
                        {
                            Name = "FilterAttribute",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_FilterAttribute
#endif
                        }
                    },
                    {
                        "FilterName_static",
                        new MemberRegisterInfo
                        {
                            Name = "FilterName",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_FilterName
#endif
                        }
                    },
                    {
                        "FilterNameIgnoreCase_static",
                        new MemberRegisterInfo
                        {
                            Name = "FilterNameIgnoreCase",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Type_Wrap.G_FilterNameIgnoreCase
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Input_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Input_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "GetAxis_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetAxis",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetAxis
#endif
                        }
                    },
                    {
                        "GetAxisRaw_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetAxisRaw",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetAxisRaw
#endif
                        }
                    },
                    {
                        "GetButton_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetButton",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetButton
#endif
                        }
                    },
                    {
                        "GetButtonDown_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetButtonDown",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetButtonDown
#endif
                        }
                    },
                    {
                        "GetButtonUp_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetButtonUp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetButtonUp
#endif
                        }
                    },
                    {
                        "GetMouseButton_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetMouseButton",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetMouseButton
#endif
                        }
                    },
                    {
                        "GetMouseButtonDown_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetMouseButtonDown",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetMouseButtonDown
#endif
                        }
                    },
                    {
                        "GetMouseButtonUp_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetMouseButtonUp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetMouseButtonUp
#endif
                        }
                    },
                    {
                        "ResetInputAxes_static",
                        new MemberRegisterInfo
                        {
                            Name = "ResetInputAxes",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_ResetInputAxes
#endif
                        }
                    },
                    {
                        "IsJoystickPreconfigured_static",
                        new MemberRegisterInfo
                        {
                            Name = "IsJoystickPreconfigured",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.SlowBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "GetJoystickNames_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetJoystickNames",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetJoystickNames
#endif
                        }
                    },
                    {
                        "GetTouch_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTouch",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetTouch
#endif
                        }
                    },
                    {
                        "GetAccelerationEvent_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetAccelerationEvent",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetAccelerationEvent
#endif
                        }
                    },
                    {
                        "GetKey_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetKey",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetKey
#endif
                        }
                    },
                    {
                        "GetKeyUp_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetKeyUp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetKeyUp
#endif
                        }
                    },
                    {
                        "GetKeyDown_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetKeyDown",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Input_Wrap.F_GetKeyDown
#endif
                        }
                    },
                    {
                        "simulateMouseWithTouches_static",
                        new MemberRegisterInfo
                        {
                            Name = "simulateMouseWithTouches",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_simulateMouseWithTouches,
                            PropertySetter = UnityEngine_Input_Wrap.S_simulateMouseWithTouches
#endif
                        }
                    },
                    {
                        "anyKey_static",
                        new MemberRegisterInfo
                        {
                            Name = "anyKey",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_anyKey
#endif
                        }
                    },
                    {
                        "anyKeyDown_static",
                        new MemberRegisterInfo
                        {
                            Name = "anyKeyDown",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_anyKeyDown
#endif
                        }
                    },
                    {
                        "inputString_static",
                        new MemberRegisterInfo
                        {
                            Name = "inputString",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_inputString
#endif
                        }
                    },
                    {
                        "mousePosition_static",
                        new MemberRegisterInfo
                        {
                            Name = "mousePosition",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_mousePosition
#endif
                        }
                    },
                    {
                        "mouseScrollDelta_static",
                        new MemberRegisterInfo
                        {
                            Name = "mouseScrollDelta",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_mouseScrollDelta
#endif
                        }
                    },
                    {
                        "imeCompositionMode_static",
                        new MemberRegisterInfo
                        {
                            Name = "imeCompositionMode",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_imeCompositionMode,
                            PropertySetter = UnityEngine_Input_Wrap.S_imeCompositionMode
#endif
                        }
                    },
                    {
                        "compositionString_static",
                        new MemberRegisterInfo
                        {
                            Name = "compositionString",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_compositionString
#endif
                        }
                    },
                    {
                        "imeIsSelected_static",
                        new MemberRegisterInfo
                        {
                            Name = "imeIsSelected",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_imeIsSelected
#endif
                        }
                    },
                    {
                        "compositionCursorPos_static",
                        new MemberRegisterInfo
                        {
                            Name = "compositionCursorPos",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_compositionCursorPos,
                            PropertySetter = UnityEngine_Input_Wrap.S_compositionCursorPos
#endif
                        }
                    },
                    {
                        "mousePresent_static",
                        new MemberRegisterInfo
                        {
                            Name = "mousePresent",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_mousePresent
#endif
                        }
                    },
                    {
                        "touchCount_static",
                        new MemberRegisterInfo
                        {
                            Name = "touchCount",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_touchCount
#endif
                        }
                    },
                    {
                        "touchPressureSupported_static",
                        new MemberRegisterInfo
                        {
                            Name = "touchPressureSupported",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_touchPressureSupported
#endif
                        }
                    },
                    {
                        "stylusTouchSupported_static",
                        new MemberRegisterInfo
                        {
                            Name = "stylusTouchSupported",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_stylusTouchSupported
#endif
                        }
                    },
                    {
                        "touchSupported_static",
                        new MemberRegisterInfo
                        {
                            Name = "touchSupported",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_touchSupported
#endif
                        }
                    },
                    {
                        "multiTouchEnabled_static",
                        new MemberRegisterInfo
                        {
                            Name = "multiTouchEnabled",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_multiTouchEnabled,
                            PropertySetter = UnityEngine_Input_Wrap.S_multiTouchEnabled
#endif
                        }
                    },
                    {
                        "deviceOrientation_static",
                        new MemberRegisterInfo
                        {
                            Name = "deviceOrientation",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_deviceOrientation
#endif
                        }
                    },
                    {
                        "acceleration_static",
                        new MemberRegisterInfo
                        {
                            Name = "acceleration",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_acceleration
#endif
                        }
                    },
                    {
                        "compensateSensors_static",
                        new MemberRegisterInfo
                        {
                            Name = "compensateSensors",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_compensateSensors,
                            PropertySetter = UnityEngine_Input_Wrap.S_compensateSensors
#endif
                        }
                    },
                    {
                        "accelerationEventCount_static",
                        new MemberRegisterInfo
                        {
                            Name = "accelerationEventCount",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_accelerationEventCount
#endif
                        }
                    },
                    {
                        "backButtonLeavesApp_static",
                        new MemberRegisterInfo
                        {
                            Name = "backButtonLeavesApp",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_backButtonLeavesApp,
                            PropertySetter = UnityEngine_Input_Wrap.S_backButtonLeavesApp
#endif
                        }
                    },
                    {
                        "location_static",
                        new MemberRegisterInfo
                        {
                            Name = "location",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_location
#endif
                        }
                    },
                    {
                        "compass_static",
                        new MemberRegisterInfo
                        {
                            Name = "compass",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_compass
#endif
                        }
                    },
                    {
                        "gyro_static",
                        new MemberRegisterInfo
                        {
                            Name = "gyro",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_gyro
#endif
                        }
                    },
                    {
                        "touches_static",
                        new MemberRegisterInfo
                        {
                            Name = "touches",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_touches
#endif
                        }
                    },
                    {
                        "accelerationEvents_static",
                        new MemberRegisterInfo
                        {
                            Name = "accelerationEvents",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Input_Wrap.G_accelerationEvents
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Object_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Object_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "GetInstanceID",
                        new MemberRegisterInfo
                        {
                            Name = "GetInstanceID",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.M_GetInstanceID
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "ToString",
                        new MemberRegisterInfo
                        {
                            Name = "ToString",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.M_ToString
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "name",
                        new MemberRegisterInfo
                        {
                            Name = "name",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Object_Wrap.G_name,
                            PropertySetter = UnityEngine_Object_Wrap.S_name
#endif
                        }
                    },
                    {
                        "hideFlags",
                        new MemberRegisterInfo
                        {
                            Name = "hideFlags",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Object_Wrap.G_hideFlags,
                            PropertySetter = UnityEngine_Object_Wrap.S_hideFlags
#endif
                        }
                    },
                    {
                        "Instantiate_static",
                        new MemberRegisterInfo
                        {
                            Name = "Instantiate",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_Instantiate
#endif
                        }
                    },
                    {
                        "Destroy_static",
                        new MemberRegisterInfo
                        {
                            Name = "Destroy",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_Destroy
#endif
                        }
                    },
                    {
                        "DestroyImmediate_static",
                        new MemberRegisterInfo
                        {
                            Name = "DestroyImmediate",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_DestroyImmediate
#endif
                        }
                    },
                    {
                        "FindObjectsOfType_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindObjectsOfType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_FindObjectsOfType
#endif
                        }
                    },
                    {
                        "FindObjectsByType_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindObjectsByType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_FindObjectsByType
#endif
                        }
                    },
                    {
                        "DontDestroyOnLoad_static",
                        new MemberRegisterInfo
                        {
                            Name = "DontDestroyOnLoad",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_DontDestroyOnLoad
#endif
                        }
                    },
                    {
                        "FindObjectOfType_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindObjectOfType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_FindObjectOfType
#endif
                        }
                    },
                    {
                        "FindFirstObjectByType_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindFirstObjectByType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_FindFirstObjectByType
#endif
                        }
                    },
                    {
                        "FindAnyObjectByType_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindAnyObjectByType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Object_Wrap.F_FindAnyObjectByType
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_GameObject_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_GameObject_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "GetComponent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponent
#endif
                        }
                    },
                    {
                        "GetComponentInChildren",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentInChildren",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponentInChildren
#endif
                        }
                    },
                    {
                        "GetComponentInParent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentInParent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponentInParent
#endif
                        }
                    },
                    {
                        "GetComponents",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponents",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponents
#endif
                        }
                    },
                    {
                        "GetComponentsInChildren",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentsInChildren",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponentsInChildren
#endif
                        }
                    },
                    {
                        "GetComponentsInParent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentsInParent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_GetComponentsInParent
#endif
                        }
                    },
                    {
                        "TryGetComponent",
                        new MemberRegisterInfo
                        {
                            Name = "TryGetComponent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_TryGetComponent
#endif
                        }
                    },
                    {
                        "SendMessageUpwards",
                        new MemberRegisterInfo
                        {
                            Name = "SendMessageUpwards",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_SendMessageUpwards
#endif
                        }
                    },
                    {
                        "SendMessage",
                        new MemberRegisterInfo
                        {
                            Name = "SendMessage",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_SendMessage
#endif
                        }
                    },
                    {
                        "BroadcastMessage",
                        new MemberRegisterInfo
                        {
                            Name = "BroadcastMessage",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_BroadcastMessage
#endif
                        }
                    },
                    {
                        "AddComponent",
                        new MemberRegisterInfo
                        {
                            Name = "AddComponent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_AddComponent
#endif
                        }
                    },
                    {
                        "SetActive",
                        new MemberRegisterInfo
                        {
                            Name = "SetActive",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_SetActive
#endif
                        }
                    },
                    {
                        "CompareTag",
                        new MemberRegisterInfo
                        {
                            Name = "CompareTag",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.M_CompareTag
#endif
                        }
                    },
                    {
                        "transform",
                        new MemberRegisterInfo
                        {
                            Name = "transform",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_transform
#endif
                        }
                    },
                    {
                        "layer",
                        new MemberRegisterInfo
                        {
                            Name = "layer",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_layer,
                            PropertySetter = UnityEngine_GameObject_Wrap.S_layer
#endif
                        }
                    },
                    {
                        "activeSelf",
                        new MemberRegisterInfo
                        {
                            Name = "activeSelf",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_activeSelf
#endif
                        }
                    },
                    {
                        "activeInHierarchy",
                        new MemberRegisterInfo
                        {
                            Name = "activeInHierarchy",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_activeInHierarchy
#endif
                        }
                    },
                    {
                        "isStatic",
                        new MemberRegisterInfo
                        {
                            Name = "isStatic",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_isStatic,
                            PropertySetter = UnityEngine_GameObject_Wrap.S_isStatic
#endif
                        }
                    },
                    {
                        "tag",
                        new MemberRegisterInfo
                        {
                            Name = "tag",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_tag,
                            PropertySetter = UnityEngine_GameObject_Wrap.S_tag
#endif
                        }
                    },
                    {
                        "scene",
                        new MemberRegisterInfo
                        {
                            Name = "scene",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_scene
#endif
                        }
                    },
                    {
                        "sceneCullingMask",
                        new MemberRegisterInfo
                        {
                            Name = "sceneCullingMask",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_sceneCullingMask
#endif
                        }
                    },
                    {
                        "gameObject",
                        new MemberRegisterInfo
                        {
                            Name = "gameObject",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_GameObject_Wrap.G_gameObject
#endif
                        }
                    },
                    {
                        "CreatePrimitive_static",
                        new MemberRegisterInfo
                        {
                            Name = "CreatePrimitive",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.F_CreatePrimitive
#endif
                        }
                    },
                    {
                        "FindWithTag_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindWithTag",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.F_FindWithTag
#endif
                        }
                    },
                    {
                        "FindGameObjectWithTag_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindGameObjectWithTag",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.F_FindGameObjectWithTag
#endif
                        }
                    },
                    {
                        "FindGameObjectsWithTag_static",
                        new MemberRegisterInfo
                        {
                            Name = "FindGameObjectsWithTag",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.F_FindGameObjectsWithTag
#endif
                        }
                    },
                    {
                        "Find_static",
                        new MemberRegisterInfo
                        {
                            Name = "Find",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_GameObject_Wrap.F_Find
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Transform_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        "SetParent",
                        new MemberRegisterInfo
                        {
                            Name = "SetParent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetParent
#endif
                        }
                    },
                    {
                        "SetPositionAndRotation",
                        new MemberRegisterInfo
                        {
                            Name = "SetPositionAndRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetPositionAndRotation
#endif
                        }
                    },
                    {
                        "SetLocalPositionAndRotation",
                        new MemberRegisterInfo
                        {
                            Name = "SetLocalPositionAndRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetLocalPositionAndRotation
#endif
                        }
                    },
                    {
                        "GetPositionAndRotation",
                        new MemberRegisterInfo
                        {
                            Name = "GetPositionAndRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_GetPositionAndRotation
#endif
                        }
                    },
                    {
                        "GetLocalPositionAndRotation",
                        new MemberRegisterInfo
                        {
                            Name = "GetLocalPositionAndRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_GetLocalPositionAndRotation
#endif
                        }
                    },
                    {
                        "Translate",
                        new MemberRegisterInfo
                        {
                            Name = "Translate",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_Translate
#endif
                        }
                    },
                    {
                        "Rotate",
                        new MemberRegisterInfo
                        {
                            Name = "Rotate",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_Rotate
#endif
                        }
                    },
                    {
                        "RotateAround",
                        new MemberRegisterInfo
                        {
                            Name = "RotateAround",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_RotateAround
#endif
                        }
                    },
                    {
                        "LookAt",
                        new MemberRegisterInfo
                        {
                            Name = "LookAt",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_LookAt
#endif
                        }
                    },
                    {
                        "TransformDirection",
                        new MemberRegisterInfo
                        {
                            Name = "TransformDirection",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_TransformDirection
#endif
                        }
                    },
                    {
                        "InverseTransformDirection",
                        new MemberRegisterInfo
                        {
                            Name = "InverseTransformDirection",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_InverseTransformDirection
#endif
                        }
                    },
                    {
                        "TransformVector",
                        new MemberRegisterInfo
                        {
                            Name = "TransformVector",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_TransformVector
#endif
                        }
                    },
                    {
                        "InverseTransformVector",
                        new MemberRegisterInfo
                        {
                            Name = "InverseTransformVector",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_InverseTransformVector
#endif
                        }
                    },
                    {
                        "TransformPoint",
                        new MemberRegisterInfo
                        {
                            Name = "TransformPoint",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_TransformPoint
#endif
                        }
                    },
                    {
                        "InverseTransformPoint",
                        new MemberRegisterInfo
                        {
                            Name = "InverseTransformPoint",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_InverseTransformPoint
#endif
                        }
                    },
                    {
                        "DetachChildren",
                        new MemberRegisterInfo
                        {
                            Name = "DetachChildren",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_DetachChildren
#endif
                        }
                    },
                    {
                        "SetAsFirstSibling",
                        new MemberRegisterInfo
                        {
                            Name = "SetAsFirstSibling",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetAsFirstSibling
#endif
                        }
                    },
                    {
                        "SetAsLastSibling",
                        new MemberRegisterInfo
                        {
                            Name = "SetAsLastSibling",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetAsLastSibling
#endif
                        }
                    },
                    {
                        "SetSiblingIndex",
                        new MemberRegisterInfo
                        {
                            Name = "SetSiblingIndex",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_SetSiblingIndex
#endif
                        }
                    },
                    {
                        "GetSiblingIndex",
                        new MemberRegisterInfo
                        {
                            Name = "GetSiblingIndex",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_GetSiblingIndex
#endif
                        }
                    },
                    {
                        "Find",
                        new MemberRegisterInfo
                        {
                            Name = "Find",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_Find
#endif
                        }
                    },
                    {
                        "IsChildOf",
                        new MemberRegisterInfo
                        {
                            Name = "IsChildOf",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_IsChildOf
#endif
                        }
                    },
                    {
                        "GetEnumerator",
                        new MemberRegisterInfo
                        {
                            Name = "GetEnumerator",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_GetEnumerator
#endif
                        }
                    },
                    {
                        "GetChild",
                        new MemberRegisterInfo
                        {
                            Name = "GetChild",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Transform_Wrap.M_GetChild
#endif
                        }
                    },
                    {
                        "position",
                        new MemberRegisterInfo
                        {
                            Name = "position",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_position,
                            PropertySetter = UnityEngine_Transform_Wrap.S_position
#endif
                        }
                    },
                    {
                        "localPosition",
                        new MemberRegisterInfo
                        {
                            Name = "localPosition",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_localPosition,
                            PropertySetter = UnityEngine_Transform_Wrap.S_localPosition
#endif
                        }
                    },
                    {
                        "eulerAngles",
                        new MemberRegisterInfo
                        {
                            Name = "eulerAngles",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_eulerAngles,
                            PropertySetter = UnityEngine_Transform_Wrap.S_eulerAngles
#endif
                        }
                    },
                    {
                        "localEulerAngles",
                        new MemberRegisterInfo
                        {
                            Name = "localEulerAngles",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_localEulerAngles,
                            PropertySetter = UnityEngine_Transform_Wrap.S_localEulerAngles
#endif
                        }
                    },
                    {
                        "right",
                        new MemberRegisterInfo
                        {
                            Name = "right",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_right,
                            PropertySetter = UnityEngine_Transform_Wrap.S_right
#endif
                        }
                    },
                    {
                        "up",
                        new MemberRegisterInfo
                        {
                            Name = "up",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_up,
                            PropertySetter = UnityEngine_Transform_Wrap.S_up
#endif
                        }
                    },
                    {
                        "forward",
                        new MemberRegisterInfo
                        {
                            Name = "forward",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_forward,
                            PropertySetter = UnityEngine_Transform_Wrap.S_forward
#endif
                        }
                    },
                    {
                        "rotation",
                        new MemberRegisterInfo
                        {
                            Name = "rotation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_rotation,
                            PropertySetter = UnityEngine_Transform_Wrap.S_rotation
#endif
                        }
                    },
                    {
                        "localRotation",
                        new MemberRegisterInfo
                        {
                            Name = "localRotation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_localRotation,
                            PropertySetter = UnityEngine_Transform_Wrap.S_localRotation
#endif
                        }
                    },
                    {
                        "localScale",
                        new MemberRegisterInfo
                        {
                            Name = "localScale",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_localScale,
                            PropertySetter = UnityEngine_Transform_Wrap.S_localScale
#endif
                        }
                    },
                    {
                        "parent",
                        new MemberRegisterInfo
                        {
                            Name = "parent",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_parent,
                            PropertySetter = UnityEngine_Transform_Wrap.S_parent
#endif
                        }
                    },
                    {
                        "worldToLocalMatrix",
                        new MemberRegisterInfo
                        {
                            Name = "worldToLocalMatrix",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_worldToLocalMatrix
#endif
                        }
                    },
                    {
                        "localToWorldMatrix",
                        new MemberRegisterInfo
                        {
                            Name = "localToWorldMatrix",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_localToWorldMatrix
#endif
                        }
                    },
                    {
                        "root",
                        new MemberRegisterInfo
                        {
                            Name = "root",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_root
#endif
                        }
                    },
                    {
                        "childCount",
                        new MemberRegisterInfo
                        {
                            Name = "childCount",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_childCount
#endif
                        }
                    },
                    {
                        "lossyScale",
                        new MemberRegisterInfo
                        {
                            Name = "lossyScale",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_lossyScale
#endif
                        }
                    },
                    {
                        "hasChanged",
                        new MemberRegisterInfo
                        {
                            Name = "hasChanged",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_hasChanged,
                            PropertySetter = UnityEngine_Transform_Wrap.S_hasChanged
#endif
                        }
                    },
                    {
                        "hierarchyCapacity",
                        new MemberRegisterInfo
                        {
                            Name = "hierarchyCapacity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_hierarchyCapacity,
                            PropertySetter = UnityEngine_Transform_Wrap.S_hierarchyCapacity
#endif
                        }
                    },
                    {
                        "hierarchyCount",
                        new MemberRegisterInfo
                        {
                            Name = "hierarchyCount",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Transform_Wrap.G_hierarchyCount
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Rigidbody_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Rigidbody_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "SetDensity",
                        new MemberRegisterInfo
                        {
                            Name = "SetDensity",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_SetDensity
#endif
                        }
                    },
                    {
                        "MovePosition",
                        new MemberRegisterInfo
                        {
                            Name = "MovePosition",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_MovePosition
#endif
                        }
                    },
                    {
                        "MoveRotation",
                        new MemberRegisterInfo
                        {
                            Name = "MoveRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_MoveRotation
#endif
                        }
                    },
                    {
                        "Sleep",
                        new MemberRegisterInfo
                        {
                            Name = "Sleep",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_Sleep
#endif
                        }
                    },
                    {
                        "IsSleeping",
                        new MemberRegisterInfo
                        {
                            Name = "IsSleeping",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_IsSleeping
#endif
                        }
                    },
                    {
                        "WakeUp",
                        new MemberRegisterInfo
                        {
                            Name = "WakeUp",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_WakeUp
#endif
                        }
                    },
                    {
                        "ResetCenterOfMass",
                        new MemberRegisterInfo
                        {
                            Name = "ResetCenterOfMass",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_ResetCenterOfMass
#endif
                        }
                    },
                    {
                        "ResetInertiaTensor",
                        new MemberRegisterInfo
                        {
                            Name = "ResetInertiaTensor",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_ResetInertiaTensor
#endif
                        }
                    },
                    {
                        "GetRelativePointVelocity",
                        new MemberRegisterInfo
                        {
                            Name = "GetRelativePointVelocity",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_GetRelativePointVelocity
#endif
                        }
                    },
                    {
                        "GetPointVelocity",
                        new MemberRegisterInfo
                        {
                            Name = "GetPointVelocity",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_GetPointVelocity
#endif
                        }
                    },
                    {
                        "AddForce",
                        new MemberRegisterInfo
                        {
                            Name = "AddForce",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddForce
#endif
                        }
                    },
                    {
                        "AddRelativeForce",
                        new MemberRegisterInfo
                        {
                            Name = "AddRelativeForce",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddRelativeForce
#endif
                        }
                    },
                    {
                        "AddTorque",
                        new MemberRegisterInfo
                        {
                            Name = "AddTorque",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddTorque
#endif
                        }
                    },
                    {
                        "AddRelativeTorque",
                        new MemberRegisterInfo
                        {
                            Name = "AddRelativeTorque",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddRelativeTorque
#endif
                        }
                    },
                    {
                        "AddForceAtPosition",
                        new MemberRegisterInfo
                        {
                            Name = "AddForceAtPosition",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddForceAtPosition
#endif
                        }
                    },
                    {
                        "AddExplosionForce",
                        new MemberRegisterInfo
                        {
                            Name = "AddExplosionForce",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_AddExplosionForce
#endif
                        }
                    },
                    {
                        "ClosestPointOnBounds",
                        new MemberRegisterInfo
                        {
                            Name = "ClosestPointOnBounds",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_ClosestPointOnBounds
#endif
                        }
                    },
                    {
                        "SweepTest",
                        new MemberRegisterInfo
                        {
                            Name = "SweepTest",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_SweepTest
#endif
                        }
                    },
                    {
                        "SweepTestAll",
                        new MemberRegisterInfo
                        {
                            Name = "SweepTestAll",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Rigidbody_Wrap.M_SweepTestAll
#endif
                        }
                    },
                    {
                        "velocity",
                        new MemberRegisterInfo
                        {
                            Name = "velocity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_velocity,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_velocity
#endif
                        }
                    },
                    {
                        "angularVelocity",
                        new MemberRegisterInfo
                        {
                            Name = "angularVelocity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_angularVelocity,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_angularVelocity
#endif
                        }
                    },
                    {
                        "drag",
                        new MemberRegisterInfo
                        {
                            Name = "drag",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_drag,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_drag
#endif
                        }
                    },
                    {
                        "angularDrag",
                        new MemberRegisterInfo
                        {
                            Name = "angularDrag",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_angularDrag,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_angularDrag
#endif
                        }
                    },
                    {
                        "mass",
                        new MemberRegisterInfo
                        {
                            Name = "mass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_mass,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_mass
#endif
                        }
                    },
                    {
                        "useGravity",
                        new MemberRegisterInfo
                        {
                            Name = "useGravity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_useGravity,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_useGravity
#endif
                        }
                    },
                    {
                        "maxDepenetrationVelocity",
                        new MemberRegisterInfo
                        {
                            Name = "maxDepenetrationVelocity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_maxDepenetrationVelocity,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_maxDepenetrationVelocity
#endif
                        }
                    },
                    {
                        "isKinematic",
                        new MemberRegisterInfo
                        {
                            Name = "isKinematic",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_isKinematic,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_isKinematic
#endif
                        }
                    },
                    {
                        "freezeRotation",
                        new MemberRegisterInfo
                        {
                            Name = "freezeRotation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_freezeRotation,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_freezeRotation
#endif
                        }
                    },
                    {
                        "constraints",
                        new MemberRegisterInfo
                        {
                            Name = "constraints",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_constraints,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_constraints
#endif
                        }
                    },
                    {
                        "collisionDetectionMode",
                        new MemberRegisterInfo
                        {
                            Name = "collisionDetectionMode",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_collisionDetectionMode,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_collisionDetectionMode
#endif
                        }
                    },
                    {
                        "centerOfMass",
                        new MemberRegisterInfo
                        {
                            Name = "centerOfMass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_centerOfMass,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_centerOfMass
#endif
                        }
                    },
                    {
                        "worldCenterOfMass",
                        new MemberRegisterInfo
                        {
                            Name = "worldCenterOfMass",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_worldCenterOfMass
#endif
                        }
                    },
                    {
                        "inertiaTensorRotation",
                        new MemberRegisterInfo
                        {
                            Name = "inertiaTensorRotation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_inertiaTensorRotation,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_inertiaTensorRotation
#endif
                        }
                    },
                    {
                        "inertiaTensor",
                        new MemberRegisterInfo
                        {
                            Name = "inertiaTensor",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_inertiaTensor,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_inertiaTensor
#endif
                        }
                    },
                    {
                        "detectCollisions",
                        new MemberRegisterInfo
                        {
                            Name = "detectCollisions",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_detectCollisions,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_detectCollisions
#endif
                        }
                    },
                    {
                        "position",
                        new MemberRegisterInfo
                        {
                            Name = "position",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_position,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_position
#endif
                        }
                    },
                    {
                        "rotation",
                        new MemberRegisterInfo
                        {
                            Name = "rotation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_rotation,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_rotation
#endif
                        }
                    },
                    {
                        "interpolation",
                        new MemberRegisterInfo
                        {
                            Name = "interpolation",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_interpolation,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_interpolation
#endif
                        }
                    },
                    {
                        "solverIterations",
                        new MemberRegisterInfo
                        {
                            Name = "solverIterations",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_solverIterations,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_solverIterations
#endif
                        }
                    },
                    {
                        "sleepThreshold",
                        new MemberRegisterInfo
                        {
                            Name = "sleepThreshold",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_sleepThreshold,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_sleepThreshold
#endif
                        }
                    },
                    {
                        "maxAngularVelocity",
                        new MemberRegisterInfo
                        {
                            Name = "maxAngularVelocity",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_maxAngularVelocity,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_maxAngularVelocity
#endif
                        }
                    },
                    {
                        "solverVelocityIterations",
                        new MemberRegisterInfo
                        {
                            Name = "solverVelocityIterations",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Rigidbody_Wrap.G_solverVelocityIterations,
                            PropertySetter = UnityEngine_Rigidbody_Wrap.S_solverVelocityIterations
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Vector3_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = true,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Vector3_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "Set",
                        new MemberRegisterInfo
                        {
                            Name = "Set",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_Set
#endif
                        }
                    },
                    {
                        "Scale",
                        new MemberRegisterInfo
                        {
                            Name = "Scale",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_Scale
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "Normalize",
                        new MemberRegisterInfo
                        {
                            Name = "Normalize",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_Normalize
#endif
                        }
                    },
                    {
                        "op_Addition_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Addition",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Addition
#endif
                        }
                    },
                    {
                        "op_Subtraction_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Subtraction",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Subtraction
#endif
                        }
                    },
                    {
                        "op_UnaryNegation_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_UnaryNegation",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_UnaryNegation
#endif
                        }
                    },
                    {
                        "op_Multiply_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Multiply",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Multiply
#endif
                        }
                    },
                    {
                        "op_Division_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Division",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Division
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "ToString",
                        new MemberRegisterInfo
                        {
                            Name = "ToString",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.M_ToString
#endif
                        }
                    },
                    {
                        "get_Item",
                        new MemberRegisterInfo
                        {
                            Name = "get_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.GetItem
#endif
                        }
                    },
                    {
                        "set_Item",
                        new MemberRegisterInfo
                        {
                            Name = "set_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.SetItem
#endif
                        }
                    },
                    {
                        "normalized",
                        new MemberRegisterInfo
                        {
                            Name = "normalized",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_normalized
#endif
                        }
                    },
                    {
                        "magnitude",
                        new MemberRegisterInfo
                        {
                            Name = "magnitude",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_magnitude
#endif
                        }
                    },
                    {
                        "sqrMagnitude",
                        new MemberRegisterInfo
                        {
                            Name = "sqrMagnitude",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_sqrMagnitude
#endif
                        }
                    },
                    {
                        "x",
                        new MemberRegisterInfo
                        {
                            Name = "x",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_x,
                            PropertySetter = UnityEngine_Vector3_Wrap.S_x
#endif
                        }
                    },
                    {
                        "y",
                        new MemberRegisterInfo
                        {
                            Name = "y",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_y,
                            PropertySetter = UnityEngine_Vector3_Wrap.S_y
#endif
                        }
                    },
                    {
                        "z",
                        new MemberRegisterInfo
                        {
                            Name = "z",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_z,
                            PropertySetter = UnityEngine_Vector3_Wrap.S_z
#endif
                        }
                    },
                    {
                        "Lerp_static",
                        new MemberRegisterInfo
                        {
                            Name = "Lerp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Lerp
#endif
                        }
                    },
                    {
                        "LerpUnclamped_static",
                        new MemberRegisterInfo
                        {
                            Name = "LerpUnclamped",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_LerpUnclamped
#endif
                        }
                    },
                    {
                        "MoveTowards_static",
                        new MemberRegisterInfo
                        {
                            Name = "MoveTowards",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_MoveTowards
#endif
                        }
                    },
                    {
                        "SmoothDamp_static",
                        new MemberRegisterInfo
                        {
                            Name = "SmoothDamp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_SmoothDamp
#endif
                        }
                    },
                    {
                        "Scale_static",
                        new MemberRegisterInfo
                        {
                            Name = "Scale",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Scale
#endif
                        }
                    },
                    {
                        "Cross_static",
                        new MemberRegisterInfo
                        {
                            Name = "Cross",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Cross
#endif
                        }
                    },
                    {
                        "Reflect_static",
                        new MemberRegisterInfo
                        {
                            Name = "Reflect",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Reflect
#endif
                        }
                    },
                    {
                        "Normalize_static",
                        new MemberRegisterInfo
                        {
                            Name = "Normalize",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Normalize
#endif
                        }
                    },
                    {
                        "Dot_static",
                        new MemberRegisterInfo
                        {
                            Name = "Dot",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Dot
#endif
                        }
                    },
                    {
                        "Project_static",
                        new MemberRegisterInfo
                        {
                            Name = "Project",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Project
#endif
                        }
                    },
                    {
                        "ProjectOnPlane_static",
                        new MemberRegisterInfo
                        {
                            Name = "ProjectOnPlane",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_ProjectOnPlane
#endif
                        }
                    },
                    {
                        "Angle_static",
                        new MemberRegisterInfo
                        {
                            Name = "Angle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Angle
#endif
                        }
                    },
                    {
                        "SignedAngle_static",
                        new MemberRegisterInfo
                        {
                            Name = "SignedAngle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_SignedAngle
#endif
                        }
                    },
                    {
                        "Distance_static",
                        new MemberRegisterInfo
                        {
                            Name = "Distance",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Distance
#endif
                        }
                    },
                    {
                        "ClampMagnitude_static",
                        new MemberRegisterInfo
                        {
                            Name = "ClampMagnitude",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_ClampMagnitude
#endif
                        }
                    },
                    {
                        "Magnitude_static",
                        new MemberRegisterInfo
                        {
                            Name = "Magnitude",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Magnitude
#endif
                        }
                    },
                    {
                        "SqrMagnitude_static",
                        new MemberRegisterInfo
                        {
                            Name = "SqrMagnitude",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_SqrMagnitude
#endif
                        }
                    },
                    {
                        "Min_static",
                        new MemberRegisterInfo
                        {
                            Name = "Min",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Min
#endif
                        }
                    },
                    {
                        "Max_static",
                        new MemberRegisterInfo
                        {
                            Name = "Max",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Max
#endif
                        }
                    },
                    {
                        "Slerp_static",
                        new MemberRegisterInfo
                        {
                            Name = "Slerp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_Slerp
#endif
                        }
                    },
                    {
                        "SlerpUnclamped_static",
                        new MemberRegisterInfo
                        {
                            Name = "SlerpUnclamped",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_SlerpUnclamped
#endif
                        }
                    },
                    {
                        "OrthoNormalize_static",
                        new MemberRegisterInfo
                        {
                            Name = "OrthoNormalize",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_OrthoNormalize
#endif
                        }
                    },
                    {
                        "RotateTowards_static",
                        new MemberRegisterInfo
                        {
                            Name = "RotateTowards",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector3_Wrap.F_RotateTowards
#endif
                        }
                    },
                    {
                        "zero_static",
                        new MemberRegisterInfo
                        {
                            Name = "zero",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_zero
#endif
                        }
                    },
                    {
                        "one_static",
                        new MemberRegisterInfo
                        {
                            Name = "one",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_one
#endif
                        }
                    },
                    {
                        "forward_static",
                        new MemberRegisterInfo
                        {
                            Name = "forward",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_forward
#endif
                        }
                    },
                    {
                        "back_static",
                        new MemberRegisterInfo
                        {
                            Name = "back",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_back
#endif
                        }
                    },
                    {
                        "up_static",
                        new MemberRegisterInfo
                        {
                            Name = "up",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_up
#endif
                        }
                    },
                    {
                        "down_static",
                        new MemberRegisterInfo
                        {
                            Name = "down",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_down
#endif
                        }
                    },
                    {
                        "left_static",
                        new MemberRegisterInfo
                        {
                            Name = "left",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_left
#endif
                        }
                    },
                    {
                        "right_static",
                        new MemberRegisterInfo
                        {
                            Name = "right",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_right
#endif
                        }
                    },
                    {
                        "positiveInfinity_static",
                        new MemberRegisterInfo
                        {
                            Name = "positiveInfinity",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_positiveInfinity
#endif
                        }
                    },
                    {
                        "negativeInfinity_static",
                        new MemberRegisterInfo
                        {
                            Name = "negativeInfinity",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_negativeInfinity
#endif
                        }
                    },
                    {
                        "kEpsilon_static",
                        new MemberRegisterInfo
                        {
                            Name = "kEpsilon",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_kEpsilon
#endif
                        }
                    },
                    {
                        "kEpsilonNormalSqrt_static",
                        new MemberRegisterInfo
                        {
                            Name = "kEpsilonNormalSqrt",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector3_Wrap.G_kEpsilonNormalSqrt
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_BoxCollider_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_BoxCollider_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "center",
                        new MemberRegisterInfo
                        {
                            Name = "center",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_BoxCollider_Wrap.G_center,
                            PropertySetter = UnityEngine_BoxCollider_Wrap.S_center
#endif
                        }
                    },
                    {
                        "size",
                        new MemberRegisterInfo
                        {
                            Name = "size",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_BoxCollider_Wrap.G_size,
                            PropertySetter = UnityEngine_BoxCollider_Wrap.S_size
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Collider_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Collider_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "ClosestPoint",
                        new MemberRegisterInfo
                        {
                            Name = "ClosestPoint",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Collider_Wrap.M_ClosestPoint
#endif
                        }
                    },
                    {
                        "Raycast",
                        new MemberRegisterInfo
                        {
                            Name = "Raycast",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Collider_Wrap.M_Raycast
#endif
                        }
                    },
                    {
                        "ClosestPointOnBounds",
                        new MemberRegisterInfo
                        {
                            Name = "ClosestPointOnBounds",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Collider_Wrap.M_ClosestPointOnBounds
#endif
                        }
                    },
                    {
                        "enabled",
                        new MemberRegisterInfo
                        {
                            Name = "enabled",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_enabled,
                            PropertySetter = UnityEngine_Collider_Wrap.S_enabled
#endif
                        }
                    },
                    {
                        "attachedRigidbody",
                        new MemberRegisterInfo
                        {
                            Name = "attachedRigidbody",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_attachedRigidbody
#endif
                        }
                    },
                    {
                        "attachedArticulationBody",
                        new MemberRegisterInfo
                        {
                            Name = "attachedArticulationBody",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_attachedArticulationBody
#endif
                        }
                    },
                    {
                        "isTrigger",
                        new MemberRegisterInfo
                        {
                            Name = "isTrigger",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_isTrigger,
                            PropertySetter = UnityEngine_Collider_Wrap.S_isTrigger
#endif
                        }
                    },
                    {
                        "contactOffset",
                        new MemberRegisterInfo
                        {
                            Name = "contactOffset",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_contactOffset,
                            PropertySetter = UnityEngine_Collider_Wrap.S_contactOffset
#endif
                        }
                    },
                    {
                        "bounds",
                        new MemberRegisterInfo
                        {
                            Name = "bounds",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_bounds
#endif
                        }
                    },
                    {
                        "hasModifiableContacts",
                        new MemberRegisterInfo
                        {
                            Name = "hasModifiableContacts",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_hasModifiableContacts,
                            PropertySetter = UnityEngine_Collider_Wrap.S_hasModifiableContacts
#endif
                        }
                    },
                    {
                        "sharedMaterial",
                        new MemberRegisterInfo
                        {
                            Name = "sharedMaterial",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_sharedMaterial,
                            PropertySetter = UnityEngine_Collider_Wrap.S_sharedMaterial
#endif
                        }
                    },
                    {
                        "material",
                        new MemberRegisterInfo
                        {
                            Name = "material",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Collider_Wrap.G_material,
                            PropertySetter = UnityEngine_Collider_Wrap.S_material
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Debug_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Debug_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "DrawLine_static",
                        new MemberRegisterInfo
                        {
                            Name = "DrawLine",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_DrawLine
#endif
                        }
                    },
                    {
                        "DrawRay_static",
                        new MemberRegisterInfo
                        {
                            Name = "DrawRay",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_DrawRay
#endif
                        }
                    },
                    {
                        "Break_static",
                        new MemberRegisterInfo
                        {
                            Name = "Break",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_Break
#endif
                        }
                    },
                    {
                        "DebugBreak_static",
                        new MemberRegisterInfo
                        {
                            Name = "DebugBreak",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_DebugBreak
#endif
                        }
                    },
                    {
                        "Log_static",
                        new MemberRegisterInfo
                        {
                            Name = "Log",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_Log
#endif
                        }
                    },
                    {
                        "LogFormat_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogFormat",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogFormat
#endif
                        }
                    },
                    {
                        "LogError_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogError",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogError
#endif
                        }
                    },
                    {
                        "LogErrorFormat_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogErrorFormat",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogErrorFormat
#endif
                        }
                    },
                    {
                        "ClearDeveloperConsole_static",
                        new MemberRegisterInfo
                        {
                            Name = "ClearDeveloperConsole",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_ClearDeveloperConsole
#endif
                        }
                    },
                    {
                        "LogException_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogException",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogException
#endif
                        }
                    },
                    {
                        "LogWarning_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogWarning",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogWarning
#endif
                        }
                    },
                    {
                        "LogWarningFormat_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogWarningFormat",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogWarningFormat
#endif
                        }
                    },
                    {
                        "Assert_static",
                        new MemberRegisterInfo
                        {
                            Name = "Assert",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_Assert
#endif
                        }
                    },
                    {
                        "AssertFormat_static",
                        new MemberRegisterInfo
                        {
                            Name = "AssertFormat",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_AssertFormat
#endif
                        }
                    },
                    {
                        "LogAssertion_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogAssertion",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogAssertion
#endif
                        }
                    },
                    {
                        "LogAssertionFormat_static",
                        new MemberRegisterInfo
                        {
                            Name = "LogAssertionFormat",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Debug_Wrap.F_LogAssertionFormat
#endif
                        }
                    },
                    {
                        "unityLogger_static",
                        new MemberRegisterInfo
                        {
                            Name = "unityLogger",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Debug_Wrap.G_unityLogger
#endif
                        }
                    },
                    {
                        "developerConsoleVisible_static",
                        new MemberRegisterInfo
                        {
                            Name = "developerConsoleVisible",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Debug_Wrap.G_developerConsoleVisible,
                            PropertySetter = UnityEngine_Debug_Wrap.S_developerConsoleVisible
#endif
                        }
                    },
                    {
                        "isDebugBuild_static",
                        new MemberRegisterInfo
                        {
                            Name = "isDebugBuild",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Debug_Wrap.G_isDebugBuild
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_GameManager_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = GameManager_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "BallSpawnPoint",
                        new MemberRegisterInfo
                        {
                            Name = "BallSpawnPoint",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameManager_Wrap.G_BallSpawnPoint,
                            PropertySetter = GameManager_Wrap.S_BallSpawnPoint
#endif
                        }
                    },
                    {
                        "BallPrefab",
                        new MemberRegisterInfo
                        {
                            Name = "BallPrefab",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameManager_Wrap.G_BallPrefab,
                            PropertySetter = GameManager_Wrap.S_BallPrefab
#endif
                        }
                    },
                    {
                        "PrescoreTrigger",
                        new MemberRegisterInfo
                        {
                            Name = "PrescoreTrigger",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameManager_Wrap.G_PrescoreTrigger,
                            PropertySetter = GameManager_Wrap.S_PrescoreTrigger
#endif
                        }
                    },
                    {
                        "ScoredTrigger",
                        new MemberRegisterInfo
                        {
                            Name = "ScoredTrigger",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameManager_Wrap.G_ScoredTrigger,
                            PropertySetter = GameManager_Wrap.S_ScoredTrigger
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_PerformanceHelper_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = PerformanceHelper_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "ReturnNumber_static",
                        new MemberRegisterInfo
                        {
                            Name = "ReturnNumber",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = PerformanceHelper_Wrap.F_ReturnNumber
#endif
                        }
                    },
                    {
                        "ReturnVector_static",
                        new MemberRegisterInfo
                        {
                            Name = "ReturnVector",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = PerformanceHelper_Wrap.F_ReturnVector
#endif
                        }
                    },
                    {
                        "JSNumber_static",
                        new MemberRegisterInfo
                        {
                            Name = "JSNumber",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_JSNumber,
                            PropertySetter = PerformanceHelper_Wrap.S_JSNumber
#endif
                        }
                    },
                    {
                        "JSVector_static",
                        new MemberRegisterInfo
                        {
                            Name = "JSVector",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_JSVector,
                            PropertySetter = PerformanceHelper_Wrap.S_JSVector
#endif
                        }
                    },
                    {
                        "JSFibonacci_static",
                        new MemberRegisterInfo
                        {
                            Name = "JSFibonacci",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_JSFibonacci,
                            PropertySetter = PerformanceHelper_Wrap.S_JSFibonacci
#endif
                        }
                    },
                    {
                        "LuaNumber_static",
                        new MemberRegisterInfo
                        {
                            Name = "LuaNumber",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_LuaNumber,
                            PropertySetter = PerformanceHelper_Wrap.S_LuaNumber
#endif
                        }
                    },
                    {
                        "LuaVector_static",
                        new MemberRegisterInfo
                        {
                            Name = "LuaVector",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_LuaVector,
                            PropertySetter = PerformanceHelper_Wrap.S_LuaVector
#endif
                        }
                    },
                    {
                        "LuaFibonacci_static",
                        new MemberRegisterInfo
                        {
                            Name = "LuaFibonacci",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = PerformanceHelper_Wrap.G_LuaFibonacci,
                            PropertySetter = PerformanceHelper_Wrap.S_LuaFibonacci
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_UI_Text_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        "FontTextureChanged",
                        new MemberRegisterInfo
                        {
                            Name = "FontTextureChanged",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_UI_Text_Wrap.M_FontTextureChanged
#endif
                        }
                    },
                    {
                        "GetGenerationSettings",
                        new MemberRegisterInfo
                        {
                            Name = "GetGenerationSettings",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_UI_Text_Wrap.M_GetGenerationSettings
#endif
                        }
                    },
                    {
                        "CalculateLayoutInputHorizontal",
                        new MemberRegisterInfo
                        {
                            Name = "CalculateLayoutInputHorizontal",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_UI_Text_Wrap.M_CalculateLayoutInputHorizontal
#endif
                        }
                    },
                    {
                        "CalculateLayoutInputVertical",
                        new MemberRegisterInfo
                        {
                            Name = "CalculateLayoutInputVertical",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_UI_Text_Wrap.M_CalculateLayoutInputVertical
#endif
                        }
                    },
                    {
                        "OnRebuildRequested",
                        new MemberRegisterInfo
                        {
                            Name = "OnRebuildRequested",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.SlowBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "cachedTextGenerator",
                        new MemberRegisterInfo
                        {
                            Name = "cachedTextGenerator",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_cachedTextGenerator
#endif
                        }
                    },
                    {
                        "cachedTextGeneratorForLayout",
                        new MemberRegisterInfo
                        {
                            Name = "cachedTextGeneratorForLayout",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_cachedTextGeneratorForLayout
#endif
                        }
                    },
                    {
                        "mainTexture",
                        new MemberRegisterInfo
                        {
                            Name = "mainTexture",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_mainTexture
#endif
                        }
                    },
                    {
                        "font",
                        new MemberRegisterInfo
                        {
                            Name = "font",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_font,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_font
#endif
                        }
                    },
                    {
                        "text",
                        new MemberRegisterInfo
                        {
                            Name = "text",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_text,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_text
#endif
                        }
                    },
                    {
                        "supportRichText",
                        new MemberRegisterInfo
                        {
                            Name = "supportRichText",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_supportRichText,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_supportRichText
#endif
                        }
                    },
                    {
                        "resizeTextForBestFit",
                        new MemberRegisterInfo
                        {
                            Name = "resizeTextForBestFit",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_resizeTextForBestFit,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_resizeTextForBestFit
#endif
                        }
                    },
                    {
                        "resizeTextMinSize",
                        new MemberRegisterInfo
                        {
                            Name = "resizeTextMinSize",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_resizeTextMinSize,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_resizeTextMinSize
#endif
                        }
                    },
                    {
                        "resizeTextMaxSize",
                        new MemberRegisterInfo
                        {
                            Name = "resizeTextMaxSize",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_resizeTextMaxSize,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_resizeTextMaxSize
#endif
                        }
                    },
                    {
                        "alignment",
                        new MemberRegisterInfo
                        {
                            Name = "alignment",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_alignment,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_alignment
#endif
                        }
                    },
                    {
                        "alignByGeometry",
                        new MemberRegisterInfo
                        {
                            Name = "alignByGeometry",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_alignByGeometry,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_alignByGeometry
#endif
                        }
                    },
                    {
                        "fontSize",
                        new MemberRegisterInfo
                        {
                            Name = "fontSize",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_fontSize,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_fontSize
#endif
                        }
                    },
                    {
                        "horizontalOverflow",
                        new MemberRegisterInfo
                        {
                            Name = "horizontalOverflow",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_horizontalOverflow,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_horizontalOverflow
#endif
                        }
                    },
                    {
                        "verticalOverflow",
                        new MemberRegisterInfo
                        {
                            Name = "verticalOverflow",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_verticalOverflow,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_verticalOverflow
#endif
                        }
                    },
                    {
                        "lineSpacing",
                        new MemberRegisterInfo
                        {
                            Name = "lineSpacing",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_lineSpacing,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_lineSpacing
#endif
                        }
                    },
                    {
                        "fontStyle",
                        new MemberRegisterInfo
                        {
                            Name = "fontStyle",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_fontStyle,
                            PropertySetter = UnityEngine_UI_Text_Wrap.S_fontStyle
#endif
                        }
                    },
                    {
                        "pixelsPerUnit",
                        new MemberRegisterInfo
                        {
                            Name = "pixelsPerUnit",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_pixelsPerUnit
#endif
                        }
                    },
                    {
                        "minWidth",
                        new MemberRegisterInfo
                        {
                            Name = "minWidth",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_minWidth
#endif
                        }
                    },
                    {
                        "preferredWidth",
                        new MemberRegisterInfo
                        {
                            Name = "preferredWidth",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_preferredWidth
#endif
                        }
                    },
                    {
                        "flexibleWidth",
                        new MemberRegisterInfo
                        {
                            Name = "flexibleWidth",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_flexibleWidth
#endif
                        }
                    },
                    {
                        "minHeight",
                        new MemberRegisterInfo
                        {
                            Name = "minHeight",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_minHeight
#endif
                        }
                    },
                    {
                        "preferredHeight",
                        new MemberRegisterInfo
                        {
                            Name = "preferredHeight",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_preferredHeight
#endif
                        }
                    },
                    {
                        "flexibleHeight",
                        new MemberRegisterInfo
                        {
                            Name = "flexibleHeight",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_flexibleHeight
#endif
                        }
                    },
                    {
                        "layoutPriority",
                        new MemberRegisterInfo
                        {
                            Name = "layoutPriority",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_UI_Text_Wrap.G_layoutPriority
#endif
                        }
                    },
                    {
                        "GetTextAnchorPivot_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetTextAnchorPivot",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_UI_Text_Wrap.F_GetTextAnchorPivot
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Vector2_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Vector2_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "Set",
                        new MemberRegisterInfo
                        {
                            Name = "Set",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_Set
#endif
                        }
                    },
                    {
                        "Scale",
                        new MemberRegisterInfo
                        {
                            Name = "Scale",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_Scale
#endif
                        }
                    },
                    {
                        "Normalize",
                        new MemberRegisterInfo
                        {
                            Name = "Normalize",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_Normalize
#endif
                        }
                    },
                    {
                        "ToString",
                        new MemberRegisterInfo
                        {
                            Name = "ToString",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_ToString
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "SqrMagnitude",
                        new MemberRegisterInfo
                        {
                            Name = "SqrMagnitude",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.M_SqrMagnitude
#endif
                        }
                    },
                    {
                        "op_Addition_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Addition",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Addition
#endif
                        }
                    },
                    {
                        "op_Subtraction_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Subtraction",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Subtraction
#endif
                        }
                    },
                    {
                        "op_Multiply_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Multiply",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Multiply
#endif
                        }
                    },
                    {
                        "op_Division_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Division",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Division
#endif
                        }
                    },
                    {
                        "op_UnaryNegation_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_UnaryNegation",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_UnaryNegation
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "get_Item",
                        new MemberRegisterInfo
                        {
                            Name = "get_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.GetItem
#endif
                        }
                    },
                    {
                        "set_Item",
                        new MemberRegisterInfo
                        {
                            Name = "set_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.SetItem
#endif
                        }
                    },
                    {
                        "normalized",
                        new MemberRegisterInfo
                        {
                            Name = "normalized",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_normalized
#endif
                        }
                    },
                    {
                        "magnitude",
                        new MemberRegisterInfo
                        {
                            Name = "magnitude",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_magnitude
#endif
                        }
                    },
                    {
                        "sqrMagnitude",
                        new MemberRegisterInfo
                        {
                            Name = "sqrMagnitude",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_sqrMagnitude
#endif
                        }
                    },
                    {
                        "x",
                        new MemberRegisterInfo
                        {
                            Name = "x",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_x,
                            PropertySetter = UnityEngine_Vector2_Wrap.S_x
#endif
                        }
                    },
                    {
                        "y",
                        new MemberRegisterInfo
                        {
                            Name = "y",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_y,
                            PropertySetter = UnityEngine_Vector2_Wrap.S_y
#endif
                        }
                    },
                    {
                        "Lerp_static",
                        new MemberRegisterInfo
                        {
                            Name = "Lerp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Lerp
#endif
                        }
                    },
                    {
                        "LerpUnclamped_static",
                        new MemberRegisterInfo
                        {
                            Name = "LerpUnclamped",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_LerpUnclamped
#endif
                        }
                    },
                    {
                        "MoveTowards_static",
                        new MemberRegisterInfo
                        {
                            Name = "MoveTowards",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_MoveTowards
#endif
                        }
                    },
                    {
                        "Scale_static",
                        new MemberRegisterInfo
                        {
                            Name = "Scale",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Scale
#endif
                        }
                    },
                    {
                        "Reflect_static",
                        new MemberRegisterInfo
                        {
                            Name = "Reflect",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Reflect
#endif
                        }
                    },
                    {
                        "Perpendicular_static",
                        new MemberRegisterInfo
                        {
                            Name = "Perpendicular",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Perpendicular
#endif
                        }
                    },
                    {
                        "Dot_static",
                        new MemberRegisterInfo
                        {
                            Name = "Dot",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Dot
#endif
                        }
                    },
                    {
                        "Angle_static",
                        new MemberRegisterInfo
                        {
                            Name = "Angle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Angle
#endif
                        }
                    },
                    {
                        "SignedAngle_static",
                        new MemberRegisterInfo
                        {
                            Name = "SignedAngle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_SignedAngle
#endif
                        }
                    },
                    {
                        "Distance_static",
                        new MemberRegisterInfo
                        {
                            Name = "Distance",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Distance
#endif
                        }
                    },
                    {
                        "ClampMagnitude_static",
                        new MemberRegisterInfo
                        {
                            Name = "ClampMagnitude",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_ClampMagnitude
#endif
                        }
                    },
                    {
                        "SqrMagnitude_static",
                        new MemberRegisterInfo
                        {
                            Name = "SqrMagnitude",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_SqrMagnitude
#endif
                        }
                    },
                    {
                        "Min_static",
                        new MemberRegisterInfo
                        {
                            Name = "Min",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Min
#endif
                        }
                    },
                    {
                        "Max_static",
                        new MemberRegisterInfo
                        {
                            Name = "Max",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_Max
#endif
                        }
                    },
                    {
                        "SmoothDamp_static",
                        new MemberRegisterInfo
                        {
                            Name = "SmoothDamp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Vector2_Wrap.F_SmoothDamp
#endif
                        }
                    },
                    {
                        "zero_static",
                        new MemberRegisterInfo
                        {
                            Name = "zero",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_zero
#endif
                        }
                    },
                    {
                        "one_static",
                        new MemberRegisterInfo
                        {
                            Name = "one",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_one
#endif
                        }
                    },
                    {
                        "up_static",
                        new MemberRegisterInfo
                        {
                            Name = "up",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_up
#endif
                        }
                    },
                    {
                        "down_static",
                        new MemberRegisterInfo
                        {
                            Name = "down",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_down
#endif
                        }
                    },
                    {
                        "left_static",
                        new MemberRegisterInfo
                        {
                            Name = "left",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_left
#endif
                        }
                    },
                    {
                        "right_static",
                        new MemberRegisterInfo
                        {
                            Name = "right",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_right
#endif
                        }
                    },
                    {
                        "positiveInfinity_static",
                        new MemberRegisterInfo
                        {
                            Name = "positiveInfinity",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_positiveInfinity
#endif
                        }
                    },
                    {
                        "negativeInfinity_static",
                        new MemberRegisterInfo
                        {
                            Name = "negativeInfinity",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_negativeInfinity
#endif
                        }
                    },
                    {
                        "kEpsilon_static",
                        new MemberRegisterInfo
                        {
                            Name = "kEpsilon",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_kEpsilon
#endif
                        }
                    },
                    {
                        "kEpsilonNormalSqrt_static",
                        new MemberRegisterInfo
                        {
                            Name = "kEpsilonNormalSqrt",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Vector2_Wrap.G_kEpsilonNormalSqrt
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Quaternion_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Quaternion_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "Set",
                        new MemberRegisterInfo
                        {
                            Name = "Set",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_Set
#endif
                        }
                    },
                    {
                        "op_Multiply_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Multiply",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.O_op_Multiply
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "SetLookRotation",
                        new MemberRegisterInfo
                        {
                            Name = "SetLookRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_SetLookRotation
#endif
                        }
                    },
                    {
                        "ToAngleAxis",
                        new MemberRegisterInfo
                        {
                            Name = "ToAngleAxis",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_ToAngleAxis
#endif
                        }
                    },
                    {
                        "SetFromToRotation",
                        new MemberRegisterInfo
                        {
                            Name = "SetFromToRotation",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_SetFromToRotation
#endif
                        }
                    },
                    {
                        "Normalize",
                        new MemberRegisterInfo
                        {
                            Name = "Normalize",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_Normalize
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "ToString",
                        new MemberRegisterInfo
                        {
                            Name = "ToString",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.M_ToString
#endif
                        }
                    },
                    {
                        "get_Item",
                        new MemberRegisterInfo
                        {
                            Name = "get_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.GetItem
#endif
                        }
                    },
                    {
                        "set_Item",
                        new MemberRegisterInfo
                        {
                            Name = "set_Item",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.SetItem
#endif
                        }
                    },
                    {
                        "eulerAngles",
                        new MemberRegisterInfo
                        {
                            Name = "eulerAngles",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_eulerAngles,
                            PropertySetter = UnityEngine_Quaternion_Wrap.S_eulerAngles
#endif
                        }
                    },
                    {
                        "normalized",
                        new MemberRegisterInfo
                        {
                            Name = "normalized",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_normalized
#endif
                        }
                    },
                    {
                        "x",
                        new MemberRegisterInfo
                        {
                            Name = "x",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_x,
                            PropertySetter = UnityEngine_Quaternion_Wrap.S_x
#endif
                        }
                    },
                    {
                        "y",
                        new MemberRegisterInfo
                        {
                            Name = "y",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_y,
                            PropertySetter = UnityEngine_Quaternion_Wrap.S_y
#endif
                        }
                    },
                    {
                        "z",
                        new MemberRegisterInfo
                        {
                            Name = "z",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_z,
                            PropertySetter = UnityEngine_Quaternion_Wrap.S_z
#endif
                        }
                    },
                    {
                        "w",
                        new MemberRegisterInfo
                        {
                            Name = "w",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_w,
                            PropertySetter = UnityEngine_Quaternion_Wrap.S_w
#endif
                        }
                    },
                    {
                        "Dot_static",
                        new MemberRegisterInfo
                        {
                            Name = "Dot",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Dot
#endif
                        }
                    },
                    {
                        "Angle_static",
                        new MemberRegisterInfo
                        {
                            Name = "Angle",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Angle
#endif
                        }
                    },
                    {
                        "Euler_static",
                        new MemberRegisterInfo
                        {
                            Name = "Euler",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Euler
#endif
                        }
                    },
                    {
                        "RotateTowards_static",
                        new MemberRegisterInfo
                        {
                            Name = "RotateTowards",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_RotateTowards
#endif
                        }
                    },
                    {
                        "Normalize_static",
                        new MemberRegisterInfo
                        {
                            Name = "Normalize",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Normalize
#endif
                        }
                    },
                    {
                        "FromToRotation_static",
                        new MemberRegisterInfo
                        {
                            Name = "FromToRotation",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_FromToRotation
#endif
                        }
                    },
                    {
                        "Inverse_static",
                        new MemberRegisterInfo
                        {
                            Name = "Inverse",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Inverse
#endif
                        }
                    },
                    {
                        "Slerp_static",
                        new MemberRegisterInfo
                        {
                            Name = "Slerp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Slerp
#endif
                        }
                    },
                    {
                        "SlerpUnclamped_static",
                        new MemberRegisterInfo
                        {
                            Name = "SlerpUnclamped",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_SlerpUnclamped
#endif
                        }
                    },
                    {
                        "Lerp_static",
                        new MemberRegisterInfo
                        {
                            Name = "Lerp",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_Lerp
#endif
                        }
                    },
                    {
                        "LerpUnclamped_static",
                        new MemberRegisterInfo
                        {
                            Name = "LerpUnclamped",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_LerpUnclamped
#endif
                        }
                    },
                    {
                        "AngleAxis_static",
                        new MemberRegisterInfo
                        {
                            Name = "AngleAxis",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_AngleAxis
#endif
                        }
                    },
                    {
                        "LookRotation_static",
                        new MemberRegisterInfo
                        {
                            Name = "LookRotation",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Quaternion_Wrap.F_LookRotation
#endif
                        }
                    },
                    {
                        "identity_static",
                        new MemberRegisterInfo
                        {
                            Name = "identity",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_identity
#endif
                        }
                    },
                    {
                        "kEpsilon_static",
                        new MemberRegisterInfo
                        {
                            Name = "kEpsilon",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Quaternion_Wrap.G_kEpsilon
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Random_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        "ColorHSV_static",
                        new MemberRegisterInfo
                        {
                            Name = "ColorHSV",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Random_Wrap.F_ColorHSV
#endif
                        }
                    },
                    {
                        "InitState_static",
                        new MemberRegisterInfo
                        {
                            Name = "InitState",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Random_Wrap.F_InitState
#endif
                        }
                    },
                    {
                        "Range_static",
                        new MemberRegisterInfo
                        {
                            Name = "Range",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Random_Wrap.F_Range
#endif
                        }
                    },
                    {
                        "state_static",
                        new MemberRegisterInfo
                        {
                            Name = "state",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_state,
                            PropertySetter = UnityEngine_Random_Wrap.S_state
#endif
                        }
                    },
                    {
                        "value_static",
                        new MemberRegisterInfo
                        {
                            Name = "value",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_value
#endif
                        }
                    },
                    {
                        "insideUnitSphere_static",
                        new MemberRegisterInfo
                        {
                            Name = "insideUnitSphere",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_insideUnitSphere
#endif
                        }
                    },
                    {
                        "insideUnitCircle_static",
                        new MemberRegisterInfo
                        {
                            Name = "insideUnitCircle",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_insideUnitCircle
#endif
                        }
                    },
                    {
                        "onUnitSphere_static",
                        new MemberRegisterInfo
                        {
                            Name = "onUnitSphere",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_onUnitSphere
#endif
                        }
                    },
                    {
                        "rotation_static",
                        new MemberRegisterInfo
                        {
                            Name = "rotation",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_rotation
#endif
                        }
                    },
                    {
                        "rotationUniform_static",
                        new MemberRegisterInfo
                        {
                            Name = "rotationUniform",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Random_Wrap.G_rotationUniform
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Time_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Time_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "time_static",
                        new MemberRegisterInfo
                        {
                            Name = "time",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_time
#endif
                        }
                    },
                    {
                        "timeAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "timeAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_timeAsDouble
#endif
                        }
                    },
                    {
                        "timeSinceLevelLoad_static",
                        new MemberRegisterInfo
                        {
                            Name = "timeSinceLevelLoad",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_timeSinceLevelLoad
#endif
                        }
                    },
                    {
                        "timeSinceLevelLoadAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "timeSinceLevelLoadAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_timeSinceLevelLoadAsDouble
#endif
                        }
                    },
                    {
                        "deltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "deltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_deltaTime
#endif
                        }
                    },
                    {
                        "fixedTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedTime
#endif
                        }
                    },
                    {
                        "fixedTimeAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedTimeAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedTimeAsDouble
#endif
                        }
                    },
                    {
                        "unscaledTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "unscaledTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_unscaledTime
#endif
                        }
                    },
                    {
                        "unscaledTimeAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "unscaledTimeAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_unscaledTimeAsDouble
#endif
                        }
                    },
                    {
                        "fixedUnscaledTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedUnscaledTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedUnscaledTime
#endif
                        }
                    },
                    {
                        "fixedUnscaledTimeAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedUnscaledTimeAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedUnscaledTimeAsDouble
#endif
                        }
                    },
                    {
                        "unscaledDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "unscaledDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_unscaledDeltaTime
#endif
                        }
                    },
                    {
                        "fixedUnscaledDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedUnscaledDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedUnscaledDeltaTime
#endif
                        }
                    },
                    {
                        "fixedDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "fixedDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_fixedDeltaTime,
                            PropertySetter = UnityEngine_Time_Wrap.S_fixedDeltaTime
#endif
                        }
                    },
                    {
                        "maximumDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "maximumDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_maximumDeltaTime,
                            PropertySetter = UnityEngine_Time_Wrap.S_maximumDeltaTime
#endif
                        }
                    },
                    {
                        "smoothDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "smoothDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_smoothDeltaTime
#endif
                        }
                    },
                    {
                        "maximumParticleDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "maximumParticleDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_maximumParticleDeltaTime,
                            PropertySetter = UnityEngine_Time_Wrap.S_maximumParticleDeltaTime
#endif
                        }
                    },
                    {
                        "timeScale_static",
                        new MemberRegisterInfo
                        {
                            Name = "timeScale",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_timeScale,
                            PropertySetter = UnityEngine_Time_Wrap.S_timeScale
#endif
                        }
                    },
                    {
                        "frameCount_static",
                        new MemberRegisterInfo
                        {
                            Name = "frameCount",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_frameCount
#endif
                        }
                    },
                    {
                        "renderedFrameCount_static",
                        new MemberRegisterInfo
                        {
                            Name = "renderedFrameCount",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_renderedFrameCount
#endif
                        }
                    },
                    {
                        "realtimeSinceStartup_static",
                        new MemberRegisterInfo
                        {
                            Name = "realtimeSinceStartup",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_realtimeSinceStartup
#endif
                        }
                    },
                    {
                        "realtimeSinceStartupAsDouble_static",
                        new MemberRegisterInfo
                        {
                            Name = "realtimeSinceStartupAsDouble",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_realtimeSinceStartupAsDouble
#endif
                        }
                    },
                    {
                        "captureDeltaTime_static",
                        new MemberRegisterInfo
                        {
                            Name = "captureDeltaTime",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_captureDeltaTime,
                            PropertySetter = UnityEngine_Time_Wrap.S_captureDeltaTime
#endif
                        }
                    },
                    {
                        "captureFramerate_static",
                        new MemberRegisterInfo
                        {
                            Name = "captureFramerate",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_captureFramerate,
                            PropertySetter = UnityEngine_Time_Wrap.S_captureFramerate
#endif
                        }
                    },
                    {
                        "inFixedTimeStep_static",
                        new MemberRegisterInfo
                        {
                            Name = "inFixedTimeStep",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Time_Wrap.G_inFixedTimeStep
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Application_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Application_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "add_lowMemory_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_lowMemory",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_lowMemory
#endif
                        }
                    },
                    {
                        "remove_lowMemory_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_lowMemory",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_lowMemory
#endif
                        }
                    },
                    {
                        "add_logMessageReceived_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_logMessageReceived",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_logMessageReceived
#endif
                        }
                    },
                    {
                        "remove_logMessageReceived_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_logMessageReceived",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_logMessageReceived
#endif
                        }
                    },
                    {
                        "add_logMessageReceivedThreaded_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_logMessageReceivedThreaded",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_logMessageReceivedThreaded
#endif
                        }
                    },
                    {
                        "remove_logMessageReceivedThreaded_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_logMessageReceivedThreaded",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_logMessageReceivedThreaded
#endif
                        }
                    },
                    {
                        "add_onBeforeRender_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_onBeforeRender",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_onBeforeRender
#endif
                        }
                    },
                    {
                        "remove_onBeforeRender_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_onBeforeRender",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_onBeforeRender
#endif
                        }
                    },
                    {
                        "add_focusChanged_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_focusChanged",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_focusChanged
#endif
                        }
                    },
                    {
                        "remove_focusChanged_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_focusChanged",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_focusChanged
#endif
                        }
                    },
                    {
                        "add_deepLinkActivated_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_deepLinkActivated",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_deepLinkActivated
#endif
                        }
                    },
                    {
                        "remove_deepLinkActivated_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_deepLinkActivated",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_deepLinkActivated
#endif
                        }
                    },
                    {
                        "add_wantsToQuit_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_wantsToQuit",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_wantsToQuit
#endif
                        }
                    },
                    {
                        "remove_wantsToQuit_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_wantsToQuit",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_wantsToQuit
#endif
                        }
                    },
                    {
                        "add_quitting_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_quitting",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_quitting
#endif
                        }
                    },
                    {
                        "remove_quitting_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_quitting",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_quitting
#endif
                        }
                    },
                    {
                        "add_unloading_static",
                        new MemberRegisterInfo
                        {
                            Name = "add_unloading",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.A_unloading
#endif
                        }
                    },
                    {
                        "remove_unloading_static",
                        new MemberRegisterInfo
                        {
                            Name = "remove_unloading",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.R_unloading
#endif
                        }
                    },
                    {
                        "Quit_static",
                        new MemberRegisterInfo
                        {
                            Name = "Quit",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_Quit
#endif
                        }
                    },
                    {
                        "Unload_static",
                        new MemberRegisterInfo
                        {
                            Name = "Unload",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_Unload
#endif
                        }
                    },
                    {
                        "CanStreamedLevelBeLoaded_static",
                        new MemberRegisterInfo
                        {
                            Name = "CanStreamedLevelBeLoaded",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_CanStreamedLevelBeLoaded
#endif
                        }
                    },
                    {
                        "IsPlaying_static",
                        new MemberRegisterInfo
                        {
                            Name = "IsPlaying",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_IsPlaying
#endif
                        }
                    },
                    {
                        "GetBuildTags_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetBuildTags",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_GetBuildTags
#endif
                        }
                    },
                    {
                        "SetBuildTags_static",
                        new MemberRegisterInfo
                        {
                            Name = "SetBuildTags",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_SetBuildTags
#endif
                        }
                    },
                    {
                        "HasProLicense_static",
                        new MemberRegisterInfo
                        {
                            Name = "HasProLicense",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_HasProLicense
#endif
                        }
                    },
                    {
                        "RequestAdvertisingIdentifierAsync_static",
                        new MemberRegisterInfo
                        {
                            Name = "RequestAdvertisingIdentifierAsync",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method =
                                UnityEngine_Application_Wrap.F_RequestAdvertisingIdentifierAsync
#endif
                        }
                    },
                    {
                        "OpenURL_static",
                        new MemberRegisterInfo
                        {
                            Name = "OpenURL",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_OpenURL
#endif
                        }
                    },
                    {
                        "GetStackTraceLogType_static",
                        new MemberRegisterInfo
                        {
                            Name = "GetStackTraceLogType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_GetStackTraceLogType
#endif
                        }
                    },
                    {
                        "SetStackTraceLogType_static",
                        new MemberRegisterInfo
                        {
                            Name = "SetStackTraceLogType",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_SetStackTraceLogType
#endif
                        }
                    },
                    {
                        "RequestUserAuthorization_static",
                        new MemberRegisterInfo
                        {
                            Name = "RequestUserAuthorization",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_RequestUserAuthorization
#endif
                        }
                    },
                    {
                        "HasUserAuthorization_static",
                        new MemberRegisterInfo
                        {
                            Name = "HasUserAuthorization",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Application_Wrap.F_HasUserAuthorization
#endif
                        }
                    },
                    {
                        "isPlaying_static",
                        new MemberRegisterInfo
                        {
                            Name = "isPlaying",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isPlaying
#endif
                        }
                    },
                    {
                        "isFocused_static",
                        new MemberRegisterInfo
                        {
                            Name = "isFocused",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isFocused
#endif
                        }
                    },
                    {
                        "buildGUID_static",
                        new MemberRegisterInfo
                        {
                            Name = "buildGUID",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_buildGUID
#endif
                        }
                    },
                    {
                        "runInBackground_static",
                        new MemberRegisterInfo
                        {
                            Name = "runInBackground",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_runInBackground,
                            PropertySetter = UnityEngine_Application_Wrap.S_runInBackground
#endif
                        }
                    },
                    {
                        "isBatchMode_static",
                        new MemberRegisterInfo
                        {
                            Name = "isBatchMode",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isBatchMode
#endif
                        }
                    },
                    {
                        "dataPath_static",
                        new MemberRegisterInfo
                        {
                            Name = "dataPath",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_dataPath
#endif
                        }
                    },
                    {
                        "streamingAssetsPath_static",
                        new MemberRegisterInfo
                        {
                            Name = "streamingAssetsPath",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_streamingAssetsPath
#endif
                        }
                    },
                    {
                        "persistentDataPath_static",
                        new MemberRegisterInfo
                        {
                            Name = "persistentDataPath",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_persistentDataPath
#endif
                        }
                    },
                    {
                        "temporaryCachePath_static",
                        new MemberRegisterInfo
                        {
                            Name = "temporaryCachePath",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_temporaryCachePath
#endif
                        }
                    },
                    {
                        "absoluteURL_static",
                        new MemberRegisterInfo
                        {
                            Name = "absoluteURL",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_absoluteURL
#endif
                        }
                    },
                    {
                        "unityVersion_static",
                        new MemberRegisterInfo
                        {
                            Name = "unityVersion",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_unityVersion
#endif
                        }
                    },
                    {
                        "version_static",
                        new MemberRegisterInfo
                        {
                            Name = "version",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_version
#endif
                        }
                    },
                    {
                        "installerName_static",
                        new MemberRegisterInfo
                        {
                            Name = "installerName",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_installerName
#endif
                        }
                    },
                    {
                        "identifier_static",
                        new MemberRegisterInfo
                        {
                            Name = "identifier",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_identifier
#endif
                        }
                    },
                    {
                        "installMode_static",
                        new MemberRegisterInfo
                        {
                            Name = "installMode",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_installMode
#endif
                        }
                    },
                    {
                        "sandboxType_static",
                        new MemberRegisterInfo
                        {
                            Name = "sandboxType",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_sandboxType
#endif
                        }
                    },
                    {
                        "productName_static",
                        new MemberRegisterInfo
                        {
                            Name = "productName",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_productName
#endif
                        }
                    },
                    {
                        "companyName_static",
                        new MemberRegisterInfo
                        {
                            Name = "companyName",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_companyName
#endif
                        }
                    },
                    {
                        "cloudProjectId_static",
                        new MemberRegisterInfo
                        {
                            Name = "cloudProjectId",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_cloudProjectId
#endif
                        }
                    },
                    {
                        "targetFrameRate_static",
                        new MemberRegisterInfo
                        {
                            Name = "targetFrameRate",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_targetFrameRate,
                            PropertySetter = UnityEngine_Application_Wrap.S_targetFrameRate
#endif
                        }
                    },
                    {
                        "consoleLogPath_static",
                        new MemberRegisterInfo
                        {
                            Name = "consoleLogPath",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_consoleLogPath
#endif
                        }
                    },
                    {
                        "backgroundLoadingPriority_static",
                        new MemberRegisterInfo
                        {
                            Name = "backgroundLoadingPriority",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter =
                                UnityEngine_Application_Wrap.G_backgroundLoadingPriority,
                            PropertySetter =
                                UnityEngine_Application_Wrap.S_backgroundLoadingPriority
#endif
                        }
                    },
                    {
                        "genuine_static",
                        new MemberRegisterInfo
                        {
                            Name = "genuine",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_genuine
#endif
                        }
                    },
                    {
                        "genuineCheckAvailable_static",
                        new MemberRegisterInfo
                        {
                            Name = "genuineCheckAvailable",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_genuineCheckAvailable
#endif
                        }
                    },
                    {
                        "platform_static",
                        new MemberRegisterInfo
                        {
                            Name = "platform",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_platform
#endif
                        }
                    },
                    {
                        "isMobilePlatform_static",
                        new MemberRegisterInfo
                        {
                            Name = "isMobilePlatform",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isMobilePlatform
#endif
                        }
                    },
                    {
                        "isConsolePlatform_static",
                        new MemberRegisterInfo
                        {
                            Name = "isConsolePlatform",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isConsolePlatform
#endif
                        }
                    },
                    {
                        "systemLanguage_static",
                        new MemberRegisterInfo
                        {
                            Name = "systemLanguage",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_systemLanguage
#endif
                        }
                    },
                    {
                        "internetReachability_static",
                        new MemberRegisterInfo
                        {
                            Name = "internetReachability",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_internetReachability
#endif
                        }
                    },
                    {
                        "isEditor_static",
                        new MemberRegisterInfo
                        {
                            Name = "isEditor",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Application_Wrap.G_isEditor
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_MonoBehaviour_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_MonoBehaviour_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "IsInvoking",
                        new MemberRegisterInfo
                        {
                            Name = "IsInvoking",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_IsInvoking
#endif
                        }
                    },
                    {
                        "CancelInvoke",
                        new MemberRegisterInfo
                        {
                            Name = "CancelInvoke",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_CancelInvoke
#endif
                        }
                    },
                    {
                        "Invoke",
                        new MemberRegisterInfo
                        {
                            Name = "Invoke",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_Invoke
#endif
                        }
                    },
                    {
                        "InvokeRepeating",
                        new MemberRegisterInfo
                        {
                            Name = "InvokeRepeating",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_InvokeRepeating
#endif
                        }
                    },
                    {
                        "StartCoroutine",
                        new MemberRegisterInfo
                        {
                            Name = "StartCoroutine",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_StartCoroutine
#endif
                        }
                    },
                    {
                        "StopCoroutine",
                        new MemberRegisterInfo
                        {
                            Name = "StopCoroutine",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_StopCoroutine
#endif
                        }
                    },
                    {
                        "StopAllCoroutines",
                        new MemberRegisterInfo
                        {
                            Name = "StopAllCoroutines",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.M_StopAllCoroutines
#endif
                        }
                    },
                    {
                        "useGUILayout",
                        new MemberRegisterInfo
                        {
                            Name = "useGUILayout",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_MonoBehaviour_Wrap.G_useGUILayout,
                            PropertySetter = UnityEngine_MonoBehaviour_Wrap.S_useGUILayout
#endif
                        }
                    },
                    {
                        "runInEditMode",
                        new MemberRegisterInfo
                        {
                            Name = "runInEditMode",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.SlowBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS

#endif
                        }
                    },
                    {
                        "print_static",
                        new MemberRegisterInfo
                        {
                            Name = "print",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_MonoBehaviour_Wrap.F_print
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Behaviour_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Behaviour_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "enabled",
                        new MemberRegisterInfo
                        {
                            Name = "enabled",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Behaviour_Wrap.G_enabled,
                            PropertySetter = UnityEngine_Behaviour_Wrap.S_enabled
#endif
                        }
                    },
                    {
                        "isActiveAndEnabled",
                        new MemberRegisterInfo
                        {
                            Name = "isActiveAndEnabled",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Behaviour_Wrap.G_isActiveAndEnabled
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_UnityEngine_Component_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = UnityEngine_Component_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "GetComponent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponent
#endif
                        }
                    },
                    {
                        "TryGetComponent",
                        new MemberRegisterInfo
                        {
                            Name = "TryGetComponent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_TryGetComponent
#endif
                        }
                    },
                    {
                        "GetComponentInChildren",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentInChildren",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponentInChildren
#endif
                        }
                    },
                    {
                        "GetComponentsInChildren",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentsInChildren",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponentsInChildren
#endif
                        }
                    },
                    {
                        "GetComponentInParent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentInParent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponentInParent
#endif
                        }
                    },
                    {
                        "GetComponentsInParent",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponentsInParent",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponentsInParent
#endif
                        }
                    },
                    {
                        "GetComponents",
                        new MemberRegisterInfo
                        {
                            Name = "GetComponents",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_GetComponents
#endif
                        }
                    },
                    {
                        "CompareTag",
                        new MemberRegisterInfo
                        {
                            Name = "CompareTag",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_CompareTag
#endif
                        }
                    },
                    {
                        "SendMessageUpwards",
                        new MemberRegisterInfo
                        {
                            Name = "SendMessageUpwards",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_SendMessageUpwards
#endif
                        }
                    },
                    {
                        "SendMessage",
                        new MemberRegisterInfo
                        {
                            Name = "SendMessage",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_SendMessage
#endif
                        }
                    },
                    {
                        "BroadcastMessage",
                        new MemberRegisterInfo
                        {
                            Name = "BroadcastMessage",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = UnityEngine_Component_Wrap.M_BroadcastMessage
#endif
                        }
                    },
                    {
                        "transform",
                        new MemberRegisterInfo
                        {
                            Name = "transform",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Component_Wrap.G_transform
#endif
                        }
                    },
                    {
                        "gameObject",
                        new MemberRegisterInfo
                        {
                            Name = "gameObject",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Component_Wrap.G_gameObject
#endif
                        }
                    },
                    {
                        "tag",
                        new MemberRegisterInfo
                        {
                            Name = "tag",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = UnityEngine_Component_Wrap.G_tag,
                            PropertySetter = UnityEngine_Component_Wrap.S_tag
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_System_Delegate_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        "DynamicInvoke",
                        new MemberRegisterInfo
                        {
                            Name = "DynamicInvoke",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_DynamicInvoke
#endif
                        }
                    },
                    {
                        "Clone",
                        new MemberRegisterInfo
                        {
                            Name = "Clone",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_Clone
#endif
                        }
                    },
                    {
                        "Equals",
                        new MemberRegisterInfo
                        {
                            Name = "Equals",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_Equals
#endif
                        }
                    },
                    {
                        "GetHashCode",
                        new MemberRegisterInfo
                        {
                            Name = "GetHashCode",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_GetHashCode
#endif
                        }
                    },
                    {
                        "GetObjectData",
                        new MemberRegisterInfo
                        {
                            Name = "GetObjectData",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_GetObjectData
#endif
                        }
                    },
                    {
                        "GetInvocationList",
                        new MemberRegisterInfo
                        {
                            Name = "GetInvocationList",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.M_GetInvocationList
#endif
                        }
                    },
                    {
                        "op_Equality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Equality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.O_op_Equality
#endif
                        }
                    },
                    {
                        "op_Inequality_static",
                        new MemberRegisterInfo
                        {
                            Name = "op_Inequality",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.O_op_Inequality
#endif
                        }
                    },
                    {
                        "Method",
                        new MemberRegisterInfo
                        {
                            Name = "Method",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Delegate_Wrap.G_Method
#endif
                        }
                    },
                    {
                        "Target",
                        new MemberRegisterInfo
                        {
                            Name = "Target",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = System_Delegate_Wrap.G_Target
#endif
                        }
                    },
                    {
                        "CreateDelegate_static",
                        new MemberRegisterInfo
                        {
                            Name = "CreateDelegate",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.F_CreateDelegate
#endif
                        }
                    },
                    {
                        "Combine_static",
                        new MemberRegisterInfo
                        {
                            Name = "Combine",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.F_Combine
#endif
                        }
                    },
                    {
                        "Remove_static",
                        new MemberRegisterInfo
                        {
                            Name = "Remove",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.F_Remove
#endif
                        }
                    },
                    {
                        "RemoveAll_static",
                        new MemberRegisterInfo
                        {
                            Name = "RemoveAll",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = System_Delegate_Wrap.F_RemoveAll
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_Puerts_TSLoader_TSLoader_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = Puerts_TSLoader_TSLoader_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "OnBuiltinLoaded",
                        new MemberRegisterInfo
                        {
                            Name = "OnBuiltinLoaded",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_OnBuiltinLoaded
#endif
                        }
                    },
                    {
                        "UseRuntimeLoader",
                        new MemberRegisterInfo
                        {
                            Name = "UseRuntimeLoader",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_UseRuntimeLoader
#endif
                        }
                    },
                    {
                        "IsESM",
                        new MemberRegisterInfo
                        {
                            Name = "IsESM",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_IsESM
#endif
                        }
                    },
                    {
                        "Resolve",
                        new MemberRegisterInfo
                        {
                            Name = "Resolve",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_Resolve
#endif
                        }
                    },
                    {
                        "FileExists",
                        new MemberRegisterInfo
                        {
                            Name = "FileExists",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_FileExists
#endif
                        }
                    },
                    {
                        "ReadFile",
                        new MemberRegisterInfo
                        {
                            Name = "ReadFile",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_TSLoader_TSLoader_Wrap.M_ReadFile
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_Puerts_DefaultLoader_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = Puerts_DefaultLoader_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "FileExists",
                        new MemberRegisterInfo
                        {
                            Name = "FileExists",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_DefaultLoader_Wrap.M_FileExists
#endif
                        }
                    },
                    {
                        "ReadFile",
                        new MemberRegisterInfo
                        {
                            Name = "ReadFile",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_DefaultLoader_Wrap.M_ReadFile
#endif
                        }
                    },
                    {
                        "IsESM",
                        new MemberRegisterInfo
                        {
                            Name = "IsESM",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Puerts_DefaultLoader_Wrap.M_IsESM
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_Joystick_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = Joystick_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "OnPointerDown",
                        new MemberRegisterInfo
                        {
                            Name = "OnPointerDown",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Joystick_Wrap.M_OnPointerDown
#endif
                        }
                    },
                    {
                        "OnDrag",
                        new MemberRegisterInfo
                        {
                            Name = "OnDrag",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Joystick_Wrap.M_OnDrag
#endif
                        }
                    },
                    {
                        "OnPointerUp",
                        new MemberRegisterInfo
                        {
                            Name = "OnPointerUp",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = Joystick_Wrap.M_OnPointerUp
#endif
                        }
                    },
                    {
                        "Horizontal",
                        new MemberRegisterInfo
                        {
                            Name = "Horizontal",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_Horizontal
#endif
                        }
                    },
                    {
                        "Vertical",
                        new MemberRegisterInfo
                        {
                            Name = "Vertical",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_Vertical
#endif
                        }
                    },
                    {
                        "Direction",
                        new MemberRegisterInfo
                        {
                            Name = "Direction",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_Direction
#endif
                        }
                    },
                    {
                        "HandleRange",
                        new MemberRegisterInfo
                        {
                            Name = "HandleRange",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_HandleRange,
                            PropertySetter = Joystick_Wrap.S_HandleRange
#endif
                        }
                    },
                    {
                        "DeadZone",
                        new MemberRegisterInfo
                        {
                            Name = "DeadZone",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_DeadZone,
                            PropertySetter = Joystick_Wrap.S_DeadZone
#endif
                        }
                    },
                    {
                        "AxisOptions",
                        new MemberRegisterInfo
                        {
                            Name = "AxisOptions",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_AxisOptions,
                            PropertySetter = Joystick_Wrap.S_AxisOptions
#endif
                        }
                    },
                    {
                        "SnapX",
                        new MemberRegisterInfo
                        {
                            Name = "SnapX",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_SnapX,
                            PropertySetter = Joystick_Wrap.S_SnapX
#endif
                        }
                    },
                    {
                        "SnapY",
                        new MemberRegisterInfo
                        {
                            Name = "SnapY",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = Joystick_Wrap.G_SnapY,
                            PropertySetter = Joystick_Wrap.S_SnapY
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_GameWithJS_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = GameWithJS_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "ScriptName",
                        new MemberRegisterInfo
                        {
                            Name = "ScriptName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_ScriptName
#endif
                        }
                    },
                    {
                        "SubPrefab",
                        new MemberRegisterInfo
                        {
                            Name = "SubPrefab",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_SubPrefab,
                            PropertySetter = GameWithJS_Wrap.S_SubPrefab
#endif
                        }
                    },
                    {
                        "Main",
                        new MemberRegisterInfo
                        {
                            Name = "Main",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_Main,
                            PropertySetter = GameWithJS_Wrap.S_Main
#endif
                        }
                    },
                    {
                        "Joystick",
                        new MemberRegisterInfo
                        {
                            Name = "Joystick",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_Joystick,
                            PropertySetter = GameWithJS_Wrap.S_Joystick
#endif
                        }
                    },
                    {
                        "FpsText",
                        new MemberRegisterInfo
                        {
                            Name = "FpsText",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_FpsText,
                            PropertySetter = GameWithJS_Wrap.S_FpsText
#endif
                        }
                    },
                    {
                        "BoxText",
                        new MemberRegisterInfo
                        {
                            Name = "BoxText",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = GameWithJS_Wrap.G_BoxText,
                            PropertySetter = GameWithJS_Wrap.S_BoxText
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_BoxWithJS_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = BoxWithJS_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "GetPositionSetterPointer",
                        new MemberRegisterInfo
                        {
                            Name = "GetPositionSetterPointer",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = BoxWithJS_Wrap.M_GetPositionSetterPointer
#endif
                        }
                    },
                    {
                        "GetRotationSetterPointer",
                        new MemberRegisterInfo
                        {
                            Name = "GetRotationSetterPointer",
                            IsStatic = false,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = BoxWithJS_Wrap.M_GetRotationSetterPointer
#endif
                        }
                    },
                    {
                        "ScriptName",
                        new MemberRegisterInfo
                        {
                            Name = "ScriptName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = BoxWithJS_Wrap.G_ScriptName
#endif
                        }
                    },
                    {
                        "target",
                        new MemberRegisterInfo
                        {
                            Name = "target",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = BoxWithJS_Wrap.G_target,
                            PropertySetter = BoxWithJS_Wrap.S_target
#endif
                        }
                    },
                    {
                        "TotalBoxCount_static",
                        new MemberRegisterInfo
                        {
                            Name = "TotalBoxCount",
                            IsStatic = true,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = BoxWithJS_Wrap.G_TotalBoxCount,
                            PropertySetter = BoxWithJS_Wrap.S_TotalBoxCount
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_JSBehaviour_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = JSBehaviour_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "ScriptName",
                        new MemberRegisterInfo
                        {
                            Name = "ScriptName",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JSBehaviour_Wrap.G_ScriptName
#endif
                        }
                    },
                    {
                        "ScriptOnDestroy",
                        new MemberRegisterInfo
                        {
                            Name = "ScriptOnDestroy",
                            IsStatic = false,
                            MemberType = MemberType.Property,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            PropertyGetter = JSBehaviour_Wrap.G_ScriptOnDestroy,
                            PropertySetter = JSBehaviour_Wrap.S_ScriptOnDestroy
#endif
                        }
                    },
                }
            };
        }

        public static RegisterInfo GetRegisterInfo_ScriptBehaviourManager_Wrap()
        {
            return new RegisterInfo
            {
#if !EXPERIMENTAL_IL2CPP_PUERTS
                BlittableCopy = false,
#endif

                Members = new System.Collections.Generic.Dictionary<string, MemberRegisterInfo>
                {
                    {
                        ".ctor",
                        new MemberRegisterInfo
                        {
                            Name = ".ctor",
                            IsStatic = false,
                            MemberType = MemberType.Constructor,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Constructor = ScriptBehaviourManager_Wrap.Constructor
#endif
                        }
                    },
                    {
                        "AddUpdate_static",
                        new MemberRegisterInfo
                        {
                            Name = "AddUpdate",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = ScriptBehaviourManager_Wrap.F_AddUpdate
#endif
                        }
                    },
                    {
                        "InvokeUpdate_static",
                        new MemberRegisterInfo
                        {
                            Name = "InvokeUpdate",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = ScriptBehaviourManager_Wrap.F_InvokeUpdate
#endif
                        }
                    },
                    {
                        "InvokeStarter_static",
                        new MemberRegisterInfo
                        {
                            Name = "InvokeStarter",
                            IsStatic = true,
                            MemberType = MemberType.Method,
                            UseBindingMode = BindingMode.FastBinding
#if !EXPERIMENTAL_IL2CPP_PUERTS
                            ,
                            Method = ScriptBehaviourManager_Wrap.F_InvokeStarter
#endif
                        }
                    },
                }
            };
        }

        public static void AddRegisterInfoGetterIntoJsEnv(JsEnv jsEnv)
        {
            jsEnv.AddRegisterInfoGetter(
                typeof(JsMonoBehaviour),
                GetRegisterInfo_JsMonoBehaviour_Wrap
            );
            jsEnv.AddRegisterInfoGetter(typeof(System.Type), GetRegisterInfo_System_Type_Wrap);
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Input),
                GetRegisterInfo_UnityEngine_Input_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Object),
                GetRegisterInfo_UnityEngine_Object_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.GameObject),
                GetRegisterInfo_UnityEngine_GameObject_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Transform),
                GetRegisterInfo_UnityEngine_Transform_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Rigidbody),
                GetRegisterInfo_UnityEngine_Rigidbody_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Vector3),
                GetRegisterInfo_UnityEngine_Vector3_Wrap
            );
#if !EXPERIMENTAL_IL2CPP_PUERTS
            UnityEngine_Vector3_Wrap.InitBlittableCopy(jsEnv);
#endif
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.BoxCollider),
                GetRegisterInfo_UnityEngine_BoxCollider_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Collider),
                GetRegisterInfo_UnityEngine_Collider_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Debug),
                GetRegisterInfo_UnityEngine_Debug_Wrap
            );
            jsEnv.AddRegisterInfoGetter(typeof(GameManager), GetRegisterInfo_GameManager_Wrap);
            jsEnv.AddRegisterInfoGetter(
                typeof(PerformanceHelper),
                GetRegisterInfo_PerformanceHelper_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.UI.Text),
                GetRegisterInfo_UnityEngine_UI_Text_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Vector2),
                GetRegisterInfo_UnityEngine_Vector2_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Quaternion),
                GetRegisterInfo_UnityEngine_Quaternion_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Random),
                GetRegisterInfo_UnityEngine_Random_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Time),
                GetRegisterInfo_UnityEngine_Time_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Application),
                GetRegisterInfo_UnityEngine_Application_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.MonoBehaviour),
                GetRegisterInfo_UnityEngine_MonoBehaviour_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Behaviour),
                GetRegisterInfo_UnityEngine_Behaviour_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(UnityEngine.Component),
                GetRegisterInfo_UnityEngine_Component_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(System.Delegate),
                GetRegisterInfo_System_Delegate_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(Puerts.TSLoader.TSLoader),
                GetRegisterInfo_Puerts_TSLoader_TSLoader_Wrap
            );
            jsEnv.AddRegisterInfoGetter(
                typeof(Puerts.DefaultLoader),
                GetRegisterInfo_Puerts_DefaultLoader_Wrap
            );
            jsEnv.AddRegisterInfoGetter(typeof(Joystick), GetRegisterInfo_Joystick_Wrap);
            jsEnv.AddRegisterInfoGetter(typeof(GameWithJS), GetRegisterInfo_GameWithJS_Wrap);
            jsEnv.AddRegisterInfoGetter(typeof(BoxWithJS), GetRegisterInfo_BoxWithJS_Wrap);
            jsEnv.AddRegisterInfoGetter(typeof(JSBehaviour), GetRegisterInfo_JSBehaviour_Wrap);
            jsEnv.AddRegisterInfoGetter(
                typeof(ScriptBehaviourManager),
                GetRegisterInfo_ScriptBehaviourManager_Wrap
            );
        }
    }
}
