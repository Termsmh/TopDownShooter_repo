using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    Animator animator;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
        
    }
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
        


    }

    

}
