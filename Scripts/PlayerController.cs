using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform playerCamera;
    public float mouseSensitivity = 3.0f;
    private float cameraPitch = 0.0f;
    private float maxPitchAngle = 90.0f;

    public CharacterController controller;
    public float walkSpeed = 3.0f;
    public float runSpeed = 16.0f;


    Vector3 gravity;
    float gravityForce = 9.81f;
    float jumpForce = 5.0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        MouseLook();
        Debug.Log(gravity.y);
    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    void MouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -maxPitchAngle, maxPitchAngle);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);
        
    }


    void UpdateMovement()
    {
        if (controller.isGrounded) {
            gravity.y = 0f;
            if (Input.GetKey(KeyCode.Space)) {
                gravity.y += jumpForce;
            }
        } else if (!controller.isGrounded) {
            gravity.y -= gravityForce * Time.deltaTime;
        }


        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection.Normalize();

        Vector3 velocity = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed) * (transform.forward * inputDirection.y + transform.right * inputDirection.x);

        controller.Move(velocity * Time.deltaTime);

        controller.Move(gravity * Time.deltaTime);
    }
    
}
