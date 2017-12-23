using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    public Text ammoCount;
    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;
    private int ammo = 100;

    void Start()
    {
        AmmoCountText();
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
    public void Shoot()
    {
        if(equippedGun != null && ammo >= 0)
        {
            equippedGun.Shoot();
            AmmoCountText();
            ammo -= 1;
        }
    }
    public void GainAmmo(int bullets)
    {
        ammo += bullets;
        AmmoCountText();
    }

    public void AmmoCountText()
    {
        ammoCount.text = "Gun ammo:" + ammo.ToString();
    }
}
