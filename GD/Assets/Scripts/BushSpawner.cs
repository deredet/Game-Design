using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushSpawner : MonoBehaviour {

	private Vector3 last;
	public GameObject[] road;
	private float skyLength;

	// Use this for initialization
	void Start () {
		skyLength = road [0].GetComponent<SpriteRenderer> ().bounds.size.x;
		last = transform.position;
		last.x = -100;
		do {
			Instantiate (road [0], last, transform.rotation);
			last.x = last.x + skyLength;
		} while (last.x < 120);
		last = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (last, transform.position) > 3) {
			Instantiate (road [0], last, transform.rotation);
			last.x = last.x + 3;
		}
	}
}
