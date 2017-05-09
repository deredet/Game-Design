using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {

	private player_move player;

	void OnTriggerEnter2D(Collider2D col){
		player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col){
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col){
		player.grounded = false;
	}
	// Use this for initialization
	void Start () {
		player = GetComponentInParent<player_move> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
