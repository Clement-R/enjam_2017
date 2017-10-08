using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : EnemyBehavior
{
    public float sprintCooldown = 5.0f;
    public float sprintDuration = 1.0f;
    public float sprintSpeedMultiplier = 2.0f;

    private bool _canSprint = true;
    private float _baseSpeed;

    protected new void Awake()
    {
        base.Awake();
        _baseSpeed = speed;
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("hand_shadow"))
        {
            if (isActive && _canSprint) {
                StartCoroutine(SprintCooldown());
                StartCoroutine(Sprint());
            }
        }
    }

    IEnumerator Sprint()
    {
        speed = speed * sprintSpeedMultiplier;
        yield return new WaitForSeconds(sprintDuration);
        speed = _baseSpeed;
    }

    IEnumerator SprintCooldown()
    {
        _canSprint = false;
        yield return new WaitForSeconds(sprintCooldown);
        _canSprint = true;
    }
}
