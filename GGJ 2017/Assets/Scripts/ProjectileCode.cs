using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCode : MonoBehaviour {
    public float Speed;
    private Rigidbody2D ProjectileRigid;
	public enum projectileColourType {Blue, Green, Red, Yellow};
	public projectileColourType projectileColour;
	private SpriteRenderer bulletSprite;
	public Color32[] bulletColours;
    public AudioClip shootSound;
    public CameraScript CS;

    // Use this for initialization
    void Start ()
    {
		bulletSprite = GetComponent<SpriteRenderer> ();
        ProjectileRigid = GetComponent<Rigidbody2D>();
        SoundManager.instance.PlaySingle(shootSound);
        CS = Camera.main.transform.GetComponent<CameraScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		bulletSprite.color = bulletColours[(int)projectileColour];

        ProjectileRigid.velocity = transform.right * Speed;
	}
    /*void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "ProjectileBoundary")
        {
            //print("i return to the void");
            Destroy(gameObject);
        }
    }*/
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
			if (other.GetComponent<EnemyChaser> () != null)
			{
				if ((int)other.GetComponent<EnemyChaser> ().enemyColour == (int)projectileColour) {
					Instantiate (other.GetComponent<EnemyChaser>().DeathParticle, other.transform.position, Quaternion.identity);
					Instantiate (other.GetComponent<EnemyChaser>().deathAudio, other.transform.position, Quaternion.identity);
					Destroy (other.gameObject);
					Destroy (gameObject);
                    CS.ShakeCamera(0.05f, 1);
				}
			} 
			else if (other.GetComponent<EnemyPulser> () != null)
			{
				if ((int)other.GetComponent<EnemyPulser> ().enemyColour == (int)projectileColour) {
					Instantiate (other.GetComponent<EnemyPulser>().deathAudio, other.transform.position, Quaternion.identity);
					Destroy (other.gameObject);
					Destroy (gameObject);
                    CS.ShakeCamera(0.05f, 1);
				}
			}
            else if (other.GetComponent<Boss>() != null)
            {
                if ((int)other.GetComponent<Boss>().enemyColour == (int)projectileColour)
                {
					other.GetComponent<Boss> ().health -= 1;
                    Destroy(gameObject);
                    CS.ShakeCamera(0.1f, 1);
                    //Instantiate(other.GetComponent<Boss>().deathAudio, other.transform.position, Quaternion.identity);
                    //Destroy(other.gameObject);
                }
            }
        }
        if (other.gameObject.tag == "ProjectileBoundary")
        {
            //print("i return to the void");
            Destroy(gameObject);
        }
    }
}
