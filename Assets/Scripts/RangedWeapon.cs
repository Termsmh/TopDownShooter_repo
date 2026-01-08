using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    public GunInfo gunInfo;

    public int ammoMax;
   
    public float bulletSpeed = 10;

    public int ammo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammo = ammoMax;
    }

    
}
