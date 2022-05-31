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

//note: this should be cleaned up and replaced with moq mocks where possible

namespace NLuaTest.Mock
{
	using System;
	using System.Threading;
	using System.Diagnostics;
	using System.Reflection;
	using SLua;
	using Debug = UnityEngine.Debug;
	
	public class parameter
	{
		public string field1 = "parameter-field1";
	}
	
	public class UnicodeClass{
		public static readonly char UnicodeChar = '\uE007';
		public static string UnicodeString
		{
			get
			{
				return Convert.ToString (UnicodeChar);
			}
		}
	}
	
	#if MONOTOUCH
	[Preserve (AllMembers = true)]
	#endif
	public class master
	{
		public static string read()
		{
			return "test-master";
		}

		public static string read( parameter test )
		{
			return test.field1;
		}
	}

	#if MONOTOUCH
	[Preserve (AllMembers = true)]
	#endif
	public class testClass3 : master 
	{
		public String strData;
		public int intData;
		public static string read2()
		{
			return "test";
		}

		public static string read( int test )
		{
			return "int-test";
		}
	}

	#if MONOTOUCH
	[Preserve (AllMembers = true)]
	#endif
	public class TestCaseName {
		public string name = "name";
		public string Name {
			get {
				return "**" + name + "**";
			}
		}
	}



	#if MONOTOUCH
		[Preserve (AllMembers = true)]
	#endif
	public class Vector
	{
		public double x;
		public double y;
		public static Vector operator * (float k, Vector v)
		{
			var r = new Vector ();
			r.x = v.x * k;
			r.y = v.y * k;
			return r;
		}

		public static Vector operator * (Vector v, float k)
		{
			var r = new Vector ();
			r.x = v.x * k;
			r.y = v.y * k;
			return r;
		}

		public void Func ()
		{
			Debug.Log ("Func");
		}
	}

	public static class VectorExtension
	{
		public static double Length (this Vector v)
		{
			return v.x * v.x + v.y * v.y;
		}
	}
	
	public class DefaultElementModel
	{  
		public Action<double> DrawMe{ get; set; }  
	}  
	
	/*
     * Delegates used for testing Lua function -> delegate translation
     */
	public delegate int TestDelegate1 (int a, int b);
	
	public delegate int TestDelegate2 (int a, out int b);
	
	public delegate void TestDelegate3 (int a, ref int b);
	
	public delegate TestClass TestDelegate4 (int a, int b);
	
	public delegate int TestDelegate5 (TestClass a, TestClass b);
	
	public delegate int TestDelegate6 (int a, out TestClass b);
	
	public delegate void TestDelegate7 (int a, ref TestClass b);
	
	/* Delegate Lua-handlers */
	
//	class LuaTestDelegate1Handler : NLua.Method.LuaDelegate
//	{
//		int CallFunction (int a, int b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a, b };
//			int [] outArgs = new int [] { };
//			
//			object ret = base.CallFunction (args, inArgs, outArgs);
//			
//			return (int)ret;
//		}
//	}
//	
//	class LuaTestDelegate2Handler : NLua.Method.LuaDelegate
//	{
//		int CallFunction (int a, out int b)
//		{
//			object [] args = new object [] { a, 0 };
//			object [] inArgs = new object [] { a };
//			int [] outArgs = new int [] { 1 };
//			
//			object ret = base.CallFunction (args, inArgs, outArgs);
//			
//			b = (int)args [1];
//			return (int)ret;
//		}
//	}
//	
//	class LuaTestDelegate3Handler : NLua.Method.LuaDelegate
//	{
//		void CallFunction (int a, ref int b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a, b };
//			int [] outArgs = new int [] { 1 };
//			
//			base.CallFunction (args, inArgs, outArgs);
//			
//			b = (int)args [1];
//		}
//	}
//	
//	class LuaTestDelegate4Handler : NLua.Method.LuaDelegate
//	{
//		TestClass CallFunction (int a, int b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a, b };
//			int [] outArgs = new int [] { };
//			
//			object ret = base.CallFunction (args, inArgs, outArgs);
//			
//			return (TestClass)ret;
//		}
//	}
//	
//	class LuaTestDelegate5Handler : NLua.Method.LuaDelegate
//	{	
//		int CallFunction (TestClass a, TestClass b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a, b };
//			int [] outArgs = new int [] {  };
//			
//			object ret = base.CallFunction (args, inArgs, outArgs);
//			
//			return (int)ret;
//		}
//	}
//	
//	class LuaTestDelegate6Handler : NLua.Method.LuaDelegate
//	{
//		int CallFunction (int a, ref TestClass b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a };
//			int [] outArgs = new int [] { 1 };
//			
//			object ret = base.CallFunction (args, inArgs, outArgs);
//			
//			b = (TestClass)args [1];
//			return (int)ret;
//		}
//	}
//	
//	class LuaTestDelegate7Handler : NLua.Method.LuaDelegate
//	{
//		void CallFunction (int a, ref TestClass b)
//		{
//			object [] args = new object [] { a, b };
//			object [] inArgs = new object [] { a , b};
//			int [] outArgs = new int [] { 1 };
//			
//			base.CallFunction (args, inArgs, outArgs);
//			
//			b = (TestClass)args [1];
//		}
//	}
	
	
	/*
     * Interface used for testing Lua table -> interface translation
     */
	public interface ITest
	{
		int intProp {
			get;
			set;
		}
		
		TestClass refProp {
			get;
			set;
		}
		
		int test1 (int a, int b);
		
		int test2 (int a, out int b);
		
		void test3 (int a, ref int b);
		
		TestClass test4 (int a, int b);
		
		int test5 (TestClass a, TestClass b);
		
		int test6 (int a, out TestClass b);
		
		void test7 (int a, ref TestClass b);
	}
	
	public interface IFoo1
	{
		int foo ();
	}
	
	public interface IFoo2
	{
		int foo ();
	}
	
	class MyClass
	{
		public int Func1 ()
		{
			return 1;
		}
	}
	
	/// <summary>
	/// Use to test threading
	/// </summary>
	class DoWorkClass
	{
		
		public void DoWork ()
		{
			
			//simulate work by sleeping
			//Debug.Log("Started to do work on thread: " + Thread.CurrentThread.ManagedThreadId);
			Thread.Sleep (new Random ().Next (0, 1000));
			//Debug.Log("Finished work on thread: " + Thread.CurrentThread.ManagedThreadId);
		}
	}
	
	/// <summary>
	/// test structure passing
	/// </summary>
	public struct TestStruct
	{
		public TestStruct(float val)
		{
			v = val;
		}
		
		public float v;
		
		public float val
		{
			get { return v; }
			set { v = value; }
		}
	}
	
	/// <summary>
	/// test enum
	/// </summary>
	public enum TestEnum
	{
		ValueA,
		ValueB
	}
	
	/// <summary>
	/// Generic class with generic and non-generic methods
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TestClassGeneric<T>
	{
		private object _PassedValue;
		private bool _RegularMethodSuccess;
		
		public bool RegularMethodSuccess {
			get { return _RegularMethodSuccess; }
		}
		
		private bool _GenericMethodSuccess;
		
		public bool GenericMethodSuccess {
			get { return _GenericMethodSuccess; }
		}
		
		public void GenericMethod (T value)
		{
			_PassedValue = value;
			_GenericMethodSuccess = true;
		}
		
		public void RegularMethod ()
		{
			_RegularMethodSuccess = true;
		}
		
		/// <summary>
		/// Returns true if the generic method was successfully passed a matching value
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Validate (T value)
		{
			return value.Equals (_PassedValue);
		}
	}
	
	/// <summary>
	/// Normal class containing a generic method
	/// </summary>
	public class TestClassWithGenericMethod
	{
		private object _PassedValue;
		
		public object PassedValue {
			get { return _PassedValue; }
		}
		
		private bool _GenericMethodSuccess;
		
		public bool GenericMethodSuccess {
			get { return _GenericMethodSuccess; }
		}
		
		public void GenericMethod<T> (T value)
		{
			_PassedValue = value;
			_GenericMethodSuccess = true;
		}
		
		internal bool Validate<T> (T value)
		{
			return value.Equals (_PassedValue);
		}
	}
	
	public class TestClass2
	{
		public static int func (int x, int y)
		{
			return x + y;
		}
		
		public int funcInstance (int x, int y)
		{
			return x + y;
		}
	}
	
	/*
	 * Sample class used in several test cases to check if
	 * Lua scripts are accessing objects correctly
	 */
	public class TestClass : IFoo1, IFoo2
	{
		public int val;
		private string strVal;
		
		public TestClass ()
		{
			val = 0;
		}
		
		public TestClass (int val)
		{
			this.val = val;
		}
		
		public TestClass (string val)
		{
			this.strVal = val;
		}
		
		public static TestClass makeFromString (String str)
		{
			return new TestClass (str);
		}
		
//		bool? nb2 = null;
//		
//		public bool? NullableBool {
//			get { return nb2; }
//			set { nb2 = value; }
//		}
		
		TestStruct s = new TestStruct ();
		
		public TestStruct Struct {
			get { return s; }
			set { s = (TestStruct)value; }
		}
		
		public int testval {
			get {
				return this.val;
			}
			set {
				this.val = value;
			}
		}
		
		public string teststrval {
			get {
				return this.strVal;
			}
			set {
				this.strVal = value;
			}
		}
		
		public int this [int index] {
			get { return 1; }
			set { }
		}
		
		public int this [string index] {
			get { return 1; }
			set { }
		}
		
//		public TimeSpan? NullableMethod (TimeSpan? input)
//		{
//			return input;
//		}
//		
//		public int? NullableMethod2 (int? input)
//		{
//			return input;
//		}
		
		public object TestLuaFunction (LuaFunction func)
		{
			if (func != null) {
				return func.call (1, 2);
			}
			return null;
		}
		
		public int sum (int x, int y)
		{
			return x + y;
		}
		
		public void setVal (int newVal)
		{
			val = newVal;
		}
		
		public void setVal (string newVal)
		{
			strVal = newVal;
		}
		
		public int getVal ()
		{
			return val;
		}
		
		public string getStrVal ()
		{
			return strVal;
		}
		
		public int outVal (out int val)
		{
			val = 5;
			return 3;
		}
		
		public int outVal (out int val, int val2)
		{
			val = 5;
			return val2;
		}
		
		public int outVal (int val, ref int val2)
		{
			val2 = val + val2;
			return val;
		}
		
		public int outValMutiple (int arg, out string arg2, out string arg3)
		{
			arg2 = Guid.NewGuid ().ToString ();
			arg3 = Guid.NewGuid ().ToString ();
			
			return arg;
		}
		
		public int callDelegate1 (TestDelegate1 del)
		{
			return del (2, 3);
		}
		
		public int callDelegate2 (TestDelegate2 del)
		{
			int a = 3;
			int b = del (2, out a);
			return a + b;
		}
		
		public int callDelegate3 (TestDelegate3 del)
		{
			int a = 3;
			del (2, ref a);
			//Debug.Log(a);
			return a;
		}
		
		public int callDelegate4 (TestDelegate4 del)
		{
			return del (2, 3).testval;
		}
		
		public int callDelegate5 (TestDelegate5 del)
		{
			return del (new TestClass (2), new TestClass (3));
		}
		
		public int callDelegate6 (TestDelegate6 del)
		{
			TestClass test = new TestClass ();
			int a = del (2, out test);
			return a + test.testval;
		}
		
		public int callDelegate7 (TestDelegate7 del)
		{
			TestClass test = new TestClass (3);
			del (2, ref test);
			return test.testval;
		}
		
		public int callInterface1 (ITest itest)
		{
			return itest.test1 (2, 3);
		}
		
		public int callInterface2 (ITest itest)
		{
			int a = 3;
			int b = itest.test2 (2, out a);
			return a + b;
		}
		
		public int callInterface3 (ITest itest)
		{
			int a = 3;
			itest.test3 (2, ref a);
			//Debug.Log(a);
			return a;
		}
		
		public int callInterface4 (ITest itest)
		{
			return itest.test4 (2, 3).testval;
		}
		
		public int callInterface5 (ITest itest)
		{
			return itest.test5 (new TestClass (2), new TestClass (3));
		}
		
		public int callInterface6 (ITest itest)
		{
			TestClass test = new TestClass ();
			int a = itest.test6 (2, out test);
			return a + test.testval;
		}
		
		public int callInterface7 (ITest itest)
		{
			TestClass test = new TestClass (3);
			itest.test7 (2, ref test);
			return test.testval;
		}
		
		public int callInterface8 (ITest itest)
		{
			itest.intProp = 3;
			return itest.intProp;
		}
		
		public int callInterface9 (ITest itest)
		{
			itest.refProp = new TestClass (3);
			return itest.refProp.testval;
		}
		
		public void exceptionMethod ()
		{
			throw new Exception ("exception test");
		}
		
		public virtual int overridableMethod (int x, int y)
		{
			return x + y;
		}
		
		public static int callOverridable (TestClass test, int x, int y)
		{
			return test.overridableMethod (x, y);
		}
		
		int IFoo1.foo ()
		{
			return 3;
		}
		
		public int foo ()
		{
			return 5;
		}
		
		private void _PrivateMethod ()
		{
			Debug.Log ("Private method called");
		}
		
		public int MethodOverload ()
		{
			Debug.Log ("Method with no params");
			return 1;
		}
		
		public int MethodOverload (TestClass testClass)
		{
			Debug.Log ("Method with testclass param");
			return 2;
		}

		public int MethodOverload (Type type)
		{
			Debug.Log ("Method with testclass param");
			return 3;
		}
		
		public int MethodOverload (int i, int j, int k)
		{
			Debug.Log ("Overload without out param: " + i + ", " + j + ", " + k);
			return 4;
		}
		
		public int MethodOverload (int i, int j, out int k)
		{
			k = 5;
			Debug.Log ("Overload with out param" + i + ", " + j);
			return 5;
		}
		
		public void Print(object format,params object[] args)
		{
			//just for test,this is not printf implements
			var output = format.ToString() + "\t";
			foreach(var msg in args)
			{
				output += msg.ToString() + "\t";
			}
			Debug.Log(output);
		}
		
		static public int MethodWithParams (int a, params int[] others) {
			Debug.Log (a);
			int i = 0;
			foreach (int val in others) {
				Debug.Log (val);
				i++;
			}
			return i;
		}

		public bool TestType(Type t)
		{
			return this.GetType() == t;
		}
	}
	
	public class TestClassWithOverloadedMethod
	{
		public int CallsToStringFunc {get;set;}
		public int CallsToIntFunc {get;set;}
		public void Func (string param)
		{
			CallsToStringFunc++;
		}
		
		public void Func (int param)
		{
			CallsToIntFunc++;
		}
		
	}
}
