using System.Linq;
using Unity.VisualScripting;
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

        if (Input.GetMouseButtonDown(1)) 
        {
            if (currentSprite == sprites[0])
            {
                Debug.Log("swap" + Crowbar.index);
                SwapStates(Crowbar.index);
            }
            else if (currentSprite == sprites[Crowbar.index])
            {
                currentSprite.GetComponent<Weapon>().Throw();
            }
        }
       

        
    }

    public void SwapStates(int a)
    {

        currentSprite = sprites[a];
        foreach (var state in sprites)
        {
            state.SetActive(false);
        }
        currentSprite.SetActive(true);
        animator = currentSprite.GetComponent<Animator>();
        
    }

    
    

    void Attack()
    {
        //animator.SetTrigger("Attack");
        
        //animator.SetBool("IsLeft", !animator.GetBool("IsLeft"));
        
        currentSprite.GetComponent<Weapon>().Attack();
        
        


    }

    void AnimatorHandler()
    {
        
        animator.SetBool("IsMoving", true); 
    }
}
