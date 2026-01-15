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

        var collider = Physics2D.OverlapBox(AttackField.transform.position, new Vector2(1, 2), AttackField.transform.rotation.z + 90);

        if (collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("KILL ENEMY");
            collider.gameObject.GetComponent<Enemy>().Die();

        }



        animator.SetBool("IsLeft", !animator.GetBool("IsLeft"));

    }
   




    public override void Throw()
    {

        var pos = playerController.transform.position;
        var rot = playerController.transform.rotation;

        
        

        var thing = Instantiate(weaponSprite, pos, rot);

        

        //thing.AddForce()

        playerController.SwapStates(0);
    }

    
    
}
