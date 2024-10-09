using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    float LocalYRotation;

    void Awake()
    {
        LocalYRotation = transform.localEulerAngles.y;
    }

    void Update()
    {
        Vector3 currentLocalEulerAngles = transform.localEulerAngles;

        currentLocalEulerAngles.x = LocalYRotation;
        transform.localEulerAngles = currentLocalEulerAngles;
    }
}
