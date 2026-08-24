using UnityEngine;

public class DestroySelf : MonoBehaviour
{


    [SerializeField]
    float delay = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, delay);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
