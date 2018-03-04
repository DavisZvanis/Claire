using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float startinghealth;
    public float health;
    public bool dead;
    public float hunger;
    public float temperture;
    public float water;
    public bool isBleeding;

    public event System.Action OnDeath;

    protected virtual void Start()
    {
        health = startinghealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        TakeDamage(damage);
    }
    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }
    protected void Die()
    {
        dead = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }
    public void UpdatePlayerStatus(float hp,float hung, float watr)
    {
        health += hp;
        hunger += hung;
        water += watr;
    }
}
