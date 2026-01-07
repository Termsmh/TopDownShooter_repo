using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    

    public Rigidbody2D weaponSprite;
    public bool lethalThrow;
    public float cooldown;
    
    public abstract void Attack();

    

    public abstract void Throw();

    



}
