using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform cameraTransform;

    float minMagniude = 0.01f;
    float movementSpeed;
    public float fastMovementSpeed = 0.8f;
    public float notmalMovementSpeed = 0.3f;
    public float rotationSpeed = 2;

    void Start()
    {
        cameraTransform = GetComponentsInChildren<Transform>()[1];
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
        HandleKeyboardZoomInput();
    }

    private void HandleKeyboardZoomInput()
    {
        cameraTransform.localPosition += new Vector3(0,-1,1) * Input.GetAxis("Zoom Axis");
    }

    private void HandleKeyboardRotateInput()
    {
        transform.Rotate(0, Input.GetAxis("Rotation Axis") *rotationSpeed, 0);
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
