using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
	public Image timer;
	public Text tScore;
	public Text tSpecScore;
	public Text tdistance;
	public Text tRealScore;
	public Text tFinalScore;
	public bool grounded;
	public bool alive;
	public int coinScore;
	public int specialScore;
	public float moveSpeed;
	public float jumpPower;
	public float maxSpeed;
	public float timeDamage;
	public float maxTime;
	public GameObject popupfail;
	public GameObject popupwin;
	public GameObject spawner;
	public bool isPaused = false;

	private float initPos = 0f;
	private GameObject tGO;
	private float curTime = 0f;
	private int score = 0;
	private int sScore = 0;
	private float tempDistance = 0f;
	private int realDistance = 0;
	private int realScore = 0;
	private float tempScore;
	private float multiplier;
	private Rigidbody2D r2D;
	private Animator anim;
	private AudioSource[] sounds;
	private int timeDecrease;

	// Use this for initialization
	void Start () {
		maxSpeed = maxSpeed * (3 + (PlayerPrefs.HasKey("Wheels") ? PlayerPrefs.GetInt("Wheels") : 0))/3;
		timeDamage = timeDamage / ((PlayerPrefs.HasKey("Buses") ? PlayerPrefs.GetInt("Buses") : 0) + 1);
		timeDecrease = 4 / ((PlayerPrefs.HasKey("Fuels") ? PlayerPrefs.GetInt("Fuels") : 0) + 1);
		r2D = transform.GetComponent<Rigidbody2D> ();
		curTime = maxTime;
		anim = GetComponent<Animator> ();
		multiplier = PlayerPrefs.HasKey("Multiplier") ? PlayerPrefs.GetFloat ("Multiplier") : 1;
		initPos = transform.position.x;
		sounds = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(realDistance >= 100){
			r2D.velocity = r2D.velocity.normalized * 0;
			alive = false;
			tFinalScore.text = "" + realScore;
			popupwin.SetActive (true);
			spawner.SetActive (false);
		}
		else if (alive) {
			r2D.AddForce (Vector2.right * moveSpeed, ForceMode2D.Force);
			if (r2D.velocity.magnitude > maxSpeed)
				r2D.velocity = r2D.velocity.normalized * maxSpeed;
			curTime -= Time.deltaTime * timeDecrease;
			timer.fillAmount = curTime / maxTime;
			if (curTime < maxTime / 2)
				timer.color = Color.Lerp (Color.red, Color.yellow, curTime*2/maxTime);
			else
				timer.color = Color.Lerp (Color.yellow, Color.green, (curTime - (maxTime/2)) * 2 /maxTime);

			// distance
			tempDistance = (transform.position.x - initPos)/10;
			realDistance = (int)tempDistance;
			tdistance.text = "Distance: " + realDistance + " m";

			// coin
			tScore.text = "" + score;

			// special loot
			tSpecScore.text = "" + sScore;

			//score
			float distanceScore = realDistance * 10 * multiplier;
			realScore = (int) (tempScore + distanceScore);
			tRealScore.text = "Score: " + realScore +" (x" + multiplier + ")";

			if (curTime <= 0) {
				alive = false;
			}
		} else {
			r2D.velocity = r2D.velocity.normalized * 0;
			tFinalScore.text = "" + realScore;
			popupfail.SetActive (true);
			spawner.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Coin")) {
			increaseScore (coinScore);
		} else if (other.gameObject.CompareTag("Special")){
			increaseSpecialScore (specialScore);
		}else if (other.gameObject.CompareTag ("Obstacle")) {
			anim.SetBool ("hit", true);
			decreaseTimer (timeDamage);
			StartCoroutine (hit ());
		} 
	}

	private IEnumerator hit(){
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("hit", false);

	}
	public void Jump(){
		if (grounded) {
			grounded = false;
			r2D.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			r2D.AddForce (Vector2.right * moveSpeed, ForceMode2D.Impulse);
			sounds [0].Play();
		}
	}

	public void horn (){
		tGO = GameObject.Find ("telolet1(Clone)");
		if(tGO == null)
			tGO = GameObject.Find ("telolet2(Clone)");
		if (tGO != null) {
			Destroy (tGO);
			increaseTimer (timeDamage);
			tempScore += 50 * multiplier;
			sounds [1].Play ();
		}
	}
	public void decreaseTimer(float num){
		curTime -= num;
		if (curTime < 0f)
			curTime = 0f;
	}

	public void increaseTimer(float num){
		curTime += num;
		if (curTime > maxTime)
			curTime = maxTime;
	}

	public void increaseScore (int num){
		// coin
		score += num;

		// score
		tempScore += num * multiplier;

		// save coin
		int latestCoins = PlayerPrefs.HasKey("Coins") ? PlayerPrefs.GetInt ("Coins") : 0;
		latestCoins += num;
		PlayerPrefs.SetInt ("Coins", latestCoins);
	}

	public void increaseSpecialScore (int num){
		// special loot
		sScore += num;

		// score
		tempScore += num * 50 * multiplier;

		// save special loot
		int latestSpecloots = PlayerPrefs.HasKey("Special") ? PlayerPrefs.GetInt ("Special") : 0;
		latestSpecloots += num;
		PlayerPrefs.SetInt ("Special", latestSpecloots);
	}

	public void pause(){
		if (isPaused) {
			Time.timeScale = 1;
			isPaused = false;
			sounds [2].Play ();
		} else {
			Time.timeScale = 0;
			isPaused = true;
			sounds [2].Play ();
		}
	}
}
