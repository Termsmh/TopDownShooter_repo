using UnityEngine;

public class GasCan : MeleeWeapon
{
    public readonly static int index = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponentInParent<Movement>().moveSpeed = 4;
        animator.speed = 0.5f;
    }
    public override void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attacking with gas can");
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

        Debug.Log("tohorwn");
        weaponSprite.GetComponent<WeaponThrow>().Throw(throwDirection);
        weaponSprite.GetComponent<Explosion>().isThrown = true;

        GetComponentInParent<Movement>().moveSpeed = 8;
        playerController.SwapStates(0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
}
