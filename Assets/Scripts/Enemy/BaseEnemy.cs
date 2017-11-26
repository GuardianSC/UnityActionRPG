using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnityActionRPG.AI
{
    public class BaseEnemy : MonoBehaviour
    {
        private Rigidbody rb;
        private CapsuleCollider cc;

        public float sightRange = 20f;        // Length of raycast for seeing player
        public Transform[] waypoints;       // Used for patrol state
        public Vector3 waypoint;       // Used for wander state
        public GameObject waypointPrefab;   // Waypoint prefab
        public Transform raycastOrigin;       // Enemy
        public MeshRenderer meshRendererFlag; // Indicator to show an enemy's state
        public bool spawnWanderWaypoint = false;

        [HideInInspector] public Transform    chaseTarget; // Player
        [HideInInspector] public IEnemyStates currentState;
        [HideInInspector] public PatrolState  patrolState;
        [HideInInspector] public ChaseState   chaseState;
        [HideInInspector] public IdleState    idleState;
        [HideInInspector] public WanderState  wanderState;
        [HideInInspector] public UnityEngine.AI.NavMeshAgent nma;

        //public List<BaseEnemy> enemyList = new List<BaseEnemy>();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            cc = GetComponent<CapsuleCollider>();
            nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
            patrolState = new PatrolState(this);
            chaseState  = new ChaseState(this);
            idleState   = new IdleState(this);
            wanderState = new WanderState(this);
        }

	    // Use this for initialization
	    void Start ()
        {
            currentState = wanderState;
	    }
	
	    // Update is called once per frame
	    public void Update ()
        {
            currentState.UpdateState();
	    }

        private void OnTriggerEnter(Collider other)
        {
            currentState.OnTriggerEnter(other);
        }
    }
}
