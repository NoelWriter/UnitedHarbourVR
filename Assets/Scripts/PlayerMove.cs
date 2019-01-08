using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private string JumpInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementSpeedMultiplier;
    [SerializeField] private string mouseYInputName;
    [SerializeField] private bool isFly;

    private float deltaYAxis;
    private float gravity = 25.0f;
    private float axisModulator = 0.01f;
    private float heightConstant;
    private float boostConstant = 1;
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
            //check boost
            checkBoost();
            //Check for flying
            checkFlying();
            playerMovement();
        }
    }

    private void playerMovement()
    {
        heightConstant = movementSpeed * boostConstant * axisModulator;
        float mouseY = Input.GetAxis(mouseYInputName) * heightConstant * Time.deltaTime;
        deltaYAxis += mouseY;

        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed * boostConstant;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed * boostConstant;

        Vector3 forwardMovement = Camera.main.transform.forward * vertInput;
        Vector3 rightMovement = Camera.main.transform.right * horizInput;
        Vector3 upMovement = Camera.main.transform.up * deltaYAxis;
        Vector3 downMovement = Camera.main.transform.up * -deltaYAxis;
        Vector3 gravMovement = -Camera.main.transform.up * 0.3f;

        if (isFly)
        {

            if (Input.GetAxis(verticalInputName) > 0.1)
            {
                charController.Move(forwardMovement + rightMovement + upMovement);
            }
            else if (Input.GetAxis(verticalInputName) < -0.1)
            {
                charController.Move(forwardMovement + rightMovement + downMovement);
            } else
            {
                charController.Move(forwardMovement + rightMovement);
            }

        }
        else
        {
            charController.Move(transform.forward * vertInput + transform.right * horizInput + -transform.up * 0.3f * 2);
        }
    }

    private void checkFlying()
    {
        float flying = Input.GetAxis("Jump");
        if (flying != lastFlyState)
            {
                lastFlyState = flying;

                if (flying != 0)
                {
                    isFly = !isFly;
                }
            }
    }

    private void checkBoost()
    {
        //Check for boost
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boostConstant = movementSpeedMultiplier;
        }
        else
        {
            boostConstant = 1;
        }
    }
}