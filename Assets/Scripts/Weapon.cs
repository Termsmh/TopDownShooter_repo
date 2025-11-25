using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown;

    public virtual void Attack()
    {
        Debug.Log("BOOM");
    }

    public virtual void Throw()
    {
        Debug.Log("Throwwwwww");
    }


}
