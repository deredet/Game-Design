using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class story_advance : MonoBehaviour {
	public int story_index = 1;

	// Use this for initialization
	void Start () {
		story_index = 1;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i < story_index; i++) {
			GameObject component = GetObject (i);
			if (component != null) {
				SpriteRenderer sr = component.GetComponent (typeof(SpriteRenderer)) as SpriteRenderer;
				Color c = sr.color;
				c.a = 0;
				c[3] = 0;
				sr.color = c;
				//Debug.LogFormat (string.Format ("{0}: {1}",sr.ToString (), c.ToString ()));
			}
		}
	}

	private GameObject GetObject() {
		return GetObject (story_index);
	}

	private GameObject GetObject(int index) {
		return GameObject.Find(string.Format("story{0}",index));
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
