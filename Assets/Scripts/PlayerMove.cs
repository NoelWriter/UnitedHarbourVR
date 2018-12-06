using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private string JumpInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private string mouseYInputName;
    [SerializeField] private bool isFly;

    private float deltaYAxis;
    private float gravity = 20.0f;
    private float axisModulator = 1.15f;
    private float heightConstant;
    float lastFlyState;

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Checks if the game if paused. When it is, dont update.
        if (Time.timeScale != 0)
        {
            float flying = Input.GetAxis("Fire3");

            if (flying != lastFlyState)
            {
                lastFlyState = flying;

                if (flying != 0)
                {
                    isFly = !isFly;
                }
            }
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        heightConstant = movementSpeed * axisModulator;
        float mouseY = Input.GetAxis(mouseYInputName) * heightConstant * Time.deltaTime;
        deltaYAxis += mouseY;

        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;
        Vector3 upMovement = Vector3.up * deltaYAxis;
        Vector3 gravMovement = Vector3.down * 0.1f;

        if (isFly)
        {
            if (vertInput > 0)
            {
                charController.Move(forwardMovement + rightMovement + upMovement);
            }
            else
            {
                charController.Move(forwardMovement + rightMovement);
            }
        }
        else
        {
            //moveDirection.y = moveDirection.y - (gravity* Time.deltaTime);
            charController.Move(forwardMovement + rightMovement + gravMovement);
        }
    }
}