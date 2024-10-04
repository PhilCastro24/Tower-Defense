using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<WaypointScript> path = new List<WaypointScript>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        foreach (WaypointScript waypoint in path)
        {
            //Debug.Log(waypoint.name);
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;

            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }


        }
        FinishPath();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            WaypointScript waypoint = child.GetComponent<WaypointScript>();

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
    }
}
