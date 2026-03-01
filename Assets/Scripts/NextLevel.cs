 using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public bool active = true;

    public LevelManagement levelManagement;

    public Fade fade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(LoadNextLevel());
            }
        }
            
    }

    IEnumerator LoadNextLevel()
    {

        fade.FadeIn();
        yield return new WaitForSeconds(5f/6f);
        levelManagement.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        fade.FadeOut();
        
    }

}
