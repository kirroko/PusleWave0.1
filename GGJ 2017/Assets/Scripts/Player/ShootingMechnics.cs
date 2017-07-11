using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechnics : MonoBehaviour {
    public GameObject FiredProjectile;
    public GameObject BulletSPWNPoint;
    public GameObject BlastProjectiles;
    public GameObject fireTwo;
	public enum bulletColourType{Blue, Green, Red, Yellow};
	public bulletColourType bulletType;

    public float shotdelay;
    public float blastdelay;
    public bool canSchuut;
    public bool canBlast;
	// Use this for initialization
	void Start ()
    {
        canSchuut = true;
        canBlast = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButton("Fire1") && canSchuut ==true && GetComponent<CircleCollider2D>().enabled == true)
        {
            GameObject obj = Instantiate(FiredProjectile,BulletSPWNPoint.transform.position,transform.rotation);
			obj.GetComponent<ProjectileCode> ().projectileColour = (ProjectileCode.projectileColourType)((int)bulletType);
            canSchuut = false;
            StartCoroutine(countdown(shotdelay));
        }
		if (Input.GetButton("Fire2")&& canBlast == true && GetComponent<CircleCollider2D>().enabled == true)
        {
			GameObject obj = Instantiate(BlastProjectiles, BulletSPWNPoint.transform.position, transform.rotation);
            Instantiate(fireTwo, transform.position, Quaternion.identity);
            foreach (Transform child in obj.transform)
            {
                child.GetComponent<ProjectileCode>().projectileColour = (ProjectileCode.projectileColourType)((int)bulletType);
            }

            canBlast = false;
            StartCoroutine(countdown(blastdelay));
        }
	}

    IEnumerator countdown(float time)
    {
        yield return new WaitForSeconds(time);
        canSchuut = true;
        canBlast = true;
    }
    
}
