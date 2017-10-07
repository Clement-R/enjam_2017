using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    protected bool isAttacking = false;
    protected Rigidbody2D _rb;
    protected float hMaxSpeed = 25f;
    protected float vMaxSpeed = 75f;

    protected string type;

    protected float h = 0;
    protected float v = 0;

    private Coroutine _runningCoroutine = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Stun()
    {
        StartCoroutine(StunEffect());
    }

    IEnumerator StunEffect()
    {
        // TODO : Stun effect

        yield return new WaitForSeconds(1.5f);

        Release();
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
        GetComponent<BoxCollider2D>().enabled = true;
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
