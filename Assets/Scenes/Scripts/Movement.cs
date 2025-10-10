using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
   

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        LookAtCamera();



    }


    private void LookAtCamera()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Camera.main.transform.rotation = Quaternion.Euler(0f,0f,0f);
    }

    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void ProcessInputs() //check for input
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; // makes diagonal speed the same
        
    }
}
