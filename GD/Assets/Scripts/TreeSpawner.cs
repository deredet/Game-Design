using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	private Vector3 last;
	public float dist2Spawn;
	public GameObject[] road;
	private int lastRandom = 0;

	// Use this for initialization
	void Start () {
		last = transform.position;
		last.x = -100f;

		while (last.x < 60) {
			int rand;
			do {
				rand = Random.Range (0, road.Length);
			} while (rand == lastRandom);
			Instantiate (road [rand], last, transform.rotation);
			last.x = last.x + dist2Spawn;
			lastRandom = rand;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( Vector3.Distance (last, transform.position) > dist2Spawn) {
			last = transform.position;
			int rand;
			do {
				rand = Random.Range (0, road.Length);
			} while (rand == lastRandom);
			Instantiate(road[rand],transform.position,transform.rotation);
			lastRandom = rand;
		}
	}
}
