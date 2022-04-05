using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform cameraTransform;

    private readonly float minMagniude = 0.1f;
    private float movementSpeed;
    public float fastMovementSpeed = 5f;
    public float notmalMovementSpeed = 2f;
    public float rotationSpeed = 2;
    public float zoomSpeed = 2;
    public float mouseExtraZoomSpeed = 40;

    public Vector3 cameraZoomMinLimit = new Vector3(0, 500, -500);
    public Vector3 cameraZoomMaxLimit = new Vector3(0, 2500, -2500);
    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;

    Ray MouseRay { get { return Camera.main.ScreenPointToRay(Input.mousePosition); } }

    void Start()
    {
        cameraTransform = GetComponentsInChildren<Transform>()[1];
    }

    void LateUpdate()
    {
        HandleKeyboardInput();
        HandleMouseInput();
        RestrictToCameraMaxAndMinZoom();
    }

    private void HandleMouseInput()
    {
        HandleMouseRotateInput();
        HandleMouseZoomInput();
        HandleMouseMiddleButtonInput();
        HandleMouseLeftClickInput();
    }

    private void HandleMouseLeftClickInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(MouseRay, out RaycastHit hitInfo) &&
                hitInfo.collider.CompareTag("Building Tile"))
            {
                hitInfo.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void HandleMouseMiddleButtonInput()
    {
        if (Input.GetMouseButtonDown(2))
        {
            var rayCastHits = Physics.RaycastAll(MouseRay);
            foreach (var hit in rayCastHits)
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    mouseStartPosition = hit.point;
                }
            }
        }
        if (Input.GetMouseButton(2))
        {
            var rayCastHits = Physics.RaycastAll(MouseRay);
            foreach (var hit in rayCastHits)
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    mouseCurrentPosition = hit.point;
                }
            }

            transform.position = Vector3.Lerp(transform.position,
              transform.position + mouseStartPosition - mouseCurrentPosition, Time.deltaTime * 30);
        }
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
        if (Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Plus))
        {
            if (cameraTransform.localPosition.y > cameraZoomMinLimit.y && 
                cameraTransform.localPosition.z < cameraZoomMinLimit.z)
            {
                cameraTransform.localPosition += new Vector3(0, -1, 1) * zoomSpeed;
            }
            RestrictToCameraMaxAndMinZoom();
        }
        if (Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.Minus))
        {
            if (cameraTransform.localPosition.y < cameraZoomMaxLimit.y &&
                cameraTransform.localPosition.z > cameraZoomMaxLimit.z)
            { 
                cameraTransform.localPosition += new Vector3(0, 1, -1) * zoomSpeed;
            }
            RestrictToCameraMaxAndMinZoom();
        }
    }
    
    private void HandleMouseZoomInput()
    {
        cameraTransform.localPosition += Input.GetAxis("Mouse ScrollWheel") 
            * mouseExtraZoomSpeed * zoomSpeed * new Vector3(0, -1, 1);
        RestrictToCameraMaxAndMinZoom();
    }

    private void RestrictToCameraMaxAndMinZoom()
    {
        if (cameraTransform.localPosition.y < cameraZoomMinLimit.y)
        {
            cameraTransform.localPosition = cameraZoomMinLimit;
        }
        if (cameraTransform.localPosition.y > cameraZoomMaxLimit.y)
        {
            cameraTransform.localPosition = cameraZoomMaxLimit;
        }
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
