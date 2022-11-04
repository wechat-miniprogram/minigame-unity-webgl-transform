using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SphereForce : PrefabBase
{
	Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	public override void ManualFixedUpdate ()
	{
		var norm = rb.position.normalized;
		var gravity = -norm * 5000 / Mathf.Max(transform.position.magnitude, 50);
		var rotation = new Vector3(norm.z, 0,  -norm.x);
		rb.AddForce(gravity + rotation);
	}
}
