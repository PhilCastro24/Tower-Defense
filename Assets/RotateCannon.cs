using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public Transform target;
    public Transform rotator;

    void LateUpdate()
    {
        Vector3 worldDirectionToTarget = target.position - transform.position;

        Vector3 localDirection = rotator.InverseTransformDirection(worldDirectionToTarget);

        Quaternion localRotation = Quaternion.LookRotation(localDirection);

        float xAngle = localRotation.eulerAngles.x;

        if (xAngle > 180f)
            xAngle -= 360f;

        transform.localRotation = Quaternion.Euler(xAngle, 0f, 0f);

        Debug.Log("Cannon Xangle" + xAngle);
    }
}
