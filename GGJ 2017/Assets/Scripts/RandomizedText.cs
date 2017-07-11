using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizedText : MonoBehaviour {

	public Text textBox;
	public string[] LoseText;
	public string[] WinText;
	public int randomLose;
	public int randomWin;
	public bool win;

	// Use this for initialization
	void Start ()
	{
		randomLose = Random.Range (0, LoseText.Length);
		randomWin = Random.Range (0, WinText.Length);

		if (win)
		{
			if (WinText.Length > 1) {
				textBox.text = WinText[randomWin];
			}
			else
			{
				textBox.text = WinText[0];
			}
		}
		else
		{
			if (LoseText.Length > 1) {
				textBox.text = LoseText [randomLose];
			} else {
				textBox.text = LoseText [0];
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
