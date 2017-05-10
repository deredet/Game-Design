using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
	public Image timer;
	public Text tScore;
	public bool grounded = true;
	public bool alive = true;
	public int coinScore = 10;
	public float moveSpeed = 2;
	public float jumpPower = 2;
	public float maxSpeed = 2;
	public float timeDamage = 50f;
	public float maxTime = 100f;


	private GameObject tGO;
	private float curTime = 0f;
	private int score = 0;
	private Rigidbody2D r2D;

	// Use this for initialization
	void Start () {
		r2D = transform.GetComponent<Rigidbody2D> ();
		curTime = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			r2D.AddForce (Vector2.right * moveSpeed, ForceMode2D.Force);
			if (r2D.velocity.magnitude > maxSpeed)
				r2D.velocity = r2D.velocity.normalized * maxSpeed;
			curTime -= Time.deltaTime;
			timer.fillAmount = curTime / maxTime;
			tScore.text = "Score: " + score;
			if (curTime <= 0) {
				alive = false;
			}
		}else
			r2D.velocity = r2D.velocity.normalized * 0;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Coin")) {
			Destroy (other.gameObject);
			increaseScore (coinScore);
		} else if (other.gameObject.CompareTag ("Obstacle")) {
			Destroy (other.gameObject);
			decreaseTimer (timeDamage);
		} else if (other.gameObject.CompareTag ("Jalan Bolong")) {
			decreaseTimer (timeDamage);
		}
	}
	public void Jump(){
		if (grounded) {
			r2D.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			r2D.AddForce(Vector2.right * moveSpeed,ForceMode2D.Force);
		}
	}

	public void horn (){
		tGO = GameObject.Find ("telolet1(Clone)");
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
}
