using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

  /*  public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;
    float skinWidth = .1f;

    float lifetime = 3;

    private void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if(initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0]);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

	// Update is called once per frame
	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	}

    void CheckCollisions (float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }

    }

  /*  void OnHitObject(RaycastHit hit)
    {
        IDamagable damagableObject = hit.collider.GetComponent<IDamagable>();
        if (damagableObject != null)
        {
            damagableObject.TakeHit(damage, hit);
        }
        //Destroy(hit.transform.gameObject);
        GameObject.Destroy(gameObject);
    }
    */

       /*
    void OnHitObject(Collider c)
    {
        IDamagable damagableObject = c.GetComponent<IDamagable>();
        if (damagableObject != null)
        {
            damagableObject.TakeDamage(damage);
        }
        //Destroy(hit.transform.gameObject);
        GameObject.Destroy(gameObject);
    }

    */
}
