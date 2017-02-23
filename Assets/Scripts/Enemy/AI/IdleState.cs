using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IEnemyStates
{
    private readonly EnemyStatePattern enemy;
    private Quaternion randomRotation;
    float lookTimer;

    public void Start()
    {
        lookTimer = Random.Range(1.75f, 5);
    }

    public IdleState(EnemyStatePattern enemyStatePattern) // Constructor
    {
        enemy = enemyStatePattern;
    }

    public void UpdateState()
    {
        Idle();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ToChaseState();
    }

    public void ToPatrolState()
    {
        //enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        //enemy.currentState = enemy.chaseState;
    }

    public void ToIdleState()
    {
        Debug.Log("Cannot transition to current state (Idle)");
    }

    void Idle()
    {
        enemy.nma.Stop();
        enemy.meshRendererFlag.material.color = Color.blue;
        //enemy.nma.destination = enemy.waypoints[nextWaypoint].position;
        lookTimer -= Time.deltaTime;
        if (lookTimer <= 0)
        {
            lookTimer = Random.Range(1.75f, 5);
            randomRotation = Quaternion.Euler(Random.Range(0, 359), enemy.transform.rotation.y, Random.Range(0, 359));
        }
    }
}