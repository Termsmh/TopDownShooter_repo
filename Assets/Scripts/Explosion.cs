using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float timeExplo = 2f;
    [SerializeField]
    float radius = 5f;

    float countdown;
    public bool isThrown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = timeExplo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrown)
        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D col in cols) {
            if (col.gameObject.GetComponent<Enemy>() != null) {
                col.gameObject.GetComponent<Enemy>().Die();
            }
        }

        Destroy(gameObject);

    }
}
