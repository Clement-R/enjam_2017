using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public SpriteRenderer timerSprite;
    public Sprite[] sprites;

    private float _timeSinceWin;
    private bool _win = false;

    public void Start() {
        Time.timeScale = 0;
        StartCoroutine(Timer());

        EventManager.StartListening("blueWin", OnWin);
        EventManager.StartListening("redWin", OnWin);
    }

    IEnumerator Timer() {
        float startTime = Time.realtimeSinceStartup + TransitionManager.timeToMove;

        while (Time.realtimeSinceStartup < startTime) {
            yield return null;
        }

        AkSoundEngine.PostEvent("decompte", gameObject);

        float pauseEndTime = Time.realtimeSinceStartup + 4;

        while (Time.realtimeSinceStartup < pauseEndTime) {

            if (pauseEndTime - Time.realtimeSinceStartup >= 0) {
                timerSprite.sprite = sprites[3];
            }

            if (pauseEndTime - Time.realtimeSinceStartup >= 1) {
                timerSprite.sprite = sprites[2];
            }

            if (pauseEndTime - Time.realtimeSinceStartup >= 2) {
                timerSprite.sprite = sprites[1];
            }

            if (pauseEndTime - Time.realtimeSinceStartup >= 3) {
                timerSprite.sprite = sprites[0];
            }

            yield return null;
        }
        
        Time.timeScale = 1;

        Destroy(timerSprite.gameObject);
        AkSoundEngine.PostEvent("main_theme", gameObject);

    }

    public void OnWin() {
        _timeSinceWin = Time.time;
        _win = true;
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
        // Wait 1s before letting the player make an input on the end screen
        if(Time.time - _timeSinceWin >= 1) {
            EventManager.TriggerEvent("hideUI");
            AkSoundEngine.PostEvent("quitter_menu_pause", gameObject);
            TransitionManager.toggleTransiton("main_menu");
        }
    }

    public void RestartGame()
    {
        if(_win && Time.time - _timeSinceWin < 1)
        {
            return;
        }

        TransitionManager.toggleTransiton("prototype");
    }
}
