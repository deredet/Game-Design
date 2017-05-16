using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
	public Image timer;
	public Text tScore;
	public Text tSpecScore;
	public bool grounded = true;
	public bool alive = true;
	public int coinScore = 10;
	public int specialScore = 20;
	public float moveSpeed = 2;
	public float jumpPower = 2;
	public float maxSpeed = 2;
	public float timeDamage = 50f;
	public float maxTime = 100f;
	public GameObject popupfail;
	public GameObject popupwin;
	public GameObject spawner;

	private float successTime = 0f;
	private GameObject tGO;
	private float curTime = 0f;
	private int score = 0;
	private int sScore = 0;
	private Rigidbody2D r2D;
	private Animator anim;

	// Use this for initialization
	void Start () {
		r2D = transform.GetComponent<Rigidbody2D> ();
		curTime = maxTime;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			r2D.AddForce (Vector2.right * moveSpeed, ForceMode2D.Force);
			if (r2D.velocity.magnitude > maxSpeed)
				r2D.velocity = r2D.velocity.normalized * maxSpeed;
			curTime -= Time.deltaTime;
			successTime += Time.deltaTime;
			timer.fillAmount = curTime / maxTime;
			if (curTime < maxTime / 2)
				timer.color = Color.Lerp (Color.red, Color.yellow, curTime*2/maxTime);
			else
				timer.color = Color.Lerp (Color.yellow, Color.green, (curTime - (maxTime/2)) * 2 /maxTime);
			tScore.text = "" + score;
			tSpecScore.text = "" + sScore;
			if (curTime <= 0) {
				alive = false;
			}
		} else {
			r2D.velocity = r2D.velocity.normalized * 0;

			if (successTime >= 10f)
				popupwin.SetActive (true);
			else
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
			r2D.velocity = r2D.velocity;
		}
	}

	public void horn (){
		tGO = GameObject.Find ("telolet1(Clone)");
		if(tGO == null)
			tGO = GameObject.Find ("telolet2(Clone)");
		if (tGO != null) {
			Destroy (tGO);
			increaseTimer (timeDamage);
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
		score += num;
	}

	public void increaseSpecialScore (int num){
		sScore += num;
	}
}
