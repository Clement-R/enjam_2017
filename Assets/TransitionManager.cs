using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {

    public static GameObject transitionScreen;
    public static TransitionManager instance;

    public AnimationCurve ac;
    static public float timeToMove = 0.75f;

    static private bool _side = true;
    
    static private int startPos1 = -1078;
    static private int endPos = 168;
    static private int startPos2 = 1511;

    private bool firstTime = true;

    private void Awake()
    {
        instance = this;
        transitionScreen = GameObject.FindGameObjectWithTag("transition_screen");
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {

        if (!firstTime)
        {
            Debug.Log("Let's move !");
            toggleTransiton();
        }

        // Don't do it the first time the main menu appear
        if (level == 0)
        {
            if(firstTime)
            {
                firstTime = false;
            }
        }
    }

    public static void toggleTransiton()
    {
        if(_side)
        {
            instance.StartCoroutine(instance.MoveTransition(transitionScreen.transform, new Vector2(startPos1, 0), new Vector2(endPos, 0)));
            _side = false;
        }
        else
        {
            instance.StartCoroutine(instance.MoveTransition(transitionScreen.transform, new Vector2(endPos, 0), new Vector2(startPos2, 0)));
            _side = true;
        }
    }

    public IEnumerator MoveTransition(Transform objectToMove, Vector2 start, Vector2 end)
    {
        float t = 0f;
        Debug.Log(timeToMove);
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            objectToMove.transform.localPosition = Vector3.Lerp(start, end, ac.Evaluate(t / timeToMove));
            yield return null;
        }
    }

    void ResetPos()
    {
        if (_side)
        {
            transitionScreen.transform.position = new Vector2(startPos2, 0);
        }
        else
        {
            transitionScreen.transform.position = new Vector2(startPos1, 0);
        }
    }
}
