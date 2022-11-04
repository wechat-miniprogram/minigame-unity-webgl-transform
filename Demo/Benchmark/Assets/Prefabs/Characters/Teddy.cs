using UnityEngine;
using System.Collections;

public class Teddy : MonoBehaviour {

	void Start () 
	{
		GetComponent<Animator>().SetFloat("Speed", Random.Range (0,50));
	}

	void Update () 
	{
		GetComponent<Animator>().SetFloat("AngularSpeed", 20 * Vector3.Dot(transform.forward, transform.position));
	}
}
