using UnityEngine;

public abstract class MeleeWeapon : Weapon
{

    
    public GameObject AttackField;

    public virtual void Start()
    {
        ammoDisplay = FindFirstObjectByType<AmmoDisplay>();
        maxAmmoDisplay = FindFirstObjectByType<MaxAmmoDisplay>();
        animator = GetComponent<Animator>();
        
    }

    public PlayerController playerController;

    public Animator animator;



}
