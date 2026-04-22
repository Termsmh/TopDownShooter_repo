using UnityEngine;

public class Unarmed : MeleeWeapon
{

    

    public readonly static int index = 0;

    


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

                
                Debug.Log(index + ", " +col.gameObject);

                playerController.SwapStates(index, col.gameObject);
                Debug.Log("awa awa");
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
