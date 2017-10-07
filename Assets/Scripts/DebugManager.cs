using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent("trooperLaunch");
        }
	}
}
