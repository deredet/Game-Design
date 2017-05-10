using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
	public float scrollspeed = 0.5f;
	private Renderer rend;
	private Vector2 startPosition;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * scrollspeed, 0);
		rend.material.mainTextureOffset = offset;
	}
}
