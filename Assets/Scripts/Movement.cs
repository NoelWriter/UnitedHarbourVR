using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public Transform[] target;
    public float speed;
    private int current;
    public Transform proppelor;

    private void Update()
    {
        if (Vector3.Distance(transform.position, target[current].position) > 15)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current + 1) % target.Length;
        }
        moveProppelor();
        steer();
    }
    private void steer()
    {
        Vector3 targetDir = target[current].position - transform.position;

        // The step size is equal to speed times frame time.
        float step = ((speed/40)/2) * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward , targetDir, step, 0.0f);


        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void moveProppelor()
    {
        proppelor.Rotate(0, 0, Time.deltaTime * 10000);
    }
}

