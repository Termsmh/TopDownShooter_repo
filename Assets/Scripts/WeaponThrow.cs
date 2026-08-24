using Unity.VisualScripting;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{

    float speed = 20f;
    Rigidbody2D rb;
    bool hit = true;
    [SerializeField]
    bool lethalThrow;
    [SerializeField]
    float rotationSpeed = 700;

    float rot = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Throw(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
       
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        rb.linearVelocity = direction.normalized * speed;
        transform.right = direction;
        hit = false;
        rot = rotationSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hit) return;
        hit = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            if (gameObject.GetComponent<Explosion>() != null) 
            {
                
                gameObject.GetComponent<Explosion>().Explode();
            }
        }
        else if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.gameObject.GetComponent<Breakable>().Break();
        }


            //rb.linearVelocity = Vector2.zero;





            rot = 0;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Rotate(new Vector3(0, 0, rot) * Time.deltaTime);
        
        
    }
}
