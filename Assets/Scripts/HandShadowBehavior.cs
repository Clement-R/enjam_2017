using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShadowBehavior : MonoBehaviour {

    public GameObject targetedUnit = null;
    public EnemyBehavior targetedUnitBehavior = null;
    public bool isInAreaZone = false;

    void Start () {
		
	}
	
	void Update () {
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
