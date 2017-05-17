using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_script : MonoBehaviour {
	private AudioSource click;
	// Use this for initialization
	void Start () {
		click = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScene(string sceneName){
		click.Play();
		StartCoroutine (delay());
		SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
	}

	private IEnumerator delay(){
		yield return new WaitForSeconds (click.clip.length+0.2f);
	}
}
