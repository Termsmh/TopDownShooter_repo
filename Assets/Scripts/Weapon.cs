using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public LayerMask enemyMask;

    public GameObject weaponSprite;
    public bool lethalThrow;
    public float cooldown;
    
    public abstract void Attack();

    

    public abstract void Throw();

    public abstract void Check(GameObject obj);

    



}
