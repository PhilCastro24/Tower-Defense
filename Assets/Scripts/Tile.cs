using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] bool isWalkable = true;
    [SerializeField] Tower towerPrefab;

    GridManager gridManager;
    Pathfinder pathfinder;

    Vector2Int coordinates = new Vector2Int();

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    public bool IsWalkable
    {
        get
        {
            return isWalkable;
        }
    }

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            // Block the node in the grid only if it is not walkable
            if (!isWalkable)
            {
                if (!IsPlaceable)
                {
                    gridManager.BlockNode(coordinates);
                }
                else if (!isWalkable)
                {
                    gridManager.BlockNode(coordinates);
                }
            }
        }
    }

    void OnMouseDown()
    {
        Node node = gridManager.GetNode(coordinates);

        // Check if the tile is placeable
        if (!isPlaceable)
        {
            Debug.Log("Cannot place tower here. Tile is set to !isPlaceable or another tower already was placed here.");
            return;
        }

        // Check if placing a tower will not block the path
        if (node != null && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);

            if (isSuccessful)
            {
                // Mark the node as blocked for pathfinding
                gridManager.BlockNode(coordinates);

                // Notify the pathfinder to recalculate paths
                pathfinder.NotifyReceivers();

                // Set the tile to be non-placeable since a tower is now placed
                isPlaceable = false;
            }
            else
            {
                Debug.Log("Cannot Place Tower");
            }
        }
        else
        {
            Debug.Log("Cannot place tower here. It would block the path.");
        }
    }
}
