using System.Collections;
using UnityEngine;
using SLua;

[CustomLuaClass]
public class NewCoroutine : MonoBehaviour
{
    public static IEnumerator MyMethod(string test, float time, LuaFunction func)
    {
        Debug.Log(test);
        yield return new WaitForSeconds(time);
        func.call();
        yield return new SLua.UnityExtension.YieldBreak(1, 2.0f, "hello");
        Debug.Assert(false, "never reach here");
    }

	void Start () {
		var svr = new LuaSvr();
		svr.init(null, () =>
		{
            var func = (LuaFunction)svr.start("new_coroutine");
            func.call(this);
				func.Dispose();
		});
	}
	
}