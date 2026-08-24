using UnityEngine;
using UnityEngine.UI;

public class MaxAmmoDisplay : MonoBehaviour
{
    [SerializeField]
    Sprite[] numsImages;
    [SerializeField]
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
