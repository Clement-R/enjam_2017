using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnManager : MonoBehaviour {
    public BrickSpawner[] spawners;
    public int activeSpawners = 1;
    public float timerBeforeSpawn = 2.0f;
	public float timerBeforeSpawnMin = 2.0f;
	public float timerBeforeSpawnDiminution = 2.0f;

    private bool _isPaused = false;

    void Start () {
        StartCoroutine(SpawnBrick());

        EventManager.StartListening("gameEnd", OnEnd);
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
    }

    IEnumerator SpawnBrick()
    {
        while(_isPaused)
        {
            yield return null;
        }
        
        // Get random spawner
        for (int i = 0; i < activeSpawners; i++)
        {
            BrickSpawner spawner = spawners[Random.Range(0, spawners.Length)];
            spawner.Spawn();
        }
        
        yield return new WaitForSeconds(timerBeforeSpawn);

		if (timerBeforeSpawn > timerBeforeSpawnMin)
			timerBeforeSpawn -= timerBeforeSpawnDiminution;
        StartCoroutine(SpawnBrick());
    }

    void OnPause()
    {
        _isPaused = true;
    }

    void OnResume()
    {
        _isPaused = false;
    }

    void OnEnd()
    {
        _isPaused = true;
    }
}
