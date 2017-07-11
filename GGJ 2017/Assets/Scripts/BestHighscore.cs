using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestHighscore : MonoBehaviour {
	
	public Text finalScoreText;

	// Use this for initialization
	void Start () {
		finalScoreText = GetComponent<Text> ();
		finalScoreText.text = "Highscore: " +PlayerPrefs.GetInt ("HighscoreCurrent", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		finalScoreText = GetComponent<Text> ();
		finalScoreText.text = "Highscore: " +PlayerPrefs.GetInt ("HighscoreCurrent", 0).ToString();
	}
}
