using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseEnemy : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider cc;

    public float sightRange = 20f;        // Length of raycast for seeing player
    public Transform[] waypoints;         // Used for patrol state
    public GameObject waypointPrefab;     // Waypoint prefab
    public Transform raycastOrigin;       // Enemy
    public MeshRenderer meshRendererFlag; // Debugging thing to show enemy state

    [HideInInspector] public Transform    chaseTarget; // Player
    [HideInInspector] public IEnemyStates currentState;
    [HideInInspector] public PatrolState  patrolState;
    [HideInInspector] public ChaseState   chaseState;
    [HideInInspector] public IdleState    idleState;
    [HideInInspector] public UnityEngine.AI.NavMeshAgent nma;

    public List<BaseEnemy> enemyList = new List<BaseEnemy>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        nma = GetComponent<UnityEngine.AI.NavMeshAgent>();
        patrolState = new PatrolState(this);
        chaseState  = new  ChaseState(this);
    }

	// Use this for initialization
	void Start ()
    {
        currentState = patrolState;
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

    //public void RandomizeWaypoints()
    //{
    //    Vector3 randomVector = new Vector3(raycastOrigin.position.x + Random.Range(-5, 5), 0, raycastOrigin.position.z + Random.Range(-5, 5));
        
    //    for (int i = 0; i > 0; i++)
    //    {
            
    //    }
    //}
}