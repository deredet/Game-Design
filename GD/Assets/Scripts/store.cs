using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class store : MonoBehaviour {

	public Image[] chars;
	private int pos;
	private int eq;
	private int specloots;
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
	public float[] multipliers;

	private Image charMid;
	private Image charLeft;
	private Image charRight;

	private bool[] isLocked;

	int bool2int(bool b) {
		if (b)
			return 1;
		else
			return 0;
	}

	bool int2bool(int i) {
		return (i != 0);
	}

	// Use this for initialization
	void Start () {
		
		eq = PlayerPrefs.HasKey("Equipped") ? PlayerPrefs.GetInt("Equipped") : 0;
		pos = eq;
		specloots = PlayerPrefs.HasKey("Special") ? PlayerPrefs.GetInt ("Special") : 0;
		charMid = GameObject.Find("charsMid").GetComponent<Image>();
		charLeft = GameObject.Find("charsLeft").GetComponent<Image>();
		charRight = GameObject.Find("charsRight").GetComponent<Image>();
		charLocked.enabled = false;
		isLocked = new bool[chars.Length];
		isLocked [0] = false;
		for (int i = 1; i < chars.Length; i++) {
			isLocked [i] = PlayerPrefs.HasKey("Chars" + i) ? int2bool(PlayerPrefs.GetInt("Chars" + i)) : true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// do char selection
		charMid.sprite = chars[pos].sprite;
		charLocked.enabled = isLocked [pos];
		charMid.color = isLocked[pos] ? new Color(0.5f, 0.5f, 0.5f, 1f) : new Color(1f, 1f, 1f, 1f);
			
		coinText.text = specloots.ToString();
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
			desc.text = "\n" + prices[pos] + " special loots";
			desc.color = new Color((float)225/255, (float)144/255, (float)45/255, 1f);
			desc.alignment = TextAnchor.UpperCenter;
		}
		outfit.text = outfits [pos] + "\n(Score x" + multipliers[pos] + ")";
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
		PlayerPrefs.SetInt ("Equipped", eq);
		PlayerPrefs.SetFloat ("Multiplier", multipliers[eq]);
	}

	public void buyPressed() {
		// if duit cukup
		if (specloots >= prices [pos]) {
			specloots -= prices [pos];
			PlayerPrefs.SetInt ("Special", specloots);
			PlayerPrefs.SetFloat ("Multiplier", multipliers[pos]);
			PlayerPrefs.Save ();
			isLocked [pos] = false;
			PlayerPrefs.SetInt ("Chars" + pos, bool2int(false));
			eq = pos;
			PlayerPrefs.SetInt ("Equipped", eq);
		}
	}
}
