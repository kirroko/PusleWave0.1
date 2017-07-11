using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
        SceneManager.LoadScene("");
    }

    public void retry()
    {
        SceneManager.LoadScene("");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("");
    }

    public void quit()
    {
        Application.Quit();
    }
}
