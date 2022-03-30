using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float minMagniude = 0.1f;
    float movementSpeed;
    public float fastMovementSpeed = 0.8f;
    public float notmalMovementSpeed = 0.3f;
    public float rotationSpeed = 2;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        HandleKeyboardInput();
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        HandleMouseRotateInput();
    }

    private void HandleMouseRotateInput()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        }
    }

    private void HandleKeyboardInput()
    {
        HandleKeyboardMovementInput();
        HandleKeyboardRotateInput();
    }

    private void HandleKeyboardRotateInput()
    {
        transform.Rotate(0, Input.GetAxis("Rotation Axis"), 0);
    }

    private void HandleKeyboardMovementInput()
    {
        Vector3 keyboardInput = new Vector3(Input.GetAxis("Horizontal"),
                           Input.GetAxis("Up Axis"), Input.GetAxis("Vertical"));
        if (keyboardInput.magnitude < minMagniude)
        {
            movementSpeed = 0;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastMovementSpeed;
        }
        else
        {
            movementSpeed = notmalMovementSpeed;
        }

        transform.Translate(keyboardInput * movementSpeed);
    }
}
