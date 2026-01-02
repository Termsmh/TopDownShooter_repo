using UnityEngine;

public class Crowbar : Weapon
{
    [SerializeField]
    private GameObject AttackField;
    
    [SerializeField]
    private PlayerController playerController;

    public readonly static int index = 1;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    



    public override void Attack()
    {
        animator.SetTrigger("Attack");

        animator.SetBool("IsLeft", !animator.GetBool("IsLeft"));

    }

    public override void Throw()
    {
        playerController.SwapStates(0);
    }

    
}
