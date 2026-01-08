using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.tag.Equals("Player"))
        {
            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Enemy e = collision.gameObject.GetComponent<Enemy>();
                e.Die();
            }
         

            Debug.Log("wallboomawa");
            Destroy(gameObject);

        }
        
        
    }



}
