using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPulser : MonoBehaviour {

    public GameObject bullets;
    public Transform firingPosition;

	public enum enemyColourType {Blue, Green, Red, Yellow};
	public enemyColourType enemyColour;

	public GameObject deathAudio;
	public GameObject DeathParticle;
    public float speed;

    bool start;

	public bool touchPlayer;
	public int scoreWorth;

	// Use this for initialization
	void Start () {
        start = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(start == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * -speed);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -speed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "")
        {
            start = false;
        }
        else
        {
            start = true;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			Instantiate (DeathParticle, transform.position, Quaternion.identity);
			touchPlayer = true;

            InvokeRepeating("Shoot", 0.9f, 1.615f);
        }
    }

   void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            CancelInvoke();
        }
    }

    void Shoot()
    {
        Instantiate(bullets, firingPosition.position, transform.rotation);
    }

	void OnDestroy()
	{
		if (!touchPlayer) {
			Highscore.instance.AddToScore (scoreWorth);
		}
	}
}
