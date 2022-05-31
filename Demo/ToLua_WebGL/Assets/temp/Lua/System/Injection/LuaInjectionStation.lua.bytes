--[[
--- File:LuaInjectionStation.lua
--- Created by Jonson
--- DateTime: 2018/1/2 10:24
]]--

local pcall = pcall
local pairs = pairs
local error = error
local rawset = rawset
local rawget = rawget
local string = string
local tolua_tag = tolua_tag
local getmetatable = getmetatable
local CSLuaInjectStation
local bridgeInfo = require "System.Injection.InjectionBridgeInfo"

local function Check(csModule)
	local existmt = getmetatable(csModule)
	if rawget(existmt, tolua_tag) ~= 1 then
		error("Can't Inject")
	end

	return existmt
end

local function CacheCSLuaInjectStation()
	if CSLuaInjectStation == nil then
		CSLuaInjectStation = LuaInterface.LuaInjectionStation
	end
end

local function UpdateFunctionReference(metatable, injectInfo)
	local oldIndexMetamethod = metatable.__index
	local newMethodGroup = {}
	for funcName, infoPipeline in pairs(injectInfo) do
		local injectFunction, injectFlag = infoPipeline()
		if injectFlag == LuaInterface.InjectType.Replace
				or injectFlag == LuaInterface.InjectType.ReplaceWithPostInvokeBase
				or injectFlag == LuaInterface.InjectType.ReplaceWithPreInvokeBase
		then
			rawset(newMethodGroup, funcName, injectFunction)
		end
	end

	metatable.__index = function(t, k)
		--Ignore Overload Function
		local injectFunc = rawget(newMethodGroup, k)
		if injectFunc ~= nil then
			return injectFunc
		end

		local status, result = pcall(oldIndexMetamethod, t, k)
		if status then
			return result
		else
			error(result)
			return nil
		end
	end
end

function InjectByModule(csModule, injectInfo)
	local mt = Check(csModule)
	local moduleName = mt[".name"]

	InjectByName(moduleName, injectInfo)
	UpdateFunctionReference(mt, injectInfo)
end

--Won't Update Function Reference In Lua Env
function InjectByName(moduleName, injectInfo)
	CacheCSLuaInjectStation()
	local moduleBridgeInfo = rawget(bridgeInfo, moduleName)
	if moduleBridgeInfo == nil then
		error(string.format("Module %s Can't Inject", moduleName))
	end

	for funcName, infoPipeline in pairs(injectInfo) do
		local injectFunction, injectFlag = infoPipeline()
		local injectIndex = rawget(moduleBridgeInfo, funcName)
		if injectIndex == nil then
			error(string.format("Function %s Doesn't Exist In Module %s", funcName, moduleName))
		end

		CSLuaInjectStation.CacheInjectFunction(injectIndex, injectFlag:ToInt(), injectFunction)
	end
end

require "System.Injection.LuaInjectionBus"