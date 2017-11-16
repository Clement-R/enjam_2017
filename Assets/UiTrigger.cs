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
        // TransitionManager.toggleTransiton();
        // StartCoroutine(LaunchPlay());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LaunchPlay()
    {
        yield return new WaitForSeconds(TransitionManager.timeToMove);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Credits()
    {
        // TransitionManager.toggleTransiton();
        // StartCoroutine(LaunchCredits());
        SceneManager.LoadScene("credits");
    }

    IEnumerator LaunchCredits()
    {
        yield return new WaitForSeconds(TransitionManager.timeToMove);
        SceneManager.LoadScene("credits");
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
