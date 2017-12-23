﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float startinghealth;
    protected float health;
    protected bool dead;

    protected virtual void Start()
    {
        health = startinghealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }
}