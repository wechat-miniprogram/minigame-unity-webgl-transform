using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateTest : FPSTest {

	public GameObject prefab = null;
	public bool randomRotation = true;
	public float speed = 0.1f;
	public float minCount = 0.1f;
	public int maxCount = 100;

	protected override void Start()
	{
		base.Start();
		PrefabBase.instances.Clear();
	}

	protected virtual void initializeInstance(GameObject instance)
	{

	}

	public override void UpdateTest()
	{
		float increment = ((curFPS - goalFPS) * speed);

		if (increment < minCount)
			increment = minCount;
		if (increment > maxCount)
			increment = maxCount;

		if (curFPS != -1 && increment < 1.0f && increment < Random.value)
			return;

		for (int i=0; i<increment; i++)
		{
			var go = (GameObject)Instantiate(prefab);
			initializeInstance(go);
			score++;
		}

		//first object is the prefab so skip that
		for (int i = 1; i < PrefabBase.instances.Count; i++)
			PrefabBase.instances[i].ManualUpdate();
		
	}

	void FixedUpdate()
	{
		//first object is the prefab so skip that
		for (int i = 1; i < PrefabBase.instances.Count; i++)
			PrefabBase.instances[i].ManualFixedUpdate();
	}
			
}
