using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private Animator anim;
	private Collider2D col;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetBool ("hit", true);
			col.enabled = false;
			StartCoroutine (hit ());
		} 
	}

	private IEnumerator hit(){
		yield return new WaitForSeconds (0.6f);
		Destroy (gameObject);

	}
}
