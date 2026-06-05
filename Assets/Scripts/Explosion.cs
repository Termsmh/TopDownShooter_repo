using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float timeExplo = 2f;
    [SerializeField]
    float radius = 5f;

    [SerializeField]
    Camera cam;

    [SerializeField]
    GameObject explosion;

    [SerializeField]
    float cameraShakeDuration;
    [SerializeField]
    float cameraShakeMagnitude;

    float countdown;
    public bool isThrown = false;
    public bool isTimed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = timeExplo;
        if (cam == null)
        {
            cam = Camera.main;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimed)
        {
            return;
        }

        if (isThrown)
        {
        countdown -= Time.deltaTime;


        }

        if (countdown < 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Physics2D.queriesHitTriggers = false;
        var expl = Instantiate(explosion, transform.position,Quaternion.identity);
        expl.transform.localScale = new Vector3(radius - 1, radius - 1, radius - 1);
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius, LayerMask.GetMask("Enemy", "Player"));

        foreach (Collider2D col in cols) {

            if (col.gameObject.CompareTag("Enemy")) {
                col.gameObject.GetComponent<Enemy>().Die();
            }
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<PlayerController>().Die();
            }
        }
        
        
        cam.GetComponent<CameraShake>().Shake(cameraShakeDuration, cameraShakeMagnitude);

        Physics2D.queriesHitTriggers = true;

        Debug.Log("exploded");
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(transform.position, radius);
    }



}
