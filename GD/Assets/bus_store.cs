using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bus_store : MonoBehaviour {

	private int coins;
	private int starWheel;
	private int starBus;
	private int starFuel;

	public Sprite star_on;
	public Sprite star_off;

	public GameObject starsWheel;
	public GameObject starsBus;
	public GameObject starsFuel;

	public Text priceWheel;
	public Text priceBus;
	public Text priceFuel;
	public Text coinText;

	// Use this for initialization
	void Start () {
		
		coins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt ("Coins") : 2000;
		starWheel = PlayerPrefs.HasKey("Wheels") ? PlayerPrefs.GetInt("Wheels") : 0;
		starBus = PlayerPrefs.HasKey("Buses") ? PlayerPrefs.GetInt("Buses") : 0;
		starFuel = PlayerPrefs.HasKey("Fuels") ? PlayerPrefs.GetInt("Fuels") : 0;

	}
	
	// Update is called once per frame
	void Update () {
		Image[] im;
		im = starsWheel.GetComponentsInChildren<Image> ();
		for (int i = 0; i < 3; i++) {
			im[i].sprite = (i < starWheel) ? star_on : star_off;
		}
		im = starsBus.GetComponentsInChildren<Image> ();
		for (int i = 0; i < 3; i++) {
			im[i].sprite = (i < starBus) ? star_on : star_off;
		}
		im = starsFuel.GetComponentsInChildren<Image> ();
		for (int i = 0; i < 3; i++) {
			im[i].sprite = (i < starFuel) ? star_on : star_off;
		}

		coinText.text = coins.ToString ();
		priceWheel.text = (starWheel < 3) ? ((starWheel + 1) * 100).ToString() : "";
		priceBus.text = (starBus < 3) ? ((starBus + 1) * 100).ToString() : "";
		priceFuel.text = (starFuel < 3) ? ((starFuel + 1) * 100).ToString() : "";
	}

	public void backPressed() {
		PlayerPrefs.SetInt ("Coins", coins);
		PlayerPrefs.SetInt ("Wheels", starWheel);
		PlayerPrefs.SetInt ("Buses", starBus);
		PlayerPrefs.SetInt ("Fuels", starFuel);
		PlayerPrefs.Save ();
		SceneManager.LoadScene ("store_selection", LoadSceneMode.Single);
	}

	public void upgradePressed(int n) {
		switch (n) {
		case 0:
			if (coins >= (starWheel + 1) * 100) {
				coins -= (starWheel + 1) * 100;
				starWheel++;
				starWheel = Mathf.Min (starWheel, 3);
			}
			break;
		case 1:
			if (coins >= (starBus + 1) * 100) {
				coins -= (starBus + 1) * 100;
				starBus++;
				starBus = Mathf.Min (starBus, 3);
			}
			break;
		case 2:
			if (coins >= (starFuel + 1) * 100) {
				coins -= (starFuel + 1) * 100;
				starFuel++;
				starFuel = Mathf.Min (starFuel, 3);
			}
			break;
		}
	}
}
