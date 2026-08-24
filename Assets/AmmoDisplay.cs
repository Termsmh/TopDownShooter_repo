using UnityEngine;
using UnityEngine.UI;


public class AmmoDisplay : MonoBehaviour
{

    [SerializeField]
    Sprite[] numsImages;
    
    Image currentAmmoImage;


    private void Start()
    {
        currentAmmoImage = GetComponent<Image>();
    }




    public void ChangeAmmoImage(int ammoLeft)
    {
        currentAmmoImage.sprite = numsImages[ammoLeft];
        
    }

    
}
