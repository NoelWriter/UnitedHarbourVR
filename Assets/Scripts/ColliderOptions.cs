using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderOptions : MonoBehaviour {

    private GameObject[] Buildings = GameObject.FindGameObjectsWithTag("Building");



    public ColliderOptions()
    {
        Debug.Log("Initialized");
    }

	public void Generate()
    {
        foreach(GameObject go in Buildings)
        {
                MeshCollider mc = go.AddComponent<MeshCollider>() as MeshCollider;
                mc.convex = true;
        }

        Debug.Log("Done, generating colliders");
    }

}
