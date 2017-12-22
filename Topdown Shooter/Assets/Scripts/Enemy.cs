using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour {

    NavMeshAgent pathfinder;
    Transform target;

	// Use this for initialization
	void Start () {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
	}
	
	// Update is called once per frame
	void Update () {
 
	}

    IEnumerator UpdatePath()
    {
        float refreshRate = 1;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
