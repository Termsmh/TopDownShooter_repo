using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] Animator animator;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //LockCameraOnPlayer();
        LookAtMouse();
        ProcessInputs();



    }


    private void LookAtMouse()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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

        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else animator.SetBool("IsMoving", false);
        
    }
}
