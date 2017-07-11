using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Transform Target;

    public GameObject BullletWaves;
	public GameObject deathAudio;
    public GameObject playerHit;
	public GameObject DeathParticle;

    public HealthBar HB;

    public float speed;
    public float rotationSpeed;

	public enum enemyColourType {Blue, Green, Red, Yellow};
	public enemyColourType enemyColour;
    
	public int scoreWorth;
	private bool touchPlayer;

    void Awake()
    {

    }
	// Use this for initialization
	void Start ()
    {
        HB = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
        GameObject type1 = GameObject.FindGameObjectWithTag("Player");
        Target = type1.GetComponent<Transform>();
    }

    
	
	// Update is called once per frame
	void Update ()
    {
       /* Vector3 dir = Target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

//        if(Vector3.Distance(transform.position,Target.position)>1f) // Move to target if distance more then 1
//        {
		if (Target.GetComponent<CircleCollider2D> ().enabled == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * speed);	
		}
//        }
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
		if (obj.gameObject.tag == "Bullet")
		{
			if ((int)obj.GetComponent<ProjectileCode> ().projectileColour == (int)enemyColour)
			{
				Instantiate (deathAudio, transform.position, Quaternion.identity);
				Destroy(obj.gameObject);
				Destroy (gameObject);
			}
        }
        if (obj.gameObject.tag == "Player")
        {
            int health = HB.health--;
            print("poi");
			touchPlayer = true;
			Instantiate (DeathParticle, transform.position, Quaternion.identity);
            Instantiate(playerHit, transform.position, Quaternion.identity);
			Camera.main.GetComponent<CameraScript> ().ShakeCamera (0.5f, 0.5f);
            Destroy(gameObject);
        }
        /*
        // Delete col bullet
        Destroy(obj.gameObject);

        //  Delete enemy
        Destroy(gameObject);

        // GameManager???
		*/
    }

	void OnDestroy()
	{
		if (!touchPlayer) {
			Highscore.instance.AddToScore (scoreWorth);
		}
	}
}
