using UnityEngine;


public class Pistol : RangedWeapon
{

    [SerializeField]
    private PlayerController playerController;


    
    public readonly static int index = 2;

    private Animator animator;

    
    

    [SerializeField]
    private GameObject bulletOrigin;

    [SerializeField]
    private Bullet bullet;

    public bool fromPlayer;


    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        ammoDisplay.ChangeAmmoImage(ammo);
        maxAmmoDisplay.ChangeAmmoImage(ammoMax);

        Debug.Log("pistolenambledawawa IN START");

        slideUI.Slide(true);

    }

    private void OnEnable()
    {
        Debug.Log("pistolenambledawawa");
        if (ammoDisplay != null) {
            
            maxAmmoDisplay.ChangeAmmoImage(ammoMax);
            slideUI.Slide(true);
        }
    }
    
    

    public override void Attack()
    {
        if (ammo > 0)
        {
        animator.SetTrigger("Attack");
            ammo--;
            ammoDisplay.ChangeAmmoImage(ammo);
            Bullet b = Instantiate(bullet, bulletOrigin.transform.position, Quaternion.identity);
            attackSound.Play();
            b.rb.transform.right = bulletOrigin.transform.right.normalized;
            b.rb.linearVelocity = b.transform.right * bulletSpeed;
            
        }
        else
        {
            
            emptySound.Play();
        }
    }

    public override void Throw()
    {
        var pos = playerController.transform.position;
        var rot = playerController.transform.rotation;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mouseWorldPos - pos;

        slideUI.Slide(false);



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
        if (ammoDisplay != null) 
        {
        
        ammoDisplay.ChangeAmmoImage(ammo);
        maxAmmoDisplay.ChangeAmmoImage(ammoMax);
        }
    }
}
