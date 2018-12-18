using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{

    public Transform[] target;
    private int current;
    public Transform[] wheels;
    public Transform[] turningWheels;
    private float carSpeed;
    private Vector3 velocity = Vector3.zero;
    private float time = 5;
    private int last;

    private void Update()
    {
        rotateWheels();
        if (Vector3.Distance(transform.position, target[current].position) > 20)
        {
            float time = (Vector3.Distance(transform.position, target[current].position)/15);
            Vector3 pos = Vector3.SmoothDamp(transform.position, target[current].position, ref velocity , time);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {

            if (Vector3.Distance(transform.position, target[current].position) > 7)
            {
                time = (Vector3.Distance(transform.position, target[current].position) / 7);
                Vector3 pos = Vector3.SmoothDamp(transform.position, target[current].position, ref velocity, time);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            {
                if (Vector3.Distance(transform.position, target[current].position) > 0.1)
                {
                    time = (Vector3.Distance(transform.position, target[current].position) / 4);
                    Vector3 pos = Vector3.SmoothDamp(transform.position, target[current].position, ref velocity, time);
                    GetComponent<Rigidbody>().MovePosition(pos);
                }
                else
                {
                    last = current;
                    current = (current + 1) % target.Length;
                }
            }
        }
        steer();
    }
    private void steer()
    {
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







