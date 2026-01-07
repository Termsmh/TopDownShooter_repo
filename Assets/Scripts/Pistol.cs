using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Pistol : Weapon
{

    [SerializeField]
    private PlayerController playerController;

    public readonly static int index = 2;

    private Animator animator;

    [SerializeField]
    private int ammoMax;

    [SerializeField]
    private int ammo;

    [SerializeField]
    private GameObject bulletOrigin;

    [SerializeField]
    private Bullet bullet;

    public bool fromPlayer;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Attack()
    {
        if (ammo > 0)
        {
        animator.SetTrigger("Attack");
            ammo--;
        }
    }

    public override void Throw()
    {
        var pos = playerController.transform.position;
        var rot = playerController.transform.rotation;




        var thing = Instantiate(weaponSprite, pos, rot);
        playerController.SwapStates(0);

    }


}
