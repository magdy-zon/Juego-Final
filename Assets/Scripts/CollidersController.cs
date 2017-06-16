using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersController : MonoBehaviour {

	public GameObject godRays;
	public GameObject itemHistory;
	public GameObject jaulaCirco;
	public GameObject cañon;

	/**
	 * Script for do actions when the gamer collides when a specific target
	 */
	void Start () {
		godRays = GameObject.FindGameObjectWithTag("godRays");
		itemHistory = GameObject.FindGameObjectWithTag("itemHistory");
		jaulaCirco = GameObject.FindGameObjectWithTag ("jaulaCirco");
		cañon = GameObject.FindGameObjectWithTag ("cañon");

		itemHistory.SetActive (false);
		godRays.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "talkWizard") {
			cuentaHistoriaMago ();
			activaHistoria ();
		}
	}


	void cuentaHistoriaMago() {
		Debug.Log("Contando la historia...");
	}

	void activaHistoria() {
		itemHistory.SetActive (true);
		godRays.SetActive (true);
		if (jaulaCirco != null)
			jaulaCirco.SetActive (false);
		if (cañon != null)
			cañon.SetActive (false);
	}

	void recargaEscenaCircoPrincipal() {
	
	
	}
}
	