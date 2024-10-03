using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> path = new List<Transform>();
    [SerializeField] float waitTime = 1f;

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
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
