using UnityEngine;

public class DoorManagement : MonoBehaviour
{
    Animation anim;
    
    

    private void Start()
    {
        anim = GetComponent<Animation>();
        foreach (var state in anim)
        {
            Debug.Log(state);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!anim.isPlaying)
            {
                
                anim.Play();
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!anim.isPlaying)
            {
                anim.Play("DoorClose");
                
            }
        }
    }

   
}
