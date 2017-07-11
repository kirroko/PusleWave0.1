using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetInteger ("Health", GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>().health);
	}
}
