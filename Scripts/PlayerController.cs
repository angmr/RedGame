using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] float mouseSensitivity = 3.0f;
    public float moveSpeed = 4.0f;
    public float runSpeed = 40.0f;
    public float walkSpeed = 4.0f;
    [SerializeField] float gravity = -10.0f;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        UpdateMouseLook();
        IsRunning();
        UpdateMovement();
    }


    void UpdateMouseLook()
    {
        Vector2 mouseDela = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDela.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDela.x * mouseSensitivity);
    }


    void UpdateMovement()
    {
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDirection.Normalize();

        if(controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;



        Vector3 velocity = (transform.forward * inputDirection.y + transform.right * inputDirection.x) * moveSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

    float IsRunning() // Sprint
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && controller.isGrounded) {moveSpeed = runSpeed;} // Hold Shift to Sprint
        if (Input.GetKeyUp(KeyCode.LeftShift) && controller.isGrounded) {moveSpeed = walkSpeed;} // Release Shift to Walk

        return walkSpeed;
    }
}
