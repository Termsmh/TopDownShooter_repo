using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{

    [SerializeField] GameObject weapon;
    

    public void SpawnWeapons()
    {
        if (weapon != null)
        {
           Instantiate(weapon, transform.position, Quaternion.identity);
        }
    }
}
