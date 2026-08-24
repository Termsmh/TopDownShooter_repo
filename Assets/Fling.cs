using UnityEngine;

public class Fling : MonoBehaviour
{

    [Header("Power")]
    [SerializeField]
    float flingPower = 10;
    [SerializeField]
    float rotPower = 1000;
    [Header("Damping")]
    [SerializeField]
    float RDamping = 10;
    [SerializeField]
    float FDamping = 10;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = gameObject.transform.up * flingPower;
        rb.angularVelocity = rotPower;
        rb.angularDamping = RDamping;
        rb.linearDamping = FDamping;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
