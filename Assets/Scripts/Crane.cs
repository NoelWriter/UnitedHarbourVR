using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{

    public Transform container;
    public Transform craneTop;
    public Transform craneBottom;
    public Transform hook;
    public Transform target;
    public Transform containerPivot;
    public Transform trailer;
    private Quaternion setRotation = new Quaternion(0, 180f, 0, 0);


    private bool getContainer = false;
    private bool moveCrane = false;
    private bool turnCrane = false;
    private bool setContainer = false;
    private bool getButton = false;
    private float speed = 0.5f;


    public void Update()
    {
        if (getButton == true || Input.GetKeyDown("t"))
        {
            getButton = true;

            if (getContainer == false)
            {
                GetContainer();

            }
            else if (moveCrane == false)
            {
                MoveCrane();

            }
            else if (turnCrane == false)
            {
                TurnCrane();
            }
            else if (setContainer == false)
            {
                Debug.Log(setContainer);
                SetContainer();
            }
        }
        else
        {

        }
    }
        

    public void GetContainer()
    {

        if(container.position == hook.position)
        {
            getContainer = true;
        }
        else
        {
            float step = speed * Time.deltaTime;
            container.position = Vector3.MoveTowards(container.position, hook.position, step);
        } 
    }

    public void MoveCrane()
    {
        if (Vector3.Distance(transform.position, target.position) > 20) {
            transform.Translate(0, 0, -3 * Time.deltaTime);
        }
        else
        {
            moveCrane = true;
        }
    }

    public void TurnCrane()
    {
        if (craneTop.rotation.eulerAngles.y < 180)
        {
            float rotation_y;
            float speed = 20f;
            rotation_y = craneTop.rotation.eulerAngles.x;
            rotation_y += 180;
            craneTop.rotation = Quaternion.RotateTowards(craneTop.rotation, Quaternion.Euler(craneTop.eulerAngles.x, rotation_y, craneTop.eulerAngles.z), Time.deltaTime * speed);
            Debug.Log(craneTop.rotation.eulerAngles.y);
        }
        else
        {
            turnCrane = true;
            Debug.Log(turnCrane);
            Update();
        }
    }

    public void SetContainer()
    {
        if (Vector3.Distance(container.position, trailer.position) != 0)
        {

            float speed = 0.5f;
            Debug.Log(speed);
            float step = speed * Time.deltaTime;
            container.position = Vector3.MoveTowards(container.position, target.position, step);
        }
        else
        {
            setContainer = true;
        }
    }


}
