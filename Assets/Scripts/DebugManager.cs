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
#endif
    }
}
