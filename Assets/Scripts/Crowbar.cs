using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crowbar : MeleeWeapon
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

        Collider2D[] collider = Physics2D.OverlapBoxAll(AttackField.transform.position, new Vector2(1, 2.5f), AttackField.transform.eulerAngles.z, enemyMask);

        foreach (var col in collider)
        {
            
        if (col.isTrigger) continue;

            if (col.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("KILL ENEMY");
                col.gameObject.GetComponent<Enemy>().Die();

            }
        }


        



        animator.SetBool("IsLeft", !animator.GetBool("IsLeft"));

    }
   

    


    public override void Throw()
    {
        var pos = playerController.transform.position;
        

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = mouseWorldPos - pos;





        weaponSprite.transform.position = pos;

        weaponSprite.GetComponent<WeaponThrow>().Throw(throwDirection);



        playerController.SwapStates(0);
    }

    public override void Check(GameObject obj)
    {
        weaponSprite = obj;
        Debug.Log("crowbarcheck");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Matrix4x4 matrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(
            AttackField.transform.position,
            Quaternion.Euler(0,0,AttackField.transform.eulerAngles.z),
            Vector3.one);

        Gizmos.DrawWireCube(Vector3.zero, new Vector2(1, 2));

        Gizmos.matrix = matrix;
    }
}
