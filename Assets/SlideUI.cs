using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SlideUI : MonoBehaviour
{
    [SerializeField]
    int pos1 = 0;
    [SerializeField]
    int pos2 = -300;

    
    float duration = 1f;
    float elapsed = 0f;

    Vector3 position1;
    Vector3 position2;
    private void Start()
    {
        Vector3 pos1 = new Vector3(transform.position.x, this.pos1, transform.position.z);
        Vector3 pos2 = new Vector3(transform.position.x, this.pos2, transform.position.z);

        position1 = pos1;
        position2 = pos2;



        transform.position = pos2;
    }

    public void Slide(bool up = true) //false - go down
    {
        StartCoroutine(SlideIn(up));
         
    }

    IEnumerator SlideIn(bool up)
    {
        Vector3 ogPos;
        Vector3 newPos;
        if (up)
        {
            ogPos = position2;
            newPos = position1;

        }
        else
        {
            ogPos = position1;
            newPos = position2;
        }
        while (duration < elapsed)
        {
            Debug.Log("did it");
            transform.position = Vector3.Lerp(transform.position, newPos, (elapsed/duration));
            elapsed += Time.deltaTime;
        }
        
        gameObject.transform.position = newPos;

        yield return null;
    }


}
