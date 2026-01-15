using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Rigidbody2D rb;

    public float timeToDestroy = 3f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;

    }

    private void Update()
    {
        float timeSinceSpawn = Time.time - startTime;

        if (timeSinceSpawn < timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

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
        else
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.Die();
            }

        }
    }



}
