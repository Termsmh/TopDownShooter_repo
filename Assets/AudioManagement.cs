using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagement : MonoBehaviour
{

    [SerializeField]
    AudioSource[] audioSources;

    private static AudioManagement instance;

    public static AudioManagement Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != 0) 
        {
            PlaySong(1);
        }
        else if (level == 0)
        {
            PlaySong(0);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            PlaySong(0);
        }
    }



    public void PlaySong(int songId)
    {
       
        

        if (!audioSources[songId].isPlaying)
        {
            StopSong();


            audioSources[songId].Play();
        }
    }



    public void StopSong()
    {
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }
    }
}
