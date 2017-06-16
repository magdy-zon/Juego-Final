using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollidersController : MonoBehaviour {

	public GameObject godRays;
	public GameObject itemHistory;
	public GameObject jaulaCirco;
	public GameObject cañon;
	public GameObject aCarpaGrande;
	public GameObject aPrincipalJuego;
	public GameObject talkArlequinBueno;
	public GameObject key;

	DatosController datos;
	int escenaActual;

	/**
	 * Script for do actions when the gamer collides when a specific target
	 */
	void Start () {
		
		godRays = GameObject.FindGameObjectWithTag("godRays");
		itemHistory = GameObject.FindGameObjectWithTag("itemHistory");
		jaulaCirco = GameObject.FindGameObjectWithTag ("jaulaCirco");
		cañon = GameObject.FindGameObjectWithTag ("cañon");
		aCarpaGrande = GameObject.FindGameObjectWithTag ("aCarpaGrande");
		aPrincipalJuego = GameObject.FindGameObjectWithTag ("aPrincipalJuego");
		talkArlequinBueno = GameObject.FindGameObjectWithTag ("forTalkArlequinBueno");
		key = GameObject.FindGameObjectWithTag ("key");

		datos = new DatosController (0);

		if (itemHistory != null)
			itemHistory.SetActive (false);
		if (godRays != null)
			godRays.SetActive (false);
		if (aPrincipalJuego != null)
			aPrincipalJuego.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		escenaActual = datos.getScene();
	}

	void OnTriggerEnter (Collider other) {
		//Scena inicioJuego
		if (other.gameObject.tag == "aCarpaGrande") {
			datos.setEscena (escenaActual++);
			Debug.Log(escenaActual);
			SceneManager.LoadScene ("carpaGrandeJuego");
		}
		//Scene CarpaGrande
		if (other.gameObject.tag == "talkWizard") {
			Debug.Log(escenaActual);
			cuentaHistoriaMago ();
			activaHistoria1 ();
		}
		if (other.gameObject.tag == "aPrincipalJuego") {
			Debug.Log("Contando la historia...");
			datos.setEscena (escenaActual++);
			Debug.Log(escenaActual);
			SceneManager.LoadScene ("PrincipalJuego");
		}
		//Scene PrincipalJuego
		if (other.gameObject.tag == "forTalkArlequinBueno") {
			Debug.Log(escenaActual);
			talkArlequinBueno.SetActive (false);
			arlequinBueno ();
		}
		//Scene MiniCarpa
		if (other.gameObject.tag == "recogerKey") {
			recogerKey ();
		}

	}

	/** 
	 * Se cuenta la primera historia del mago, cuando convierte al niño en lobo
	 */
	void cuentaHistoriaMago() {
		Debug.Log("Contando la historia...");
	}

	/**
	 * El arlequin bueno nos dice que el mago lo trata mal, solicita la llave
	 */
	void arlequinBueno() {
		Debug.Log("Contando la historia de que el mago trata mal al arlequin...");

	}

	void activaHistoria1() {
		itemHistory.SetActive (true);
		godRays.SetActive (true);
		if (jaulaCirco != null)
			jaulaCirco.SetActive (false);
		if (cañon != null)
			cañon.SetActive (false);
		if (aPrincipalJuego != null)
			aPrincipalJuego.SetActive (true);
	}

	void recogerKey() {
		godRays.SetActive (false);
		key.SetActive (false);
		aPrincipalJuego.SetActive (true);
	}
}
	