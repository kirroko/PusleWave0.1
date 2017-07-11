﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData mouse)
	{
		anim.SetBool ("Highlighted", true);
	}
	public void OnPointerExit(PointerEventData mosue)
	{
		anim.SetBool ("Highlighted", false);
	}
}
