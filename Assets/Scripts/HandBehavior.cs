using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour {

    public string playerId = "1";

    public GameObject handShadow;

    public float shadowY = 75f;
    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    private Rigidbody2D _rb;
    private int _xVelocity;
    private int _yVelocity;
    private SpriteRenderer _handShadowSr;
    private HandShadowBehavior _handShadowBehavior;

    private EnemyBehavior _draggedUnit;

    private bool _isDragging = false;

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _handShadowSr = handShadow.GetComponent<SpriteRenderer>();
        _handShadowBehavior = _handShadowSr.GetComponent<HandShadowBehavior>();
        _handShadowBehavior.playerId = playerId;
    }

    private void Update()
    {
        if (Input.GetButtonDown("A_" + playerId))
        {
            // Drag the unit that's in the hand shadow
            if (_handShadowBehavior.targetedUnitBehavior != null && !_isDragging)
            {
                _draggedUnit = _handShadowBehavior.targetedUnitBehavior;
                _draggedUnit.StopMovement();
                Destroy(_draggedUnit.gameObject.GetComponent<Rigidbody2D>());
                _draggedUnit.gameObject.transform.parent = this.transform;
                _draggedUnit.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                _isDragging = true;
                _handShadowBehavior.isDragging = true;
                _handShadowBehavior.draggedUnit = _draggedUnit.gameObject;
            }

            _handShadowSr.color = Color.red;
        }

        if (Input.GetButton("A_" + playerId))
        {
            _handShadowSr.color = Color.red;
        } else {

            // If we were dragging a unit
            if(_isDragging)
            {
                Debug.Log("LEL");

                if(_handShadowBehavior.isInGoodAreaZone)
                {
                    // Stun the unit and reset variables
                }
                else if (_handShadowBehavior.isInAreaZone)
                {
                    // Teleport the unit at the brick line (get brick zone, move trooper width / 2)
                    // Release the unit
                }
                else
                {
                    _draggedUnit.Release();
                    _draggedUnit.gameObject.AddComponent(typeof(Rigidbody2D));
                    _draggedUnit.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                    _draggedUnit.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    _draggedUnit.gameObject.transform.parent = null;
                }

                _isDragging = false;
                _handShadowBehavior.draggedUnit = null;
                _handShadowBehavior.isDragging = false;
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
