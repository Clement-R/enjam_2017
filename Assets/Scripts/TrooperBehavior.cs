using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperBehavior : EnemyBehavior
{
    new void Start () {
        base.Start();
        type = "brick";
        EventManager.StartListening("trooperLaunch", OnLaunch);
    }

    void OnDisable()
    {
        EventManager.StopListening("trooperLaunch", OnLaunch);
    }
}
