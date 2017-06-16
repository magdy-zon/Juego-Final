using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosController : MonoBehaviour {

	public static DatosController estadoJuego;

	void Awake() {
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
			Destroy (gameObject);
		}
	}

	public int numEscena;

	public DatosController(int scene) {
		this.numEscena = scene;
	}

	public void setEscena(int valor) {
		this.numEscena = valor;
	}

	public int getScene() {
		return numEscena;
	}

}
