using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {
	public string objectName;
	// Use this for initialization
	void Start () {
		transform.position = GameObject.FindGameObjectWithTag (objectName).transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
