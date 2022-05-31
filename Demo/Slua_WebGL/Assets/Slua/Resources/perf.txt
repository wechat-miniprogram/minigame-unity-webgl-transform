
if not UnityEngine.GameObject then
	error("Click Make/All to generate lua wrap file")
end

local Vector3 = UnityEngine.Vector3
local GameObject = UnityEngine.GameObject
local Profiler = UnityEngine.Profiler
local Time = UnityEngine.Time
local Matrix4x4 = UnityEngine.Matrix4x4
local Texture2D = UnityEngine.Texture2D
local Quaternion = UnityEngine.Quaternion
local SkinnedMeshRenderer = UnityEngine.SkinnedMeshRenderer

function main()
	print(jit and "jit on" or "jit off, pls run test with luajit")
end

local cube = GameObject("Script cube")


function test1()
	local transform = cube.transform
	local start = os.clock()
	for i=1,200000 do
        transform.position=transform.position
	end
	print("test1/lua " .. (os.clock() - start));
end

function test2()
	local transform=cube.transform
	local start = os.clock()
	for i=1,200000 do
		transform:Rotate(Vector3.up, 90)
	end
	print("test2/lua " .. (os.clock() - start));
end

function test3()
	local start = os.clock()
	for i=1,2000000 do 
		local v = Vector3(i,i,i)
		Vector3.Normalize(v)
	end
	print("test3/lua " .. (os.clock() - start));
end

function test4()
	local t = cube.transform
	local v = Vector3.one
	local start = os.clock()
	for i=1,200000 do
		local v = GameObject()	
	end
	print("test4/lua " .. (os.clock() - start));
end


function test5()
	local v = cube.transform.position
	local start = os.clock()
	for i=1,20000 do
		local v = GameObject()
		v:AddComponent(SkinnedMeshRenderer)
		local c=v:GetComponent(SkinnedMeshRenderer)
		c.castShadows=false
		c.receiveShadows=false
	end
	print("test5/lua " .. (os.clock() - start));
end

function test6()
	local transform=cube.transform
	local start = os.clock()
	for i=1,200000 do
		local t=Quaternion.Euler(100,100,100)
		local q=Quaternion.Slerp(Quaternion.identity,t,0.5)
	end
	print("test6/lua jit  " .. (os.clock() - start));
end

function test7()
	local transform=cube.transform
	local Quaternion = (jit and Quaternion.__raw) or Quaternion
	local start = os.clock()
	for i=1,200000 do
		local t=Quaternion.Euler(100,100,100)
		local q=Quaternion.Slerp(Quaternion.identity,t,0.5)
	end
	print("test6/lua non-jit  " .. (os.clock() - start));
end
