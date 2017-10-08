using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float timeBeforeMoving = 0.0f;
    public string aimedArea = "area_1";
    public float stunDuration = 2f;
	public float stunDurationMin = 2f;
	public float stunDurationDiminution = 2f;
    public string side = "blue";

    public string wwiseGrab = "cris_brique";
    public string wwiseDrop = "planter_brique";
    public bool isGrabbed = false;

    protected bool isAttacking = false;
    protected Rigidbody2D _rb = null;
    protected SpriteRenderer _sr;
    protected float hMaxSpeed = 25f;
    protected float vMaxSpeed = 75f;

    [HideInInspector]
    public string type = "";

    public float h = 0;
    public float v = 0;
    public float speed = 150f;

    public bool isActive = false;

    private bool started = false;
    private Coroutine _runningCoroutine = null;
    private Animator _animator;
    private bool _isPause = false;

    protected void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        _animator.SetBool("is_walking", true);
        started = true;
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
        Debug.Log("STUN");
        _animator.SetBool("is_stunned", true);
        isActive = false;

        yield return new WaitForSeconds(stunDuration);

		if (stunDuration > stunDurationMin)
			stunDuration -= stunDurationDiminution;
        
        _animator.SetBool("is_stunned", false);
        Release();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(aimedArea))
        {
            if (side == "blue")
            {
                EventManager.TriggerEvent("blueWin");
            }
            else
            {
                EventManager.TriggerEvent("redWin");
            }

            EventManager.TriggerEvent("gameEnd");
        }
    }

    protected void OnPause()
    {
        StopMovement();
        _isPause = true;
        if(_rb != null)
        {
            _rb.simulated = false;
        }
    }

    protected void OnResume()
    {
        _rb.simulated = true;
        _isPause = false;
        if (started)
        {
            OnLaunch();
        }
    }

    protected void OnEnd()
    {
        if(_rb != null)
        {
            _rb.simulated = false;
        } else
        {
            Destroy(this.gameObject);
        }
        
        StopMovement();
    }

    public void StopMovement()
    {
        if (_runningCoroutine != null)
        {
            _rb.velocity = new Vector2(0, 0);
            this.StopCoroutine(_runningCoroutine);
            _runningCoroutine = null;
            isActive = false;
        }
    }

    protected IEnumerator Run()
    {
        while (!isAttacking && !_isPause)
        {
            Vector2 direction = new Vector2(0, 0);
            direction.x = h;
            direction.y = v;
            direction.Normalize();
            _rb.velocity = direction * speed;

            yield return null;
        }
    }

    public void Grab()
    {
        isGrabbed = true;

        _animator.SetBool("is_walking", false);
        _animator.SetBool("is_grabbed", true);

        AkSoundEngine.PostEvent(wwiseGrab, gameObject);
    }

    public void Drop()
    {
        isGrabbed = false;
        Debug.Log("DROPPED");
        _animator.SetBool("is_grabbed", false);
        AkSoundEngine.PostEvent(wwiseDrop, gameObject);
    }

    public void Release()
    {
        isActive = true;

        if(_rb == null)
        {
            gameObject.AddComponent(typeof(Rigidbody2D));
        }
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
