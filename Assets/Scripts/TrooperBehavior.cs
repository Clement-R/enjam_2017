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

    void Update () {
		
	}
}
