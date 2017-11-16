using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {

    public GameObject mainButton;
    public EventSystem sys;
    public Canvas _canvas;

    private bool _isPaused = false;

	void Start () {
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
        EventManager.StartListening("hideUI", OnHide);
    }

    private void Update() {
        if (Input.GetButtonDown("Start_1" ) || Input.GetButtonDown("Start_2")) {
            if (_isPaused) {
                EventManager.TriggerEvent("gameResume");
            }
            else {
                EventManager.TriggerEvent("gamePause");
            }
        }
    }

    void OnHide() {
        if(_canvas.gameObject.activeSelf) {
            _canvas.gameObject.SetActive(false);
            _canvas.enabled = false;
        }
    }

    void OnPause()
    {
        _isPaused = true;
        _canvas.gameObject.SetActive(true);
        _canvas.enabled = true;
    }

    void OnResume()
    {
        _isPaused = false;
        _canvas.gameObject.SetActive(false);
        _canvas.enabled = false;
    }

    private void OnDestroy() {
        EventManager.StopListening("gamePause", OnPause);
        EventManager.StopListening("gameResume", OnResume);
    }
}
