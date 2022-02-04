using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float detectionRadius = 7.0f;
    private float rotationSpeed = 100;

    private Rigidbody rigidbody = null;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= detectionRadius)
        {
            agent.SetDestination(target.position);
        }

        // Rotate the player (TODO IF CHASING)
        Vector3 lookAtPosition = new Vector3(target.position.x, 0.0f, target.position.z); 
        transform.LookAt(lookAtPosition);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
