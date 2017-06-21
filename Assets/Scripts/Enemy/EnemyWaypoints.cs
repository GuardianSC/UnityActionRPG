//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace UnityActionRPG.AI
//{
//    public class EnemyWaypoints : MonoBehaviour
//    {
//        //BaseEnemy enemy;
//        public Transform[] waypoints;
//        public GameObject waypointPrefab;

//        // Use this for initialization
//        void Start()
//        {

//        }

//        // Update is called once per frame
//        void Update()
//        {
//            //foreach (BaseEnemy enemy in enemy.enemyList)
//            //{
//                foreach (Transform waypoint in waypoints)
//                {
//                    Vector3 spawnPosition = new Vector3(this.transform.position.x + Random.Range(-10, 10), 0, this.transform.position.z + Random.Range(-10, 10));
//                    transform.position = new Vector3(this.transform.position.x + Random.Range(-5, 5), 0, this.transform.position.z + Random.Range(-5, 5));
//                    GameObject clone = (GameObject)Instantiate(waypointPrefab, transform.position, Quaternion.Euler(0, 0, 0));
//                }
//            //}
//        }
//    }
//}