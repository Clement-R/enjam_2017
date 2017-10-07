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
    private int xVelocity;
    private int yVelocity;

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("L_XAxis_" + playerId);
        float v = -Input.GetAxisRaw("L_YAxis_" + playerId);

        _rb.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);

        handShadow.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - shadowY);
    }
}
