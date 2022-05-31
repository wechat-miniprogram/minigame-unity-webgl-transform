local somemodule = require 'module.some'
import "UnityEngine"
if not UnityEngine.GameObject then
	error("Click Make/All to generate lua wrap file")
end


MyGameObject=Slua.Class(GameObject,
	nil,
	{
		AddComponent=function(self,t)
			print "overloaded AddComponent"
			self.__base:AddComponent(t)
		end,
	}	
)

function testArray()
	local x=GameObject("TestArray")
	local c=x:AddComponent(UnityEngine.RectTransform)
	local a=Slua.MakeArray("UnityEngine.Vector3",{Vector3(1,0,0),Vector3(1,0,0),Vector3(1,0,0),Vector3(1,0,0)})
	c:GetLocalCorners(a)
	for v in Slua.iter(a) do
		print(v)
	end
	
	local a=Slua.MakeArray("System.Int16",{1,2,3,4})
	for v in Slua.iter(a) do
		print(v)
	end
	
	HelloWorld.int16Array(a)
	HelloWorld.int16Array({1,2,3,4})
	HelloWorld.byteArrayTest()

	local rtarr = {c}
	HelloWorld.transformArray(rtarr)
end

function testNullable()
	HelloWorld.nullf(1)
	HelloWorld.nullf()
end

local function click(...)
	print("fuck")
end

function main()
	-- Cache unpack function.
	local unpack = (unpack and unpack) or table.unpack

	-- test split of System.String
	local x=String("a,b,c,d/e/f/g")
	print(unpack(x:Split(",/",0).Table))
	print(unpack(x:Split({",","/"},0).Table))
	
	testArray()
	testNullable()
	

	local t=dofile('module/some')
	assert(type(t)=='table')
	assert(t.add(1,2)==3)

	local fu=loadfile('module/some')
	assert(type(fu)=='function')

	if jit then
		print("using luajit ",jit.version,jit.arch)
		local ffi=require 'ffi'
		print(ffi)
	else
		print("using lua")
	end

	-- test override function
	HelloWorld.AFuncByDouble(1);

	-- test negetive value
	assert(HelloWorld.getNegInt()==-1)

	-- test custom component
	local x=UnityEngine.GameObject("OoOo")
	x:AddComponent(SLuaTest)
	local c=x:GetComponent(SLuaTest)
	print("test monobehaviour",c, c.transform, c:GetType().Name)
	assert(c.gameObject.name=="OoOo")
	local c=x:GetComponent(UnityEngine.BoxCollider)
	assert(c==null)

	local ll=XXList() -- it's List<int>
	ll:Add(1)
	print(ll.Count)

	local x=MyGameObject("MyGameObject")
	x:AddComponent(SphereCollider)
	HelloWorld.ofunc(x)

	-- test value type
	local x=Vector3(3,3,3)
	x:Normalize()
	print(x.x,x.y,x.z)
	x=-x
	print(x.x,x.y,x.z)

	local c=Color(1,1,1,1)
	print("color",c.r)
	local fs=foostruct()
	fs.mode=1
	fs.x=11.1
	assert(fs.mode==1)

	-- test module require
	print(somemodule.add(2,3))

	local go = GameObject.Find("Canvas/Button")
	local btn = go:GetComponent("Button")

	local Canvas = GameObject.Find("Canvas")
	-- foreach
	for t in Slua.iter(Canvas.transform) do
		print("foreach transorm",t)
	end
	
	-- bytes return byte[]
	local data = HelloWorld.bytes()
	data[1]=11
	print("data type ",type(data),#data,data.Table[1],data,data[1],data[2])

	-- test bytearray object wity array
	local ba = Slua.ByteArray(data)

	data = Slua.ToString(data)
	print("data type ",type(data),data)


	print('Construct bytearray object',ba)
	print(ba:ReadByte(),ba:ReadByte())
	assert(ba.Length==4)
	assert(ba.Position==2)
	assert(ba:ReadByte()==53)

	-- construct new byte array
	local ba = Slua.ByteArray()
	ba:WriteByte(11)
	ba:WriteByte(22)
	ba:WriteVarInt(1024)
	ba:WriteShort(5656)
	ba:WriteNum(3.1415)
	ba.Position=0
	assert(ba:ReadByte()==11)
	assert(ba:ReadByte()==22)
	assert(ba:ReadVarInt()==1024)
	assert(ba:ReadShort()==5656)
	assert(ba:ReadDouble()==3.1415)


	-- get out parameter
	local ok,hitinfo = Physics.Raycast(Vector3(0,0,0),Vector3(0,0,1),Slua.out)
	print("Physics Hitinfo",ok,hitinfo)
	
	local clickCount=0
	btn.onClick:AddListener(function()
		local go = GameObject.Find("Canvas/Text")
		local label = go:GetComponent("Text")
		clickCount=clickCount+1
		label.text="hello world " ..tostring(clickCount)

	end)

	btn.onClick:AddListener(click)
	

	local go = GameObject.Find("Canvas/Panel2"):GetComponent("ScrollRect")
	local go2 = GameObject.Find("Canvas/Panel2"):GetComponent("ScrollRect")
	assert(go==go2)

	go.onValueChanged:AddListener(function(v)
		print("scroll value changed",v.x,v.y)
	end)

	local cube = GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube)
	local cube2 = GameObject.CreatePrimitive(UnityEngine.PrimitiveType.Cube)
	local mat = cube:GetComponent(Renderer).material
	mat.color=Color.red

	cube.name="Script cube"
	cube2.name="Script cube2"

	cube.transform:SetParent(cube2.transform)

	local pos = Vector3(10,10,10)+Vector3(1,1,1)
	cube.transform.position = pos
	cube.transform.localScale = Vector3(10,10,10)
	print("cube==cube2",cube==cube2)
	assert(cube.transform==cube.transform)

	LuaTimer.Add(0,20,function(id)
		cube.transform.localScale = Vector3(10,10,10)*(0.1+math.sin(Time.time))
		cube2.transform.position = Vector3(math.sin(Time.time)*5,0,0)
		cube.transform.localRotation = Quaternion.Euler(0,0,math.sin(Time.time)*90)
		return true
	end)

	-- test timer
	for i=1,20 do
		LuaTimer.Add(0,i*1000,function()
			print("timer callback",i*1000)
			return true
		end)
	end
	
	print(UnityEngine.PrimitiveType.Cube,type(UnityEngine.PrimitiveType.Cube))


	print("LogCallback occured",n)

	local c=coroutine.create(function()

		print "coroutine start"

		Yield(WaitForSeconds(2))
		print "coroutine WaitForSeconds 2"

		local www = WWW("http://www.baidu.com")
		Yield(www)
		print(#Slua.ToString(www.bytes))

		local y = HelloWorld()
		local y = y:y()
		Yield(y)
		print("Yield ok")
	end)
	coroutine.resume(c)

	-- test lua table
	HelloWorld.setv({name="yes",value=12,[-2]="siney",[0]="no"})
	local t=HelloWorld.getv()
	for k,v in pairs(t) do
		print("table value",k,v)
	end

	-- test overload func
	HelloWorld.ofunc(GameObject)
	HelloWorld.ofunc(cube)

	-- test variant number args
	HelloWorld.func6("aa",1,2)
	HelloWorld.func6("aa",1,2,3,"bb")
	HelloWorld.func6("aa",1,2,3,"bb",true,false)
	HelloWorld.func6("aa")
	local ss=String("bb")
	HelloWorld.func6(ss,1,2) -- func6 accpet system.string as 1st parameter, you can pass "xx" or String("xx")
	assert(ss~="bb") -- bb is luastring, ss is System.String
	
	-- test luafunction
	local h=HelloWorld()
	h:func7(abc)
	h.cc = Color32(255,0,0,255)
	print("Hellor world color",h.cc)

    HelloWorld.setObjs({{1,2},{3,4},{5,6}})
end

function abc()
	print("call func7 callback")
end

function foo(a,b,c)
	return a,b,c,"slua"
end

function str()
	return "slua"
end

return 1,2,3
