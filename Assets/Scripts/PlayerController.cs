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

    void AnimatorHandler()
    {
        
        animator.SetBool("IsMoving", true); 
    }
}
