using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    bool MeleeBreakable;

    [SerializeField]
    int spawnAmount;

    [SerializeField]
    GameObject[] fragments;

    [SerializeField]
    GameObject breakSound;
    
    SpawnWeapon wpnSpawner;

    private void Start()
    {
        if (wpnSpawner == null) 
        {
            wpnSpawner = GetComponent<SpawnWeapon>();
        }
    }

    public void SpawnFrags()
    {

        

        if (wpnSpawner != null) { wpnSpawner.SpawnWeapons(); }




        GameObject[] spawningFrags = new GameObject[spawnAmount];

        for (int i = 0; i < spawningFrags.Length; ++i)
        {
            
            spawningFrags[i] = fragments[Random.Range(0, fragments.Length)];
        }


        foreach (GameObject frag in spawningFrags)
        {
            if (frag != null) 
            {
                GameObject g = Instantiate(frag, transform.position, Quaternion.identity);
                Debug.Log("spawned");
                g.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0,360));
                
                
            }
        }
    }
    

    void PlaySound()
    {
        if ( breakSound != null && breakSound.GetComponent<AudioSource>() != null)
        {
            Instantiate(breakSound, transform.position, Quaternion.identity);
        }
    }

    public void ExploBreak()
    {
        Break();
    }

    public void MeleeBreak()
    {
        if (MeleeBreakable)
        {
            Break();
        }
    }

    public void Break()
    {
        PlaySound();
        Debug.Log("broke");
        SpawnFrags();
        Destroy(gameObject);
        
    }
}
