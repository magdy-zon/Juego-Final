using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

	/**
	 * Controller for set the movement of the player
	 */
	public float inputDelay = 0.1f;
	public float forwardVel = 12f;
	public float rotateVel = 160f;
	public float distanceToGround = 0.1f;
	public float jumpVel = 12f;
	public float downAcccel = 0.65f;

	public LayerMask ground; 

	Rigidbody rbody;
	Quaternion targetRotation;
	Vector3 velocity = Vector3.zero;
	float forwardInput, turnInput, jumpInput;

	void Start () {
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody> ())
			rbody = GetComponent<Rigidbody> ();
		else
			Debug.LogError("Falle");

		forwardInput = turnInput = jumpInput = 0;
	}

	void GetInput() {
		turnInput = Input.GetAxis ("Horizontal");
		forwardInput = Input.GetAxis ("Vertical");
		jumpInput = Input.GetAxisRaw ("Jump");
	}

	void Turn () {
		if(Mathf.Abs(turnInput) > inputDelay)
			targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

	bool Grounded () {
		return Physics.Raycast( transform.position, Vector3.down, distanceToGround, ground);
	}

	void Update () {
		GetInput();
		Turn();
	}

	void Run () {
		if(Mathf.Abs(forwardInput) > inputDelay)
			velocity.z = forwardInput * forwardVel;
		else
			velocity.z = 0;
	}

	void Jump () {
		if (jumpInput > 0 && Grounded ())
			velocity.y = jumpVel;
		else if (jumpInput == 0 && Grounded ())
			velocity.y = 0;
		else
			velocity.y -= downAcccel;	
	}

	void FixedUpdate () {
		Run();
		Jump ();

		rbody.velocity = transform.TransformDirection (velocity);

	}

}
