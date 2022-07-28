using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/Player/Movement")]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Character")]
    public Vector3 moveDir;
    private CharacterController _characterController;

    [Header("Speeds")]
    public float speed = 5f;
    public float gravity = 10f;
    public float jumpSpeed = 5f;
    public float crouch = 2.5f;
    public float walk = 5f;
    public float run = 10f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;

        _characterController.Move(moveDir * Time.deltaTime);
    }
    
}