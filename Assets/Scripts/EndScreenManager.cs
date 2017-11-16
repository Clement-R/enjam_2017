using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour {

    public string side = "red";
    public GameObject mainButton;
    public EventSystem sys;
    public Canvas canvas;

    public void Start()
    {
        EventManager.StartListening("hideUI", OnHide);

        if (side == "red")
        {
            EventManager.StartListening("blueWin", OnBlueWin);
        } else
        {
            EventManager.StartListening("redWin", OnRedWin);
        }
    }

    void ShowScreen()
    {
        canvas.gameObject.SetActive(true);
        canvas.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    protected void OnRedWin()
    {
        ShowScreen();
    }

    protected void OnBlueWin()
    {
        ShowScreen();
    }

    private void OnDestroy() {
        EventManager.StopListening("blueWin", OnBlueWin);
        EventManager.StopListening("redWin", OnRedWin);
    }

    void OnHide() {
        if(canvas.gameObject.activeSelf) {
            canvas.gameObject.SetActive(false);
            canvas.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
