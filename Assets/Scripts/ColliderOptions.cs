using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderOptions : MonoScript{

    private GameObject[] tagStr;
    private string state;

    //Fill the gameobject array with gameobjects with the tag received from the drop-down selection
    public ColliderOptions(string tag)
    {
        tagStr = GameObject.FindGameObjectsWithTag(tag);

    }

    //Generate a meshcollider for every gameobject in the array tagStr
    public void Generate()
    {
        foreach(GameObject go in tagStr)
        {
            MeshCollider mc = go.AddComponent<MeshCollider>() as MeshCollider;
            mc.convex = true;

        }
        state = "Colliders have been generated";
    }

    //Remove the meshcollider from every gameobject in the array tagStr
    public void Remove()
    {
        foreach(GameObject go in tagStr)
        {
            DestroyImmediate(go.GetComponent<MeshCollider>());

        }
        state = "Colliders have been removed";
    }

    public string getState()
    {
        return state;
    }
}
