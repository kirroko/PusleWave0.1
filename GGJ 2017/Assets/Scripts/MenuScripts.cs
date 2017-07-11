using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour {

    public GameObject panel;
    public AudioClip Click;
    public AudioClip Click2;
    public AudioClip Click3;
    public AudioClip BackClick;
    
    bool PB;

    // Use this for initialization
    void Start ()
    {
        PB = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void StartGame()
    {
        SoundManager.instance.PlaySingle(Click);
        SceneManager.LoadScene("LevelSelector");
    }
    public void Exit()
    {
        SoundManager.instance.PlaySingle(BackClick);
        Application.Quit();
    }
    public void ReturntoMainMenu()
    {
        SoundManager.instance.PlaySingle(Click);
        SoundManager.instance.PlayBuildUp();
        SoundManager.instance.PlayerDeath = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void ReturnToLevelSelector()
    {
        SoundManager.instance.PlaySingle(Click2);
        SoundManager.instance.PlayBuildUp();
        SoundManager.instance.PlayerDeath = false;
        SceneManager.LoadScene("LevelSelector");
    }
    public void To1stLevel()
    {
        SoundManager.instance.PlaySingle(Click);
        if(SoundManager.instance.LevelEnded)
        {
            SoundManager.instance.musicSource.clip = SoundManager.instance.buildUP;
            SoundManager.instance.PlayerDeath = false;
            SoundManager.instance.LevelEnded = false;
        }
        SceneManager.LoadScene("Level1");
    }
    public void To2ndLevel()
    {
        SoundManager.instance.PlaySingle(Click);
        SoundManager.instance.PlayerDeath = false;
        SoundManager.instance.LevelEnded = false;
        SceneManager.LoadScene("Level2");
    }
    public void ToBossLevel()
    {
        SoundManager.instance.PlaySingle(Click);
        SoundManager.instance.LevelEnded = false;
        SceneManager.LoadScene("BossLevel");
    }
    public void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        print("playerPref has been deleted");
    }
    public void SETplayerprefTo2()
    {
        PlayerPrefs.SetInt("Unlock", 2);
        print("playerPref has been set to 2");
    }
    public void instruction()
    {
        if (PB == false)
        {
            panel.gameObject.SetActive(true);
            PB = true;
        }
        else
        {
            panel.gameObject.SetActive(false);
            PB = false;
        }
    }

	public void ResetCurrentHighScore()
	{
		PlayerPrefs.DeleteKey ("HighscoreCurrent");
	}
}
