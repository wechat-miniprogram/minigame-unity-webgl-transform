using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

public interface LuaSerialization
{
    bool Serialize(StringBuilder sb, int indent);
    //void UnSerilize(IntPtr L);
}

public static class ToLuaText
{
    static Type listTypeDefinition = typeof(List<>);
    static Type dictionaryTypeDefinition = typeof(Dictionary<,>);
    static MethodInfo customTransferGenericMethod;
    static MethodInfo listTransferGenericMethod;
    static MethodInfo arrayTransferGenericMethod;
    static MethodInfo dictionaryTransferGenericMethod;

    static ToLuaText()
    {
        var classType = typeof(ToLuaText);
        customTransferGenericMethod = classType.GetMethod("TransferCustomData", BindingFlags.Static | BindingFlags.NonPublic);
        listTransferGenericMethod = classType.GetMethod("TransferList");
        arrayTransferGenericMethod = classType.GetMethod("TransferArray");
        dictionaryTransferGenericMethod = classType.GetMethod("TransferDic");
    }

    public static bool TransferList<T>(List<T> list, StringBuilder sb, int indent = 0)
    {
        return TransferArray<T>(list.ToArray(), sb, indent);
    }

    public static bool TransferArray<T>(T[] array, StringBuilder sb, int indent = 0)
    {
        bool bSerializeSuc = false;
        int validContentLength = sb.Length;

        NestBegin(sb, indent);

        if (array.Length <= 0)
        {
            bSerializeSuc = false;
            WipeInvalidContent(sb, validContentLength);
            return bSerializeSuc;
        }

        foreach (var item in array)
        {
            if (SerializeData(sb, indent, item))
                bSerializeSuc = true;
        }

        if (!IsCommonData(typeof(T)))
            sb.Append("\n");
        else
            sb.Remove(sb.Length - 2, 2);///移除最后一个", "字符组,为了部分满足强迫症

        if (bSerializeSuc)
            NestEnd(sb, indent);
        else
            WipeInvalidContent(sb, validContentLength);

        return bSerializeSuc;
    }

    public static bool TransferDic<T, U>(Dictionary<T, U> dic, StringBuilder sb, int indent = 0)
    {
        var keyType = typeof(T);
        bool bSerializeSuc = false;
        int validContentLength = sb.Length;

        NestBegin(sb, indent);

        if (dic.Count <= 0/* || !IsDataTypeSerializable(keyType)*/)
        {
            bSerializeSuc = false;
            WipeInvalidContent(sb, validContentLength);
            return bSerializeSuc;
        }

        string keyDataFormat = keyType == typeof(string) ? "[\"{0}\"] = " : "[{0}] = ";

        ++indent;
        foreach (var item in dic)
        {
            int tempValidContentLength = sb.Length;
            sb.Append("\n");
            AppendIndent(sb, indent);
            /// 不管是不是自定义数据，只要tostring能用就行
            sb.AppendFormat(keyDataFormat, item.Key);

            if (SerializeData(sb, indent, item.Value))
                bSerializeSuc = true;
            else
                WipeInvalidContent(sb, tempValidContentLength);
        }
        --indent;

        sb.Append("\n");
        if (bSerializeSuc)
            NestEnd(sb, indent);
        else
            WipeInvalidContent(sb, validContentLength);

        return bSerializeSuc;
    }

    public static MethodInfo MakeGenericArrayTransferMethod(Type type)
    {
        return arrayTransferGenericMethod.MakeGenericMethod(new Type[] { type });
    }

    public static void AppendIndent(StringBuilder sb, int indent)
    {
        for (int i = 0; i < indent; ++i)
            sb.Append("\t");
    }

    public static void AppendValue(Type valueType, string value, StringBuilder sb)
    {
        string dataFormat = valueType == typeof(string) ? "\"{0}\", " : "{0}, ";
        sb.AppendFormat(dataFormat, value.Replace("\n", @"\n").Replace("\"", @"\"""));
    }

    public static void WipeInvalidContent(StringBuilder sb, int validLength)
    {
        sb.Remove(validLength, sb.Length - validLength);
    }

    static bool TransferCustomData<T>(T data, StringBuilder sb, int indent = 0) where T : LuaSerialization
    {
        LuaSerialization serializor = data as LuaSerialization;
        return serializor.Serialize(sb, indent);
    }

    static bool SerializeNestData<T>(StringBuilder sb, int indent, T data, MethodInfo transferMethod)
    {
        bool bSerializeSuc = false;
        int validContentLength = sb.Length;

        if (transferMethod != null)
        {
            ++indent;
            sb.Append("\n");
            bSerializeSuc = (bool)transferMethod.Invoke(null, new object[] { data, sb, indent });
            if (!bSerializeSuc)
                WipeInvalidContent(sb, validContentLength);
            --indent;
        }

        return bSerializeSuc;
    }

    static bool SerializeData<T>(StringBuilder sb, int indent, T Data)
    {
        Type dataType = typeof(T);
        bool bSerializeSuc = false;

        if (dataType.IsPrimitive || dataType == typeof(string))
        {
            AppendValue(dataType, Data.ToString(), sb);
            bSerializeSuc = true;
        }
        else
        {
            MethodInfo nestEleTranferMethod = GetCollectionTransferMethod(dataType);
            bSerializeSuc = SerializeNestData(sb, indent, Data, nestEleTranferMethod);
        }

        return bSerializeSuc;
    }

    static MethodInfo GetCollectionTransferMethod(Type collectionType)
    {
        MethodInfo method = null;

        if (typeof(LuaSerialization).IsAssignableFrom(collectionType))
            method = customTransferGenericMethod.MakeGenericMethod(collectionType);
        else if (collectionType.GetGenericTypeDefinition() == dictionaryTypeDefinition)
            method = dictionaryTransferGenericMethod.MakeGenericMethod(collectionType.GetGenericArguments());
        else if (collectionType.GetGenericTypeDefinition() == listTypeDefinition)
            method = listTransferGenericMethod.MakeGenericMethod(collectionType.GetGenericArguments());
        else if (collectionType.IsArray)
            method = arrayTransferGenericMethod.MakeGenericMethod(new Type[] { collectionType.GetElementType() });

        return method;
    }

    static void NestBegin(StringBuilder sb, int indent)
    {
        AppendIndent(sb, indent);
        sb.Append("{");
    }

    static void NestEnd(StringBuilder sb, int indent)
    {
        AppendIndent(sb, indent);
        sb.Append("},");
    }

    static bool IsDataTypeSerializable(Type type)
    {
        if (type != typeof(int) && type != typeof(string))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Can't Serialize Specify Data Type : {0} To Lua", type));
            return false;
        }

        return true;
    }

    static bool IsCommonData(Type type)
    {
        if (type == typeof(string) || type.IsPrimitive)
            return true;

        return false;
    }
}
