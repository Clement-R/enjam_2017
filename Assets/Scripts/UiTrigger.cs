using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiTrigger : MonoBehaviour {
    public string eventToListen = "unitMenuDrop";
    public string methodToLaunch = "";

    private void Start()
    {
        EventManager.StartListening(eventToListen, OnDrop);
    }

    void OnDrop()
    {
        Invoke(methodToLaunch, 0f);
    }

    void Play()
    {
        TransitionManager.toggleTransiton("lobby");
    }

    void Credits()
    {
        TransitionManager.toggleTransiton("credits");
    }

    void Quit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        EventManager.StopListening(eventToListen, OnDrop);
    }
}
