using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperBehavior : EnemyBehavior
{
    void Start () {
        EventManager.StartListening("trooperLaunch", OnLaunch);
        this.h = 1;
    }

    void OnDisable()
    {
        EventManager.StopListening("trooperLaunch", OnLaunch);
    }

    void OnLaunch()
    {
        StartCoroutine("Run");
    }

    IEnumerator Run()
    {
        while(!isAttacking)
        {
            _rb.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);
            yield return null;
        }
    }

    void Update () {
		
	}
}
