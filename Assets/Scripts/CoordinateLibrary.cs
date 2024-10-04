using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLibrary : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    WaypointScript waypoint;

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        label.enabled = true;

        waypoint = GetComponentInParent<WaypointScript>();
        ColorCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x =
            Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);

        coordinates.y =
            Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + " ; " + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ColorCoordinates()
    {
        if (waypoint == null)
        {
            Debug.Log("Waypoint not Found");
        }

        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }
}
