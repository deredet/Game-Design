using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class store_selection : MonoBehaviour {

	private AudioSource aSource;
	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void busPressed() {
		aSource.Play ();
		StartCoroutine (delay ());
		SceneManager.LoadScene ("bus_store", LoadSceneMode.Single);
	}

	public void ujangPressed() {
		aSource.Play ();
		StartCoroutine (delay ());
		SceneManager.LoadScene ("ujang_store", LoadSceneMode.Single);
	}

	public void backPressed() {
		aSource.Play ();
		StartCoroutine (delay ());
		SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
	}
	private IEnumerator delay(){
		yield return new WaitForSeconds (aSource.clip.length + 0.5f);
	}
}
