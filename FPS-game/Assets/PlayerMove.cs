using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float jumpForce;
    public float jumpCoolDown;
    public float airMulti;
    bool ready;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHt;
    public LayerMask isGround;
    bool grounded;

    [Header("Keybindings")]
    public KeyCode jumpkey = KeyCode.Space;

    public Transform orientation;
    float HorizantolInput;
    float VerticalInput;
    Vector3 moveDir;
    Rigidbody rb;

    private void Start()
    {

        ready = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHt * 0.5f + 0.2f, isGround);
        Myinput();
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        movePlayer();
    }
    void Myinput()
    {
        HorizantolInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(jumpkey) && ready  && grounded){
            ready = false;
            jump();
            Invoke(nameof(readyjump), jumpCoolDown);
        }

    }

    void movePlayer()
    {
        moveDir = orientation.forward * VerticalInput + orientation.right * HorizantolInput;
        if(grounded)
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMulti, ForceMode.Force);

    }
    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce , ForceMode.Impulse);
    }

    void readyjump()
    {
        ready = true;
    }

}
