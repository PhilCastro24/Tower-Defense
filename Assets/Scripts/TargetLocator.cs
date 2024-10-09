using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon; // Reference to the weapon transform (in our case that's the rotator thing inside the tower)
    Transform target; // Current target being aimed at

    [SerializeField] ParticleSystem projectileParticles; // Particle system for projectile effects
    [SerializeField] float range = 15f; // Maximum range to detect and attack enemies

    RotationController rotationController; // Reference to the RotationController component

    // Called when the script instance is being loaded
    void Awake()
    {
        // Get the RotationController component attached to the SAME GameObject
        rotationController = GetComponent<RotationController>();
    }

    // Called once per frame
    void Update()
    {
        // Find the closest enemy
        FindClosestTarget();

        // Aim at the enemy and attack if within range
        AimAndAttack();
    }

    // Method to aim at the enemy and perform an attack
    void AimAndAttack()
    {
        // If there's no enemy, exit the method
        if (target == null) return;

        // Calculate the distance to the enemy
        float targetDistance = Vector3.Distance(transform.position, target.position);

        // Aim the weapon at the enemy using RotationController
        rotationController?.AimWeapon(target);

        // If the enemy is within range, activate the attack
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            // If the enemy is out of range, deactivate the attack
            Attack(false);
        }
    }

    // Method to find the closest target (enemy) within the scene
    void FindClosestTarget()
    {
        // Get all EnemyController instances in the scene
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();

        Transform closestTarget = null; // Variable to store the closest enemy
        float maxDistance = Mathf.Infinity; // Set the initial maximum distance to infinity

        // Loop through each enemy to find the one closest to this GameObject
        foreach (EnemyController enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            // If the current enemy is closer than the previous closest, update the closest target
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        // Update the current target to the closest enemy found
        target = closestTarget;
    }

    // Method to handle the attack, enabling or disabling the projectile particle effects
    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission; // Get the emission module of the particle system
        emissionModule.enabled = isActive; // Enable or disable emission based on isActive

        // If activating the attack, play the particle effects if they're not already playing
        if (isActive && projectileParticles.isStopped)
        {
            projectileParticles.Play();
        }
        // If deactivating the attack, stop the particle effects if they're playing
        else if (!isActive && projectileParticles.isPlaying)
        {
            projectileParticles.Stop();
        }
    }
}
