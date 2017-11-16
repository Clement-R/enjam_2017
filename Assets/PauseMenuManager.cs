using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour {

    public GameObject mainButton;
    public EventSystem sys;
    public Canvas _canvas;

	void Start () {
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
    }

    void OnPause()
    {
        _canvas.gameObject.SetActive(true);
        _canvas.enabled = true;
    }

    void OnResume()
    {
        _canvas.gameObject.SetActive(false);
        _canvas.enabled = false;
    }
}
