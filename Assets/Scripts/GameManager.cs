using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    void OnLevelWasLoaded(int level)
    {
        // TransitionManager.toggleTransiton();
    }

    public void ResumeGame()
    {
        EventManager.TriggerEvent("gameResume");
    }

    public void PauseGame()
    {
        EventManager.TriggerEvent("gamePause");
    }

    public void ReturnToMenu()
    {
        // TransitionManager.toggleTransiton();
        AkSoundEngine.PostEvent("quitter_menu_pause", gameObject);
        // StartCoroutine(LaunchMenu());
        SceneManager.LoadScene("main_menu");
    }

    public void RestartGame()
    {
        // TransitionManager.toggleTransiton();
        // StartCoroutine(Restart());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(TransitionManager.timeToMove);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LaunchMenu()
    {
        yield return new WaitForSeconds(TransitionManager.timeToMove);
        SceneManager.LoadScene("main_menu");
    }
}
