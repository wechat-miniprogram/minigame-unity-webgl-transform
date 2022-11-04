using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class SphereForce2D : PrefabBase {

	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	public override void ManualFixedUpdate ()
	{
		var norm = rb.position.normalized;
		var gravity = -norm * 10000 / Mathf.Max(transform.position.magnitude, 50);
		var rotation = new Vector2(norm.y, -norm.x) * 2;
		rb.AddForce(gravity + rotation);
	}
}
