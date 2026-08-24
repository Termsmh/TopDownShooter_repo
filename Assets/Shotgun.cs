using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private PlayerController playerController;



    public readonly static int index = 6;

    private Animator animator;




    [SerializeField]
    private GameObject bulletOrigin;

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private Vector2 range;

    public bool fromPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        ammoDisplay.ChangeAmmoImage(ammo);
        maxAmmoDisplay.ChangeAmmoImage(ammoMax);

       

        slideUI.Slide(true);
    }

    private void OnEnable()
    {
        Debug.Log("gunshotung,n");
        if (ammoDisplay != null)
        {
            ammoDisplay.ChangeAmmoImage(ammo);
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
            attackSound.Play();

            for (int i = 0; i < 4; i++)
            {
                float spread = Random.Range(range.x, range.y);

                Debug.Log("loop " + i);

                Bullet b = Instantiate(bullet, bulletOrigin.transform.position, bulletOrigin.transform.rotation * Quaternion.Euler(new Vector3(0,0,spread)));
                b.rb.transform.right = bulletOrigin.transform.right.normalized;
                b.rb.linearVelocity = b.transform.right * bulletSpeed;
                
            }

                
            


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
