using UnityEngine;

public class Unarmed : MeleeWeapon
{

    

    public readonly static int index = 0;

    


    

    private void OnEnable()
    {
        if (ammoDisplay != null) 
        {
        ammoDisplay.ChangeAmmoImage(0);
        maxAmmoDisplay.ChangeAmmoImage(0);
        }

    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attacking with unarmed");
    }

    public override void Throw() //actually pick up
    {

        Collider2D[] cols = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f);
        Collider2D closest = null;
        float closestDist = Mathf.Infinity;
        foreach (Collider2D col in cols) 
        {
            if (col.gameObject.GetComponent<WeaponGround>() != null)
            {
                float distance = Vector2.Distance(transform.position, col.gameObject.transform.position);

                if (distance < closestDist)
                {
                    closestDist = distance;
                    closest = col;
                    
                }
                

            }
        }

        if (closest != null)
        {
            int index = closest.gameObject.GetComponent<WeaponGround>().weaponIndex;


            Debug.Log(index + ", " + closest.gameObject);


            playerController.SwapStates(index, closest.gameObject);
            Debug.Log("awa awa");
            closest.gameObject.transform.position = new Vector3(999, 999, closest.gameObject.transform.position.z);

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
