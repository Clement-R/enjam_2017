using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {

    public List<string> inputs;

    private void Start()
    {
        inputs.Add("A_1");
        inputs.Add("A_2");

        inputs.Add("B_1");
        inputs.Add("B_2");

        inputs.Add("X_1");
        inputs.Add("X_2");

        inputs.Add("Y_1");
        inputs.Add("Y_2");

        inputs.Add("Start_1");
        inputs.Add("Start_2");

        inputs.Add("Back_1");
        inputs.Add("Back_2");
    }

    void Update () {
        foreach (var input in inputs)
        {
            if(Input.GetButtonDown(input))
            {
                TransitionManager.toggleTransiton("main_menu");
            }
        }
	}
}
