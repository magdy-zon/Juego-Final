using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	/**
	 * Controller for set the movement of the player
	 */
	 public float inputDelay = 0.1f;
	public float forwardVel = 12f;
	public float rotateVel = 160f;

	Rigidbody rbody;
	Quaternion targetRotation;
	Vector3 walking;
	float forwardInput, turnInput;

	void Start () {
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody> ())
			rbody = GetComponent<Rigidbody> ();
		else
			Debug.LogError("Falle");

		forwardInput = turnInput = 0;
	}

	void GetInput() {
		turnInput = Input.GetAxis ("Horizontal");
		forwardInput = Input.GetAxis ("Vertical");
	}

	void Turn () {
		if(Mathf.Abs(turnInput) > inputDelay)
			targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	void Update () {
		GetInput();
		Turn();
	}

	void Run () {
		if(Mathf.Abs(forwardInput) > inputDelay)
			rbody.velocity = transform.forward * forwardInput * forwardVel;
		else
			rbody.velocity = Vector3.zero;
	}

	void FixedUpdate () {
		Run();
	}
	
}
