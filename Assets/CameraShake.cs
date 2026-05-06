using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    

    float elapsed = 0.0f; // Elapsed time since the shake started   

    [SerializeField]
    float damping = 1f;
    

    
   
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    IEnumerator ShakeCoroutine(float duration, float magnitude)
    {

        elapsed = 0f;

        Vector3 originalPos = transform.localPosition;

        while (elapsed < duration)
        {

            float xOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(originalPos.x + xOffset,originalPos.y + yOffset, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;


        }


        transform.localPosition = originalPos;




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
