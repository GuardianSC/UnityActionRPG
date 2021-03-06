﻿using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyStates 
{
    private readonly BaseEnemy enemy;
    private int nextWaypoint;

    public PatrolState(BaseEnemy baseEnemy) // Constructor
    {
        enemy = baseEnemy;
    }

    public void UpdateState()
    {
        Look();
        Patrol();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ToChaseState();
    }

    public void ToPatrolState()
    {
        Debug.Log("Cannot transition to current state (Patrol)");
    }

    public void ToChaseState()
    {
        //enemy.currentState = enemy.chaseState;
    }

    public void ToIdleState()
    {
        //enemy.currentState = enemy.idleState;
    }

    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.raycastOrigin.transform.position, enemy.raycastOrigin.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform; // Start chasing player if sighted
            ToChaseState();

            Debug.Log("Target Sighted");
        }
    }

    void Patrol()
    {
        foreach (BaseEnemy enemy in enemy.enemyList)
        {
            enemy.meshRendererFlag.material.color = Color.green;
            enemy.nma.destination = enemy.waypoints[nextWaypoint].position;
            enemy.nma.Resume();

            if (enemy.nma.remainingDistance <= enemy.nma.stoppingDistance && !enemy.nma.pathPending)
            {
                nextWaypoint = (nextWaypoint + 1) % enemy.waypoints.Length;
            }
        }
    }
}