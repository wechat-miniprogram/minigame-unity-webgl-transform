-- unit test
function main()



	local Vector3 = UnityEngine.Vector3
	local Quaternion = UnityEngine.Quaternion
	local v=Vector3(0,0,0)+Vector3.one*2/2
	assert(v.y==1)
	v.y=2
	assert(v.x==1)
	assert(v.y==2)
	assert(v.y==2 and v[2]==2)
	local x1=Vector3.RotateTowards(Vector3.up,Vector3.right,0.45,0.2)
	local x2=Vector3.__raw.RotateTowards(Vector3.up,Vector3.right,0.45,0.2)
	print(x1,x2)
	assert(x1==x2)

	local v1=2*Vector3(1,2,3)
	local v2=Vector3(1,2,3)*2
	print("2*Vector",v1,v2)
	assert(v1==v2)

	local v=Vector3(2,0,0)
	v:Set(3,0,0)
	assert(v.x==v[1] and v.x==3)
	v:Normalize()
	local v2=Vector3.Normalize(v)
	assert(v.x==1 and v2==v)

	local dir = (Vector3.up - Vector3.zero).normalized
	assert(dir==Vector3.up)

	local v1=Vector3.MoveTowards(Vector3.zero,Vector3.one,0.3)
	local v2=Vector3.__raw.MoveTowards(Vector3.zero,Vector3.one,0.3)
	assert(v1==v2)
	assert(-v1+v2==Vector3.zero)

	local n1,t1=Vector3(0.5,1,1),Vector3(1,0.5,0.5)
	Vector3.OrthoNormalize(n1,t1)
	local n2,t2=Vector3(0.5,1,1),Vector3(1,0.5,0.5)
	n2,t2=Vector3.__raw.OrthoNormalize(n2,t2)
	print(n1,n2,t1,t2)
	assert(n1==n2)
	assert(t1==t2)

	local n1,t1,b1=Vector3(0.5,1,1),Vector3(1,0.5,0.5),Vector3(1,2,0)
	Vector3.OrthoNormalize(n1,t1,b1)
	local n2,t2,b2=Vector3(0.5,1,1),Vector3(1,0.5,0.5),Vector3(1,2,0)
	n2,t2,b2=Vector3.__raw.OrthoNormalize(n2,t2,b2)
	print(n1,n2,t1,t2,b1,b2)
	assert(n1==n2)
	assert(t1==t2)
	assert(b1==b2)

	local currentV=Vector3(0,0.1,0)
	local v4=Vector3.SmoothDamp(Vector3.zero,Vector3.up,currentV,5)
	print(v4,currentV)

	local r=Vector3.Reflect(Vector3(0.5,0.5,0),Vector3.up)
	local r2=Vector3.__raw.Reflect(Vector3(0.5,0.5,0),Vector3.up)
	print(r,r2)
	assert(r==r2)

	local r=Vector3.ProjectOnPlane(Vector3(0.5,0.5,0),Vector3.up)
	local r2=Vector3.__raw.ProjectOnPlane(Vector3(0.5,0.5,0),Vector3.up)
	print(r,r2)
	assert(r==r2)

	local r=Vector3.Slerp(Vector3.up,Vector3.zero,0.5)
	local r2=Vector3.__raw.Slerp(Vector3.up,Vector3.zero,0.5)
	assert(r==r2)

	local r=Vector3.Slerp(Vector3.up,Vector3(0.5,-1,0),0.1)
	local r2=Vector3.__raw.Slerp(Vector3.up,Vector3(0.5,-1,0),0.1)
	assert(r==r2)

	local st=os.clock()
	for i=1,200000 do
		local r=Vector3.Slerp(Vector3.up,Vector3.down,0.1)
	end
	print("slerp time",os.clock()-st)
	local st=os.clock()
	for i=1,200000 do
		local r2=Vector3.__raw.Slerp(Vector3.up,Vector3.down,0.1)
	end
	print("slerp raw time",os.clock()-st)

	local r=Vector3.RotateTowards(Vector3.up,Vector3.down,0.1,0.1)
	local r2=Vector3.__raw.RotateTowards(Vector3.up,Vector3.down,0.1,0.1)
	print(r,r2)
	assert(r==r2)

	local Color=UnityEngine.Color

	local r=Color.red
	print(r,r.linear,r.gamma)

	local r=Color(0.2,0.8,1,1)
	print(r,r.linear,r.gamma)

	r.r=1
	assert(r.r==1 and r[1]==1)

	local r = Color.Lerp(Color.clear,Color.white,0.3)
	print(r)
	assert(r==Color(0.3,0.3,0.3,0.3))

	local r = Quaternion.Euler(30,30,30)
	print(r)
	local Inst=_G['UnityEngine.Quaternion.Instance']
	local r1,r2=r:ToAngleAxis()
	local r3,r4=Inst.ToAngleAxis(r)
	print("ToAngleAxis",r1,r2,r3,r4)
	assert(r1==r3 and r2==r4)
	r:SetFromToRotation(Vector3.up,Vector3.right)
	print(r,r.x,r.y,r.z,r.w)
	r:SetLookRotation(Vector3.back,Vector3.up)
	print(r)
	local r=Quaternion.Dot(Quaternion(1,0,0,1),Quaternion(0.5,0,0,1))
	print("dot of q",r)
	local r=Quaternion(1,0,0,1)*Quaternion(0.5,0,0,1)
	print("mul q",r)
	local v=r*Vector3.up
	print("mul q,v",v)

	local r=Quaternion.Euler(30,30,30)
	local r2=Quaternion.__raw.Euler(30,30,30)
	assert(r==r2)
	print("xxx",r2.eulerAngles)
	r2.eulerAngles=Vector3(40,40,40)
	print("yyy",r2.eulerAngles)

	local Vector2 = UnityEngine.Vector2
	local r = Vector2.one
	assert(r==Vector2(1,1))
	assert(Vector2.Dot(Vector2.one,Vector2(0.5,0.5))==1)
	local r=Vector2.Lerp(Vector2.zero,Vector2.one,0.3)
	assert(r==Vector2(1,1)*0.3)
	print(r.normalized)

	Vector2.Normalize(r)
end