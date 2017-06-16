using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaController : MonoBehaviour {

	public float rotateVel = 50f;

	public GameObject itemHistory;
	Quaternion targetRotation;

	/**
	 * Script for animate elements of the scenary automatically
	 */
	void Start () {
		targetRotation = transform.rotation;
		itemHistory = GameObject.FindGameObjectWithTag("itemHistory");

	}
	
	// Update is called once per frame
	void Update () {
		if ( itemHistory )
			rotarHistoria ();
	}

	void rotarHistoria() {
		targetRotation *= Quaternion.AngleAxis(rotateVel * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

}
