using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {
    void Update () {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent("trooperLaunch");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.TriggerEvent("gameEnd");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Launch song");
            AkSoundEngine.PostEvent("switch", gameObject);
            AkSoundEngine.SetSwitch("Main_switch", "boucle1", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle2", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle3", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle4", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition1", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition2", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition3", gameObject);
        }
#endif

        if (Input.GetKeyDown("m"))
        {
            TransitionManager.toggleTransiton();
        }
    }
}
