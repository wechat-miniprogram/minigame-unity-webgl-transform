
import "UnityEngine"

if not UnityEngine.GameObject or not  UnityEngine.UI then
	error("Click Make/All to generate lua wrap file")
end

local pi=math.pi
local class={}

function main()
	local slider = GameObject.Find("Canvas/Slider"):GetComponent(UI.Slider)
	local counttxt = GameObject.Find("Canvas/Count"):GetComponent(UI.Text)
	slider.onValueChanged:AddListener(
		function(v)
			class:init(v)
			counttxt.text=string.format("cube:%d",v)
		end
	)
	
	class.root = GameObject("root")
	class.ftext = GameObject.Find("Canvas/Text"):GetComponent(UI.Text)
	class.r=10
	class.cubes={}
	class.t=0
	class.f=0
	class.framet=0
	class.max=0
	
	class:init()
	return class
end

function class:init(count)

	for _,v in ipairs(self.cubes) do
		GameObject.Destroy(v[1])
	end

	self.cubes={}
	self.max=count or 400
	
	local P = Resources.Load("Particle System")
	
	self.colors={Color.red,Color.blue,Color.green,Color.cyan,Color.grey,Color.white,Color.yellow,Color.magenta,Color.black}

	for i=0,self.max do
		local cube = GameObject.CreatePrimitive(PrimitiveType.Cube)
		cube.transform.position = Vector3(math.cos(i/self.max*pi*2)*self.r,math.sin( i/self.max*pi*2)*self.r,0)
		cube.transform:SetParent(self.root.transform)
		local mat=cube:GetComponent(Renderer).material

		local box=cube:GetComponent(BoxCollider)
		GameObject.Destroy(box)
		
		local p = GameObject.Instantiate(P,Vector3.zero,Quaternion.identity)
		p.transform:SetParent( cube.transform )

		mat.color=self.colors[math.random(#self.colors)]
		table.insert(self.cubes,{cube,mat})
	end
end

function class:update() -- gc alloc is zero
	
	for i,v in ipairs(self.cubes) do
		local offset = i%2==1 and 5 or -5
		local r = self.r+math.sin(Time.time)*offset
		local angle= i%2==1 and Time.time or -Time.time
		local base=Vector3(math.cos(i/self.max*pi*2+angle)*r,
			math.sin(i/self.max*pi*2+angle)*r,0)

		v[1].transform.position = base
		--v[2].color=self.colors[math.random(#self.colors)]
	end

	if not self.fogStart or self.t>1 then
		self.fogStart=Time.time
		self.bgCurrent = Camera.main.backgroundColor
		self.bgColor=self.colors[math.random(#self.colors)]
	end

	self.t=(Time.time-self.fogStart)/10
	Camera.main.backgroundColor = Color.Lerp(self.bgCurrent,self.bgColor,self.t)

	--calc fps
	self.f=self.f+1
	self.framet=self.framet+Time.deltaTime
	if self.framet>=1 then
		self.ftext.text=string.format("fps:%d",self.f)
		self.f=0
		self.framet=self.framet-1
	end
end