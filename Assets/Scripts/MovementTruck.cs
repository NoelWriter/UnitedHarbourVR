using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTruck : MonoBehaviour
{

    public Transform[] target;
    public float speed;
    private int current;
    public Transform[] wheels;
    public Transform[] turningWheels;
    private float distance;

    private void Update()
    {
        //Updating variables
        distance = Vector3.Distance(transform.position, target[current].position);

        //Updating Wheelrotation
        rotateWheels();
        steer();

        //Updating speed over distance
        if (distance > 3)
            MoveTowards(speed);
        else if (distance > 1)
            MoveTowards(speed / 4);
        else
        {
            current = (current + 1) % target.Length;
        }      
    }

    private void MoveTowards(float moveSpeed)
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, moveSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(pos);
    }

    private void steer()
    {
        // Calculate rotation to destination
        Vector3 targetDir = target[current].position - transform.position;

        // The step size is equal to speed / 5 times frame time.
        float step = 0.5f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void rotateWheels()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].Rotate(Time.deltaTime * 1000, 0, 0);
        }
    }

}








