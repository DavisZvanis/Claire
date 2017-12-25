using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity {

    NavMeshAgent pathfinder;
    Transform target;

    float attackDistanceThreshold = 1.5f;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
	}
	
	// Update is called once per frame
	void Update () {
        
 
	}
    // So update not on every frame
    IEnumerator UpdatePath()
    {
        float refreshRate = 1;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
