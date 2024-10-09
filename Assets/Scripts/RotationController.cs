using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    // References to the rotating parts of the weapon
    [SerializeField] Transform rotator; // The part of the weapon that rotates horizontally (rotator)
    [SerializeField] Transform cannon; // The part of the weapon that aims vertically (cannon)
    [SerializeField] float rotationAngle = 90f; // Maximum angle for the cannon's vertical rotation (you can create two different values for this)
    [Tooltip("Control the smooth movement of the cannon. Bigger value = more smoothness, smaller value = less smoothness")]
    [SerializeField] float smoothingFactor = 5f; // Controls the smooth movement of the cannon by multiplying this by the Time.deltaTime

    // Public method to aim the weapon at a target
    public void AimWeapon(Transform target)
    {
        AimRotator(target); // Aim the horizontal rotator towards the target
        AimCannon(target); // Aim the vertical cannon towards the target
    }

    // Method to aim the horizontal rotator
    void AimRotator(Transform target)
    {
        // Calculate the direction from the rotator to the target
        Vector3 directionToTarget = target.position - rotator.position;
        directionToTarget.y = 0; // Ignore vertical difference, only rotate horizontally

        // Calculate the desired rotation to look at the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Smoothly rotate the rotator towards the target direction
        rotator.rotation = Quaternion.Lerp(rotator.rotation, targetRotation, Time.deltaTime * smoothingFactor);
    }

    // Method to aim the vertical cannon
    void AimCannon(Transform target)
    {
        // Calculate the direction from the cannon to the target
        Vector3 directionToTarget = target.position - cannon.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Extract the X angle from the target rotation
        float targetAngleX = targetRotation.eulerAngles.x;

        // Normalize the angle to be within -180 to 180 degrees
        if (targetAngleX > 180)
        {
            targetAngleX -= 360;
        }

        // Clamp the angle to the allowed rotation range
        targetAngleX = Mathf.Clamp(targetAngleX, -rotationAngle, rotationAngle);

        // Smoothly rotate the cannon to the target angle, avoiding sudden jumps
        cannon.localRotation = Quaternion.Lerp(cannon.localRotation, Quaternion.Euler(targetAngleX, 0, 0), Time.deltaTime * 5f);
    }
}
