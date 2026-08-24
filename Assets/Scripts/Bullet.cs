using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody2D rb;

    public float timeToDestroy = 3f;

    

    

    private void Start()
    {
        

        StartCoroutine(BulletCoroutine());

    }

    IEnumerator BulletCoroutine()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("Bullet"))
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Enemy e = collision.gameObject.GetComponent<Enemy>();
                e.Die();
            }

            if (collision.gameObject.GetComponent<Explosion>() != null) 
            {
                collision.gameObject.GetComponent<Explosion>().Explode();
            }


            Debug.Log(collision.gameObject.name);
                Destroy(gameObject);
            

        }
                

    }



}
