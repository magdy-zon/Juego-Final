using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaController : MonoBehaviour {

	public float rotateVel = 160f;

	Rigidbody rbody;
	Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody> ())
			rbody = GetComponent<Rigidbody> ();
		else
			Debug.LogError("Falle");
	}
	
	// Update is called once per frame
	void Update () {
		rotarHistoria ();
	}

	void rotarHistoria() {
		targetRotation *= Quaternion.AngleAxis(rotateVel * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}
}
