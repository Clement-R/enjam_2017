using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBehavior : EnemyBehavior
{
    public float rollCooldown = 5.0f;
    public float rollSpeed = 250f;

    public string handToAvoid = "hand_1";
    public float safeDistance = 130f;

    private GameObject hand;
    private bool _canRoll = true;

    new void Awake()
    {
        base.Awake();

        hand = GameObject.FindGameObjectWithTag(handToAvoid).GetComponent<HandBehavior>().handShadow;
        Debug.Log(hand.GetInstanceID());
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            var distance = Vector2.Distance(transform.position, hand.transform.position);

            if (distance < safeDistance)
            {
                if (_canRoll)
                {
                    StartCoroutine(RollCooldown());
                    StartCoroutine(Roll());
                }

                Vector2 vec = transform.position - hand.transform.position;
                Debug.DrawLine(transform.position, new Vector2(transform.position.x + vec.normalized.x * 150, transform.position.y + vec.normalized.y * 150), Color.green);
            }
        }
    }

    IEnumerator Roll()
    {
        StopMovement();
        Vector2 vec = transform.position - hand.transform.position;
        vec.Normalize();

        float startTime = Time.time;

        while (Time.time < startTime + 0.5f) {
            _rb.velocity = vec * rollSpeed;
            yield return null;
        }

        Release();
    }

    IEnumerator RollCooldown()
    {
        _canRoll = false;
        yield return new WaitForSeconds(rollCooldown);
        _canRoll = true;
    }
}
