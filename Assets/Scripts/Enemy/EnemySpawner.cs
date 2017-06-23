using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityActionRPG.AI
{
    // Randomly spawns enemies in an area around it. There can be multiple in an area (all are controlled by an enemy spawner controller that determines when they are active, etc.)
    public class EnemySpawner : MonoBehaviour
    {
        BaseEnemy enemy;
        public BaseEnemy defaultEnemyPrefab;
        public int numberOfDefaultEnemyOnSpawn;
        public int maxNumberofDefaultEnemies;
        // Implement later: Gradually spawn enemies if there are less than the maximum allowed enemies
        public int spawnTimer;

        //public Transform[] waypoints;

        // Use this for initialization
        void Start ()
        {
            // Initially spawn a number of enemies
            for (int i = 0; i < numberOfDefaultEnemyOnSpawn; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
                BaseEnemy clone = Instantiate(defaultEnemyPrefab, spawnPosition, spawnRotation);
                Debug.Log("Enemy spawned!");
            }
        }
	
	    // Update is called once per frame
	    void Update ()
        {
        
	    }
    }
}


