using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	public static Highscore instance;
	public int score;
	public int showScore;
	public float increaseRate;
	public bool canGetBonus;
	public int bonus;
	public float bonusTimer;
	private float originalBonusTime;
	public Text highscoreText;

	// Use this for initialization
	void Start ()
	{
		if (instance == null) {
			instance = GetComponent<Highscore> ();
			originalBonusTime = bonusTimer;
			DontDestroyOnLoad (gameObject);
		} else {
			if (instance != GetComponent<Highscore> ())
			{
				Destroy (gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		showScore = (int) Mathf.SmoothStep ((float)showScore, (float)score, Time.deltaTime * increaseRate); //(int)Mathf.Lerp ((float)showScore, (float)score, Time.deltaTime*increaseRate);

		if (highscoreText != null)
		{
			highscoreText.text = "Score: " + showScore.ToString();
		}
		else
		{
			if (GameObject.Find ("HighScoreText").GetComponent<Text> () != null) {
				highscoreText = GameObject.Find ("HighScoreText").GetComponent<Text>();
			}
		}

		if (canGetBonus == true) {
			bonusTimer -= Time.deltaTime;
		}

		if (bonusTimer <= 0) {
			canGetBonus = false;
			bonusTimer = originalBonusTime;
			bonus = 0;
		}
	}

	public void AddToScore(int addition)
	{
		score += (addition + bonus);
		canGetBonus = true;
		bonus++;
	}
}
