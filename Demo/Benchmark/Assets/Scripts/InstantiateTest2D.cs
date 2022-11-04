using UnityEngine;
using System.Collections;

public class InstantiateTest2D : InstantiateTest {

	public Vector2 scale = new Vector2(1, 1);

	protected override void initializeInstance(GameObject go)
	{
		go.transform.position = Vector3.Scale (Random.insideUnitCircle, scale);

		if (randomRotation)
		{
			var rigidbody = go.GetComponent<Rigidbody2D>();
			rigidbody.angularVelocity = Random.value * 400;
			rigidbody.rotation = Random.value * 360;
		}
	}


}
