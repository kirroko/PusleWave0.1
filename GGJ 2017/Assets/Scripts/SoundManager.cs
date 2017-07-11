using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource efxSource;
    public AudioSource musicSource;
    public AudioClip buildUP;
    public AudioClip Looped;
    public AudioClip LevelSelect;
    public AudioClip Outro;
    public AudioClip ScrectClip;
    public AudioClip PlayerHit;
    public bool PlayerDeath;
    public bool LevelEnded;
    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;


    void Awake ()
    {
        if (instance == null)
            instance = GetComponent<SoundManager>();
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}
	
    // to call from another script to play clip SINGLE
    public void PlaySingle (AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }
    public void PlayBuildUp()
    {
        musicSource.clip = buildUP;
        musicSource.Play();
        musicSource.loop = false;
    }
    public void PlayLevelSelect ()
    {
        musicSource.clip = LevelSelect;
        musicSource.Play();
    }
    public void RandomizeSfx (params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }
	
    void Update()
    {
        if (!musicSource.isPlaying && !PlayerDeath)
        {
            musicSource.clip = Looped;
            musicSource.Play();
            musicSource.loop = true;
        }

        if (Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            musicSource.clip = ScrectClip;
            musicSource.Play();
        }
        //else if (musicSource.clip = Looped /* && outro boolean to true*/)
        //{
          //  musicSource.clip = Outro;
            //musicSource.Play();
            //musicSource.loop = false;
        //}
        
    }
}
