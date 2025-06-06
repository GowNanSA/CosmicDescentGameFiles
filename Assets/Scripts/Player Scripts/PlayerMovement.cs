using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //script for playermovement
    [Header("Player Movement")] 
    public float speed;
    
    public float drag;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    private void Update() {
        MyInput();
        rb.linearDamping = drag;
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer() {

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        //have player bob up and down when moving and not keep flying
        if (verticalInput != 0 || horizontalInput != 0)
        {
            rb.AddForce(Vector3.down * 10f, ForceMode.Force);
        }
        //limit player speed to max speed
        if (rb.linearVelocity.magnitude > speed)
        {
            Vector3 limitVelocity = rb.linearVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(limitVelocity.x, rb.linearVelocity.y, limitVelocity.z);
        }
        //limit player speed to max speed when moving up and down
        if (rb.linearVelocity.y > speed)
        {
            Vector3 limitVelocity = rb.linearVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, limitVelocity.y, rb.linearVelocity.z);
        }

    }

}