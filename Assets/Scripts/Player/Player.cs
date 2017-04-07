using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    Classes charClass;
    //public GameObject playerPrefab = null;
    public List<Classes> classes;

    public Rigidbody rb;
    public CapsuleCollider cc;

    private NavMeshAgent nma;
    private Transform    targetEnemy;
    private bool         enemyClicked;
    private bool         moving;

    //public float attackDistance = 20;
    //public float attackRate = .5f;
    //public float nextAttack;

#region Stats stuff
    public int strength;       // Attack damage, health
    public int intelligence;   // Amount of mana
    public int dexterity;      // Attack rate
    public int health, maxHealth;
    public int mana, maxMana;
#endregion

    // Use this for initialization
    void Start ()
    {
        nma     = GetComponent<NavMeshAgent>();
        rb      = GetComponent<Rigidbody>();
        cc      = GetComponent<CapsuleCollider>();
        classes = new List<Classes>();
#region Start Stats stuff
        strength = Random.Range(5, 15) + charClass.strengthBonus;
        Debug.Log("Strength: " + strength);
        intelligence = Random.Range(5, 15) + charClass.intelligenceBonus;
        Debug.Log("Intelligence: " + intelligence);
        dexterity = Random.Range(5, 15) + charClass.dexterityBonus;
        Debug.Log("Dexterity: " + dexterity);

        maxHealth = Random.Range(30, 55) + (int)Mathf.Round(strength * .33f);
        health = maxHealth;
        Debug.Log("Health/MaxHealth = " + health + "/" + maxHealth);

        maxMana = Random.Range(30, 55) + (int)Mathf.Round(intelligence * .4f);
        mana = maxMana;
        Debug.Log("Mana/MaxMana = " + mana + "/" + maxMana);
#endregion
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetButton("Fire1")) // Left mouse button
        {
            if (Physics.Raycast(ray, out hit, 50)) // 50 should be at least the distance between camera and clicked surface (make a variable for that later? For elevation changes)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    targetEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    enemyClicked = false;
                    nma.destination = hit.point;
                    nma.Resume();
                }
            }
        }

        if (nma.remainingDistance <= nma.stoppingDistance)
            if (!nma.hasPath || Mathf.Abs(nma.velocity.sqrMagnitude) < float.Epsilon)
                moving = false;
        else
        {
            moving = true;
        }
    }

    //private void MoveAndAttack()
    //{
    //    if (targetEnemy == null)
    //        return;
    //    nma.destination = targetEnemy.position;
    //    if (nma.remainingDistance <= attackDistance)
    //    {
    //        nma.Resume();
    //        moving = true;
    //    }

    //    if (nma.remainingDistance <= attackDistance)
    //    {
    //        transform.LookAt(targetEnemy);
    //        Vector3 directionToAttack = targetEnemy.transform.position - transform.position;
    //        if (Time.time < nextAttack)
    //        {
    //            nextAttack = Time.time + attackRate;
    //        }
    //    }
    //}
}
