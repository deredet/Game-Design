using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posScript : MonoBehaviour {
	public GameObject reference;
	public float distance = 20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (reference.transform.position.x + distance, transform.position.y, transform.position.z);
	}
}
