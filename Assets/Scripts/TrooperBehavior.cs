using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperBehavior : EnemyBehavior
{
    private Vector2 oldDirection;

    new void Start () {
        base.Start();
        type = "brick";
        EventManager.StartListening("trooperLaunch", OnLaunch);
    }

    void OnDisable()
    {
        EventManager.StopListening("trooperLaunch", OnLaunch);
    }

   void FixedUpdate()
    {
        oldDirection = _rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "unit_walls")
        {
            ContactPoint2D cp = coll.contacts[0];

            this.StopMovement();
            _rb.velocity = Vector2.Reflect(oldDirection, cp.normal);
        }
    }
}
