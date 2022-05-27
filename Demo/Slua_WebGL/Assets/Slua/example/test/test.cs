/*
NLua License
--------------------

NLua is licensed under the terms of the MIT license reproduced below.
This mean that NLua is free software and can be used for both academic and
commercial purposes at absolutely no cost.

===============================================================================

Copyright (C) 2013 - Vinicius Jarina (viniciusjarina@gmail.com)
Copyright (C) 2012 Megax <http://megax.yeahunter.hu/>
Copyright (C) 2003-2005 Fabio Mascarenhas de Queiroz.


Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

===============================================================================
*/

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Threading;
using System;
using SLua;
using NLuaTest.Mock;

class Assert{
	public static void True(bool v)
	{
		IsTrue(v);
	}
	public static void IsTrue(bool v)
	{
		if (!v) {
			throw new Exception("not true");
		}
	}

	public static void AreEqual(object a, object b, string extra = "")
	{
		if (!object.Equals(a,b)) {
			throw new Exception(a + " != " + b + ", " + extra);
		}
	}

	public static void AreNotEqual(object a, object b)
	{
		if (object.Equals (a, b)) {
			throw new Exception(a + " == " + b);
		}
	}
}
public class test : MonoBehaviour {

	private LuaSvr l;
	void Start()
	{
		l = new LuaSvr();
		l.init(null, () =>{
			LuaTests t = new LuaTests();
			t.lua = LuaSvr.mainState;
			t.lua.doString ("TestClass=NLuaTest.Mock.TestClass");

			MethodInfo[] methods = t.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

			int pass = 0;
			int failed = 0;

			int i = 0;
			foreach(MethodInfo m in methods)
			{
				++i;
				try{
					Debug.Log("start test: " + m.Name);
					m.Invoke(t, null);
					++pass;
				}catch(Exception e)
				{
					++failed;
					Debug.LogError("[" + i + "] test failed: " + m.Name + ", e: "  + e);
				}
			}
			Debug.Log("test done. pass: " + pass + ", failed: " + failed);
		});
	}

	
	public class LuaTests
	{
		public LuaState lua;

		/*
        * Tests capturing an exception
        */
		public void ThrowException ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("err,errMsg=pcall(test.exceptionMethod,test)");
			Assert.AreEqual (false , lua ["err"]);

//			Exception errMsg = (Exception)lua ["errMsg"];

//			Assert.AreNotEqual (null, errMsg.InnerException);
//			Assert.AreEqual ("exception test", errMsg.InnerException.Message);
		}
		
		/*
		* Tests passing a LuaFunction
		*/
		public void CallLuaFunction()
		{
			lua.doString ("function someFunc(v1,v2) return v1 + v2 end");
			lua ["funcObject"] = lua.getFunction ("someFunc");

			lua.doString ("b = TestClass():TestLuaFunction(funcObject)");
			Assert.AreEqual (3d, lua ["b"]);

//			lua.doString ("a = TestClass():TestLuaFunction(nil)");
//			Assert.AreEqual (null, lua ["a"]);
		}
		
		/*
        * Tests capturing an exception
        */
//		public void ThrowUncaughtException ()
//		{
//		
//			lua.doString ("test=TestClass()");
			
//			try {
//				lua.doString ("test:exceptionMethod()");
//				//failed
//				Assert.AreEqual(false, true);
//			} catch (Exception) {
//				//passed
//				Assert.AreEqual (true, true);
//			}
//		}
		
		
		/*
        * Tests nullable fields
        */
//		public void TestNullable ()
//		{
//			lua.doString ("test=TestClass()");
//			lua.doString ("val=test.NullableBool");
//			Assert.AreEqual (null, (object)lua ["val"]);
//			lua.doString ("test.NullableBool = true");
//			lua.doString ("val=test.NullableBool");
//			Assert.AreEqual (true, lua ["val"]);
//		}
		
		/*
        * Tests structure assignment
        */
		public void TestStructs ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("TestStruct=NLuaTest.Mock.TestStruct");
			lua.doString ("struct=TestStruct(2)");
			lua.doString ("test.Struct = struct");
			lua.doString ("val=test.Struct.val");
			Assert.AreEqual (2d, (double)lua ["val"]);
		}

		/*
		* Tests structure creation via the default constructor
		*/
//		public void TestStructDefaultConstructor ()
//		{
//			lua.doString ("TestStruct=NLuaTest.Mock.TestStruct");
//			lua.doString ("struct=TestStruct()");
//			Assert.AreEqual (new TestStruct(), (TestStruct)lua ["struct"]);
//		}

		public void TestStructHashesEqual()
		{
			lua.doString("TestStruct=NLuaTest.Mock.TestStruct");
			lua.doString("struct1=TestStruct(0)");
			lua.doString("struct2=TestStruct(0)");
			lua.doString("struct2.val=1");
			Assert.AreEqual(0d, (double)lua["struct1.val"]);
		}

		public void TestEnumEqual()
		{
			lua.doString("TestEnum=NLuaTest.Mock.TestEnum");
			lua.doString("enum1=TestEnum.ValueA");
			lua.doString("enum2=TestEnum.ValueB");
			Assert.AreEqual(true, (bool)lua.doString("return enum1 ~= enum2"));
			Assert.AreEqual(false, (bool)lua.doString("return enum1 == enum2"));
		}

		public void TestMethodOverloads ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("a1 = test:MethodOverload()");
			lua.doString ("a2 = test:MethodOverload(test)");
			lua.doString ("a3 = test:MethodOverload(TestClass)");
			lua.doString ("a31 = test:MethodOverload(test:GetType())");
			lua.doString ("a32 = test:MethodOverload(NLuaTest.Mock.TestClass2():GetType())");
			lua.doString ("a4 = test:MethodOverload(1,1,1)");
			lua.doString ("a5, i = test:MethodOverload(2,2,Slua.out)\r\n");
			Assert.AreEqual(1d, lua["a1"]);
			Assert.AreEqual(2d, lua["a2"]);
			Assert.AreEqual(3d, lua["a3"]);
			Assert.AreEqual(3d, lua["a31"]);
			Assert.AreEqual(3d, lua["a32"]);
			Assert.AreEqual(4d, lua["a4"]);
			Assert.AreEqual(5d, lua["a5"]);
			Assert.AreEqual(5d, lua["i"]);

		}

		public void TestDispose ()
		{
			System.GC.Collect ();
			long startingMem = System.Diagnostics.Process.GetCurrentProcess ().WorkingSet64;
			
			for (int i = 0; i < 100; i++) {
				
					_Calc (lua, i);
			}
			
			//TODO: make this test assert so that it is useful
			Debug.Log ("Was using " + (startingMem / 1024 / 1024) + "MB, now using: " + (System.Diagnostics.Process.GetCurrentProcess ().WorkingSet64 / 1024 / 1024) + "MB");
		}
		
		private void _Calc (LuaState lua, int i)
		{
			lua.doString (
				"sqrt = math.sqrt;" +
				"sqr = function(x) return math.pow(x,2); end;" +
				"log = math.log;" +
				"log10 = math.log10;" +
				"exp = math.exp;" +
				"sin = math.sin;" +
				"cos = math.cos;" +
				"tan = math.tan;" +
				"abs = math.abs;"
				);
			lua.doString ("function calcVP(a,b) return a+b end");
			LuaFunction lf = lua.getFunction ("calcVP");
			lf.call (i, 20);
			lf.Dispose ();
		}
		

		// public void TestThreading ()
		// {
		// 	object lua_locker = new object ();
		// 	DoWorkClass doWork = new DoWorkClass ();
		// 	
		// 	bool failureDetected = false;
		// 	int completed = 0;
		// 	int iterations = 10;
		// 	
		// 	for (int i = 0; i < iterations; i++) {
		// 		ThreadPool.QueueUserWorkItem (new WaitCallback (delegate (object o) {
		// 			try {
		// 				lock (lua_locker) {
		// 					lua.doString ("dowork()");
		// 				}
		// 			} catch (Exception e) {
		// 				Console.Write (e);
		// 				failureDetected = true;
		// 			}
		// 			
		// 			completed++;
		// 		}));
		// 	}
		// 	
		// 	while (completed < iterations && !failureDetected)
		// 		Thread.Sleep (50);
		// 	
		// 	Assert.AreEqual (false, failureDetected);
		// }
		
		// public void TestPrivateMethod ()
		// {
		// 	lua.doString ("test=TestClass()");
		// 	
		// 	try {
		// 		lua.doString ("test:_PrivateMethod()");
		// 	} catch {
		// 		Assert.AreEqual (true, true);
		// 		return;
		// 	}
		// 	
		// 	Assert.AreEqual(true, false);
		// }

//		/*
//       * Tests functions
//       */
//		public void TestFunctions ()
//		{
//			lua.RegisterFunction ("p", null, typeof(System.Console).GetMethod ("WriteLine", new Type [] { typeof(String) }));
//			/// Lua command that works (prints to console)
//			lua.doString ("p('Foo')");
//			/// Yet this works...
//			lua.doString ("string.gsub('some string', '(%w+)', function(s) p(s) end)");
//			/// This fails if you don't fix Lua5.1 lstrlib.c/add_value to treat LUA_TUSERDATA the same as LUA_FUNCTION
//			lua.doString ("string.gsub('some string', '(%w+)', p)");
//		}
//		
//		
		/*
        * Tests making an object from a Lua table and calling one of
        * methods the table overrides.
        */
		// public void LuaTableOverridedMethod ()
		// {
		// 	lua.doString ("test={}");
		// 	lua.doString ("function test:overridableMethod(x,y) return x*y; end");
		// 	lua.doString ("luanet.make_object(test,'NLuaTest.Mock.TestClass')");
		// 	lua.doString ("a=TestClass.callOverridable(test,2,3)");
		// 	int a = (int)lua["a"];
		// 	lua.doString ("luanet.free_object(test)");
		// 	Assert.AreEqual (6, a);
		// }
		
		
		/*
        * Tests making an object from a Lua table and calling a method
        * the table does not override.
        */
//		public void LuaTableInheritedMethod ()
//		{
//			lua.doString ("test={}");
//			lua.doString ("function test:overridableMethod(x,y) return x*y; end");
//			lua.doString ("luanet.make_object(test,'NLuaTest.Mock.TestClass')");
//			lua.doString ("test:setVal(3)");
//			lua.doString ("a=test.testval");
//			int a = (int)lua["a"];
//			lua.doString ("luanet.free_object(test)");
//			Assert.AreEqual (3, a);
//			//Debug.Log("interface returned: "+a);
//		}

		/// <summary>
		/// Basic multiply method which expects 2 floats
		/// </summary>
		/// <param name="val"></param>
		/// <param name="val2"></param>
		/// <returns></returns>
		private float _TestException (float val, float val2)
		{
			return val * val2;
		}
		
//		class LuaEventArgsHandler : NLua.Method.LuaDelegate
//		{
//			void CallFunction (object sender, EventArgs eventArgs)
//			{
//				object [] args = new object [] {sender, eventArgs };
//				object [] inArgs = new object [] { sender, eventArgs };
//				int [] outArgs = new int [] { };
//				base.CallFunction (args, inArgs, outArgs);
//			}
//		}
//		

//		public void TestEventException ()
//		{
//			
//				//Register a C# function
//				MethodInfo testException = this.GetType ().GetMethod ("_TestException", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance, null, new Type [] {
//					typeof(float),
//					typeof(float)
//				}, null);
//				lua.RegisterFunction ("Multiply", this, testException);
//				lua.RegisterLuaDelegateType (typeof(EventHandler<EventArgs>), typeof(LuaEventArgsHandler));
//				//create the lua event handler code for the entity
//				//includes the bad code!
//				lua.doString ("function OnClick(sender, eventArgs)\r\n" +
//				              "--Multiply expects 2 floats, but instead receives 2 strings\r\n" +
//				              "Multiply(asd, es)\r\n" +
//				              "end");
//				//create the lua event handler code for the entity
//				//good code
//				//lua.doString("function OnClick(sender, eventArgs)\r\n" +
//				//              "--Multiply expects 2 floats\r\n" +
//				//              "Multiply(2, 50)\r\n" +
//				//            "end");
//				//Create the event handler script
//				lua.doString ("function SubscribeEntity(e)\r\ne.Clicked:Add(OnClick)\r\nend");
//				//Create the entity object
//				Entity entity = new Entity ();
//				//Register the entity object with the event handler inside lua
//				LuaFunction lf = lua.getFunction ("SubscribeEntity");
//				lf.Call (new object [1] { entity });
//				
//				try {
//					//Cause the event to be fired
//					entity.Click ();
//					//failed
//					Assert.AreEqual(true, false);
//				} catch (LuaException) {
//					//passed
//					Assert.AreEqual (true, true);
//				}
//			}
//		}
//		

		public void TestExceptionWithChunkOverload ()
		{			
			try {
				lua.doString ("thiswillthrowanerror", "MyChunk");
			} catch (Exception e) {
				Assert.AreEqual (true, e.Message.StartsWith ("[string \"MyChunk\"]"));
			}
		}
//		

//		public void TestGenerics ()
//		{
//			//Im not sure support for generic classes is possible to implement, see: http://msdn.microsoft.com/en-us/library/system.reflection.methodinfo.containsgenericparameters.aspx
//			//specifically the line that says: "If the ContainsGenericParameters property returns true, the method cannot be invoked"
//			//TestClassGeneric<string> genericClass = new TestClassGeneric<string>();
//			//lua.RegisterFunction("genericMethod", genericClass, typeof(TestClassGeneric<>).GetMethod("GenericMethod"));
//			//lua.RegisterFunction("regularMethod", genericClass, typeof(TestClassGeneric<>).GetMethod("RegularMethod"));
//			
//				TestClassWithGenericMethod classWithGenericMethod = new TestClassWithGenericMethod ();
//				
//				////////////////////////////////////////////////////////////////////////////
//				/// ////////////////////////////////////////////////////////////////////////
//				///  IMPORTANT: Use generic method with the type you will call or generic methods will fail with iOS
//				/// ////////////////////////////////////////////////////////////////////////
//				classWithGenericMethod.GenericMethod<double>(99.0);
//				classWithGenericMethod.GenericMethod<TestClass>(new TestClass (99));
//				////////////////////////////////////////////////////////////////////////////
//				/// ////////////////////////////////////////////////////////////////////////
//				
//				lua.RegisterFunction ("genericMethod2", classWithGenericMethod, typeof(TestClassWithGenericMethod).GetMethod ("GenericMethod"));
//				
//				try {
//					lua.doString ("genericMethod2(100)");
//				} catch {
//				}
//				
//				Assert.AreEqual (true, classWithGenericMethod.GenericMethodSuccess);
//				Assert.AreEqual (true, classWithGenericMethod.Validate<double> (100)); //note the gotcha: numbers are all being passed to generic methods as doubles
//				
//				try {
//					
//					
//					lua.doString ("test=TestClass(56)");
//					lua.doString ("genericMethod2(test)");
//				} catch {
//				}
//				
//				Assert.AreEqual (true, classWithGenericMethod.GenericMethodSuccess);
//				Assert.AreEqual (56, (classWithGenericMethod.PassedValue as TestClass).val);
//			}
//		}
//		

//		public void RegisterFunctionStressTest ()
//		{
//			const int Count = 200;  // it seems to work with 41
//			
//				MyClass t = new MyClass ();
//				
//				for (int i = 1; i < Count - 1; ++i) {
//					lua.RegisterFunction ("func" + i, t, typeof(MyClass).GetMethod ("Func1"));
//				}
//				
//				lua.RegisterFunction ("func" + (Count - 1), t, typeof(MyClass).GetMethod ("Func1"));
//				lua.doString ("print(func1())");
//			}
//		}
//		

		public void TestMultipleOutParameters ()
		{			
			TestClass t1 = new TestClass ();
			lua ["netobj"] = t1;
			lua.doString ("a,b,c=netobj:outValMutiple(2)");
			Assert.AreEqual (2d, lua["a"]);
			Assert.AreNotEqual (null, lua["b"]);
			Assert.AreNotEqual (null, lua["c"]);
		}
		

		// public void TestLoadStringLeak ()
		// {
		// 	//Test to prevent stack overflow
		// 	//See: http://code.google.com/p/nlua/issues/detail?id=5
		// 	//number of iterations to test
		// 	int count = 1000;
		// 	for (int i = 0; i < count; i++) {
		// 		lua.LoadString ("abc = 'def'", string.Empty);
		// 	}
		// 	//any thrown exceptions cause the test run to fail
		// }
		

		// public void TestLoadFileLeak ()
		// {
		// 	//Test to prevent stack overflow
		// 	//See: http://code.google.com/p/nlua/issues/detail?id=5
		// 	//number of iterations to test
		// 	int count = 1000;
		// 	for (int i = 0; i < count; i++) {
		// 		lua.LoadFile (Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "test.lua");
		// 	}
		// 	//any thrown exceptions cause the test run to fail
		// }
		

//		public void TestRegisterFunction ()
//		{
//				lua.RegisterFunction ("func1", null, typeof(TestClass2).GetMethod ("func"));
//				object[] vals1 = lua.getFunction ("func1").Call (2, 3);
//				Assert.AreEqual (5.0f, Convert.ToSingle (vals1 [0]));
//				TestClass2 obj = new TestClass2 ();
//				lua.RegisterFunction ("func2", obj, typeof(TestClass2).GetMethod ("funcInstance"));
//				vals1 = lua.getFunction ("func2").Call (2, 3);
//				Assert.AreEqual (5.0f, Convert.ToSingle (vals1 [0]));
//			}
//		}
//		
//		/*
//		 * Tests passing a null object as a parameter to a
//		 * method that accepts a nullable.
//		 */
//		public void TestNullableParameter ()
//		{
//			lua.doString ("test=TestClass()");
//			lua.doString ("a = test:NullableMethod(nil)");
//			Assert.AreEqual (null, lua ["a"]);
//			lua ["timeVal"] = TimeSpan.FromSeconds (5);
//			lua.doString ("b = test:NullableMethod(timeVal)");
//			Assert.AreEqual (TimeSpan.FromSeconds (5), lua ["b"]);
//			lua.doString ("d = test:NullableMethod2(2)");
//			Assert.AreEqual (2, lua ["d"]);
//			lua.doString ("c = test:NullableMethod2(nil)");
//			Assert.AreEqual (null, lua ["c"]);
//		}
		
		/*
        * Tests if DoString is correctly returning values
        */

		public void DoString ()
		{
			object[] res = (object[])lua.doString ("a=2\nreturn a,3");
			//Debug.Log("a="+res[0]+", b="+res[1]);
			Assert.AreEqual (res [0], 2d);
			Assert.AreEqual (res [1], 3d);
		}

		/*
        * Tests getting of global numeric variables
        */
		public void GetGlobalNumber ()
		{
			lua.doString ("a=2");
			Assert.AreEqual (lua["a"], 2d);
		}

		/*
        * Tests setting of global numeric variables
        */
		public void SetGlobalNumber ()
		{
			lua.doString ("a=2");
			lua ["a"] = 3;
			Assert.AreEqual (lua ["a"], 3d);
		}
		/*
        * Tests getting of numeric variables from tables
        * by specifying variable path
        */
		public void GetNumberInTable ()
		{
			lua.doString ("a={b={c=2}}");
			Assert.AreEqual (lua["a.b.c"], 2d);
		}

		/*
        * Tests setting of numeric variables from tables
        * by specifying variable path
        */

		public void SetNumberInTable ()
		{
			lua.doString ("a={b={c=2}}");
			lua ["a.b.c"] = 3;
			Assert.AreEqual (lua ["a.b.c"], 3d);
		}

		/*
        * Tests getting of global string variables
        */

		public void GetGlobalString ()
		{
			lua.doString ("a=\"test\"");
			Assert.AreEqual (lua["a"], "test");
		}
		/*
        * Tests setting of global string variables
        */

		public void SetGlobalString ()
		{		
			lua.doString ("a=\"test\"");
			lua ["a"] = "new test";
			Assert.AreEqual (lua ["a"], "new test");
		}

		/*
        * Tests getting of string variables from tables
        * by specifying variable path
        */
		public void GetStringInTable ()
		{
			
			lua.doString ("a={b={c=\"test\"}}");
			Assert.AreEqual (lua["a.b.c"], "test");
		}

		/*
        * Tests setting of string variables from tables
        * by specifying variable path
        */
		public void SetStringInTable ()
		{
			lua.doString ("a={b={c=\"test\"}}");
			lua ["a.b.c"] = "new test";
			Assert.AreEqual (lua ["a.b.c"], "new test");
		}
		
		/*
        * Tests getting and setting of global table variables
        */
		public void GetAndSetTable ()
		{
			lua.doString ("a={b={c=2}}\nb={c=3}");
			LuaTable tab = lua.getTable ("b");
			lua ["a.b"] = tab;
			Assert.AreEqual (lua["a.b.c"], 3d);
		}

		/*
        * Tests getting of numeric field of a table
        */
		public void GetTableNumericField1 ()
		{
			lua.doString ("a={b={c=2}}");
			LuaTable tab = lua.getTable ("a.b");
			double num = (double)tab ["c"];
			Assert.AreEqual (num, 2d);
		}

		/*
        * Tests getting of numeric field of a table
        * (the field is inside a subtable)
        */
		public void GetTableNumericField2 ()
		{	
			lua.doString ("a={b={c=2}}");
			LuaTable tab = lua.getTable ("a");
			double num = (double)tab ["b.c"];
			//Debug.Log("a.b.c="+num);
			Assert.AreEqual (num, 2d);
		}
		
		/*
        * Tests setting of numeric field of a table
        */
		public void SetTableNumericField1 ()
		{	
			lua.doString ("a={b={c=2}}");
			LuaTable tab = lua.getTable ("a.b");
			tab ["c"] = 3;
			Assert.AreEqual (lua["a.b.c"], 3d);
		}
		
		/*
        * Tests setting of numeric field of a table
        * (the field is inside a subtable)
        */
		public void SetTableNumericField2 ()
		{
			lua.doString ("a={b={c=2}}");
			LuaTable tab = lua.getTable ("a");
			tab ["b.c"] = 3;
			Assert.AreEqual (tab ["b.c"], 3d);
		}
		
		/*
        * Tests getting of string field of a table
        */
		public void GetTableStringField1 ()
		{
			lua.doString ("a={b={c=\"test\"}}");
			LuaTable tab = lua.getTable ("a.b");
			string str = (string)tab ["c"];
			Assert.AreEqual (str, "test");
		}

		/*
        * Tests getting of string field of a table
        * (the field is inside a subtable)
        */
		public void GetTableStringField2 ()
		{
			lua.doString ("a={b={c=\"test\"}}");
			LuaTable tab = lua.getTable ("a");
			string str = (string)tab ["b.c"];
			//Debug.Log("a.b.c="+str);
			Assert.AreEqual (str, "test");
		}

		/*
        * Tests setting of string field of a table
        */
		public void SetTableStringField1 ()
		{			
			lua.doString ("a={b={c=\"test\"}}");
			LuaTable tab = lua.getTable ("a.b");
			tab ["c"] = "new test";
			Assert.AreEqual (lua["a.b.c"], "new test");
		}
		
		/*
        * Tests setting of string field of a table
        * (the field is inside a subtable)
        */
		public void SetTableStringField2 ()
		{			
			lua.doString ("a={b={c=\"test\"}}");
			LuaTable tab = lua.getTable ("a");
			tab ["b.c"] = "new test";
			Assert.AreEqual (lua["a.b.c"], "new test");
		}

		/*
        * Tests calling of a global function with zero arguments
        */
		public void CallGlobalFunctionNoArgs ()
		{		
			lua.doString ("a=2\nfunction f()\na=3\nend");
			lua.getFunction ("f").call ();
			Assert.AreEqual (lua["a"], 3d);
		}

		/*
        * Tests calling of a global function with one argument
        */
		public void CallGlobalFunctionOneArg ()
		{			
			lua.doString ("a=2\nfunction f(x)\na=a+x\nend");
			lua.getFunction ("f").call (1);
			Assert.AreEqual (lua["a"], 3d);
		}
		
		/*
        * Tests calling of a global function with two arguments
        */
		public void CallGlobalFunctionTwoArgs ()
		{
			lua.doString ("a=2\nfunction f(x,y)\na=x+y\nend");
			lua.getFunction ("f").call (1, 3);
			//Debug.Log("a="+num);
			Assert.AreEqual (lua["a"], 4d);
		}
		
		/*
        * Tests calling of a global function that returns one value
        */
		public void CallGlobalFunctionOneReturn ()
		{
			lua.doString ("function f(x)\nreturn x+2\nend");
			object ret = lua.getFunction ("f").call (3);
			Assert.AreEqual (5d, ret);
		}
		
		/*
        * Tests calling of a global function that returns two values
        */
		public void CallGlobalFunctionTwoReturns ()
		{
			lua.doString ("function f(x,y)\nreturn x,x+y\nend");
			object[] ret = (object[])lua.getFunction ("f").call (3, 2);
			//Debug.Log("ret="+ret[0]+","+ret[1]);
			Assert.AreEqual (2, ret.Length);
			Assert.AreEqual (3d, (double)ret [0]);
			Assert.AreEqual (5d, (double)ret [1]);
		}
		
		/*
        * Tests calling of a function inside a table
        */
		public void CallTableFunctionTwoReturns ()
		{
			lua.doString ("a={}\nfunction a.f(x,y)\nreturn x,x+y\nend");
			object[] ret = (object[])lua.getFunction ("a.f").call (3, 2);
			//Debug.Log("ret="+ret[0]+","+ret[1]);
			Assert.AreEqual (2, ret.Length);
			Assert.AreEqual (3d, (double)ret [0]);
			Assert.AreEqual (5d, (double)ret [1]);
		}
		
		/*
        * Tests setting of a global variable to a CLR object value
        */
		public void SetGlobalObject ()
		{	
			TestClass t1 = new TestClass ();
			t1.testval = 4;
			lua ["netobj"] = t1;
			object o = lua ["netobj"];
			Assert.AreEqual (true, o is TestClass);
			TestClass t2 = (TestClass)lua ["netobj"];
			Assert.AreEqual (t2.testval, 4);
			Assert.AreEqual (t1 , t2);
		}

		/*
		* Tests if CLR object is being correctly collected by Lua
		*/
		public void GarbageCollection()
		{
			ObjectCache oc = ObjectCache.get(lua.L);
			Dictionary<object, int> objMap = (Dictionary<object, int>)oc.GetType ()
				.GetField ("objMap", BindingFlags.Instance| BindingFlags.NonPublic).GetValue(oc);
			Assert.True(objMap != null);

	        TestClass t1 = new TestClass();
	        t1.testval = 4;
	        lua["netobj"] = t1;
	        
			Assert.True(objMap.ContainsKey(t1));
	        
			lua.doString("netobj=nil;collectgarbage();");

			Assert.True(!objMap.ContainsKey(t1));
		 }

		/*
        * Tests setting of a table field to a CLR object value
        */
		public void SetTableObjectField1 ()
		{
			lua.doString ("a={b={c=\"test\"}}");
			LuaTable tab = lua.getTable ("a.b");
			TestClass t1 = new TestClass ();
			t1.testval = 4;
			tab ["c"] = t1;
			TestClass t2 = (TestClass)lua ["a.b.c"];
			//Debug.Log("a.b.c="+t2.testval);
			Assert.AreEqual (4, t2.testval);
			Assert.AreEqual (t1 , t2);
		}
		
		/*
        * Tests reading and writing of an object's field
        */
		public void AccessObjectField ()
		{
			TestClass t1 = new TestClass ();
			t1.val = 4;
			lua ["netobj"] = t1;
			lua.doString ("var=netobj.val");
			double var = (double)lua ["var"];
			Assert.AreEqual (4d, var);
			lua.doString ("netobj.val=3");
			Assert.AreEqual (3, t1.val);
		}
		
		/*
        * Tests reading and writing of an object's non-indexed
        * property
        */
		public void AccessObjectProperty ()
		{	
			TestClass t1 = new TestClass ();
			t1.testval = 4;
			lua ["netobj"] = t1;
			lua.doString ("var=netobj.testval");
			double var = (double)lua ["var"];
			//Debug.Log("value from Lua="+var);
			Assert.AreEqual (4d, var);
			lua.doString ("netobj.testval=3");
			Assert.AreEqual (3, t1.testval);
			//Debug.Log("new val (from Lua)="+t1.testval);
		}

		public void AccessObjectStringProperty ()
		{	
			TestClass t1 = new TestClass ();
			t1.teststrval = "This is a string test";
			lua ["netobj"] = t1;
			lua.doString ("var=netobj.teststrval");
			string var = (string)lua ["var"];
			
			Assert.AreEqual ("This is a string test", var);
			lua.doString ("netobj.teststrval='Another String'");
			Assert.AreEqual ("Another String", t1.teststrval);
			//Debug.Log("new val (from Lua)="+t1.testval);
		}
		
		/*
        * Tests calling of an object's method with no overloads
        */
		public void CallObjectMethod ()
		{			
			TestClass t1 = new TestClass ();
			t1.testval = 4;
			lua ["netobj"] = t1;
			lua.doString ("netobj:setVal(3)");
			Assert.AreEqual (3, t1.testval);
			//Debug.Log("new val(from C#)="+t1.testval);
			lua.doString ("val=netobj:getVal()");
			Assert.AreEqual (3d, lua["val"]);
			//Debug.Log("new val(from Lua)="+val);
		}
		
		/*
        * Tests calling of an object's method with overloading
        */
		public void CallObjectMethodByType ()
		{
			TestClass t1 = new TestClass ();
			lua ["netobj"] = t1;
			lua.doString ("netobj:setVal('str')");
			Assert.AreEqual ("str", t1.getStrVal ());
			//Debug.Log("new val(from C#)="+t1.getStrVal());
		}

		/*
        * Tests calling of an object's method with no overloading
        * and out parameters
        */
		 public void CallObjectMethodOutParam ()
		 {
		 	TestClass t1 = new TestClass ();
		 	lua ["netobj"] = t1;
			lua.doString ("a,b=netobj:outVal(Slua.out)");
		 	Assert.AreEqual (3d, lua["a"]);
		 	Assert.AreEqual (5d, lua["b"]);
		 	//Debug.Log("function returned (from lua)="+a+","+b);
		 }

		/*
        * Tests calling of an object's method with overloading and
        * out params
        */
		 public void CallObjectMethodOverloadedOutParam ()
		 {			
		 	TestClass t1 = new TestClass ();
		 	lua ["netobj"] = t1;
			lua.doString ("a,b=netobj:outVal(Slua.out, 2)");
		 	Assert.AreEqual (2d, lua["a"]);
		 	Assert.AreEqual (5d, lua["b"]);
		 	//Debug.Log("function returned (from lua)="+a+","+b);
		 }

		/*
        * Tests calling of an object's method with ref params
        */
		 public void CallObjectMethodByRefParam ()
		 {			
		 	TestClass t1 = new TestClass ();
		 	lua ["netobj"] = t1;
		 	lua.doString ("a,b=netobj:outVal(2,3)");
		 	Assert.AreEqual (2d, lua["a"]);
		 	Assert.AreEqual (5d, lua["b"]);
		 }

		/*
        * Tests calling of two versions of an object's method that have
        * the same name and signature but implement different interfaces
        */
//		 public void CallObjectMethodDistinctInterfaces ()
//		 {
//		 	TestClass t1 = new TestClass ();
//		 	lua ["netobj"] = t1;
//		 	lua.doString ("a=netobj:foo()");
//		 	lua.doString ("b=netobj['NLuaTest.Mock.IFoo1.foo']");
//		 	Assert.AreEqual (5d, lua["a"]);
//		 	Assert.AreEqual (1d, lua["b"]);
//		 }

		/*
        * Tests instantiating an object with no-argument constructor
        */
		public void CreateNetObjectNoArgsCons ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("test:setVal(3)");
			TestClass test = (TestClass)lua.doString ("return test");
			//Debug.Log("returned: "+test.testval);
			Assert.AreEqual (3, test.testval);
		}
		
		/*
        * Tests instantiating an object with one-argument constructor
        */
		public void CreateNetObjectOneArgCons ()
		{
			lua.doString ("test=TestClass(3)");
			TestClass test = (TestClass)lua.doString ("return test");
			//Debug.Log("returned: "+test.testval);
			Assert.AreEqual (3, test.testval);
		}
		
		/*
        * Tests instantiating an object with overloaded constructor
        */
		public void CreateNetObjectOverloadedCons ()
		{
			lua.doString ("test=TestClass('str')");
			TestClass test = (TestClass)lua.doString ("return test");
			//Debug.Log("returned: "+test.getStrVal());
			Assert.AreEqual ("str", test.getStrVal ());
		}
		
		/*
        * Tests getting item of a CLR array
        */
		public void ReadArrayField ()
		{
			string[] arr = new string [] { "str1", "str2", "str3" };
			lua ["netobj"] = arr;
			lua.doString ("val=netobj[1]");
			Assert.AreEqual ("str2", lua["val"]);
			//Debug.Log("new val(from array to Lua)="+val);
		}

		/*
        * Tests setting item of a CLR array
        */
		public void WriteArrayField ()
		{			
			string[] arr = new string [] { "str1", "str2", "str3" };
			lua ["netobj"] = arr;
			lua.doString ("netobj[1]='test'");
			Assert.AreEqual ("test", arr [1]);
			//Debug.Log("new val(from Lua to array)="+arr[1]);
		}
		
		/*
        * Tests creating a new CLR array
        */
//		 public void CreateArray ()
//		 {
//		 	lua.doString ("arr=TestClass[3]");
//		 	lua.doString ("for i=0,2 do arr[i]=TestClass(i+1) end");
//		 	TestClass[] arr = (TestClass[])lua ["arr"];
//		 	Assert.AreEqual (arr[1].testval, 2);
//		 }

		/*
        * Tests passing a Lua function to a delegate
        * with value-type arguments
        */
		public void LuaDelegateValueTypes ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x,y) return x+y; end");
			lua.doString ("test=TestClass()");
			lua.doString ("a=test:callDelegate1(func)");
			Assert.AreEqual (5d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}

		/*
        * Tests passing a Lua function to a delegate
        * with value-type arguments and out params
        */
		public void LuaDelegateValueTypesOutParam ()
		{			
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x) return x,x*2; end");
			lua.doString ("test=TestClass()");
			lua.doString ("a=test:callDelegate2(func)");
			Assert.AreEqual (6d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}

		/*
        * Tests passing a Lua function to a delegate
        * with value-type arguments and ref params
        * 
        */
		public void LuaDelegateValueTypesByRefParam ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x,y) return x+y; end");
			lua.doString ("test=TestClass()");
			lua.doString ("a=test:callDelegate3(func)");
			Assert.AreEqual (5d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}

		/*
        * Tests passing a Lua function to a delegate
        * with value-type arguments that returns a reference type
        */
		public void LuaDelegateValueTypesReturnReferenceType ()
		{		
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x,y) return TestClass(x+y); end");
			lua.doString ("test=TestClass()");
			lua.doString ("a=test:callDelegate4(func)");
			Assert.AreEqual (5d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}

		/*
        * Tests passing a Lua function to a delegate
        * with reference type arguments
        */
		public void LuaDelegateReferenceTypes ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x,y) return x.testval+y.testval; end");
			lua.doString ("a=test:callDelegate5(func)");
			Assert.AreEqual (5d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}
		
		/*
        * Tests passing a Lua function to a delegate
        * with reference type arguments and an out param
        */
		public void LuaDelegateReferenceTypesOutParam ()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x) return x,TestClass(x*2); end");
			lua.doString ("test=TestClass()");
			lua.doString ("a=test:callDelegate6(func)");
			Assert.AreEqual (6d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}

		/*
        * Tests passing a Lua function to a delegate
        * with reference type arguments and a ref param
        */
		public void LuaDelegateReferenceTypesByRefParam ()
		{	
			lua.doString ("test=TestClass()");
			lua.doString ("function func(x,y) return TestClass(x+y.testval); end");
			lua.doString ("a=test:callDelegate7(func)");
			Assert.AreEqual (5d, lua["a"]);
			//Debug.Log("delegate returned: "+a);
		}
//		
//		
//		/*
//        * Tests passing a Lua table as an interface and
//        * calling one of its methods with value-type params
//        */

//		public void NLuaAAValueTypes ()
//		{
//			
//				lua.RegisterLuaClassType (typeof(ITest), typeof(LuaITestClassHandler));
//				
//				
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:test1(x,y) return x+y; end");
//				lua.doString ("test=TestClass()");
//				lua.doString ("a=test:callInterface1(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (5, a);
//				//Debug.Log("interface returned: "+a);
//			}
//		}
		/*
        * Tests passing a Lua table as an interface and
        * calling one of its methods with value-type params
        * and an out param
        */
		// public void NLuaValueTypesOutParam ()
		// {
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("itest={}");
		// 	lua.doString ("function itest:test2(x) return x,x*2; end");
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("a=test:callInterface2(itest)");
		// 	Assert.AreEqual (6d, lua["a"]);
		// 		//Debug.Log("interface returned: "+a);
		// }

		/*
        * Tests passing a Lua table as an interface and
        * calling one of its methods with value-type params
        * and a ref param
        */
		// public void NLuaValueTypesByRefParam ()
		// {
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("itest={}");
		// 	lua.doString ("function itest:test3(x,y) return x+y; end");
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("a=test:callInterface3(itest)");
		// 	Assert.AreEqual (5d, lua["a"]);
		// 	//Debug.Log("interface returned: "+a);
		// }

		/*
        * Tests passing a Lua table as an interface and
        * calling one of its methods with value-type params
        * returning a reference type param
        */
		// public void NLuaValueTypesReturnReferenceType ()
		// {
		// 		
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("itest={}");
		// 	lua.doString ("function itest:test4(x,y) return TestClass(x+y); end");
		// 	lua.doString ("test=TestClass()");
		// 	lua.doString ("a=test:callInterface4(itest)");
		// 	int a = (int)lua["a"];
		// 	Assert.AreEqual (5, a);
		// 	//Debug.Log("interface returned: "+a);
		// }

//		 /*
//        * Tests passing a Lua table as an interface and
//        * calling one of its methods with reference type params
//        */
//		public void NLuaReferenceTypes ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:test5(x,y) return x.testval+y.testval; end");
//				lua.doString ("test=TestClass()");
//				lua.doString ("a=test:callInterface5(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (5, a);
//				//Debug.Log("interface returned: "+a);
//		}

//		 /*
//        * Tests passing a Lua table as an interface and
//        * calling one of its methods with reference type params
//        * and an out param
//        */
//		public void NLuaReferenceTypesOutParam ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:test6(x) return x,TestClass(x*2); end");
//				lua.doString ("test=TestClass()");
//				lua.doString ("a=test:callInterface6(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (6, a);
//				//Debug.Log("interface returned: "+a);
//		}

//		/*
//        * Tests passing a Lua table as an interface and
//        * calling one of its methods with reference type params
//        * and a ref param
//        */
//		public void NLuaReferenceTypesByRefParam ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:test7(x,y) return TestClass(x+y.testval); end");
//				lua.doString ("a=test:callInterface7(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (5, a);
//				//Debug.Log("interface returned: "+a);
//		}
//		
//		
//		#region LUA_BOILERPLATE_CLASS
//		/*** This class is used to bind the .NET world with the Lua world, this boilerplate code is pratically the same, get values call Lua function return value back,
//        * this class is usually dynamic generated using System.Reflection.Emit, but this will not work on iOS. */
//		
//		class LuaTestClassHandler: TestClass, ILuaGeneratedType
//		{
//			public LuaTable __luaInterface_luaTable;
//			public Type[][] __luaInterface_returnTypes;
//			
//			public LuaTestClassHandler (LuaTable luaTable, Type[][] returnTypes)
//			{
//				__luaInterface_luaTable = luaTable;
//				__luaInterface_returnTypes = returnTypes;
//			}
//			
//			public LuaTable LuaInterfaceGetLuaTable ()
//			{
//				return __luaInterface_luaTable;
//			}
//			
//			public override int overridableMethod (int x, int y)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					x,
//					y
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					x,
//					y
//				};
//				int [] outArgs = new int [] { };
//				Type [] returnTypes = __luaInterface_returnTypes [0];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "overridableMethod");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				return (int)ret;
//			}
//		}
//		
//		class LuaITestClassHandler : ILuaGeneratedType, ITest
//		{
//			public LuaTable __luaInterface_luaTable;
//			public Type[][] __luaInterface_returnTypes;
//			
//			public LuaITestClassHandler (LuaTable luaTable, Type[][] returnTypes)
//			{
//				__luaInterface_luaTable = luaTable;
//				__luaInterface_returnTypes = returnTypes;
//			}
//			
//			public LuaTable LuaInterfaceGetLuaTable ()
//			{
//				return __luaInterface_luaTable;
//			}
//			
//			public int intProp {
//				get {
//					object [] args = new object [] { __luaInterface_luaTable };
//					object [] inArgs = new object [] { __luaInterface_luaTable };
//					int [] outArgs = new int [] { };
//					Type [] returnTypes = __luaInterface_returnTypes [0];
//					LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "get_intProp");
//					object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//					return (int)ret;
//				}
//				set {
//					int i = value;
//					object [] args = new object [] {
//						__luaInterface_luaTable ,
//						i
//					};
//					object [] inArgs = new object [] {
//						__luaInterface_luaTable,
//						i
//					};
//					int [] outArgs = new int [] { };
//					Type [] returnTypes = __luaInterface_returnTypes [1];
//					LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "set_intProp");
//					NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				}
//			}
//			
//			public TestClass refProp {
//				get {
//					object [] args = new object [] { __luaInterface_luaTable };
//					object [] inArgs = new object [] { __luaInterface_luaTable };
//					int [] outArgs = new int [] { };
//					Type [] returnTypes = __luaInterface_returnTypes [2];
//					LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "get_refProp");
//					object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//					return (TestClass)ret;
//				}
//				set {
//					TestClass test = value;
//					object [] args = new object [] {
//						__luaInterface_luaTable ,
//						test
//					};
//					object [] inArgs = new object [] {
//						__luaInterface_luaTable,
//						test
//					};
//					int [] outArgs = new int [] { };
//					Type [] returnTypes = __luaInterface_returnTypes [3];
//					LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "set_refProp");
//					NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				}
//			}
//			
//			public int test1 (int a, int b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				int [] outArgs = new int [] { };
//				Type [] returnTypes = __luaInterface_returnTypes [4];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test1");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				return (int)ret;
//			}
//			
//			public int test2 (int a, out int b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					0
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a
//				};
//				int [] outArgs = new int [] { 1 };
//				Type [] returnTypes = __luaInterface_returnTypes [5];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test2");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				b = (int)args [1];
//				return (int)ret;
//			}
//			
//			public void test3 (int a, ref int b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				int [] outArgs = new int [] { 1 };
//				Type [] returnTypes = __luaInterface_returnTypes [6];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test3");
//				NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				b = (int)args [1];
//			}
//			
//			public TestClass test4 (int a, int b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				int [] outArgs = new int [] { };
//				Type [] returnTypes = __luaInterface_returnTypes [7];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test4");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				return (TestClass)ret;
//			}
//			
//			public int test5 (TestClass a, TestClass b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				int [] outArgs = new int [] { };
//				Type [] returnTypes = __luaInterface_returnTypes [8];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test5");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				return (int)ret;
//			}
//			
//			public int test6 (int a, out TestClass b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					null
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//				};
//				int [] outArgs = new int [] { 1};
//				Type [] returnTypes = __luaInterface_returnTypes [9];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test6");
//				object ret = NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				b = (TestClass)args [1];
//				
//				return (int)ret;
//			}
//			
//			public void test7 (int a, ref TestClass b)
//			{
//				object [] args = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				object [] inArgs = new object [] {
//					__luaInterface_luaTable,
//					a,
//					b
//				};
//				int [] outArgs = new int [] { 1 };
//				Type [] returnTypes = __luaInterface_returnTypes [10];
//				LuaFunction function = NLua.Method.LuaClassHelper.GetTableFunction (__luaInterface_luaTable, "test7");
//				NLua.Method.LuaClassHelper.CallFunction (function, args, returnTypes, inArgs, outArgs);
//				b = (TestClass)args [1];
//			}
//		}
//		#endregion
//		
//		/*
//        * Tests passing a Lua table as an interface and
//        * accessing one of its value-type properties
//        */
//		public void NLuaValueProperty ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:get_intProp() return itest.int_prop; end");
//				lua.doString ("function itest:set_intProp(val) itest.int_prop=val; end");
//				lua.doString ("a=test:callInterface8(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (3, a);
//				//Debug.Log("interface returned: "+a);
//		}

//		 /*
//        * Tests passing a Lua table as an interface and
//        * accessing one of its reference type properties
//        */
//		public void NLuaReferenceProperty ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("itest={}");
//				lua.doString ("function itest:get_refProp() return TestClass(itest.int_prop); end");
//				lua.doString ("function itest:set_refProp(val) itest.int_prop=val.testval; end");
//				lua.doString ("a=test:callInterface9(itest)");
//				int a = (int)lua["a"];
//				Assert.AreEqual (3, a);
//				//Debug.Log("interface returned: "+a);
//		}
//		
//		
//		/*
//        * Tests making an object from a Lua table and calling the base
//        * class version of one of the methods the table overrides.
//        */
//		public void LuaTableBaseMethod ()
//		{
//				lua.RegisterLuaClassType (typeof(TestClass), typeof(LuaTestClassHandler));		
//				lua.doString ("test={}");
//				lua.doString ("function test:overridableMethod(x,y) print(self[base]); return 6 end");
//				lua.doString ("luanet.make_object(test,'NLuaTest.Mock.TestClass')");
//				lua.doString ("a=TestClass.callOverridable(test,2,3)");
//				int a = (int)lua["a"];
//				lua.doString ("luanet.free_object(test)");
//				Assert.AreEqual (6, a);
//				//                 
//				//                 lua.doString("TestClass=NLuaTest.Mock.TestClass')");
//				//                 lua.doString("test={}");
//				//
//				//                 lua.doString("luanet.make_object(test,'NLuaTest.Mock.TestClass')");
//				//                              lua.doString ("function test.overridableMethod(test,x,y) return 2*test.base.overridableMethod(test,x,y); end");
//				//                 lua.doString("a=TestClass.callOverridable(test,2,3)");
//				//                 int a = (int)lua.GetNumber("a");
//				//                 lua.doString("luanet.free_object(test)");
//				//                 Assert.AreEqual(10, a);
//				//Debug.Log("interface returned: "+a);
//			}
//		}
//		/*
//        * Tests getting an object's method by its signature
//        * (from object)
//        */

//		public void GetMethodBySignatureFromObj ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("setMethod=luanet.get_method_bysig(test,'setVal','System.String')");
//				lua.doString ("setMethod('test')");
//				TestClass test = (TestClass)lua ["test"];
//				Assert.AreEqual ("test", test.getStrVal ());
//				//Debug.Log("interface returned: "+test.getStrVal());
//			}
//		}

//		/*
//        * Tests getting an object's method by its signature
//        * (from type)
//        */
//		public void GetMethodBySignatureFromType ()
//		{
//				lua.doString ("test=TestClass()");
//				lua.doString ("setMethod=luanet.get_method_bysig(TestClass,'setVal','System.String')");
//				lua.doString ("setMethod(test,'test')");
//				TestClass test = (TestClass)lua ["test"];
//				Assert.AreEqual ("test", test.getStrVal ());
//				//Debug.Log("interface returned: "+test.getStrVal());
//		}
//		/*
//        * Tests getting a type's method by its signature
//        */

//		public void GetStaticMethodBySignature ()
//		{
//				lua.doString ("make_method=luanet.get_method_bysig(TestClass,'makeFromString','System.String')");
//				lua.doString ("test=make_method('test')");
//				TestClass test = (TestClass)lua ["test"];
//				Assert.AreEqual ("test", test.getStrVal ());
//				//Debug.Log("interface returned: "+test.getStrVal());
//		}

//		/*
//        * Tests getting an object's constructor by its signature
//        */
//		public void GetConstructorBySignature ()
//		{		
//				lua.doString ("test_cons=luanet.get_constructor_bysig(TestClass,'System.String')");
//				lua.doString ("test=test_cons('test')");
//				TestClass test = (TestClass)lua ["test"];
//				Assert.AreEqual ("test", test.getStrVal ());
//				//Debug.Log("interface returned: "+test.getStrVal());
//			}
//		}
//		

		public void TestVarargs()
		{
			lua.doString ("test=TestClass()");
			lua.doString ("test:Print('this will pass')");
			lua.doString ("test:Print('this will ','fail')");
		}

		// public void TestCtype ()
		// {
		// 	
		// 	lua.doString ("import'System'");
		// 	var x  = lua.doString ("return luanet.ctype(String)");
		// 	Assert.AreEqual (x, typeof(String), "#1 String ctype test");
		// }
		

		public void TestPrintChars ()
		{
			lua.doString (@"print(""waüäq?=()[&]ß"")");
			Assert.IsTrue (true);
		}

		public void TestUnicodeChars ()
		{
			lua.doString ("UnicodeClass = NLuaTest.Mock.UnicodeClass");
			lua.doString ("res = UnicodeClass.UnicodeString");
			string res = (string)lua ["res"];
			
			Assert.AreEqual (UnicodeClass.UnicodeString, res);
		}

		// public void TestCoroutine ()
		// {
		// 	lua.doString (
		// 		"func = NLuaTest.Mock.TestClass2.func;" +
		// 		"function yielder() " +
		// 			"a=1;" +
		// 			"coroutine.yield();" +
		// 			"func(3,2);" +
		// 			"coroutine.yield();" + // This line triggers System.NullReferenceException
		// 			"a=2;" +
		// 			"coroutine.yield();" +
		// 		"end;" +
		// 		"co_routine = coroutine.create(yielder);" +
		// 		"while coroutine.resume(co_routine) do end;");
		// 	//Debug.Log("a="+num);
		// 	Assert.AreEqual (lua["a"], 2d);
		// }

//		public void TestDebugHook ()
//		{
//			int [] lines = { 1, 2, 1, 3 };
//			int line = 0;
//				lua.DebugHook += (sender,args) => {
//					Assert.AreEqual (args.LuaDebug.currentline,lines [line]);
//					line ++;
//				};
//				lua.SetDebugHook (NLua.Event.EventMasks.LUA_MASKLINE, 0);
//				
//				lua.doString (@"function testing_hooks() return 10 end
//							val = testing_hooks() 
//							val = val + 1");
//		}
//		

//		public void TestKeyWithDots ()
//		{			
//			lua.doString (@"g_dot = {} 
//						 g_dot['key.with.dot'] = 42");
//			
//			Assert.AreEqual (42, (int)(double)lua ["g_dot.key\\.with\\.dot"]);
//		}
		
//		public void TestOperatorAdd ()
//		{
//			var a = new System.Numerics.Complex (10, 0);
//			var b = new System.Numerics.Complex (0, 3);
//			var x = a + b;
//			
//			lua ["a"] = a;
//			lua ["b"] = b;
//			var res = lua.doString (@"return a + b");
//			Assert.AreEqual (x, res);
//		}
//
//		public void TestOperatorMinus ()
//		{	
//			var a = new System.Numerics.Complex (10, 0);
//			var b = new System.Numerics.Complex (0, 3);
//			var x = a - b;
//			
//			lua ["a"] = a;
//			lua ["b"] = b;
//			var res = lua.doString (@"return a - b") ;
//			Assert.AreEqual (x, res);
//		}
//		
//		public void TestOperatorMultiply ()
//		{
//			var a = new System.Numerics.Complex (10, 0);
//			var b = new System.Numerics.Complex (0, 3);
//			var x = a * b;
//			
//			lua ["a"] = a;
//			lua ["b"] = b;
//			var res = lua.doString (@"return a * b") ;
//			Assert.AreEqual (x, res);
//		}
//		
//		public void TestOperatorEqual ()
//		{			
//			var a = new System.Numerics.Complex (10, 0);
//			var b = new System.Numerics.Complex (0, 3);
//			var x = a == b;
//			
//			lua ["a"] = a;
//			lua ["b"] = b;
//			var res = lua.doString (@"return a == b");
//			Assert.AreEqual (x, res);
//		}
//		
//
//		public void TestOperatorNotEqual ()
//		{
//			var a = new System.Numerics.Complex (10, 0);
//			var b = new System.Numerics.Complex (0, 3);
//			var x = a != b;
//			
//			lua ["a"] = a;
//			lua ["b"] = b;
//			var res = lua.doString (@"return a ~= b") ;
//			Assert.AreEqual (x, res);
//		}

		// public void TestUnaryMinus ()
		// {	
		// 	
		// 	lua.doString (@" import ('System.Numerics')
		// 				  c = Complex (10, 5) 
		// 				  c = -c ");
		// 	
		// 	var expected = new System.Numerics.Complex (-10, -5);
		// 	
		// 	var res = lua ["c"];
		// 	Assert.AreEqual (expected, res);
		// }
		// #endif

		public void TestCaseFields ()
		{			
			lua.doString (@"
						  x = NLuaTest.Mock.TestCaseName()
						  name  = x.name;
						  name2 = x.Name;
						  Name = x.Name;
						  Name2 = x.name");
			
			Assert.AreEqual ("name", lua ["name"]);
			Assert.AreEqual ("**name**", lua ["name2"]);
			Assert.AreEqual ("**name**", lua ["Name"]);
			Assert.AreEqual ("name", lua ["Name2"]);
		}
		

		public void TestStaticOperators ()
		{	
			lua.doString (@"
						  v = NLuaTest.Mock.Vector()
						  v.x = 10
						  v.y = 3
						  v = v*2 ");
			
			var v = (Vector)lua ["v"];
			
			Assert.AreEqual (20d, v.x, "#1");
			Assert.AreEqual (6d, v.y, "#2");
			
			// lua.doString (@" x = 2 * v");
			// var x = (Vector)lua ["x"];
			
			// Assert.AreEqual (40d, x.x, "#3");
			// Assert.AreEqual (12d, x.y, "#4");
		}	

		// public void TestExtensionMethods ()
		// {		
		// 	lua.doString (@"
		// 				  v = NLuaTest.Mock.Vector()
		// 				  v.x = 10
		// 				  v.y = 3
		// 				  v = v*2 ");
		// 	
		// 	var v = (Vector)lua ["v"];
		// 	
		// 	double len = v.Length ();
		// 	lua.doString (" v:Length() ");
		// 	lua.doString (@" len2 = v:Length()");
		// 	double len2 = (double)lua ["len2"];
		// 	Assert.AreEqual (len, len2, "#1");
		// }

		 public void TestOverloadedMethods ()
		 {
	 		var obj = new TestClassWithOverloadedMethod ();
	 		lua ["obj"] = obj;
	 		lua.doString (@" 
	 						obj:Func (10)
	 						obj:Func ('10')
	 						obj:Func (10)
	 						obj:Func ('10')
	 						obj:Func (10)
	 						");
	 		Assert.AreEqual (3, obj.CallsToIntFunc,"#integer");
	 		Assert.AreEqual (2, obj.CallsToStringFunc, "#string");
		 }

		// public void TestGetStack ()
		// {
		// 	m_lua = lua;
		// 	lua.doString (@" 
		// 		import ('NLuaTest')
		// 		function f1 ()
		// 			 f2 ()
		// 		 end
		// 		 
		// 		function f2()
		// 			f3()
		// 		end
		// 
		// 		function f3()
		// 			LuaTests.func()
		// 		end
		// 		
		// 		f1 ()
		// 	");
		// 	m_lua = null;
		// }
//		
//		public static void func()
//		{
//			#if USE_KOPILUA
//			string expected = "[0] [C]:-1 -- func [field]\n[1] [string \"chunk\"]:12 -- f3 [global]\n[2] [string \"chunk\"]:8 -- f2 [global]\n[3] [string \"chunk\"]:4 -- f1 [global]\n[4] [string \"chunk\"]:15 -- <unknow> []\n";
//			KopiLua.LuaDebug info = new KopiLua.LuaDebug ();
//			#else
//			//string expected = "[0] func:-1 -- <unknown> [func]\n[1] f3:12 -- <unknown> [f3]\n[2] f2:8 -- <unknown> [f2]\n[3] f1:4 -- <unknown> [f1]\n[4] :15 --  []\n";
//			KeraLua.LuaDebug info = new KeraLua.LuaDebug ();
//			#endif
//			
//			int level = 0;
//			StringBuilder sb = new StringBuilder ();
//			while (m_lua.GetStack (level,ref info) != 0) {
//				m_lua.GetInfo ("nSl", ref info);
//				string name = "<unknow>";
//				if (info.name != null && !string.IsNullOrEmpty(info.name.ToString()))
//					name = info.name.ToString ();
//				
//				sb.AppendFormat ("[{0}] {1}:{2} -- {3} [{4}]\n",
//				                 level, info.shortsrc, info.currentline,
//				                 name, info.namewhat);
//				++level;
//			}
//			string x = sb.ToString ();
//			Assert.True (!string.IsNullOrEmpty(x));
//		}
//		

		// public void TestCallImplicitBaseMethod ()
		// {
		// 	lua.doString ("testClass3 = NLuaTest.Mock.testClass3");
		// 	lua.doString ("res = testClass3.read() ");
		// 	string res = (string)lua ["res"];
		// 	Assert.AreEqual (testClass3.read (), res);
		// }
		

//		public void TestPushLuaFunctionWhenReadingDelegateProperty ()
//		{
//			bool called = false;
//			var _model = new DefaultElementModel ();
//			_model.DrawMe = (x) => {
//				called = true;
//			};
//			
//			lua ["model"] = _model;
//			lua.doString (@" model.DrawMe (0) ");
//			
//			Assert.True (called);
//		}
		

//		 public void TestCallDelegateWithParameters ()
//		 {
//		 	string sval = "";
//		 	int nval = 0;
//		 	
//			Action<int, string> c = (n, s) => { sval = s; nval = n; };
//		 	lua ["d"] = c;
//			lua.doString (" d (10, 'string') ");
//		 	
//		 	Assert.AreEqual ("string", sval, "#1");
//		 	Assert.AreEqual (10 , nval, "#2");
//		 }
		

//		public void TestCallSimpleDelegate ()
//		{
//			bool called = false;
//
//			Action c = () => { called = true; };
//			lua ["d"] = c;
//			lua.doString (" d () ");
//			
//			Assert.True (called);
//		}

//		public void TestCallDelegateWithWrongParametersShouldFail ()
//		{
//			bool fail = false;
//			Action c = () => { fail = false; };
//			lua ["d"] = c;
//			try {
//				lua.doString (" d (10) ");
//			}
//			catch (Exception ) {
//				fail = true;
//			}
//			
//			Assert.True (fail);
//		}
		

		public void TestOverloadedMethodCallOnBase ()
		{
			lua.doString ("parameter = NLuaTest.Mock.parameter");
			lua.doString (@"
				testClass3 = NLuaTest.Mock.testClass3
				p=parameter()
				-- r1 = testClass3.read(p)     -- is not working. it is also not working if the method in base class has two parameters instead of one
				r2 = testClass3.read(1)     -- is working				
			");
			// string r1 = (string) lua ["r1"];
			string r2 = (string) lua ["r2"];
			// Assert.AreEqual ("parameter-field1", r1, "#1");
			Assert.AreEqual ("int-test" , r2, "#2");
		}	

		public void TestCallMethodWithParams2 ()
		{
			lua.doString (@"					
				r = TestClass.MethodWithParams(2)			
			");
			Assert.AreEqual (0d, lua["r"], "#1");
		}

		public void TestPassType()
		{
			TestClass o = new TestClass ();
			Type t = o.GetType();
			Assert.True (t == typeof(NLuaTest.Mock.TestClass));
			Assert.True (t != typeof(Type));
			Assert.True (t.GetType() == typeof(Type).GetType());

			lua.doString (@"
				TestClass=NLuaTest.Mock.TestClass
				t = TestClass()
				r1 = t:TestType(t:GetType())
				r2 = t:TestType(TestClass)
			");
			Assert.True ((bool)lua ["r1"]);
			Assert.True ((bool)lua ["r2"]);
		}

//		static Lua m_lua;
		
	}
}
