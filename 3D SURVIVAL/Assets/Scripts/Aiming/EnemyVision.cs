using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask enemyMask;
    public LayerMask obsticleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    public Enemy1 enemy;
    public LivingEntity enemyEntity;


    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }



    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            FindClosestEnemy();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, enemyMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obsticleMask))
                {
                    visibleTargets.Add(target);
                    //see the target
                }
            }
        }
    }
    public GameObject FindClosestEnemy()
    {
        if (visibleTargets.Count != 0)
        {
          //  enemy.PlayerVisible();
            return null;
        }
        else
        {
           // enemy.PlayerNotVisible();
            return null;
        }

    }


    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;

        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
