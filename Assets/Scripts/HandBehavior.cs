using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour {

    public string playerId = "1";

    public GameObject handShadow;
    public GameObject areaBehavior;

    public float shadowY = 75f;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    private Rigidbody2D _rb;
    private int _xVelocity;
    private int _yVelocity;
    private SpriteRenderer _handShadowSr;
    private HandShadowBehavior _handShadowBehavior;

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _handShadowSr = handShadow.GetComponent<SpriteRenderer>();
        _handShadowBehavior = _handShadowSr.GetComponent<HandShadowBehavior>();
    }

    private void Update()
    {
        if(Input.GetButton("A_" + playerId))
        {
            if(_handShadowBehavior.targetedUnitBehavior != null)
            {
                _handShadowBehavior.targetedUnitBehavior.StopMovement();
                Destroy(_handShadowBehavior.targetedUnit.GetComponent<Rigidbody2D>());
                _handShadowBehavior.targetedUnit.transform.parent = this.transform;
            }

            _handShadowSr.color = Color.red;
        } else {
            if(_handShadowBehavior.targetedUnitBehavior != null)
            {
                if(_handShadowBehavior.isInAreaZone)
                {
                    // Drop in zone (area type must be checked before and go directly in else if needed)
                    // Check if the zone is good for the type of dragged unit stun it and reset variables
                }
                else
                {
                    if (_handShadowBehavior.targetedUnit.GetComponent<Rigidbody2D>() == null)
                    {
                        _handShadowBehavior.targetedUnitBehavior.Release();
                        _handShadowBehavior.targetedUnit.gameObject.AddComponent(typeof(Rigidbody2D));
                        _handShadowBehavior.targetedUnit.GetComponent<Rigidbody2D>().gravityScale = 0;
                        _handShadowBehavior.targetedUnit.transform.parent = null;
                    }
                }
            }

            _handShadowSr.color = Color.white;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("L_XAxis_" + playerId);
        float v = -Input.GetAxisRaw("L_YAxis_" + playerId);

        _rb.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);

        handShadow.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - shadowY);
    }
}
