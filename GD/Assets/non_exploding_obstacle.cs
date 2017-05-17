using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class non_exploding_obstacle : MonoBehaviour {
	private Collider2D col;
	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			col.enabled = false;
		} 
	}

}
