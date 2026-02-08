using Unity.VisualScripting;
using UnityEngine;

public class WeaponThrow : MonoBehaviour
{

    float speed = 20f;
    Rigidbody2D rb;
    bool hit = true;
    [SerializeField]
    bool lethalThrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Throw(Vector2 direction)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = direction.normalized * speed;
        transform.right = direction;
        hit = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hit) return;
        hit = true;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Die();
        }

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
