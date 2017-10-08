using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    private int _nbrOfDrops = 0;

	void Start () {
        EventManager.StartListening("unitMenuDrop", OnDrop);
    }
	
	void OnDrop()
    {
        _nbrOfDrops++;

        if(_nbrOfDrops == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnDestroy()
    {
        EventManager.StopListening("leftDrop", OnDrop);
        EventManager.StopListening("rightDrop", OnDrop);
    }
}
