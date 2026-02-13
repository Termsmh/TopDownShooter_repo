using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public bool active = true;

    public LevelManagement levelManagement;

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
        yield return new WaitForSeconds(1f);
        levelManagement.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
