using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class store : MonoBehaviour {

	public Image[] chars;
	private int pos;
	private int eq;
	private int coins;
	public Image charLocked;

	public Text title;
	public Text desc;
	public Text outfit;
	public Text coinText;

	public GameObject[] equipStatuses;

	public GameObject equips;
	private int equipStatus;

	public string[] titles;
	public string[] descs;
	public string[] outfits;
	public int[] prices;

	private Image charMid;
	private Image charLeft;
	private Image charRight;

	private bool[] isLocked;


	// Use this for initialization
	void Start () {
		pos = 0;
		eq = 0;
		PlayerPrefs.SetInt ("Coins", 400);
		coins = PlayerPrefs.GetInt ("Coins");
		charMid = GameObject.Find("charsMid").GetComponent<Image>();
		charLeft = GameObject.Find("charsLeft").GetComponent<Image>();
		charRight = GameObject.Find("charsRight").GetComponent<Image>();
		charLocked.enabled = false;
		isLocked = new bool[chars.Length];
		isLocked [0] = false;
		isLocked [1] = false;
		for (int i = 2; i < chars.Length; i++) {
			isLocked [i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// do char selection
		charMid.sprite = chars[pos].sprite;
		charLocked.enabled = isLocked [pos];
		charMid.color = isLocked[pos] ? new Color(0.5f, 0.5f, 0.5f, 1f) : new Color(1f, 1f, 1f, 1f);
			
		coinText.text = coins.ToString();
		if (pos - 1 >= 0) {
			charLeft.sprite = chars [pos - 1].sprite;
			charLeft.enabled = true;
			charLeft.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
		}
		else {
			charLeft.enabled = false;
		}
		if (pos + 1 < chars.Length) {
			charRight.sprite = chars [pos + 1].sprite;
			charRight.enabled = true;
			charRight.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
		}
		else {
			charRight.enabled = false;
		}
		// do descriptions text
		if (!isLocked [pos]) {
			title.text = titles [pos];
			desc.text = descs [pos];
			desc.color = new Color (0f, 0f, 0f, 1f);
			desc.alignment = TextAnchor.UpperLeft;
		} else {
			title.text = "";
			desc.text = "\n" + prices[pos] + " coins";
			desc.color = new Color((float)225/255, (float)144/255, (float)45/255, 1f);
			desc.alignment = TextAnchor.UpperCenter;
		}
		outfit.text = outfits [pos];
		// do equip + char status
		equipStatus = isLocked[pos] ? (2) : ((eq == pos) ? 1 : 0);
		for (int i = 0; i < equipStatuses.Length; i++) {
			if (i == equipStatus)
				equipStatuses [i].SetActive (true);
			else
				equipStatuses [i].SetActive (false);
		}

	}

	void LoadChar() {
		for (int i = 1; i < chars.Length; i++) {
			chars[i] = GameObject.Find(string.Format("chars{0}",i)).GetComponent<Image>();
		}
	}

	public void leftPressed() {
		pos = (pos > 0) ? pos-1 : 0;
	}

	public void rightPressed() {
		pos = (pos < chars.Length-1) ? pos+1 : chars.Length-1;
	}

	public void backPressed() {
		SceneManager.LoadScene ("store_selection", LoadSceneMode.Single);
	}

	public void equipPressed() {
		eq = pos;
	}

	public void buyPressed() {
		// if duit cukup
		if (coins >= prices [pos]) {
			coins -= prices [pos];
			PlayerPrefs.SetInt ("Coins", coins);
			PlayerPrefs.Save ();
			isLocked [pos] = false;
		}
	}
}
