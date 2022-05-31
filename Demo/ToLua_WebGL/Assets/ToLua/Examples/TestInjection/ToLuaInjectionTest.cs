using System.Collections;
using UnityEngine;

public class BaseTest
{
    private int propertyTest;

    public virtual int TestRef(ref int count)
    {
        Debug.Log("CS:Base TestRef");
        ++count;

        return 1;
    }

    public virtual int PropertyTest
    {
        get
        {
            Debug.Log("CS: Base PropertyTestGet");
            return propertyTest;
        }
        set
        {
            Debug.Log("CS: Base PropertyTestSet");
            propertyTest = value;
        }
    }
}

public class ToLuaInjectionTest : BaseTest
{
    private int propertyTest;

    public ToLuaInjectionTest()
    {
        Debug.Log("CS:Constructor Test");
    }

    public ToLuaInjectionTest(bool state)
    {
        Debug.Log("CS:Constructor Test " + state);
    }

    public override int PropertyTest
    {
        get
        {
            Debug.Log("CS:PropertyTestGet");
            return propertyTest;
        }
        set
        {
            Debug.Log("CS:PropertyTestSet");
            propertyTest = value;
        }
    }

    public override int TestRef(ref int count)
    {
        Debug.Log("CS:Override TestRef");
        ++count;

        return 2;
    }

    public void TestOverload(int param1, bool param2)
    {
        Debug.Log("CS:TestOverload");
    }

    public void TestOverload(int param1, ref bool param2)
    {
        Debug.Log("CS:TestOverload");
        param2 = !param2;
    }

    public void TestOverload(bool param1, int param2)
    {
        Debug.Log("CS:TestOverload");
    }

#pragma warning disable 0219
    [LuaInterface.NoToLua]
    public void NoInject(bool param1, int param2)
    {
        int a = 0;
        int b = ++a;        
    }

    public void Inject(bool param1, int param2)
    {
        int a = 0;
        int b = ++a;
    }
#pragma warning restore 0219

    public IEnumerator TestCoroutine(float delay)
    {
        Debug.Log("CS:TestCoroutine Run");
        yield return new WaitForSeconds(delay);
        Debug.Log("CS:TestCoroutine End");
    }
}
