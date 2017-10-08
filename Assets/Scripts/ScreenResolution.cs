using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour {
	void Awake () {
        Screen.SetResolution(896, 504, true, 60);
    }
}
