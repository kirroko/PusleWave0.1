using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {

	public CharacterMovement theplayerRig;

//	private Vector3 lastPlayerPosition;
//
//	private float distancetoMoveX;
//	private float distancetoMoveY;

    public float smoothTransition;
//	public float clampMinY;
//	public float clampMaxY;
//
//	public float clampMinX;
//	public float clampMaxX;

	// Use this for initialization
	void Start () 
	{
		theplayerRig = FindObjectOfType<CharacterMovement> ();
		//lastPlayerPosition = theplayerRig.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

        transform.position = Vector3.Lerp(transform.position, new Vector3(theplayerRig.transform.position.x, theplayerRig.transform.position.y, transform.position.z), Time.deltaTime * smoothTransition);
        /*
		distancetoMoveX = theplayerRig.transform.position.x - lastPlayerPosition.x;
		distancetoMoveY = theplayerRig.transform.position.y - lastPlayerPosition.y;
		transform.position = new Vector3((transform.position.x + distancetoMoveX),(transform.position.y + distancetoMoveY), transform.position.z);
		lastPlayerPosition = theplayerRig.transform.position;
        */

		//Clamp on Y-axis for camera
		//transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, clampMinY,clampMaxY),transform.position.z);

		//Clamp on X-axis for camera
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x,clampMinX,clampMaxX), transform.position.y,transform.position.z);


	}
}
