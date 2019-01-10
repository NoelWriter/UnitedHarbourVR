using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{
    private int current;
    private int last;
    public Transform[] target;
    public Transform[] wheels;
    public Transform[] turningWheels;
    private float time;
    private float distance;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        //Updating variables
        distance = Vector3.Distance(transform.position, target[current].position);

        //Updating Wheelrotation
        rotateWheels();
        steer();

        //Updating speed over distance
        if (distance >= 20)
            MovePosition(20);
        else if (distance < 20 && distance >= 7)
            MovePosition(7);
        else if (distance < 7 && distance >= 0.1)
            MovePosition(4);
        else
        {
            last = current;
            current = (current + 1) % target.Length;
        }
    }

    private void MovePosition(float speed)
    { 
        GetComponent<Rigidbody>().MovePosition(GetPos(speed));
    }

    private Vector3 GetPos(float speed)
    {
        time = (Vector3.Distance(transform.position, target[current].position) / speed);
        Vector3 pos = Vector3.SmoothDamp(transform.position, target[current].position, ref velocity, time);
        return pos;
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







