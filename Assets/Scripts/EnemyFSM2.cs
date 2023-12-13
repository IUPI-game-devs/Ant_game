using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random=UnityEngine.Random;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState{MoveRandomly,ChasePlayer,AttackPlayer};
    public EnemyState currentState;
    public Sight sightSensor;
    public float playerAttackDistance;
    public float moveSpeed = 5f;
    public float chaseRange = 5f;
    public float rotationSpeed = 2f;
    private Vector3 destination;
    
    private void Awake()
    {
        currentState = EnemyState.MoveRandomly;
    }
    void Update()
    {
        switch (currentState)
        {
        case EnemyState.MoveRandomly:
            MoveRandomly();
            break;
        case EnemyState.ChasePlayer:
            ChasePlayer();
            break;
        case EnemyState.AttackPlayer:
            AttackPlayer();
            break;
        }
    }
    void LookTo(Vector3 targetPosition)
    {
        Vector3 directionToPosition = Vector3.Normalize(targetPosition - transform.parent.position);
        directionToPosition.y = 0;
        transform.parent.forward = directionToPosition;
    }
    void MoveRandomly()
    {
        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        // Move randomly in one direction
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate to move randomly in another direction
        transform.Rotate(Vector3.up * Random.Range(-180f, 180f) * rotationSpeed * Time.deltaTime);
    }

    

    void ChasePlayer()
    {
        LookTo(sightSensor.detectedObject.transform.position);
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.MoveRandomly;
            return;
        }
        //verifies if the player is in range to attack
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.MoveRandomly;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer > playerAttackDistance* 1.1)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
    }
}