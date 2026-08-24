using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{

    public static LevelManagement instance;

    public GameObject retryScreen;

    private Fade fade;


    

    private void Start()
    {
        fade = GetComponentInChildren<Fade>();
        retryScreen.SetActive(false);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadSceneAsync(levelIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadLevel());
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu") return;
            
            LoadLevel("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            LoadLevel("testtest");
        }
    }
    IEnumerator ReloadLevel()
    {

        fade.FadeIn();
        yield return new WaitForSeconds(5f / 6f);
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
        fade.FadeOut();

    }
}
