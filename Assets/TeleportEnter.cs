using UnityEngine;

public class TeleportEnter : MonoBehaviour
{

    [SerializeField] private GameObject teleportExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = teleportExit.transform.position;
        }
    }
}
