using UnityEngine;
using UnityEngine.UIElements;

public abstract class Weapon : MonoBehaviour
{

    public LayerMask enemyMask;

    public GameObject weaponSprite;
    public bool lethalThrow;
    public float cooldown;
    public AudioSource attackSound;

    public AmmoDisplay ammoDisplay;

    public MaxAmmoDisplay maxAmmoDisplay;

    public SlideUI slideUI;


    public abstract void Attack();

    

    public abstract void Throw();

    public abstract void Check(GameObject obj);

    

    



}
