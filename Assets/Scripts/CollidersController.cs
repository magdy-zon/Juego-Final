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
	public GameObject toPrincipalAgain;
	public GameObject toLavaCollider;
	public GameObject toMiniScene;
	public GameObject key;
	public GameObject mago;

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
		toPrincipalAgain = GameObject.FindGameObjectWithTag ("toPrincipalAgain");
		key = GameObject.FindGameObjectWithTag ("key");
		toLavaCollider = GameObject.FindGameObjectWithTag ("toLavaCollider");
		toMiniScene = GameObject.FindGameObjectWithTag ("colliderForMiniScene");
		mago = GameObject.FindGameObjectWithTag ("mago");


		if (itemHistory != null)
			itemHistory.SetActive (false);
		if (godRays != null)
			godRays.SetActive (false);
		if (aPrincipalJuego != null)
			aPrincipalJuego.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//escenaActual = datos.getScene();
	}

	void OnTriggerEnter (Collider other) {
		//Scena inicioJuego
		if (other.gameObject.tag == "aCarpaGrande") {
			SceneManager.LoadScene ("carpaGrandeJuego");
		}
		//Scene CarpaGrande
		if (other.gameObject.tag == "talkWizard") {
			cuentaHistoriaMago ();
			activaHistoria1 ();
		}
		if (other.gameObject.tag == "aPrincipalJuego") {
			Debug.Log("Contando la historia...");
			SceneManager.LoadScene ("PrincipalJuego");
		}
		//Scene PrincipalJuego
		if (other.gameObject.tag == "forTalkArlequinBueno") {
			talkArlequinBueno.SetActive (false);
			arlequinBueno ();
		}
		if (other.gameObject.tag == "colliderForMiniScene") {
			SceneManager.LoadScene ("miniCarpaJuego\t");
		}	
		//Scene MiniCarpa
		if (other.gameObject.tag == "recogerKey") {
			recogerKey ();
		}
		//Scene Globos
		if (other.gameObject.tag == "toPrincipalAgain") {
			SceneManager.LoadScene ("PrincipalJuego");
		}
		if (other.gameObject.tag == "toLavaCollider") {
			SceneManager.LoadScene ("LavaJuego");
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
		SceneManager.LoadScene ("globos");

	}

	void activaHistoria1() {
		itemHistory.SetActive (true);
		godRays.SetActive (true);
		mago.SetActive (false);
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
	