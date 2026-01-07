using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    Animator animator;
    

    [SerializeField] private int hp = 1;
    AIDestinationSetter setter;

    private void Start()
    {
        setter = GetComponent<AIDestinationSetter>();
        animator = GetComponent<Animator>();
    }



    public void Die()
    {
        // animator.SetBool("IsDead", true);
        /* setter.target = null;
         var colls = GetComponents<Collider2D>();
         foreach (Collider2D coll in colls) { coll.enabled = false; }*/
        Debug.Log("ded");
        Destroy(gameObject);
        
    }

    void Attack()
    {
       // PlayerController o = GetComponent<PlayerController>();
       // o.Die();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("i shall chase u rahhhhhh");
            setter.target = collider.gameObject.transform;
            
        }
    }


}
