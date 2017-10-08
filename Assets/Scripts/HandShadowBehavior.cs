using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShadowBehavior : MonoBehaviour {

    [HideInInspector]
    public string playerId = "1";
    //[HideInInspector]
    public bool isDragging = false;
    [HideInInspector]
    public GameObject targetedUnit = null;
    [HideInInspector]
    public GameObject draggedUnit = null;
    [HideInInspector]
    public EnemyBehavior targetedUnitBehavior = null;
    [HideInInspector]
    public GameObject dropArea = null;

    public GameObject[] brickAreas;
    public GameObject[] towerAreas;
    public GameObject[] doorArea;
    public GameObject[] dungeonArea;

    [HideInInspector]
    public bool isInGoodAreaZone = false;

    private void Update()
    {
        if (!isDragging)
        {
            isInGoodAreaZone = false;
            dropArea = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isDragging)
        {
            if (collision.CompareTag("area_" + playerId) || collision.CompareTag("menu_drop_zone") && draggedUnit.name.Contains(collision.name))
            {
                isInGoodAreaZone = true;
                dropArea = collision.gameObject;
            } else
            {
                isInGoodAreaZone = false;
                dropArea = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetedUnit == null && !isDragging)
        {
            targetedUnit = collision.gameObject;
            targetedUnitBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (targetedUnit != null && !isDragging)
        {
            targetedUnit = null;
            targetedUnitBehavior = null;
        }
    }
}
