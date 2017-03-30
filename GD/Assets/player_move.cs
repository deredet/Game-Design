using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
	private Rigidbody2D r2D;
	// Use this for initialization
	void Start () {
		r2D = transform.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		r2D.AddForce(new Vector2(5f,0f));
	}
}
