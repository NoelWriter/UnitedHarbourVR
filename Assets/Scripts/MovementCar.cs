using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour
{

    public Transform[] target;
    public float speed;
    private int current;
    public Transform[] wheels;
    public Transform[] turningWheels;

    private void Update()
    {
        rotateWheels();
        if (Vector3.Distance(transform.position, target[current].position) > 20)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, (speed * 2) * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {

            if (Vector3.Distance(transform.position, target[current].position) > 7)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            {
                if (Vector3.Distance(transform.position, target[current].position) > 1)
                {
                    Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, (speed / 2) * Time.deltaTime);
                    GetComponent<Rigidbody>().MovePosition(pos);
                }
                else
                {
                    current = (current + 1) % target.Length;
                }
            }
        }
        steer();
    }
    private void steer()
    {
        Vector3 targetDir = target[current].position - transform.position;

        // The step size is equal to speed times frame time.
        float step = (speed / 5) * Time.deltaTime;

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







