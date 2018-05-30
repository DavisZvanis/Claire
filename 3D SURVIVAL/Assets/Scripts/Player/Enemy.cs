using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity {

    public enum State { Idle, Chasing, Attacking, Patrolling};
    State currentState;

    NavMeshAgent pathfinder;
    Transform target;
    LivingEntity targetEntity;

    float attackDistanceThreshold = .5f;
    float timeBetweenAttacks = 1;
    float damage = 1;

    float nextAttackTime;
    float myCollisionRadius;
    float targetCollisionRadius;

    bool playerVisible = false;

    public Transform[] points;
    private int destPoint = 0;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
       
        currentState = State.Patrolling;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        myCollisionRadius = GetComponent<CapsuleCollider>().radius;
        targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        StartCoroutine(UpdatePath());
    }

    void GotoNextPoint()
    {
        if (points.Length == 0) return;

        pathfinder.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    void OnTargetDeath()
    {
        currentState = State.Idle;
    }
  
	
	// Update is called once per frame
	

    IEnumerator Attack()
    {
        currentState = State.Attacking;
        pathfinder.enabled = false;

        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 attackPosition = target.position - dirToTarget * (myCollisionRadius);

        float attackSpeed = 3;
        float percent = 0;

        bool hasAppliedDamage = false;

        while (percent <= 1)
        {
            if (percent >= .5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                targetEntity.TakeDamage(damage);
            }
            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }

        currentState = State.Chasing;
        pathfinder.enabled = true;
    }
    // So update not on every frame
    IEnumerator UpdatePath()
    {
        while (true)
        {
            float refreshRate = 1;
            if (playerVisible == true)
            {
                
                    if (Time.time > nextAttackTime)
                    {
                        float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
                        if (sqrDstToTarget < Mathf.Pow(attackDistanceThreshold + myCollisionRadius + targetCollisionRadius, 2))
                        {
                            nextAttackTime = Time.time + timeBetweenAttacks;
                            StartCoroutine(Attack());
                        }
                    }
                    
                    {
                        Vector3 dirToTarget = (target.position - transform.position).normalized;
                        Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2); //how far he attacks
                        if (!dead)
                        {
                            pathfinder.SetDestination(targetPosition);
                        }
                    }
            }
            else
            {
                if (!pathfinder.pathPending && pathfinder.remainingDistance < 0.5f)
                GotoNextPoint();
            }
            Debug.Log(playerVisible);
            yield return new WaitForSeconds(refreshRate);
        }
    }
    public void PlayerVisible()
    {
        playerVisible = true;
    }
    public void PlayerNotVisible()
    {
        playerVisible = false;
    } 

}
