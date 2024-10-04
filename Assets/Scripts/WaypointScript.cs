using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;

    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            //Debug.Log("You clicked on " + transform.name);

            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
