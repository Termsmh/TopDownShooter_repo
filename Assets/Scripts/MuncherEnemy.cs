using UnityEngine;

public class MuncherEnemy : Enemy
{
    Animator animator;

    public bool open = false;
    private bool walks = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public override void Die()
    {
        // animator.SetBool("IsDead", true);
        /* setter.target = null;
         var colls = GetComponents<Collider2D>();
         foreach (Collider2D coll in colls) { coll.enabled = false; }*/

        if (open) {
        

        hp--;
        Debug.Log("hp left" + hp);

        if (hp <= 0)
        {
            Debug.Log("ded");
            Destroy(gameObject);
        }

        }else
        {
            Debug.Log("didnt pierce");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            animator.SetTrigger("Attack");
            open = true;
        }

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Close");
            open = false;
        }
    }


    public override void Update()
    {
        
    }

}
