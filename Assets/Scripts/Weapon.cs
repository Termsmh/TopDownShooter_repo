using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    

    public GameObject weaponSprite;
    public bool lethalThrow;
    public float cooldown;
    
    public abstract void Attack();

    

    public abstract void Throw();

    



}
