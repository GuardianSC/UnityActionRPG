using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityActionRPG.AI
{
    public class PatrolState : IEnemyStates 
    {
        private readonly BaseEnemy enemy; // Don't change any data in BaseEnemy, just use things from it
        //public Transform waypoint;         // Used to move
        int maxWaypoints;
        //public GameObject waypointPrefab;     // Waypoint prefab
        //private int nextWaypoint;

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
         // Spawn waypoints and travel between them
        void Patrol()
        {
            maxWaypoints = 1;
            for (int i = 1; i <= maxWaypoints; i++)
            {
                //Vector3 spawnPosition = new Vector3(enemy.transform.position.x + Random.Range(-10, 10), 0, enemy.transform.position.z + Random.Range(-10, 10));
                //enemy.waypoints[i].position = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.transform.position.z + Random.Range(-5, 5));
                //GameObject clone = MonoBehaviour.Instantiate(enemy.waypointPrefab, enemy.waypoints[i].position, Quaternion.Euler(0, 0, 0));

                Vector3 spawnPosition = new Vector3(enemy.transform.position.x + Random.Range(-10, 10), 0, enemy.transform.position.z + Random.Range(-10, 10));
                enemy.waypoints[i].position = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.transform.position.z + Random.Range(-5, 5));
                GameObject clone = MonoBehaviour.Instantiate(enemy.waypointPrefab, enemy.waypoints[i].position, Quaternion.Euler(0, 0, 0));

                enemy.meshRendererFlag.material.color = Color.green;
                //enemy.nma.destination = waypoints[nextWaypoint].position;
                enemy.nma.Resume();

                if (enemy.nma.remainingDistance <= enemy.nma.stoppingDistance && !enemy.nma.pathPending)
                {
                    //nextWaypoint = (nextWaypoint + 1) % waypoints.Length;
                    enemy.waypoints[i].position = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.waypoints[i].position.z + Random.Range(-5, 5)); // Move the waypoint to another position
                }
            }
        }
    }
}