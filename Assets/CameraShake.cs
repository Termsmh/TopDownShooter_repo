using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    

    float elapsed = 0.0f; // Elapsed time since the shake started   


    
    private Camera _camera;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = gameObject.GetComponent<Camera>();
    }


    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    IEnumerator ShakeCoroutine(float duration, float magnitude)
    {

        Vector3 originalPos = _camera.transform.localPosition;
        while (elapsed < duration)
        {

            float x = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;
            float y = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;

            _camera.transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;

            
        }
        


        elapsed = 0.0f;



        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
