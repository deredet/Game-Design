using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action_script : MonoBehaviour {
	public GameObject player;
	private Rigidbody2D r2D;
	// Use this for initialization
	void Start () {
		r2D = player.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jump(){
		r2D.AddForce (new Vector2 (0f, 2f));
	}
}
