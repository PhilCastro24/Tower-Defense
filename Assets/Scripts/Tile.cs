using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] bool isWalkable;
    [SerializeField] Tower towerPrefab;

    GridManager gridManager;
    Pathfinder pathfinder;

    Vector2Int coordinates = new Vector2Int();

    public bool IsPlaceable
    {
        get { return isPlaceable; }
    }

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (gridManager != null)
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
        if (isPlaceable)
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);

            if (isSuccessful)
            {
                isPlaceable = false;
                isWalkable = false;
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
            else
            {
                Debug.Log("Cannot Place Tower");
            }
        }
    }
}
