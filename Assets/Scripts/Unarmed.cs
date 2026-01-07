using UnityEngine;

public class Unarmed : MeleeWeapon
{

    [SerializeField]
    private GameObject AttackField;

    [SerializeField]
    private PlayerController playerController;

    public readonly static int index = 0;

    private Animator animator;


    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public override void Throw()
    {
        //pick up nearby weapon 
    }

    
}
