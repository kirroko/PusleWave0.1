using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public int health = 5;

    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;
    public Image health5;
    public AudioClip deathAudio;
    public bool deathPlayed;

	private ChangePlayerColours changePlayerColours;
	private Animator animator;

    // Use this for initialization
    void Start () {
		changePlayerColours = GetComponent<ChangePlayerColours> ();
		animator = GetComponent<Animator> ();
		animator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        healthUI();
        if (health <= 0)
        {
            if (!deathPlayed)
            {
                print("NanoDesu");
                SoundManager.instance.PlaySingle(deathAudio);
                SoundManager.instance.musicSource.Stop();
                SoundManager.instance.PlayerDeath = true;
                deathPlayed = true;
            }
			GetComponent<CircleCollider2D> ().enabled = false;
			//SceneManager.LoadScene("GameOver(YouLose)");

        }

//		if(Input.GetKeyDown(KeyCode.Space)){
//			deathAnim ();
//		}
    }

    void healthUI()
    {
		/*
        switch (health)
        {
		case 0:
			health1.enabled = false;
			health2.enabled = false;
			health3.enabled = false;
			health4.enabled = false;
			health5.enabled = false;
                StartCoroutine(waitToMoveScene());
                break;

            case 1:
                health1.enabled = true;
                health2.enabled = false;
                health3.enabled = false;
                health4.enabled = false;
                health5.enabled = false;
                break;

            case 2:
                health1.enabled = true;
                health2.enabled = true;
                health3.enabled = false;
                health4.enabled = false;
                health5.enabled = false;
                break;

            case 3:
                health1.enabled = true;
                health2.enabled = true;
                health3.enabled = true;
                health4.enabled = false;
                health5.enabled = false;
                break;

            case 4:
                health1.enabled = true;
                health2.enabled = true;
                health3.enabled = true;
                health4.enabled = true;
                health5.enabled = false;
                break;

            case 5:
                health1.enabled = true;
                health2.enabled = true;
                health3.enabled = true;
                health4.enabled = true;
                health5.enabled = true;
                break;
        }
        */

		if (health <= 0) {
			StartCoroutine(waitToMoveScene());
		}
    }

	void deathAnim()
	{
		animator.enabled = true;
		animator.SetInteger ("SpriteColour", (int)changePlayerColours.spriteColour);
	}

	IEnumerator waitToMoveScene()
	{
        deathAnim();
        yield return new WaitForSeconds (3.0f);
        SoundManager.instance.musicSource.clip = SoundManager.instance.Outro;
        SoundManager.instance.musicSource.Play();
		PlayerPrefs.SetInt ("HighscoreCurrent", Highscore.instance.score);
		SceneManager.LoadScene("GameOver(YouLose)");
	}

}
