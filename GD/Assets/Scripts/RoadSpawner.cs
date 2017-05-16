using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour {

	private Vector3 last;
	public float dist2Spawn;
	public GameObject[] road;
	private bool coolDown = true;
	// Use this for initialization
	void Start () {
		last = transform.position;
		last.x = -100f;

		while (last.x < 60) {
			int rand = Random.Range (0, road.Length);
			if (rand == 1) {
				if (coolDown) {
					rand = 0;
					coolDown = false;
				} else
					coolDown = true;
			}
			Instantiate (road [rand], last, transform.rotation);
			last.x = last.x + dist2Spawn;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( Vector3.Distance (last, transform.position) > dist2Spawn) {
			last = transform.position;
			int rand = Random.Range (0, road.Length);
			if (rand == 1) {
				if (coolDown) {
					rand = 0;
					coolDown = false;
				}else 
					coolDown = true;
			}
			Instantiate(road[rand],transform.position,transform.rotation);
		}
	}
}
