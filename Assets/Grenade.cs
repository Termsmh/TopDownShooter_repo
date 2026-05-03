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
        Debug.Log(obj.name + " not supposed to be anything");
    }

    public override void Throw()
    {
        var pos = playerController.transform.position;


        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mouseWorldPos - pos;





        weaponSprite.transform.position = pos;

        weaponSprite.GetComponent<Explosion>().isThrown = true;
        weaponSprite.GetComponent<WeaponThrow>().Throw(throwDirection);


        playerController.SwapStates(0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
