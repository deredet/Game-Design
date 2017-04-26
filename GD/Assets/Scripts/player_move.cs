using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {
	private Rigidbody2D r2D;
	public float moveSpeed = 2;
	public float jumpPower = 2;

	public bool grounded = true;
	// Use this for initialization
	void Start () {
		r2D = transform.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		r2D.AddForce(Vector2.right * moveSpeed,ForceMode2D.Force);
	}

	public void Jump(){
		if (grounded) {
			r2D.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
		}
	}
}
