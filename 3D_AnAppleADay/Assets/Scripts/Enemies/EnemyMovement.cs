using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Movement + Cooldown
    private Vector3 targetDirection;
    private float changeDirectionCooldown;

    // Speed
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    // Collect components
    private Rigidbody enemyRb;
    private EnemyAwareness enemyAwareness;


    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAwareness = GetComponent<EnemyAwareness>();
        targetDirection = transform.forward;
    }

    // Call these functions
    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateToTarget();
        SetVelocity();
    }

    void UpdateTargetDirection()
    {
        //Start with possible direction change, unless awareness area entered - then target player
        PlayerTargeting();
        RandomDirectionChange();
    }

    // Make sure cooldown is aligned with frame rate time (in case of skipping), and if cooldown runs out, change direction
    // Random angle to pick, then rotate around angle axis - for target direction movement rotate towards it
    // Wait before starting change again
    void RandomDirectionChange()
    {
        changeDirectionCooldown -= Time.fixedDeltaTime;


        //This is a demonstration of counters, nothing to do with the adjoining code - Finn
        //float timeOfLastJump;
        //void Jump(){
        //  if (Time.time - timeOfLastJump > jumpCooldown)
        //     timeOfLastJump = Time.time;
        //}




        if (changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            targetDirection = rotation * targetDirection;

            changeDirectionCooldown = Random.Range(1, 5);
            Debug.Log("Picked new direction at random: " + angleChange);
        }  
    }

    void PlayerTargeting()
    {
        if (enemyAwareness.AwareofPlayer)
        {
            targetDirection = enemyAwareness.DirectionOfPlayer;
        }
    }

    void RotateToTarget()
    { 
        //// Otherwise, use Quaternion to change movement (including rotation - from current position "forward" to the target direction Vector2 ref'd above)
        //// Rotation = (current rotation, to target, at the defined speed * frame rate) - then set to the rigidbody below.

        ////Quaternion targetRotation = Quaternion.LookRotation(targetDirection, new Vector3(0, 0, 1)) ;
        ////Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);


        float desiredAngle = Mathf.Atan2(targetDirection.x, targetDirection.z);
        transform.localEulerAngles = new Vector3(0, desiredAngle, 0) * rotationSpeed;

        Debug.Log("Using angle: " + desiredAngle);
    }

    /*
     * Ignore the enemy rotation - treat that as an emergent graphical feature.
     * Constantly move the enemy forward.
     * Add its target velocity to its current velocity, then renormalise.
     * 
     * 
     * 
     */




    // Again if 0, ignore (don't move), otherwise move on Y axis at x speed
    void SetVelocity()
    {     
        enemyRb.velocity = transform.forward * speed;
    }
}
