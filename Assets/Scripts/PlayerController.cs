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
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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


    }

    void AnimatorHandler()
    {
        
        animator.SetBool("IsMoving", true); 
    }
}
