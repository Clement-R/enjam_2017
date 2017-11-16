using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperBehavior : EnemyBehavior
{
    private Vector2 oldDirection;

    new protected void Awake()
    {
        base.Awake();
        _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * Random.Range(-1, 2));
    }

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
        if(_rb != null)
        {
            oldDirection = _rb.velocity;
        }
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
