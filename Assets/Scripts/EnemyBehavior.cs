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

    private Coroutine _runningCoroutine = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void StopMovement()
    {
        if (_runningCoroutine != null)
        {
            _rb.velocity = new Vector2(0, 0);
            this.StopCoroutine(_runningCoroutine);
            _runningCoroutine = null;
        }
    }

    protected IEnumerator Run()
    {
        while (!isAttacking)
        {
            _rb.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);
            yield return null;
        }
    }

    public void Release()
    {
        gameObject.AddComponent(typeof(Rigidbody2D));
        GetComponent<Rigidbody2D>().gravityScale = 0;
        transform.parent = null;

        this.OnLaunch();
    }

    protected void OnLaunch()
    {
        if(_runningCoroutine == null) {
            _rb = GetComponent<Rigidbody2D>();
            _runningCoroutine = StartCoroutine(Run());
        }
    }

    void Start () {
    }
	
	void Update () {
		
	}
}
