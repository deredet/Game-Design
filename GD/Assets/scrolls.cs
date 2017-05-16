using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolls : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Player Sprite").GetComponent<player_move>().alive)
			transform.Translate (Vector3.left * speed);
		else {
			transform.Translate (Vector3.zero);
		}
	}
}
