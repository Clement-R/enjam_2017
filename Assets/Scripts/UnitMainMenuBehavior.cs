using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMainMenuBehavior : UnitMenuBehavior
{
    private Vector2 startPos;

    new void Awake()
    {
        base.Awake();
        startPos = transform.position;
        type = "main_menu_unit";
    }

    new void Start()
    {
        base.Start();
        type = "main_menu_unit";
    }

    public new void Release()
    {
        base.Release();
        transform.position = startPos;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
}
