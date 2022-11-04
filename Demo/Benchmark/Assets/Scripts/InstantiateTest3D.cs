using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiateTest3D : InstantiateTest
{
	public float velocityScale = 0;
	public Vector3 scale = new Vector3(30, 30, 30);


	protected override void initializeInstance(GameObject go)
	{
		if (scale != new Vector3(0.0f, 0.0f, 0.0f))
		{
			var position = Vector3.Scale(Random.insideUnitSphere, scale);
			position += position.normalized * 0;
			go.transform.position = position;
		}
		if (randomRotation)
			go.transform.rotation = Random.rotationUniform;
		if (velocityScale != 0)
			go.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * velocityScale;
	}
}
