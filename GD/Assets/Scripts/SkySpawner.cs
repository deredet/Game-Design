using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpawner : MonoBehaviour {

	private Vector3 last;
	public GameObject[] road;
	private float skyLength;

	// Use this for initialization
	void Start () {
		skyLength = road [0].GetComponent<SpriteRenderer> ().bounds.size.x;
		last = transform.position;
		last.x = -100;
		int i = 1;
		while(i<10) {
			Instantiate (road [0], last, transform.rotation);
			last.x = last.x + skyLength;
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
