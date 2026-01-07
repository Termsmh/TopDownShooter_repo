using Pathfinding;
using System;
using UnityEngine;

public class SpriteBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AIPath _aiPath;

    Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        FaceMovement();
    }

    private void FaceMovement()
    {
        direction = _aiPath.desiredVelocity;
        transform.right = direction;
    }
}
