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
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this.gameObject);
        }
        
        transitionScreen = GameObject.FindGameObjectWithTag("transition_screen");
        DontDestroyOnLoad(this.gameObject);
    }

    public static void toggleTransiton()
    {
        Debug.Log("Transition called");

        if (_side)
        {
            AkSoundEngine.PostEvent("transition_menu", Camera.main.gameObject);

            instance.StartCoroutine(instance.MoveTransition(transitionScreen.transform, new Vector2(startPos1, 0), new Vector2(endPos, 0)));
        }
        else
        {
            instance.StartCoroutine(instance.MoveTransition(transitionScreen.transform, new Vector2(endPos, 0), new Vector2(startPos2, 0)));
        }
    }

    public IEnumerator MoveTransition(Transform objectToMove, Vector2 start, Vector2 end)
    {
        Debug.Log(GetInstanceID());

        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            objectToMove.transform.localPosition = Vector3.Lerp(start, end, ac.Evaluate(t / timeToMove));
            yield return null;
        }
        
        if (_side)
        {
            _side = false;
        }
        else
        {
            _side = true;
        }
    }
}
