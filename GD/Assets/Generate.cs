using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
	public float startTime = 1f;
	public float repeatTime = 1f;
	public GameObject gObject;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateGameObject", startTime, repeatTime);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateGameObject(){
		Instantiate (gObject);
	}
}
