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
         Collider2D[] cols = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);

        foreach (Collider2D col in cols) 
        {
            if (col.gameObject.GetComponent<Weapon>() != null)
            {
                Debug.Log(col.gameObject.name);
            }
        }

        //pick up nearby weapon 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.transform.position, 2f);
    }


}
