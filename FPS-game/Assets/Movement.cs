using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float xSense;
    public float ySense;

    public Transform orientation;
    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X")*Time.deltaTime * xSense;
        float mouseY = Input.GetAxisRaw("Mouse Y") *Time.deltaTime * ySense;
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
