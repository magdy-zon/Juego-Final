using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

	public GameObject disparo;
	public Transform posicion;
	public float tiempoFuego;
	public float tiempoEspera;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("fuego",tiempoFuego,tiempoEspera);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void fuego(){
		Instantiate (disparo, posicion.position, posicion.rotation);
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("jugador")) {
			Destroy (other.gameObject);
			print ("hola");
		} else {
			print (other.gameObject.name);
		}
	}
}
