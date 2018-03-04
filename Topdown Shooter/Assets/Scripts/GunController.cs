using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;
    private int ammo = 100000;

    void Start()
    {
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

	public void EquipGun (Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position,weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void UnequipGun()
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
    }

    public void Shoot()
    {
        if(equippedGun != null && ammo >= 0)
        {
            equippedGun.Shoot();
            ammo -= 1;
        }
    }
 
}
