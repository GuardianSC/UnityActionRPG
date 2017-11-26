using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityActionRPG.AI
{
    public class WanderState : IEnemyStates
    {
        private readonly BaseEnemy enemy; // Don't change any data in BaseEnemy, just use things from it

        public WanderState(BaseEnemy baseEnemy) // Constructor
        {
            enemy = baseEnemy;
        }

        public void UpdateState()
        {
            Look();
            Wander();
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
            //enemy.currentState = enemy.idleState;
        }

        public void ToWanderState()
        {
            Debug.Log("Cannot transition to current state (Wander)");
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

        // Spawn waypoints and travel between them
        void Wander()
        {
            if (enemy.spawnWanderWaypoint)
            {
                enemy.waypoint = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.transform.position.z + Random.Range(-5, 5));
                Debug.Log(enemy.waypoint);
                enemy.spawnWanderWaypoint = false;
            }
            else
                Debug.Log("Please no more fucking waypoints");

            Debug.Log(enemy.spawnWanderWaypoint);
            enemy.meshRendererFlag.material.color = Color.green;
            enemy.nma.destination = enemy.waypoint;
            enemy.nma.Resume();

            if (enemy.nma.remainingDistance <= enemy.nma.stoppingDistance && !enemy.nma.pathPending)
            {
                // Move the waypoint to a new position when it is reached
                enemy.waypoint = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.waypoint.z + Random.Range(-5, 5));
            }
        }
    }
}