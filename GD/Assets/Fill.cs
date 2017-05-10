using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fill : MonoBehaviour {
	public float maxTime = 100f;
	private float curTime = 0f;
	private int score = 0;
	public Image timer;
	public Text tScore;
	// Use this for initialization
	void Start () {
		curTime = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		curTime -= Time.deltaTime;
		timer.fillAmount = curTime / maxTime;
		tScore.text = "Score: " + score;
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
