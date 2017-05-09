using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour {
	public float lifeTimer;
	private float timer;
	private GameObject temp;
	private player_move player;
	// Use this for initialization
	void Start () {
		timer = lifeTimer;
	}
	
	// Update is called once per frame
	void Update () {		
	temp = GameObject.Find ("Player Sprite");
		player = temp.GetComponent<player_move>();
		if (player.alive) {
			timer -= Time.deltaTime;
			if (timer <=0)
				Destroy (gameObject);
		}

	}
}
