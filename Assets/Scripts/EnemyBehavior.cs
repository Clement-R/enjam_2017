using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float timeBeforeMoving = 0.0f;
    public string aimedArea = "area_1";

    protected bool isAttacking = false;
    protected Rigidbody2D _rb;
    protected SpriteRenderer _sr;
    protected float hMaxSpeed = 25f;
    protected float vMaxSpeed = 75f;

    protected string type;

    public float h = 0;
    public float v = 0;

    private Coroutine _runningCoroutine = null;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        EventManager.StartListening("gameEnd", OnEnd);
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);

        StartCoroutine(StartMoving(timeBeforeMoving));
    }

    void Update()
    {
        _sr.sortingOrder = Mathf.Abs((int)transform.position.y - 256);
    }

    IEnumerator StartMoving(float timeBeforeMoving)
    {
        yield return new WaitForSeconds(timeBeforeMoving);
        Release();
    }

    public void Stun()
    {
        StartCoroutine(StunEffect());
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    IEnumerator StunEffect()
    {
        // TODO : Stun effect

        yield return new WaitForSeconds(1.5f);

        Release();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(aimedArea))
        {
            Debug.Log("Area reached !");
            EventManager.TriggerEvent("gameEnd");
        }
    }

    void OnPause()
    {
        Debug.Log("PAUSE");
        StopMovement();
    }

    void OnResume()
    {
        Debug.Log("RESUME");
        OnLaunch();
    }

    void OnEnd()
    {
        StopMovement();
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
}
