using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	private SpriteRenderer sr;
	public Sprite otherSprite;
	private Animator anim;
	private Collider2D col;
	private bool triggered = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		col = GetComponent<Collider2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered){
			anim.enabled = false;
			sr.sprite = otherSprite;
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetBool ("hit", true);
			col.enabled = false;

			StartCoroutine (hit ());
		} 
	}

	private IEnumerator hit(){
		yield return new WaitForSeconds (0.4f);
		anim.SetBool ("hit", false);
		triggered = true;
	}
}
