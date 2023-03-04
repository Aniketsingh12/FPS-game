using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Speed of movement
    public float moveSpeed = 5.0f;

    // Speed of rotation
    public float rotateSpeed = 3.0f;

    // Camera for looking around
   public Camera playerCamera;

    // Vertical camera rotation limits
    public float verticalRotationLimit = 80.0f;
    private float verticalRotation = 0.0f;

    // Gravity and jump force
    public float gravity = -9.81f;
    public float jumpForce = 5.0f;
    private bool isGrounded = true;

    // Character controller component
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is grounded
        isGrounded = controller.isGrounded;

        // Move the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        controller.Move(movement * moveSpeed * Time.deltaTime);

        // Rotate the player
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.Rotate(0, mouseX, 0);
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Apply gravity and allow jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
            isGrounded = false;
        }
        else
        {
            controller.Move(Vector3.up * gravity * Time.deltaTime);
        }
    }
}
