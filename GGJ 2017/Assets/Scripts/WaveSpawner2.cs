using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner2 : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]


    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    public Text next;
    public float alphaLevel = 1f;
    bool fade;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public GameManager theGameManager;

    void Start()
    {

        theGameManager = GetComponent<GameManager>();

        waveCountdown = timeBetweenWaves;

        if (spawnPoints.Length == 0)
        {
            print("No Spawn point referernce");
        }
    }

    void Update()
    {
        if (next.gameObject.activeSelf)
        {
            next.GetComponent<Text>().color = new Color(1, 1, 1, Mathf.Abs(Mathf.Sin(Time.time * 5)));
        }
        if (state == SpawnState.WAITING)
        {
            //check if enemies are stil alive
            if (EnemyIsAlive() == false)
            {
                //Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {

        searchCountdown -= Time.deltaTime;
        //check if enemies are alive
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") || GameObject.FindGameObjectWithTag("Innocent") == null)
            {
                return false;
            }

        }

        return true;

    }
    void WaveCompleted()
    {
        print("Wave Completed");
        next.gameObject.SetActive(true);

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave != 0)
            next.text = "Next Wave Incoming!";

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            print("All Waves Complete!");
            PlayerPrefs.DeleteKey("Unlock");
            PlayerPrefs.SetInt("Unlock", 2);
            SceneManager.LoadScene("LevelSelector");

            //Add finish screen or start a new a scene with new Wave
            //This is not gonna be difficulty
        }
        else
        {
            nextWave++;
        }

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);

        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            next.gameObject.SetActive(false);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        //Spawn
        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform[] _enemy)
    {
        //Spawn enemy
        if (spawnPoints.Length == 0)
        {
            print("No Spawn point referernce");
        }
        print("Spawning Enemy : " + _enemy);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy[Random.Range(0, _enemy.Length)], _sp.position, _sp.rotation);
    }
}
