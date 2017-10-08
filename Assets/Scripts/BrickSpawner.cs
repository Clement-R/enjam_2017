using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {
    public GameObject brickPrefab;
    
    public void Spawn()
    {
        GameObject go = Instantiate(brickPrefab, transform.position, Quaternion.identity);
        go.GetComponent<EnemyBehavior>().Release();

        go.GetComponent<Animator>().SetBool("is_walking", true);

        if(go.name.Contains("_1"))
        {
            go.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (go.name.Contains("_2"))
        {
            go.GetComponent<EnemyBehavior>().side = "red";
        }

        go.name = "brick";
    }
}
