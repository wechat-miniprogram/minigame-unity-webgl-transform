using UnityEngine;
using System.Collections;
using SLua;

public class ValueType : MonoBehaviour {

    class Foo{}

    LuaSvr l;
	// Use this for initialization
	void Start () {
        l = new LuaSvr();
		l.init(null, () =>
		{
			l.start("valuetype");
		});

        using (LuaState newState = new LuaState())
        {
            LuaTable table = new LuaTable(newState);

            Vector2 v2 = new Vector2(1, 2);
            Vector3 v3 = new Vector3(1, 2, 3);
            Vector4 v4 = new Vector4(1, 2, 3, 4);
            Color col = new Color(.1f, .2f, .3f);
            Foo foo = new Foo();

            table["v2"] = v2;
            table["v3"] = v3;
            table["v4"] = v4;
            table["col"] = col;
            table["foo"] = foo;

            Assert.IsTrue((Vector2)table["v2"] == v2);
            Assert.IsTrue((Vector3)table["v3"] == v3);
            Assert.IsTrue((Vector4)table["v4"] == v4);
            Assert.IsTrue((Color)table["col"] == col);
            Assert.IsTrue(table["foo"] == foo);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
