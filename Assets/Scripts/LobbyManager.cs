using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    private int _nbrOfDrops = 0;

    void OnLevelWasLoaded(int level)
    {
        // TransitionManager.toggleTransiton();
    }

    void Start () {
        EventManager.StartListening("unitMenuDrop", OnDrop);
    }
	
	void OnDrop()
    {
        _nbrOfDrops++;

        if(_nbrOfDrops == 2)
        {
            // TransitionManager.toggleTransiton();
            // StartCoroutine(LaunchGame());
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator LaunchGame()
    {
        yield return new WaitForSeconds(TransitionManager.timeToMove);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDestroy()
    {
        EventManager.StopListening("leftDrop", OnDrop);
        EventManager.StopListening("rightDrop", OnDrop);
    }
}
