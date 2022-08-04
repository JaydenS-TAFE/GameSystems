using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/Player/PlayerMovement")]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    private Vector3 _moveDir;
    //private float _cameraXRotation;
    private CharacterController _characterController;

    [Header("Camera")]
    [SerializeField] private Camera _camera;

    //[SerializeField] private Vector2 _cameraRotationLimits = new Vector2(-90f, 90f);
    //[SerializeField] private float lookSensitivity = 2f;

    [Header("Speeds")]
    public float speed = 6f;
    public float gravity = 9.81f;
    public float jumpForce = 5f;
    public float crouchSpeed = 2.5f;
    public float walkSpeed = 6f;
    public float runSpeed = 10f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        /*
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * lookSensitivity;

        transform.Rotate(0f, mouseInput.x, 0f);
        _cameraXRotation = Mathf.Clamp(_cameraXRotation - mouseInput.y, _cameraRotationLimits.x, _cameraRotationLimits.y);
        _camera.transform.localRotation = Quaternion.Euler(_cameraXRotation, 0f, 0f);
        */

        if (_characterController.isGrounded)
        {
            Vector3 groundNormal = Vector3.up;
            if (Physics.Raycast(transform.position + _characterController.center, Vector3.down, out RaycastHit hit, _characterController.height))
            {
                groundNormal = hit.normal;
            }

            _moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir = Vector3.ProjectOnPlane(_moveDir, groundNormal);
            _moveDir *= speed;

            if (Input.GetButton("Jump"))
            {
                _moveDir.y = jumpForce;
            }
        }
        _moveDir.y -= gravity * Time.deltaTime;

        _characterController.Move(_moveDir * Time.deltaTime);

        //Teleport the player back to the centre of the map if they fall off
        if (transform.position.y <= -20f)
        {
            transform.position = Vector3.zero;
            _moveDir = Vector3.zero;
        }

    }
    
}