using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 offset = new Vector3(0,0,-10f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform defaultTarget;


    private void Start()
    {
        ChangeTarget(GameObject.FindGameObjectWithTag("Player").transform);

        
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPos = defaultTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
          
    }

    private void ChangeTarget(Transform newTarget)
    {
        defaultTarget = newTarget;
    }
}
