using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {

	public float xangle = 30;
	public float speed = 20;
	public float distance = 10;
	public float yShift = 0;

	void Update () {
		var cam = Camera.main.transform;
		cam.rotation = Quaternion.Euler (xangle, Time.time * speed, 0);
		cam.position = Vector3.up * yShift - distance * cam.forward;
	}
}
