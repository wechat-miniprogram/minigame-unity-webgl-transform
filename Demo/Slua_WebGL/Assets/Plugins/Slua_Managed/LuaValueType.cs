// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SLua
{
    using System;
    class LuaValueType : LuaObject
    {
#if !LUA_5_3 && !SLUA_STANDALONE
        static string script = @"
if not UnityEngine or not UnityEngine.Vector2 then
    print('No static code gen yet, ignore `LuaValueType:reg` !!! ')
    return
end
local setmetatable=setmetatable
local getmetatable=getmetatable
local type=type
local clamp=clamp
local acos=math.acos
local sin=math.sin
local cos=math.cos
local sqrt=math.sqrt
local error=error
local min=math.min
local max=math.max
local abs=math.abs
local pow=math.pow
local Time=UnityEngine.Time

local ToAngle=57.29578
local ToRad=0.01745329
local Epsilon=0.00001
local Infinite=1/0
local Sqrt2=0.7071067811865475244008443621048490
local PI=3.14159265358979323846264338327950

local function clamp(v,min,max)
	min = min or 0
	max = max or 1
	return v>max and max or (v<min and min or v)
end

local function  lerpf(a,b,t)
	t=clamp(t,0,1)
	return a+(b-a)*t
end

local function inherite(cls,base)
	for k,v in pairs(getmetatable(base)) do
		if not cls[k] and k:sub(1,2)~='__' and  k:sub(1,1)>='A' and k:sub(1,1)<='Z' then
			cls[k]=v
		end
	end
end

local Matrix3x3={}
local I = {__typename='Matrix3x3'}
local Vector3

do
	function Matrix3x3.SetAt(m,row,col,v)
		m[row*3+col+1]=v
	end

	function Matrix3x3.New()
		local r={1,0,0,0,1,0,0,0,1}
		setmetatable(r,I)
		return r
	end

	function I.__tostring(m)
		return string.format('Matrix3x3(%f,%f,%f,%f,%f,%f,%f,%f,%f)'
			,m[1],m[2],m[3]
			,m[4],m[5],m[6]
			,m[7],m[8],m[9])
	end

	function Matrix3x3.SetAxisAngle(m,axis,rad)
		-- This function contributed by Erich Boleyn (erich@uruk.org) */
		-- This function used from the Mesa OpenGL code (matrix.c)  */
		local s, c
		local vx, vy, vz, xx, yy, zz, xy, yz, zx, xs, ys, zs, one_c

		s = sin (rad)
		c = cos (rad)

		vx = axis[1]
		vy = axis[2]
		vz = axis[3]

		xx = vx * vx
		yy = vy * vy
		zz = vz * vz
		xy = vx * vy
		yz = vy * vz
		zx = vz * vx
		xs = vx * s
		ys = vy * s
		zs = vz * s
		one_c = 1.0 - c
		local Set=Matrix3x3.SetAt
		Set(m,0,0, (one_c * xx) + c )
		Set(m,1,0, (one_c * xy) - zs)
		Set(m,2,0, (one_c * zx) + ys)
		Set(m,0,1, (one_c * xy) + zs)
		Set(m,1,1, (one_c * yy) + c )
		Set(m,2,1, (one_c * yz) - xs)
		Set(m,0,2, (one_c * zx) - ys)
		Set(m,1,2, (one_c * yz) + xs)
		Set(m,2,2, (one_c * zz) + c )
	end

	function Matrix3x3.Mul(m,v)
		local res=Vector3.New(0,0,0)
		res[1] = m[1] * v[1] + m[4] * v[2] + m[7] * v[3]
		res[2] = m[2] * v[1] + m[5] * v[2] + m[8] * v[3]
		res[3] = m[3] * v[1] + m[6] * v[2] + m[9] * v[3]
		return res
	end

	function I:SetIdentity()
		self[1],self[2],self[3]=1,0,0
		self[4],self[5],self[6]=0,1,0
		self[7],self[8],self[9]=0,0,1
	end

	function I:SetOrthoNormal( x,y,z )
		self[1],self[2],self[3]=x[1],y[1],z[1]
		self[4],self[5],self[6]=x[2],y[2],z[2]
		self[7],self[8],self[9]=x[3],y[3],z[3]
	end
end

do
	local Raw=UnityEngine.Vector3
	Vector3={__typename='Vector3',__raw=Raw}
	local T=Vector3
	local I={__typename='Vector3'}
	_G['UnityEngine.Vector3.Instance']=I
	UnityEngine.Vector3=Vector3
	local get={}
	local set={}

	Vector3.__index = function(t,k)
		local f=rawget(Vector3,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	Vector3.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end


	Vector3.New=function (x,y,z)
		local v={x or 0,y or 0,z or 0}
		setmetatable(v,I)
		return v
	end

	Vector3.__call = function(t,x,y,z)
		return Vector3.New(x,y,z)
	end

	I.__index = function(t,k)
		local f=rawget(I,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	I.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__eq = function(a,b)
		return abs(a[1]-b[1])<Epsilon
		 	and abs(a[2]-b[2])<Epsilon
		 	and abs(a[3]-b[3])<Epsilon
	end

	I.__unm = function(a)
		local ca=Vector3.New(-a[1],-a[2],-a[3])
		return ca
	end


	I.__tostring = function(self)
		return string.format('Vector3(%f,%f,%f)',self[1],self[2],self[3])
	end

	I.__mul = function(a,b)
		local ta=type(a)
		local tb=type(b)
		if ta=='table' and tb=='number' then
			return Vector3.New(a[1]*b,a[2]*b,a[3]*b)
		elseif ta=='number' and tb=='table' then
			return Vector3.New(a*b[1],a*b[2],a*b[3])
		else
			error(string.format('unexpect type of arguments, got %s,%s',ta,tb))
		end
	end

	I.__add = function(a,b)
		return Vector3.New(a[1]+b[1],a[2]+b[2],a[3]+b[3])
	end

	I.__sub = function(a,b)
		return Vector3.New(a[1]-b[1],a[2]-b[2],a[3]-b[3])
	end

	I.__div = function(a,b)
		return Vector3.New(a[1]/b,a[2]/b,a[3]/b)
	end

	function Vector3.Mul(self,b)
		self[1],self[2],self[3]=self[1]*b,self[2]*b,self[3]*b
	end

	function Vector3.Add(self,b)
		self[1],self[2],self[3]=self[1]+b[1],self[2]+b[2],self[3]+b[3]
	end

	function Vector3.Sub(self,b)
		self[1],self[2],self[3]=self[1]-b[1],self[2]-b[2],self[3]-b[3]
	end

	function Vector3.Div(self,b)
		self[1],self[2],self[3]=self[1]/b,self[2]/b,self[3]/b
	end


	function get.back() return Vector3.New(0,0,-1) end
	function get.down() return Vector3.New(0,-1,0) end
	function get.forward() return Vector3.New(0,0,1) end
	function get.left() return Vector3.New(-1,0,0) end
	function get.one() return Vector3.New(1,1,1) end
	function get.right() return Vector3.New(1,0,0) end
	function get.up() return Vector3.New(0,1,0) end
	function get.zero() return Vector3.New(0,0,0) end

	function get:x() return self[1] end
	function get:y() return self[2] end
	function get:z() return self[3] end
	function set:x(v) self[1]=v end
	function set:y(v) self[2]=v end
	function set:z(v) self[3]=v end
	function get:magnitude() return Vector3.Magnitude(self) end
	function get:sqrMagnitude() return Vector3.SqrMagnitude(self) end
	function get:normalized() 
		return Vector3.Normalize(self)
	end

	function Vector3.Clone(self)
		return Vector3.New(self[1],self[2],self[3])
	end
		
	function I:Set(x,y,z)	
		self[1],self[2],self[3]=x or 0,y or 0,z or 0
	end

	function I:ToString()
		return self:__tostring()
	end

	function Vector3.Angle(a,b)
		local dot = Vector3.Dot(Vector3.Normalize(a), Vector3.Normalize(b))
		return acos(dot)*ToAngle
	end

	function Vector3.Normalized(v)
		local m = Vector3.Magnitude(v)
		if m==1 then
			return v
		elseif m>Epsilon then
			v[1],v[2],v[3]=v[1]/m,v[2]/m,v[3]/m
		else
			v:Set(0,0,0)
		end
	end

    function Vector3.Normalize(v)
        local v=Vector3.Clone(v)
        Vector3.Normalized(v)
        return v
	end

	function I:Normalize()
		Vector3.Normalized(self)
	end

	function Vector3.Magnitude(v)
		local v= sqrt(v[1]^2+v[2]^2+v[3]^2)
		return v
	end

	function Vector3.SqrMagnitude(v)
		local v= v[1]^2+v[2]^2+v[3]^2
		return v
	end

	function Vector3.Dot(a,b)
		local v= a[1]*b[1] + a[2]*b[2] + a[3]*b[3]
		return v
	end

	function Vector3.Cross(a,b)
		return Vector3.New((a[2] * b[3]) - (a[3] * b[2])
			, (a[3] * b[1]) - (a[1] * b[3])
			, (a[1] * b[2]) - (a[2] * b[1]))
	end

	function Vector3.OrthoNormalVector(n)
		local res=Vector3.New(0,0,0)
		if abs(n[3]) > Sqrt2 then
			local a = n[2]^2 + n[3]^2
			local k = 1 / sqrt (a)
			res[1],res[2],res[3] = 0,-n[3]*k,n[2]*k
		else
			local a = n[1]^2 + n[2]^2
			local k = 1 / sqrt (a)
			res[1],res[2],res[3] = -n[2]*k,n[1]*k,0
		end
		return res
	end

	function Vector3.Slerp(a,b,t)
		if t<=0 then return Vector3.Clone(a) end
		if t>=1 then return Vector3.Clone(b) end

		local ma=Vector3.Magnitude(a)
		local mb=Vector3.Magnitude(b)
		if ma<Epsilon or mb<Epsilon then
			return Vector3.Lerp(a,b,t)
		end

		local dot=Vector3.Dot(a,b)/(ma*mb)
		if dot>1-Epsilon then
			return Vector3.Lerp(a,b,t)
		elseif dot<-1+Epsilon then
			local lerpedMagnitude = lerpf (ma, mb, t)
			local na = I.__div(a,ma)
			local axis = Vector3.OrthoNormalVector(na)
			local m=Matrix3x3.New()
			Matrix3x3.SetAxisAngle(m,axis,PI*t)
			local slerped = Matrix3x3.Mul(m,na)
			Vector3.Mul(slerped,lerpedMagnitude)
			return slerped
		else
			local lerpedMagnitude = lerpf (ma, mb, t)
			local axis = Vector3.Cross(a,b)
			local na = a/ma
			Vector3.Normalized(axis)
			local angle=acos(dot)*t
			local m=Matrix3x3.New()
			Matrix3x3.SetAxisAngle(m,axis,angle)
			local slerped = Matrix3x3.Mul(m,na)
			Vector3.Mul(slerped,lerpedMagnitude)
			return slerped
		end
	end

	function Vector3.Lerp(a,b,t)
		return Vector3.New(a[1]+(b[1]-a[1])*t
			,a[2]+(b[2]-a[2])*t
			,a[3]+(b[3]-a[3])*t
		)
	end

	function Vector3.Min(a,b)
		return Vector3.New(min(a[1],b[1])
			,min(a[2],b[2])
			,min(a[3],b[3]))
	end

	function Vector3.Max(a,b)
		return Vector3.New(max(a[1],b[1])
			,max(a[2],b[2])
			,max(a[3],b[3]))
	end

	function Vector3.MoveTowards(a,b,adv)
		local v = I.__sub(b,a)
		local m = Vector3.Magnitude(v)
		if m>adv and m~=0 then
			Vector3.Div(v,m)
			Vector3.Mul(v,adv)
			Vector3.Add(v,a)
			return v
		end
		return Vector3.Clone(b)
	end

	local function ClampedMove(a,b,mag)
		local delta = b-a
		if delta > 0 then
			return a + min (delta, mag)
		else
			return a - min (-delta, mag)
		end
	end

	function Vector3.RotateTowards(a,b,angleMove,mag)
		local ma = Vector3.Magnitude(a)
		local mb = Vector3.Magnitude (b)
		
		if ma > Epsilon and mb > Epsilon then
			local na = a / ma
			local nb = b / mb
			
			local dot = Vector3.Dot(na, nb)
			if dot > 1.0 - Epsilon then
				return Vector3.MoveTowards (a, b, mag)
			elseif dot < -1.0 + Epsilon then
				local axis = Vector3.OrthoNormalVector(na)
				local m=Matrix3x3.New()
				Matrix3x3.SetAxisAngle(m, axis, angleMove)
				local rotated = Matrix3x3.Mul(m,na)
				Vector3.Mul(rotated,ClampedMove(ma, mb, mag))
				return rotated
			else
				local angle = acos(dot);
				local axis = Vector3.Cross(na, nb)
				Vector3.Normalized(axis)
				local m=Matrix3x3.New()
				Matrix3x3.SetAxisAngle(m,axis, min(angleMove, angle))
				local rotated = Matrix3x3.Mul(m,na)
				Vector3.Mul(rotated,ClampedMove(ma, mb, mag))
				return rotated
			end
		else
			return Vector3.MoveTowards (a,b,mag)
		end
	end

	function Vector3.Distance(a,b)
		a=Vector3.Clone(a)
		Vector3.Sub(a,b)
		return Vector3.Magnitude(a)
	end

	function Vector3.OrthoNormalize(u,v,w)
		Vector3.Normalized(u)

		local dot0 = Vector3.Dot(u,v)
		local tu=Vector3.Clone(u)
		Vector3.Mul(tu,dot0)
		Vector3.Sub(v,tu)
		Vector3.Normalized(v)

		if w then
			local dot1 = Vector3.Dot(v,w)
			local dot0 = Vector3.Dot(u,w)
			local tw=I.__mul(u,dot0)
			local tv=I.__mul(v,dot1)
			Vector3.Add(tv,tw)
			Vector3.Sub(w,tv)
			Vector3.Normalized(w)
		end
	end

	function Vector3.Scale(a,b)
		return Vector3.New(a[1]*b[1],a[2]*b[2],a[3]*b[3])
	end

	function I:Scale( self,b )
		return Vector3.Scale(self,b)
	end

	-- code copy from reflactor of UnityEgnine
	function Vector3.SmoothDamp(current,target,currentVelocity,smoothTime,maxSpeed,deltaTime)
		local deltaTime = deltaTime or Time.deltaTime
		local maxSpeed = maxSpeed or Infinite
		smoothTime = max(Epsilon,smoothTime)
		local float num = 2 / smoothTime
	    local float num2 = num * deltaTime
	    local float num3 = 1 / (((1 + num2) + ((0.48 * num2) * num2)) + (((0.235 * num2) * num2) * num2))
	    local vector = current - target;
	    local vector2 = target
	    local maxLength = maxSpeed * smoothTime
	    vector = Vector3.ClampMagnitude(vector, maxLength)
	    target = current - vector
	    local vector3 = currentVelocity +  vector * deltaTime * num
	    local newv = currentVelocity -  vector3 * num3 * num
	    local vector4 = target + (vector + vector3) * num3
	    if Vector3.Dot(vector2 - current, vector4 - vector2) > 0 then
	        vector4 = vector2
	        newv = (vector4 - vector2) / deltaTime
	    end
	    currentVelocity:Set(newv.x,newv.y,newv.z)
	    return vector4,currentVelocity
	end

	-- code copy from reflactor of UnityEgnine
	function Vector3.ClampMagnitude(vector,maxLength)
	    if Vector3.SqrMagnitude(vector) > (maxLength^2) then
	        return vector.normalized * maxLength
	    end
	    return Vector3.Clone(vector)
	end

	function Vector3.Reflect(dir,nml)
		local dot=Vector3.Dot(nml,dir)*-2
		local v=I.__mul(nml,dot)
		Vector3.Add(v,dir)
		return v
	end

	-- code copy from reflactor of UnityEgnine
	function Vector3.ProjectOnPlane(vector,planeNormal)
		return vector - Vector3.Project(vector, planeNormal)
	end

	-- code copy from reflactor of UnityEgnine
	function Vector3.Project( vector,normal )
		local num = Vector3.Dot(normal, normal)
	    if num < Epsilon then
	        return Vector3.zero
	    end
	    return (normal * Vector3.Dot(vector, normal)) / num
	end

	inherite(Vector3,Raw)
	setmetatable(Vector3,Vector3)
end

do
	local Raw=UnityEngine.Color
	local Color={__typename='Color',__raw=Raw}
	local I = {__typename='Color'}
	_G['UnityEngine.Color.Instance']=I
	UnityEngine.Color=Color
	local get={}
	local set={}

	Color.__index = function(t,k)
		local f=rawget(Color,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	Color.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__index = function(t,k)
		local f=rawget(I,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	I.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__tostring = function(self)
		return string.format('Color(%f,%f,%f,%f)',self[1],self[2],self[3],self[4])
	end


	function Color.New(r,g,b,a)
		a=a or 1
		local c={r or 0,g or 0,b or 0,a or 0}
		setmetatable(c,I)
		return c
	end

	function Color.__call(t,r,g,b,a)
		return Color.New(r,g,b,a)
	end

	function I.__add(a,b)
		return Color.New(a[1]+b[1],a[2]+b[2],a[3]+b[3],a[4]+b[4])
	end

	function I.__sub(a,b)
		return Color.New(a[1]-b[1],a[2]-b[2],a[3]-b[3],a[4]-b[4])
	end

	function I.__mul( a,b )
		if type(a)=='number' then
			return Color.New(a*b[1],a*b[2],a*b[3],a*b[4])
		elseif type(b)=='number' then
			return Color.New(a[1]*b,a[2]*b,a[3]*b,a[4]*b)
		else
			return Color.New(a[1]*b[1],a[2]*b[2],a[3]*b[3],a[4]*b[4])
		end
	end

	function I.__div( a,b )
		return Color.New(a[1]/b,a[2]/b,a[3]/b,a[4]/b)
	end

	function I.__eq( a,b )
		return a[1]==b[1] and a[2]==b[2] and a[3]==b[3] and a[4]==b[4]
	end

	local function ToLinear(value)
		if value <= 0.04045 then
			return value / 12.92
		elseif value < 1.0 then
			return pow((value + 0.055)/1.055, 2.4)
		else
			return pow(value, 2.4)
		end
	end

	local function ToGamma(value)
		if value <= 0.0 then
			return 0.0
		elseif value <= 0.0031308 then
			return 12.92 * value
		elseif value <= 1.0 then
			return 1.055 * pow(value, 0.41666) - 0.055
		else
			return pow(value, 0.41666)
		end
	end

	function get.red() return Color.New(1,0,0,1) end
	function get.green() return Color.New(0,1,0,1) end
	function get.blue() return Color.New(0,0,1,1) end
	function get.white() return Color.New(1,1,1,1) end
	function get.black() return Color.New(0,0,0,1) end
	function get.yellow() return Color.New(1, 0.9215686, 0.01568628, 1) end
	function get.cyan() return Color.New(0,1,1,1) end
	function get.magenta() return Color.New(1,0,1,1) end
	function get.gray() return Color.New(0.5,0.5,0.5,1) end
	function get.grey() return Color.New(0.5,0.5,0.5,1) end
	function get.clear() return Color.New(0,0,0,0) end
	function get:grayscale() return (0.299 * self[1]) + (0.587 * self[2]) + (0.114 * self[3]) end
	function get:linear() 
		return Color.New(ToLinear(self[1]),ToLinear(self[2]),ToLinear(self[3]),self[4]) 
	end
	function get:gamma() 
		return Color.New(ToGamma(self[1]),ToGamma(self[2]),ToGamma(self[3]),self[4]) 
	end
	function get:r() return self[1]	end
	function get:g() return self[2]	end
	function get:b() return self[3]	end
	function get:a() return self[4]	end
	function set:r(v) self[1]=v	end
	function set:g(v) self[2]=v	end
	function set:b(v) self[3]=v	end
	function set:a(v) self[4]=v	end

	function Color.Lerp( a,b,t )
		t=clamp(t)
		return Color.New( lerpf(a[1],b[1],t),lerpf(a[2],b[2],t),lerpf(a[3],b[3],t),lerpf(a[4],b[4],t) )
	end


	inherite(Color,Raw)
	setmetatable(Color,Color)

end

do
	local Raw=UnityEngine.Vector2
	local Vector2={__typename='Vector2',__raw=Raw}
	local I = {__typename='Vector2'}
	_G['UnityEngine.Vector2.Instance']=I
	UnityEngine.Vector2=Vector2
	local get={}
	local set={}

	Vector2.__index = function(t,k)
		local f=rawget(Vector2,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	Vector2.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__index = function(t,k)
		local f=rawget(I,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	I.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__tostring = function(self)
		return string.format('Vector2(%f,%f)',self[1],self[2])
	end

	function Vector2.New(x,y)
		local v={x or 0,y or 0}
		setmetatable(v,I)
		return v
	end

	function Vector2.__call(t,x,y)
		return Vector2.New(x,y)
	end

	function I.__add( a,b )
		return Vector2.New(a[1]+b[1],a[2]+b[2])
	end

	function I.__sub( a,b )
		return Vector2.New(a[1]-b[1],a[2]-b[2])
	end

	function I.__eq( a,b )
		return abs(a[1]-b[1])<Epsilon
		 	and abs(a[2]-b[2])<Epsilon
	end

	function I.__mul( a,b )
		return Vector2.New(a[1]*b,a[2]*b)
	end

	function I.__div( a,b )
		return Vector2.New(a[1]/b,a[2]/b)
	end

	function I.__unm( a )
		return Vector2.New(-a[1],-a[2])
	end

	function get.one() return Vector2.New(1,1) end
	function get.zero() return Vector2.New(0,0) end
	function get.up() return Vector2.New(0,1) end
	function get.down() return Vector2.New(0,-1) end
	function get.right() return Vector2.New(1,0) end
	function get.left() return Vector2.New(-1,0) end
	function get:magnitude() return sqrt(self[1]^2+self[2]^2) end
	function get:sqrMagnitude() return self[1]^2+self[2]^2 end
	function get:normalized() 
		local m = self.magnitude
		return Vector2.New(self[1]/m,self[2]/m)
	end
	function get:x() return self[1] end
	function get:y() return self[2] end
	function set:x(v) self[1]=v	end
	function set:y(v) self[2]=v	end

	inherite(Vector2,Raw)

	function Vector2.Normalize( v )
		local m = Vector2.Magnitude(v)
		v[1],v[2]=v[1]/m,v[2]/m
	end

	function Vector2.Magnitude( v )
		return sqrt(v[1]^2+v[2]^2)
	end

	function I:Set( x,y )
		self[1],self[2]=x,y
	end

	function I:ToString( )
		return I.__tostring(self)
	end

	setmetatable(Vector2,Vector2)
end

do
	local Raw=UnityEngine.Vector4
	local Vector4={__typename='Vector4',__raw=Raw}
	local I = {__typename='Vector4'}
	_G['UnityEngine.Vector4.Instance']=I
	UnityEngine.Vector4=Vector4
	local get={}
	local set={}

	Vector4.__index = function(t,k)
		local f=rawget(Vector4,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	Vector4.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__index = function(t,k)
		local f=rawget(I,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	I.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__tostring = function(self)
		return string.format('Vector4(%f,%f,%f,%f)',self[1],self[2],self[3],self[4])
	end

	function Vector4.New(x,y,z,w)
		local v={x or 0,y or 0,z or 0,w or 0}
		setmetatable(v,I)
		return v
	end

	function Vector4.__call(t,x,y,z,w)
		return Vector4.New(x,y,z,w)
	end

	function I.__add( a,b )
		return Vector4.New(a[1]+b[1],a[2]+b[2],a[3]+b[3],a[4]+b[4])
	end

	function I.__sub( a,b )
		return Vector4.New(a[1]-b[1],a[2]-b[2],a[3]-b[3],a[4]-b[4])
	end

	function I.__eq( a,b )
		return abs(a[1]-b[1])<Epsilon
		 	and abs(a[2]-b[2])<Epsilon
		 	and abs(a[3]-b[3])<Epsilon
		 	and abs(a[4]-b[4])<Epsilon
	end

	function I.__mul( a,b )
		return Vector4.New(a[1]*b,a[2]*b,a[3]*b,a[4]*b)
	end

	function I.__div( a,b )
		return Vector4.New(a[1]/b,a[2]/b,a[3]/b,a[4]/b)
	end

	function I.__unm( a )
		return Vector4.New(-a[1],-a[2],-a[3],-a[4])
	end

	function get.one() return Vector4.New(1,1,1,1) end
	function get.zero() return Vector4.New(0,0,0,0) end
	function get:x() return self[1]	end
	function get:y() return self[2]	end
	function get:z() return self[3]	end
	function get:w() return self[4]	end
	function get:magnitude() return sqrt(self[1]^2+self[2]^2+self[3]^2+self[4]^2) end
	function get:sqrMagnitude() return self[1]^2+self[2]^2+self[3]^2+self[4]^2 end
	function get:normalized() 
		local m = self.magnitude
		return Vector4.New(self[1]/m,self[2]/m,self[3]/m,self[4]/m)
	end
	function set:x(v) self[1]=v	end
	function set:y(v) self[2]=v	end
	function set:z(v) self[3]=v	end
	function set:w(v) self[4]=v	end

	function I:Set( x,y,z,w )
		self[1],self[2],self[3],self[4]=x,y,z,w
	end

	function I:ToString()
		return I.__tostring(self)
	end

	inherite(Vector4,Raw)

	setmetatable(Vector4,Vector4)
end

do
	local Raw=UnityEngine.Quaternion
	local Inst=_G['UnityEngine.Quaternion.Instance']
	local Quaternion={__typename='Quaternion',__raw=Raw}
	local I = {__typename='Quaternion'}
	_G['UnityEngine.Quaternion.Instance']=I
	UnityEngine.Quaternion=Quaternion
	local get={}
	local set={}

	Quaternion.__index = function(t,k)
		local f=rawget(Quaternion,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	Quaternion.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__index = function(t,k)
		local f=rawget(I,k)
		if f then return f end
		local f=rawget(get,k)
		if f then return f(t) end
		error('Not found '..k)
	end

	I.__newindex = function(t,k,v)
		local f=rawget(set,k)
		if f then return f(t,v) end
		error('Not found '..k)
	end

	I.__tostring = function(self)
		return string.format('Quaternion(%f,%f,%f,%f)',self[1],self[2],self[3],self[4])
	end

	I.__div = function(a,b)
		return Quaternion.New(a[1]/b,a[2]/b,a[3]/b,a[4]/b)
	end

	-- reflector code
	I.__mul = function(a,b,target)
		if getmetatable(b).__typename=='Vector3' then
			    local vector=Vector3.New(0,0,0)
			    local num = a[1] * 2
			    local num2 = a[2] * 2
			    local num3 = a[3] * 2
			    local num4 = a[1] * num
			    local num5 = a[2] * num2
			    local num6 = a[3] * num3
			    local num7 = a[1] * num2
			    local num8 = a[1] * num3
			    local num9 = a[2] * num3
			    local num10 = a.w * num
			    local num11 = a.w * num2
			    local num12 = a.w * num3
			    vector[1] = (((1 - (num5 + num6)) * b[1]) + ((num7 - num12) * b[2])) + ((num8 + num11) * b[3])
			    vector[2] = (((num7 + num12) * b[1]) + ((1 - (num4 + num6)) * b[2])) + ((num9 - num10) * b[3])
			    vector[3] = (((num8 - num11) * b[1]) + ((num9 + num10) * b[2])) + ((1 - (num4 + num5)) * b[3])
			    return vector
		else
			local x,y,z,w =
				(((a[4] * b[1]) + (a[1] * b[4])) + (a[2] * b[3])) - (a[3] * b[2]),
			 	(((a[4] * b[2]) + (a[2] * b[4])) + (a[3] * b[1])) - (a[1] * b[3]),
			 	(((a[4] * b[3]) + (a[3] * b[4])) + (a[1] * b[2])) - (a[2] * b[1]),
			 	(((a[4] * b[4]) - (a[1] * b[1])) - (a[2] * b[2])) - (a[3] * b[3])

			 if target then
			 	target[1],target[2],target[3],target[4]=x,y,z,w
			 else
			 	return Quaternion.New(x,y,z,w)
			 end
		end
	end

	function Quaternion.Mul(a,b)
		return I.__mul(a,b,a)
	end

	-- reflector code
	I.__eq = function(a,b)
		return Quaternion.Dot(a,b)>0.999999
	end


	function Quaternion.New(x,y,z,w)
		local q={x or 0,y or 0,z or 0,w or 0}
		setmetatable(q,I)
		return q
	end

	function Quaternion.__call(t,x,y,z,w)
		return Quaternion.New(x,y,z,w)
	end

	function get.identity() return Quaternion.New(0,0,0,1)	end
	function get:x() return self[1]	end
	function get:y() return self[2]	end
	function get:z() return self[3]	end
	function get:w() return self[4]	end
	function set:x(v) self[1]=v	end
	function set:y(v) self[2]=v	end
	function set:z(v) self[3]=v	end
	function set:w(v) self[4]=v	end

	function get:eulerAngles() return Inst.eulerAngles[1](self) end
	function set:eulerAngles(v) Inst.eulerAngles[2](self,v) end

	function I:Set(x,y,z,w)
		self[1],self[2],self[3],self[4]=x,y,z,w
	end

	function Quaternion.Clone(self)
		return Quaternion.New(self[1],self[2],self[3],self[4])
	end

	function I:ToAngleAxis()
		local angle = acos(self[4])*2
		if abs(angle-0)<Epsilon then
			return angle,Vector3.New(1,0,0)
		end
		local div = 1/sqrt(1-self[4]^2)
		return angle,Vector3.New(self[1]*div,self[2]*div,self[3]*div)
	end

	--TODO
	function I:SetFromToRotation(from,to)
		Inst.SetFromToRotation(self,from,to)
	end

	--TODO
	function I:SetLookRotation(view,up)
		up = up or Vector3.up
		Inst.SetLookRotation(self,view,up)
	end

	inherite(Quaternion,Raw)

	function Quaternion.Euler( x,y,z )
		if type(x)=='table' then
			x,y,z=x[1],x[2],x[3]
		end
		x,y,z=x*ToRad*0.5,y*ToRad*0.5,z*ToRad*0.5

		local cX=cos(x)
		local sX=sin(x)
		local cY=cos(y)
		local sY=sin(y)
		local cZ=cos(z)
		local sZ=sin(z)
		
		local qX=Quaternion.New(sX, 0, 0, cX)
		local qY=Quaternion.New(0, sY, 0, cY)
		local qZ=Quaternion.New(0, 0.0, sZ, cZ)
		
		Quaternion.Mul(qY,qX)
		Quaternion.Mul(qY,qZ)
		return qY
	end

	-- code from reflector unityengine
	function Quaternion.Dot( a,b )
		return a[1] * b[1] + a[2] * b[2] + a[3] * b[3] + a[4] * b[4]
	end

	function Quaternion.Normalize(q)
		q=Quaternion.Clone(q)
		local m=Quaternion.Dot(q,q)
		q[1],q[2],q[3],q[4]=q[1]/m,q[2]/m,q[3]/m,q[4]/m
		return q
	end

	function Quaternion.Lerp( q1,q2,t )
		local tmpQuat=Quaternion.New(0,0,0,1)
		if Quaternion.Dot(q1, q2) < 0 then
			tmpQuat:Set(q1[1] + t * (-q2[1] - q1[1]),
			            q1[2] + t * (-q2[2] - q1[2]),
			            q1[3] + t * (-q2[3] - q1[3]),
			            q1[4] + t * (-q2[4] - q1[4]))
		else
			tmpQuat:Set(q1[1] + t * (q2[1] - q1[1]),
			            q1[2] + t * (q2[2] - q1[2]),
			            q1[3] + t * (q2[3] - q1[3]),
			            q1[4] + t * (q2[4] - q1[4]))
		end
		return Quaternion.Normalize(tmpQuat)
	end

	-- code from unityengine
	function Quaternion.Slerp( q1,q2,t )
		t=clamp(t)
		local dot = Quaternion.Dot( q1, q2 )
		local tmpQuat=Quaternion.New(0,0,0,1)
		if dot < 0 then
			dot = -dot
			tmpQuat:Set( -q2[1],-q2[2],-q2[3],-q2[4] )
		else
			tmpQuat = q2
		end

		
		if dot < 0.95 then
			local angle = acos(dot)
			local sinadiv, sinat, sinaomt
			sinadiv = 1/sin(angle)
			sinat   = sin(angle*t)
			sinaomt = sin(angle*(1-t))
			tmpQuat:Set( (q1[1]*sinaomt+tmpQuat[1]*sinat)*sinadiv,
				     (q1[2]*sinaomt+tmpQuat[2]*sinat)*sinadiv,
				     (q1[3]*sinaomt+tmpQuat[3]*sinat)*sinadiv, 
				     (q1[4]*sinaomt+tmpQuat[4]*sinat)*sinadiv  )
			return tmpQuat
		else
			return Quaternion.Lerp(q1,tmpQuat,t)
		end
	end

	setmetatable(Quaternion,Quaternion)
end

";
#endif
        public static void reg(IntPtr l)
        {
#if !LUA_5_3 && !SLUA_STANDALONE
            // lua implemented valuetype isn't faster than raw under non-jit.
            LuaState ls = LuaState.get(l);
            ls.doString(script, "ValueTypeScript");
#endif
        }
    }
}
