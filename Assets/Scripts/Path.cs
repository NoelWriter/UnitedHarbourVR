using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    // Use this for initialization
    public Color LineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = LineColor;

        Transform[] pathTransfom = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransfom.Length; i++)
        {
            if (pathTransfom[i] != transform)
            {
                nodes.Add(pathTransfom[i]);
            }
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode;
            if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
            else
            {
                previousNode = nodes[i - 1].position;
            }
            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawSphere(currentNode, 10.0f);
        }
    }

}
