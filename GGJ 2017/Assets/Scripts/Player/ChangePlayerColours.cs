using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerColours : MonoBehaviour {

	public Sprite[] playerSprites;
	public enum colour{Blue, Green, Red, Yellow};
	public colour spriteColour;
	public SpriteRenderer playerCurrentSprite;
	public TrailRenderer playerTrail;

	// Use this for initialization
	void Start ()
	{
		playerCurrentSprite = GetComponent<SpriteRenderer> ();
		playerTrail = GetComponent<TrailRenderer> ();
		spriteColour = colour.Blue;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("PreviousColour")) {
			if ((int)spriteColour - 1 < 0) {
				spriteColour = colour.Yellow;
			} else {
				spriteColour = spriteColour - 1;
			}
		} else if (Input.GetButtonDown ("NextColour")) {
			if ((int)spriteColour + 1 > 3) {
				spriteColour = colour.Blue;
			} else {
				spriteColour = spriteColour + 1;
			}
		}

		if (Input.GetButtonDown ("ChangeToBlue")) {
			spriteColour = colour.Blue;
		} else if (Input.GetButtonDown ("ChangeToGreen")) {
			spriteColour = colour.Green;
		} else if (Input.GetButtonDown ("ChangeToRed")) {
			spriteColour = colour.Red;
		} else if (Input.GetButtonDown ("ChangeToYellow")) {
			spriteColour = colour.Yellow;
		}

		playerCurrentSprite.sprite = playerSprites [(int)spriteColour];

		GetComponent<ShootingMechnics> ().bulletType = (ShootingMechnics.bulletColourType)((int)spriteColour);
		Color trailColour = playerTrail.material.color;

		switch (spriteColour) {
		case colour.Blue:
			trailColour = new Color32 (50,255,255,255);
			break;

		case colour.Green:
			trailColour = new Color32 (50,255,50,255);
			break;

		case colour.Red:
			trailColour = new Color32 (255,50,50,255);
			break;

		case colour.Yellow:
			trailColour = new Color32 (255,255,50,255);
			break;
		}

		playerTrail.material.color = trailColour;

	}
}
