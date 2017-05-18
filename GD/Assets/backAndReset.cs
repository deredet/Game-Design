using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backAndReset : MonoBehaviour {
	private AudioSource aSource;
	// Use this for initialization
	void Start () {
		aSource =	GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick(){
		aSource.Play ();
		PlayerPrefs.DeleteAll ();
		StartCoroutine (delay ());
		SceneManager.LoadScene ("cutscene", LoadSceneMode.Single);
	}
	private IEnumerator delay(){
		yield return new WaitForSeconds(aSource.clip.length+0.5f);
	}
}
