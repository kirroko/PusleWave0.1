using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDieOut : MonoBehaviour {
    public float lifespan;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //lifespan -= Time.deltaTime;
        lifespan--;
        if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
	}
}
