using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialOptions : MonoScript {

    private GameObject[] tagStr;

	public MaterialOptions(string tag)
    {
        tagStr = GameObject.FindGameObjectsWithTag(tag);
    }

    public void ApplyMaterial(Material selectedMaterial)
    {
        foreach(GameObject go in tagStr)
        {
            MeshRenderer mr = go.GetComponent<MeshRenderer>();
            mr.material = selectedMaterial;
        }
    }
}
