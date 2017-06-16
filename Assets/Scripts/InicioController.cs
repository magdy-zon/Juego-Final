using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioController : MonoBehaviour {

	public GameObject godRays;
	public GameObject itemHistory;
	public GameObject jaulaCirco;
	public GameObject cañon;
	public GameObject aCarpaGrande;

	/**
	 * Script for do actions when the gamer collides when a specific target
	 */
	void Start () {

		aCarpaGrande = GameObject.FindGameObjectWithTag ("aCarpaGrande");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "aCarpaGrande") {
		
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
		if (aCarpaGrande != null)
			SceneManager.LoadScene ("carpaGrandeJuego");
	}

	void recargaEscenaCircoPrincipal() {


	}
}
