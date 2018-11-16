using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;

    public bool isFlying, isGrounded;
    public float w_speed, r_speed, fly_speed, fly_boost, mouse_sensitivity, Jump_Height, Float_Force;
    private float g_speed, f_speed, mouseX, mouseY;
    
    // Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        isFlying = false;
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        //Base Settings
        var gx = Input.GetAxis("Horizontal") * g_speed;
        var fx = Input.GetAxis("Horizontal") * f_speed;
        var gz = Input.GetAxis("Vertical") * g_speed;
        var fz = Input.GetAxis("Vertical") * f_speed;

        mouseX -= Input.GetAxis("Mouse Y") * mouse_sensitivity;
        mouseY += Input.GetAxis("Mouse X") * mouse_sensitivity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            g_speed = r_speed;
            f_speed = fly_boost;
        }
        else
        {
            g_speed = w_speed;
            f_speed = fly_speed;
        }

        if (isFlying)
        {
            rb.drag = 2.5f;
            mouseX = Mathf.Clamp(mouseX, -90, 90);

            transform.Translate(fx, 0, fz);

            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.up * Float_Force, ForceMode.Force);
            }
        }
        else
        {
            rb.drag = 0;
            mouseX = Mathf.Clamp(mouseX, -60, 60);

            transform.Translate(gx, 0, gz);
        }
 
        transform.rotation = Quaternion.Euler(0, mouseY, 0);
        Camera.main.transform.rotation = Quaternion.Euler(mouseX, mouseY, 0);

        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up * Jump_Height, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            isFlying = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        isFlying = false;
    }
}
