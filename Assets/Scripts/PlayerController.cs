using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject[] sprites;
    int itester = 0;

    private float lastAttackTime = -99f;

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
            
            //testing purposes        
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
            
                currentSprite.GetComponent<Weapon>().Throw();
            
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

        if (Time.time < lastAttackTime + currentSprite.GetComponent<Weapon>().cooldown)
        {
            Debug.Log("cooldown: " + (lastAttackTime + currentSprite.GetComponent<Weapon>().cooldown - Time.time));

            return;
        }
        
        currentSprite.GetComponent<Weapon>().Attack();
        lastAttackTime = Time.time;

    }



    public void Die()
    {
        Destroy(gameObject);
         
    }
}
