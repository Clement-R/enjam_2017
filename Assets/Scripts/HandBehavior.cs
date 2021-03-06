﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehavior : MonoBehaviour {
    static public bool isPaused = false;

    public string playerId = "1";

    public GameObject handShadow;

    public Sprite handIdle;
    public Sprite handPick;

    public float shadowX = 25f;
    public float shadowY = 75f;

    public float hMaxSpeed = 175f;
    public float vMaxSpeed = 150f;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private int _xVelocity;
    private int _yVelocity;
    private SpriteRenderer _handShadowSr;
    private HandShadowBehavior _handShadowBehavior;

    private EnemyBehavior _draggedUnit;

    private bool _isDragging = false;

    void Start () {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _handShadowSr = handShadow.GetComponent<SpriteRenderer>();
        _handShadowBehavior = _handShadowSr.GetComponent<HandShadowBehavior>();
        _handShadowBehavior.playerId = playerId;

        EventManager.StartListening("gameEnd", OnEnd);
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
    }

    void OnEnd()
    {
        _rb.simulated = false;
    }

    void OnPause()
    {
        _rb.simulated = false;
    }

    void OnResume()
    {
        _rb.simulated = true;
    }

    private void Update()
    {
        if (_rb.simulated) {
            if (Input.GetButtonDown("A_" + playerId)) {
                // Drag the unit that's in the hand shadow
                if (_handShadowBehavior.targetedUnitBehavior != null && !_isDragging) {
                    _draggedUnit = _handShadowBehavior.targetedUnitBehavior;

                    _draggedUnit.Grab();
                    _draggedUnit.StopMovement();

                    Destroy(_draggedUnit.gameObject.GetComponent<Rigidbody2D>());
                    _draggedUnit.gameObject.transform.parent = this.transform;
                    _draggedUnit.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                    _isDragging = true;
                    _handShadowBehavior.isDragging = true;
                    _handShadowBehavior.draggedUnit = _draggedUnit.gameObject;
                }
            }

            if (Input.GetButton("A_" + playerId)) {
                _sr.sprite = handPick;
                _handShadowSr.color = Color.red;
            }
            else {
                // If we were dragging a unit and we drop it
                if (_isDragging) {
                    if (_handShadowBehavior.isInGoodAreaZone) {
                        if (_draggedUnit.name.Contains("brick")) {
                            AkSoundEngine.PostEvent("planter_valide", Camera.main.gameObject);
                            _draggedUnit.Kill();
                        }
                        else if (_draggedUnit.type == "menu_unit") {
                            AkSoundEngine.PostEvent("planter_valide", Camera.main.gameObject);
                            _draggedUnit.GetComponent<SpriteRenderer>().flipX = false;
                            _draggedUnit.StopMovement();
                            EventManager.TriggerEvent("unitMenuDrop");
                        }
                        else if (_draggedUnit.type == "main_menu_unit") {
                            AkSoundEngine.PostEvent("planter_valide", Camera.main.gameObject);
                            _draggedUnit.GetComponent<SpriteRenderer>().flipX = false;
                            _draggedUnit.StopMovement();
                            EventManager.TriggerEvent(_handShadowBehavior.dropArea.GetComponent<UiTrigger>().eventToListen);
                        }
                        else {
                            _draggedUnit.Stun();
                        }
                    }
                    else {
                        var myObject = _draggedUnit as UnitMainMenuBehavior;
                        if (myObject != null) {
                            myObject.Release();
                        }
                        else {
                            _draggedUnit.Release();
                        }
                    }

                    _draggedUnit.Drop();

                    // Reset the parent to avoid that the stun unit follow our hand
                    _draggedUnit.gameObject.transform.parent = null;

                    _isDragging = false;
                    _handShadowBehavior.draggedUnit = null;
                    _handShadowBehavior.isDragging = false;
                }

                _sr.sprite = handIdle;
                _handShadowSr.color = Color.white;
            }
        }
    }

    void FixedUpdate()
    {
        if (_rb.simulated) {
            float h = Input.GetAxisRaw("L_XAxis_" + playerId);
            float v = -Input.GetAxisRaw("L_YAxis_" + playerId);

            _rb.velocity = new Vector2(h * hMaxSpeed, v * vMaxSpeed);

            handShadow.transform.position = new Vector2(this.transform.position.x - shadowX, this.transform.position.y - shadowY);
        }
    }
}
