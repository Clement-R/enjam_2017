using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {
    private float time;

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

        if (Input.GetKeyDown("m"))
        {
            // TransitionManager.toggleTransiton();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("MDR");
            AkSoundEngine.PostEvent("lancement_partie", gameObject);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            AkSoundEngine.PostEvent("music_menu", gameObject);
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(LaunchSong());
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            EventManager.TriggerEvent("gameEnd");
        }
#endif
    }

    IEnumerator LaunchSong()
    {
        AkSoundEngine.SetSwitch("Main_switch", "boucle1", gameObject);
        yield return new WaitForSeconds(3f);

        AkSoundEngine.PostEvent("Main_switch", gameObject);
        yield return new WaitForSeconds(5f);
        AkSoundEngine.SetSwitch("Main_switch", "transition1", gameObject);
        yield return new WaitForSeconds(22f);
        AkSoundEngine.SetSwitch("Main_switch", "boucle2", gameObject);
        yield return new WaitForSeconds(18f);
        AkSoundEngine.SetSwitch("Main_switch", "transition2", gameObject);
        yield return new WaitForSeconds(15f);
        AkSoundEngine.SetSwitch("Main_switch", "boucle3", gameObject);
        yield return new WaitForSeconds(15f);
        AkSoundEngine.SetSwitch("Main_switch", "transition3", gameObject);
        yield return new WaitForSeconds(10f);
        AkSoundEngine.SetSwitch("Main_switch", "boucle4", gameObject);
    }
}
