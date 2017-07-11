using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public Transform player;
	public Vector3 mousePos;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		if (GetComponent<HealthBar> ().health > 0) {
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
