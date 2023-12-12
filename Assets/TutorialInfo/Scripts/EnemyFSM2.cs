using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random=UnityEngine.Random;

public class EnemyFSM : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    private NavMeshAgent agent;

    private enum EnemyState
    {
        MoveRandomly,
        ChasePlayer,
        AttackPlayer
    }

    private EnemyState currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.MoveRandomly;
    }

    private void Update()
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

    private void MoveRandomly()
    {
        // Move randomly in one direction
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate to move randomly in another direction
        transform.Rotate(Vector3.up * Random.Range(-180f, 180f) * rotationSpeed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the chase range
        if (distanceToPlayer <= chaseRange)
        {
            // Rotate towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            // Move towards the player
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Transition back to MoveRandomly state
            currentState = EnemyState.MoveRandomly;
        }
    }

    private void AttackPlayer()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the attack range
        if (distanceToPlayer <= attackRange)
        {
            // Attack the player
            Debug.Log("Attacking player!");
        }
        else
        {
            // Transition back to ChasePlayer state
            currentState = EnemyState.ChasePlayer;
        }
    }
}

