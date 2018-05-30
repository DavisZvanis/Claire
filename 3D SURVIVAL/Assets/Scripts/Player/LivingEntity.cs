using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float startinghealth;
    public float health;
    public bool dead;
    public float hunger;
    public float temperature;
    public float water;
    public int ammo;

    protected virtual void Start()
    {
        health = startinghealth;
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
    }
    public void UpdatePlayerStatus(float hp,float hung, float watr, int amm, float temp)
    {
        if(health + hp >= 0)
        {
            if(health + hp > 100)
            {
                health = 100;
            }
            else
            {
                health += hp;
            }
            
        }
        if(hunger + hung >= 0)
        {
            if(hunger + hung > 100)
            {
                hunger = 100;
            }
            else
            {
                hunger += hung;
            }
           
        }
        if(water + watr >= 0)
        {
            if(water + watr > 100)
            {
                water = 100;
            }
            else
            {
                water += watr;
            }
      
        }
        if(ammo + amm >= 0)
        {
            ammo += amm;
        }
        if(temperature + temp >= 0)
        {
            if(temperature + temp > 100)
            {
                temperature = 100;
            }
            else
            {
                temperature += temp;
            }
            
        }
    }
    public void Shoot()
    {
        ammo -= 1;
    }
    public bool HasAmmo()
    {
        if(ammo> 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
/*
    public void TakeHit(float damage, RaycastHit hit)
    {
        TakeDamage(damage);
    }
    */
