using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    

    float elapsed = 0f;  

    [SerializeField]
    float damping = 1f; //the higher value - the smaller falloff (1 or less preferable)

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

            if (damping - elapsed <= 0) 
            {
                yield return null;
            }

            float xOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude * (1 - damping - elapsed);
            float yOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude * (1 - damping - elapsed);

            

            transform.localPosition = new Vector3(originalPos.x + xOffset,originalPos.y + yOffset, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;

        }
        transform.localPosition = originalPos;

    }

    
}
