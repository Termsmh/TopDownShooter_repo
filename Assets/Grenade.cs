    using UnityEngine;

public class Grenade : MeleeWeapon
{
    public readonly static int index = 4;
    

    public override void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attacking with grenade");
    }

    public override void Check(GameObject obj)
    {
        weaponSprite = obj;
        Debug.Log(obj.name + " not supposed to be anything");
    }

    public override void Throw()
    {
        var pos = playerController.transform.position;


        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mouseWorldPos - pos;





        weaponSprite.transform.position = pos;
        Debug.Log(pos);

        Debug.Log("thrown");
        weaponSprite.GetComponent<WeaponThrow>().Throw(throwDirection);
        weaponSprite.GetComponent<Explosion>().isThrown = true;


        playerController.SwapStates(0);
    }

    
}
