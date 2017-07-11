using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public int health = 50;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    public Transform Target;

    public GameObject deathAudio;

    public float speed;

    public enum enemyColourType { Blue, Green, Red, Yellow };
    public enemyColourType enemyColour;

    // Use this for initialization
    void Start () {
        GameObject type1 = GameObject.FindGameObjectWithTag("Player");
        Target = type1.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        healthUI();
		CheckHealth ();
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * speed);
    }

    void healthUI()
    {
        if (health <= 50 && health >= 41)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(true);
        }
        else if(health <= 40 && health >= 31)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(false);
        }
        else if (health <= 30 && health >= 21)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
        }
        else if (health <= 20 && health >= 11)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
        }
        else if (health <= 10 && health >= 1)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
        }
        else
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver(YouWon)");
        }
    }

	void CheckHealth()
	{
		if (health <= 0)
		{
			Instantiate (deathAudio, transform.position, Quaternion.identity);
		}
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
       // print(obj.gameObject.tag);
		if (obj.gameObject.tag == "Player")
        {
			obj.GetComponent<HealthBar> ().health -= 1;
        }
    }
}
