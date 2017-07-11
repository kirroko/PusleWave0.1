using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreGrab : MonoBehaviour {

	public Text finalScoreText;

	// Use this for initialization
	void Start ()
	{
		finalScoreText = GetComponent<Text> ();
		finalScoreText.text = "Final Score: " +PlayerPrefs.GetInt ("HighscoreCurrent", 0).ToString();

		if (PlayerPrefs.GetInt ("HighscoreCurrent", 0) > PlayerPrefs.GetInt ("BestHighscore"))
		{
			PlayerPrefs.SetInt ("BestHighscore", PlayerPrefs.GetInt ("HighscoreCurrent", 0));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
