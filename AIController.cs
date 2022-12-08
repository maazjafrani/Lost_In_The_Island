using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float chaseDistance = 12f;
    [SerializeField] float attackDistance = 3f;
    [SerializeField] float suspicionTime = 3f;
    [SerializeField] PatrolPath patrolPath;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float gravityMultiplier = 1f;
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] float walkSpeed = 2.5f;
    //[SerializeField] float walkToRunSpeedStart = 3.5f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float attackDamage = 5f;
    Health target;
    GameObject player;

    //bool isWalking = false;
    Vector3 guardPosition;
    float timeSinceLastSawPlayer = Mathf.Infinity;
    int currentWaypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        guardPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        WalkRunAnimator();
        if (InChaseRangeOfPlayer())
        {
            AttackBehaviour(player);
        }
        else
        {
            PatrolBehaviour();
        }

        /* if(isWalking)
         {
             GetComponent<Animator>().SetBool("isWalking", true);
         }
         else
         {
             GetComponent<Animator>().SetBool("isWalking", false);
         }*/

    }

    private void WalkRunAnimator()
    {
        if (moveSpeed > walkSpeed)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }

    // AttackBehaviour() includes chasing behaviour where Attack() is raw attack(hitting)
    private void AttackBehaviour(GameObject player)
    {
        moveSpeed = runSpeed;
        timeSinceLastSawPlayer = 0;
        moveSpeed = runSpeed;
        target = player.GetComponent<Health>();
        MoveToPosition(player.transform.position);
        if (InAttackRangeOfPlayer())
        {
            Attack();
        }
        else
        {
            GetComponent<Animator>().SetBool("Attack", false);
        }

    }

    private void Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void PatrolBehaviour()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        moveSpeed = walkSpeed;
        Vector3 nextPosition = guardPosition;

        if (patrolPath != null)
        {
            if (AtWaypoint())
            {
                CycleWaypoint();
            }
            nextPosition = GetCurrentWaypoint();
        }

        MoveToPosition(nextPosition);
    }

    private void MoveToPosition(Vector3 nextPosition)
    {
        //isWalking = true;
        transform.LookAt(nextPosition);

        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, nextPosition, moveSpeed * Time.deltaTime);


    }

    private Vector3 GetCurrentWaypoint()
    {
        return patrolPath.GetWaypoint(currentWaypointIndex);
    }

    private void CycleWaypoint()
    {
        currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
    }

    private bool AtWaypoint()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWaypoint < waypointTolerance;
    }

    private bool InChaseRangeOfPlayer()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanceToPlayer < chaseDistance;
    }

    private bool InAttackRangeOfPlayer()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        return distanceToPlayer < attackDistance;
    }

    //Animation Event
    void Hit()
    {
        if (target == null) return;
        target.TakeDamage(attackDamage);
    }
}
