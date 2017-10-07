using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShadowBehavior : MonoBehaviour {

    [HideInInspector]
    public GameObject targetedUnit = null;
    [HideInInspector]
    public EnemyBehavior targetedUnitBehavior = null;

    public GameObject[] brickAreas;
    public GameObject[] towerAreas;
    public GameObject[] doorArea;
    public GameObject[] dungeonArea;

    public string playerId;

    [HideInInspector]
    public bool isInGoodAreaZone = false;
    [HideInInspector]
    public bool isInAreaZone = false;

    void Start () {
		
	}
	
	void Update () {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (targetedUnit != null)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetedUnit == null)
        {
            targetedUnit = collision.gameObject;
            targetedUnitBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
        }

        Debug.Log("Enter : " + collision.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetedUnit != null && collision.gameObject == targetedUnit)
        {
            targetedUnit = null;
            targetedUnitBehavior = null;
        }

        Debug.Log("Exit : " + collision.gameObject.name);
    }
}
