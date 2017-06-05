using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	/**
	 * Controller to indicate the target of the camera
	 */
	public Transform targetCamera;
	public Vector3 distance = new Vector3 (0f, 3f, -15f);
	public float positionDamping = 2f; 
	public float rotationDamping = 2f;

	private Transform thisTransform;

	void Start () {
		thisTransform = GetComponent<Transform> ();
	}

	void LateUpdate () {

		if (targetCamera == null)
			return;

		Vector3 wantedPosition = targetCamera.position + (targetCamera.rotation * distance);
		Vector3 currentPosition = Vector3.Lerp (thisTransform.position, wantedPosition, positionDamping * Time.deltaTime);

		thisTransform.position = currentPosition;
		Quaternion wantedRotation = Quaternion.LookRotation (targetCamera.position - thisTransform.position, targetCamera.up);

		thisTransform.rotation = wantedRotation;

	}
}
