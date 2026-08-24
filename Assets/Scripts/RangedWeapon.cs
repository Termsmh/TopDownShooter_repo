using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    public GunInfo gunInfo;

    public int ammoMax;
   
    public float bulletSpeed = 10;

    public int ammo;

    public AudioSource emptySound;




    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public virtual void Start()
    {
        ammo = ammoMax;
        slideUI = FindFirstObjectByType<SlideUI>();
        ammoDisplay = FindFirstObjectByType<AmmoDisplay>();
        maxAmmoDisplay = FindFirstObjectByType<MaxAmmoDisplay>();
    }

    private void OnEnable()
    {
        if (ammoDisplay != null) 
        {
            ammoDisplay.ChangeAmmoImage(ammo);
            maxAmmoDisplay.ChangeAmmoImage(ammoMax);
        }
    }

}
