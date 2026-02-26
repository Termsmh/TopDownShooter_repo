using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{

    public static LevelManagement instance;

    

    

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
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "MainMenu") return;
            LoadLevel("MainMenu");
        }
    }
}
