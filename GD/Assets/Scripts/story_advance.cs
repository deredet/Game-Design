using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class story_advance : MonoBehaviour {
	public GameObject[] story_object;
	public GameObject[] text_object;
	private int story_index = 0;
	private bool isReset = false;
	private AudioSource aSource;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isReset) {
			PlayerPrefs.DeleteAll ();
			isReset = false;
		}
		for (int i = 0; i < story_index; i++) {
			GameObject component = story_object[i];
			if (component != null) {
				Image im = component.GetComponent<Image>();
				Color c = im.color;
				c.a = 0;
				c[3] = 0;
				im.color = c;
			}
			GameObject component1 = text_object[i];
			if (component != null) {
				Image img = component1.GetComponent<Image>();
				Color d = img.color;
				d.a = 0;
				d[3] = 0;
				img.color = d;
			}
		}
	}

	public void buttonClick () {
		aSource.Play ();
		if (story_index < 2) {
			story_index++;
		} else {
			StartCoroutine (delay ());
			SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
		}
	}


	private IEnumerator delay(){
		yield return new WaitForSeconds(aSource.clip.length+0.5f);
	}
	public void reset () {
		aSource.Play ();
		isReset = true;
	}
}
