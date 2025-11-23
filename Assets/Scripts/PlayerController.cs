using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject[] states;

    GameObject currentState;

    Animator animator;

    private void Start()
    {
        currentState = states[1];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (var state in states)
            {
                if (currentState == state)
                {
                    state.SetActive(false);
                    SwapStates(0);
                    
                }

            }
        }
    }

    void SwapStates(int a)
    {

        currentState = states[a];
        currentState.SetActive(true);
        
    }

    void AnimatorHandler()
    {
        
        animator.SetBool("IsMoving", true); 
    }
}
