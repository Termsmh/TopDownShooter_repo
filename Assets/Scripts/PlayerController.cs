using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject[] sprites;
    int itester = 0;
    public GameObject currentSprite;



    Animator animator;


    private void Start()
    {


        SwapStates(itester);
        

        animator = currentSprite.GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
                    
                    itester++;
                    itester %= sprites.Length;
                    SwapStates(itester);
            
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            Attack();
            

        }
       

        
    }

    void SwapStates(int a)
    {

        currentSprite = sprites[a];
        foreach (var state in sprites)
        {
            state.SetActive(false);
        }
        currentSprite.SetActive(true);
        animator = currentSprite.GetComponent<Animator>();
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Die();
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        
        animator.SetBool("IsLeft", !animator.GetBool("IsLeft"));


    }

    void AnimatorHandler()
    {
        
        animator.SetBool("IsMoving", true); 
    }
}
