using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> path = new List<Transform>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    void Start()
    {
        StartCoroutine(FollowPath());
    }


    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        foreach(Transform waypoint in path)
        {
            Debug.Log(waypoint.name);
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
    }
}
