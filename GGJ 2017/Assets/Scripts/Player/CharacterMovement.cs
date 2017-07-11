using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public float playerSpeed;
	public Rigidbody2D playerRig;

	// Use this for initialization
	void Start ()
	{
		playerRig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<HealthBar> ().health > 0)
		{
			playerRig.velocity = new Vector2 (Input.GetAxis("Horizontal")*playerSpeed, Input.GetAxis("Vertical")*playerSpeed);
		}
		else
		{
			playerRig.velocity = new Vector2 (0, 0);
		}
	}
}
