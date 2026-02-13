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
        Debug.Log("Attacking with unarmed");
    }

    public override void Throw()
    {
         Collider2D[] cols = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f);

        foreach (Collider2D col in cols) 
        {
            if (col.gameObject.GetComponent<WeaponGround>() != null)
            {
                int index = col.gameObject.GetComponent<WeaponGround>().weaponIndex;

                
                
                playerController.SwapStates(index, col.gameObject);

                col.gameObject.transform.position = new Vector3(999, 999, col.gameObject.transform.position.z);

                return;
                
            }
        }

        //pick up nearby weapon 
    }

    public override void Check(GameObject obj)
    {
        Debug.Log(obj.name + " not supposed to be anything");
    }
    /*private void OnDrawGizmos()
{
   Gizmos.color = Color.yellow;
   Gizmos.DrawSphere(gameObject.transform.position, 2f);
}*/


}
