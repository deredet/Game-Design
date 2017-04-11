using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
	private Rigidbody2D r2D;
	public float moveSpeed = 2;
	// Use this for initialization
	void Start () {
		r2D = transform.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		r2D.AddForce(Vector2.right * moveSpeed,ForceMode2D.Force);
	}
}
