using UnityEngine;
using System.Collections;

public class ChaseState : IEnemyStates
{
    private readonly BaseEnemy enemy;

    public ChaseState(BaseEnemy baseEnemy) // Constructor
    {
        enemy = baseEnemy;
    }

    public void UpdateState()
    {
        LookToChase();
        Chase();
    }

    public void OnTriggerEnter(Collider other)
    {
        // end chase timer, after player is outside raycast range for a certain amount of time go back to patrolling
    }

    public void ToPatrolState()
    {
        //enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        Debug.Log("Cannot transition to current state (Chase)");
    }

    public void ToIdleState()
    {
        //enemy.currentState = enemy.idleState;
    }

    private void LookToChase()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.raycastOrigin.transform.position, enemy.raycastOrigin.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform; // Start chasing player if sighted
            ToChaseState();
        }
        else
        {
            ToPatrolState();
        }
    }

    private void Chase()
    {
        enemy.meshRendererFlag.material.color = Color.red;
        enemy.nma.destination = enemy.chaseTarget.position;
        enemy.nma.Resume();
    }
}