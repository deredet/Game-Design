using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class store_selection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void busPressed() {
		SceneManager.LoadScene ("bus_store", LoadSceneMode.Single);
	}

	public void ujangPressed() {
		SceneManager.LoadScene ("ujang_store", LoadSceneMode.Single);
	}

	public void backPressed() {
		SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
	}
}
