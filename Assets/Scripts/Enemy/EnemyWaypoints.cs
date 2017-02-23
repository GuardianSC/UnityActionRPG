using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    EnemyStatePattern enemy;
    public Transform[] waypoints;
    public GameObject[] enemyPrefabs;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (EnemyStatePattern enemy in enemy.enemyList)
        {
            foreach(Transform waypoint in waypoints)
            {
                transform.position = new Vector3(enemy.transform.position.x + Random.Range(-5, 5), 0, enemy.transform.position.z + Random.Range(-5, 5));
            }
        }
    }
}