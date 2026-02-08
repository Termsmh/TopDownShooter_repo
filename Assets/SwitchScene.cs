using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SwitchToTest()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
