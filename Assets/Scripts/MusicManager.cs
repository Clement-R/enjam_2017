using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public float time;

    private bool oneShot = false;

    private void Start()
    {
        EventManager.StartListening("gameEnd", OnEnd);
        EventManager.StartListening("gamePause", OnPause);
        EventManager.StartListening("gameResume", OnResume);
        AkSoundEngine.PostEvent("lancement_partie", gameObject);

        // AkSoundEngine.SetSwitch("Main_switch", "boucle1", gameObject);
        // AkSoundEngine.PostEvent("Main_switch", gameObject);
    }

    void OnEnd()
    {
        AkSoundEngine.PostEvent("end", gameObject);
    }

    void OnPause()
    {
        AkSoundEngine.PostEvent("menu_pause", gameObject);
    }

    void OnResume()
    {
        AkSoundEngine.PostEvent("menu_reprendre", gameObject);
    }

    void OnDestroy()
    {
        EventManager.StopListening("gameEnd", OnEnd);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f && !oneShot)
        {
            AkSoundEngine.PostEvent("main_theme", gameObject);
            oneShot = true;
        }

        /*
        time += Time.deltaTime;

        if(time >= 5f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition1", gameObject);
        }
        else if(time >= 25f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle2", gameObject);
        }
        else if(time >= 43f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition2", gameObject);
        }
        else if(time >= 58f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle3", gameObject);
        }
        else if(time >= 73f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "transition3", gameObject);
        }
        else if(time >= 83f && time <= 100f)
        {
            AkSoundEngine.SetSwitch("Main_switch", "boucle4", gameObject);
        }
        */
    }
}
