using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Randomly spawns enemies in an area around it. There can be multiple in an area (all are controlled by an enemy spawner controller that determines when they are active, etc.)
public class EnemySpawner : MonoBehaviour
{
    BaseEnemy enemy;
    public GameObject defaultEnemyPrefab;
    public int numberOfDefaultEnemyOnSpawn;
    public int maxNumberofDefaultEnemies;

    public List<GameObject> spawnedEnemyList = new List<GameObject>();

    //public Transform[] waypoints;
    //

    // Use this for initialization
    void Start ()
    {
        // Initially spawn a number of enemies
        for (int i = 0; i < numberOfDefaultEnemyOnSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
            
            GameObject clone = (GameObject)Instantiate(defaultEnemyPrefab, spawnPosition, spawnRotation);
            spawnedEnemyList.Add(clone);
            Debug.Log("Enemy added to enemy list!");

            Vector3 waypointSpawnPosition = new Vector3(enemy.transform.position.x + Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Quaternion waypointSpawnRotation = Quaternion.Euler(0, 0, 0);
            GameObject waypointClone = (GameObject)Instantiate(enemy.waypointPrefab, waypointSpawnPosition, waypointSpawnRotation);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
