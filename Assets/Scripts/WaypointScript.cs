using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    [SerializeField] bool isPlaycable;
    [SerializeField] GameObject towerPrefab;

    void OnMouseDown()
    {
        if (isPlaycable)
        {
            //Debug.Log("You clicked on " + transform.name);

            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaycable = false;
        }
    }
}
