using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMenuBehavior : EnemyBehavior
{
    private float _baseH = 0f;
    private Vector2 oldDirection;

    new protected void Awake()
    {
        base.Awake();
        _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * Random.Range(-1, 2));
        isActive = true;
    }

    new void Start()
    {
        base.Start();
        name = "dungeon";
        type = "menu_unit";
    }

    void FixedUpdate()
    {
        if(_baseH == 0f)
        {
            _baseH = _rb.velocity.x;
        }

        if (_rb != null)
        {
            oldDirection = _rb.velocity;
            
            if(Mathf.Sign(_rb.velocity.x) != Mathf.Sign(_baseH))
            {
                _baseH = _rb.velocity.x;
                if(_sr.flipX)
                {
                    _sr.flipX = false;
                } else
                {
                    _sr.flipX = true;
                }
            }
        }
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
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
