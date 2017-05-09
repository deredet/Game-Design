using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class story_advance : MonoBehaviour {
	public int story_index = 1;
	private Text[] texts = new Text[5];

	// Use this for initialization
	void Start () {
		LoadText ();
		story_index = 1;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i < story_index; i++) {
			GameObject component = GetObject (i);
			if (component != null) {
				Image im = component.GetComponent<Image>();
				Color c = im.color;
				c.a = 0;
				c[3] = 0;
				im.color = c;
				//Debug.LogFormat (string.Format ("{0}: {1}",sr.ToString (), c.ToString ()));
			}
		}

		for (int i = 1; i < texts.Length; i++) {
			if (i == story_index) {
				texts[i].enabled = true;
			} else {
				texts[i].enabled = false;
			}
		}
	}

	private GameObject GetObject() {
		return GetObject (story_index);
	}

	private GameObject GetObject(int index) {
		return GameObject.Find(string.Format("story{0}",index));
	}

	private void LoadText() {
		for (int i = 1; i < texts.Length; i++) {
			texts[i] = GameObject.Find(string.Format("Text{0}",i)).GetComponent<Text>();
		}
	}

	public void buttonClick () {
		story_index++;
		GameObject component = GetObject ();
		if (!component) {
			SceneManager.LoadScene ("main_menu", LoadSceneMode.Single);
			return;
		}
	}
}
