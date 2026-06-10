using UnityEngine;
using UnityEngine.UI;


public class VolumeManager : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
