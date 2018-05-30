using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// void TakeHit(float damage, RaycastHit hit);


public interface IDamagable
{
    void TakeDamage(float damage);
}
