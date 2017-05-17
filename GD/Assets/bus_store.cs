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
	public int[] priceBus;
	public int[] priceWheel;
	public int[] priceFuel;
	public string[] textBus;
	public string[] textWheel;
	public string[] textFuel;

	public Sprite star_on;
	public Sprite star_off;

	public GameObject starsWheel;
	public GameObject starsBus;
	public GameObject starsFuel;

	public Text tPriceWheel;
	public Text tPriceBus;
	public Text tPriceFuel;
	public Text coinText;
	public Text tWheel;
	public Text tBus;
	public Text tFuel;
	public Text tSpeed;
	public Text tArmor;
	public Text tLifetime;

	// Use this for initialization
	void Start () {
		coins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt ("Coins") : 0;
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
		tPriceWheel.text = (starWheel < 3) ? priceWheel[starWheel].ToString() : "";
		tPriceBus.text = (starBus < 3) ? priceBus[starBus].ToString() : "";
		tPriceFuel.text = (starFuel < 3) ? priceFuel[starFuel].ToString() : "";
		tWheel.text = textWheel [starWheel].ToString();
		tBus.text = textBus [starBus].ToString();
		tFuel.text = textFuel [starFuel].ToString();

		tSpeed.text = "Speed : 100% + " + starWheel * 100 / 3 + "% bonus";
		tArmor.text = "Armor : 100% + " + starBus * 100 / 3 + "% bonus";
		tLifetime.text = "Lifetime : 100% + " + starFuel * 100 / 3 + "% bonus";
	}

	public void backPressed() {
		PlayerPrefs.SetInt ("Coins", coins);
		PlayerPrefs.SetInt ("Wheels", starWheel);
		PlayerPrefs.SetInt ("Buses", starBus);
		PlayerPrefs.SetInt ("Fuels", starFuel);		SceneManager.LoadScene ("store_selection", LoadSceneMode.Single);
	}

	public void upgradePressed(int n) {
		switch (n) {
		case 0:
			if (coins >= priceWheel[starWheel]) {
				coins -= priceWheel[starWheel];
				starWheel++;
				starWheel = Mathf.Min (starWheel, 3);
			}
			break;
		case 1:
			if (coins >= priceBus[starBus]) {
				coins -= priceBus[starBus];
				starBus++;
				starBus = Mathf.Min (starBus, 3);
			}
			break;
		case 2:
			if (coins >= priceFuel[starFuel]) {
				coins -= priceFuel[starFuel];
				starFuel++;
				starFuel = Mathf.Min (starFuel, 3);
			}
			break;
		}
	}
}
