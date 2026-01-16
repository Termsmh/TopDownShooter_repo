using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;
using System;

public class Enemy : MonoBehaviour
{
    Animator animator;

    private bool angry;
    [SerializeField] private int hp = 1;
    AIDestinationSetter setter;

    private void Start()
    {
        setter = GetComponent<AIDestinationSetter>();
        animator = GetComponentInChildren<Animator>();
    }



    public void Die()
    {
        // animator.SetBool("IsDead", true);
        /* setter.target = null;
         var colls = GetComponents<Collider2D>();
         foreach (Collider2D coll in colls) { coll.enabled = false; }*/

        hp--;
        Debug.Log("hp left" + hp);

        if (hp  <= 0)
        {
        Debug.Log("ded");
        Destroy(gameObject);
        }
        
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
            angry = true;
        }
        
    }

    private void ResetBehaviour()
    {
        setter.target = null;
        angry=false;
    }
    

    private void Update()
    {
        if (angry)
        {
            animator.SetBool("IsWalking", true);

        }
        else
            animator.SetBool("IsWalking", false);
    }

}
