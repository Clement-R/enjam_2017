using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject brickPrefab;
    
    public void Spawn()
    {
        GameObject go = Instantiate(brickPrefab, transform.position, Quaternion.identity);
        go.GetComponent<EnemyBehavior>().Release();
        go.name = "brick";
    }
}
