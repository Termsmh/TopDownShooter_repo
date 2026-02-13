using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject Object;
    public int SpawnOrder;

    public void Spawn()
    {
        Instantiate(Object, transform.position, transform.rotation);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
