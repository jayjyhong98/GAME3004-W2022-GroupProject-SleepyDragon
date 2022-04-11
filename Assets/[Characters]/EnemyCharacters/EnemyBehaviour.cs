//*********************************************************************************************************
// Author: Pauleen Lam
//
// Last Modified: February 5, 2022
//  
// Description: This script is used to implement Enemy.
//
//******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    IDLE,
    ROAM,
    CHASE,
    ATTACK
}

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField, Header("PawnSensing")]
    private float detectionRadius = 7.0f;
    [SerializeField]
    private float attackRadius = 2.0f;
    private float rotationSpeed = 100;

    [SerializeField]
    private int health = 3;

    private EnemyState state = EnemyState.IDLE;

    private Rigidbody rigidbody = null;
    private Animator animator = null;

    // AI
    Transform target;
    NavMeshAgent agent;

    public readonly int IsMovingHash = Animator.StringToHash("IsMoving");
    public readonly int IsAttackingHash = Animator.StringToHash("IsAttacking");

    //Sound Manager
    [SerializeField]
    public SoundManagerScript soundManager;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        target = PlayerManager.instance.player.transform;
        //agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        soundManager = FindObjectOfType<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if can see target, if so change state to chase
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= detectionRadius)
        {
            state = EnemyState.CHASE;

            // If target is within attack range, change to attack state
            if (distance <= attackRadius)
            {
                state = EnemyState.ATTACK;
                animator.SetBool(IsAttackingHash, true);
                //soundManager.PlayEnemyAttackSFX();
            }
            else
            {
                animator.SetBool(IsMovingHash, true);
                animator.SetBool(IsAttackingHash, false);
            }
            
        }
        else
        {
            state = EnemyState.IDLE;
            animator.SetBool(IsMovingHash, false);
        }

        switch (state)
        {
            case EnemyState.IDLE:
                break;

            case EnemyState.ROAM:
                break;

            case EnemyState.CHASE:
                // Chase player
                agent.SetDestination(target.position);

                RotateToTarget();
                break;

            case EnemyState.ATTACK:
                RotateToTarget();
                break;
        }
    }

    private void RotateToTarget()
    {
        // Rotate to face the target
        Vector3 lookAtPosition = new Vector3(target.position.x, 0.0f, target.position.z);
        transform.LookAt(lookAtPosition);
    }

    public void TakeDamage(int damage = 1)
    {
        Debug.Log("Enemy is taking damage");
        //soundManager.PlayEnemyHurtSFX();
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreCounter.scoreAmount = ScoreCounter.scoreAmount + 50;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
