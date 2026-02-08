using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Pistol : RangedWeapon
{

    [SerializeField]
    private PlayerController playerController;


    [SerializeField]
    public readonly static int index = 2;

    private Animator animator;

    
    

    [SerializeField]
    private GameObject bulletOrigin;

    [SerializeField]
    private Bullet bullet;

    public bool fromPlayer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        ammo = ammoMax;
    }
    public override void Attack()
    {
        if (ammo > 0)
        {
        animator.SetTrigger("Attack");
            ammo--;
            Bullet b = Instantiate(bullet, bulletOrigin.transform.position, Quaternion.identity);
            
            b.rb.transform.right = bulletOrigin.transform.right.normalized;
            b.rb.linearVelocity = b.transform.right * bulletSpeed;
            
        }
    }

    public override void Throw()
    {
        var pos = playerController.transform.position;
        var rot = playerController.transform.rotation;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mouseWorldPos - pos;





        weaponSprite.transform.position = pos;

        weaponSprite.GetComponent<WeaponThrow>().Throw(throwDirection);

        weaponSprite.GetComponent<GunInfo>().ammoLeft = ammo;



        playerController.SwapStates(0);

    }

    

    public override void Check(GameObject obj)
    {
        weaponSprite = obj;
        gunInfo = obj.GetComponent<GunInfo>();

        ammo = gunInfo.ammoLeft;
    }
}
