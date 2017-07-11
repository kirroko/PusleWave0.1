using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressGating : MonoBehaviour {
    public GameObject L2Btn;
    public GameObject BossBtn;
	// Use this for initialization
	void Start ()
    {
        L2Btn.SetActive(false);
        BossBtn.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerPrefs.GetInt("Unlock") >= 2)
        {
            L2Btn.SetActive(true);
            BossBtn.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Unlock") >= 1)
        {
            L2Btn.SetActive(true);
        }
	}
}
