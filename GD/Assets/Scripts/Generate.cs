using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
	float lastTime;
	float interval = 0;
	bool isRandomed = false;
	public GameObject[] gObject;
	public bool test = false;
	public int n;
	private bool isReset = false;
	// Use this for initialization
	void Start () {
		lastTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Player Sprite").GetComponent<player_move> ().alive) {
			if (!isRandomed) {
				interval = Random.Range (4f, 7f);
				isRandomed = true;
			} else if(Time.fixedTime - lastTime >= interval){
				int rand = Random.Range (0, gObject.Length);
				if (test)
					rand = n;
				Instantiate (gObject[rand],transform.position,transform.rotation);
				lastTime = Time.fixedTime;
				isRandomed = false;
			}
		}
	}
}
