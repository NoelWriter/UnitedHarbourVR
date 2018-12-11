using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatEngine : Path {

    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;
    public WheelCollider black_perlR;
    public WheelCollider black_perlL;
    public float maxSteer = 45f;


    private void Start()
    {
        Transform[] pathTransfom = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransfom.Length; i++)
        {
            if (pathTransfom[i] != path.transform)
            {
                nodes.Add(pathTransfom[i]);
            }
        }
    }
    private void FixedUpdate()
    {
        ApplySteer();
        Drive();
    }

    private void Drive()
    {
        black_perlL.motorTorque = 100f;
        black_perlR.motorTorque = 100f;
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteer;
        black_perlL.steerAngle = newSteer;
        black_perlR.steerAngle = newSteer;
    }

    private void CheckWayPointDistance()
    {
       
        
    }
}

