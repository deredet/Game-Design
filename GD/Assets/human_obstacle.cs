using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_obstacle : MonoBehaviour {
	private SpriteRenderer sr;
	private Collider2D col;
	public Sprite otherSprite;
	// Use this for initialization
	void Start () {
		col = GetComponent<Collider2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			sr.sprite = otherSprite;
			col.enabled = false;

		} 
	}
}
