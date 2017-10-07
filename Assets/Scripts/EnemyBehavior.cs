using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    protected bool isAttacking = false;
    protected Rigidbody2D _rb;
    protected float hMaxSpeed = 90f;
    protected float vMaxSpeed = 75f;

    protected float h = 0;
    protected float v = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
        // EventManager.StartListening("playerMove", OnPlayerMove);
    }
	
	void Update () {
		
	}
}
