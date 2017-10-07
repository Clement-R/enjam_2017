using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnManager : MonoBehaviour {
    public BrickSpawner[] spawners;
    public int activeSpawners = 1;
    public float timerBeforeSpawn = 2.0f;

    void Start () {
        StartCoroutine(SpawnBrick());

        EventManager.StartListening("gameEnd", OnEnd);
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
    }

    IEnumerator SpawnBrick()
    {
        // Get random spawner
        for (int i = 0; i < activeSpawners; i++)
        {
            BrickSpawner spawner = spawners[Random.Range(0, spawners.Length)];
            spawner.Spawn();
        }
        
        yield return new WaitForSeconds(timerBeforeSpawn);
        StartCoroutine(SpawnBrick());
    }

    void OnPause()
    {
        Debug.Log("PAUSE");
        Time.timeScale = 0.0f;
    }

    void OnResume()
    {
        Debug.Log("RESUME");
        Time.timeScale = 1.0f;
    }

    void OnEnd()
    {
        Time.timeScale = 0.0f;
    }
}
