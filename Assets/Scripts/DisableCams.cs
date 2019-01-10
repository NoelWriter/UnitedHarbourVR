using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCams : MonoBehaviour {

    //creates fields to drag the MainCamera and XRayCamera in
    public Camera MainCamera;
    public Camera XRayCamera;

    public bool toggle;   

    // Use this for initialization
    public void Start () {
        MainCamera.enabled = true;
        XRayCamera.enabled = false;
    }
	
	// Update is called once per frame
	public void Update () {
        SwitchToXRay();
	}

    public void SwitchToXRay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            toggle = !toggle;

            if (toggle)
            {
                XRayCamera.enabled = true;
            }
            else
            {
                XRayCamera.enabled = false;
            }
        }
    }

    //HOW TO USE
    //make sure to have a second camera as a child of the MainCamera in Unity
    //create and empty GameObject and add this script as an component to that
    //drag the MainCamera into the MainCamera slot on the gameobject
    //make sure the MainCamera's "Depth" field is set to 0
    //create a layer for the pipes
    //make sure the MainCamera's culling mask has the layer that is set to the pipes unchecked
    //drag the second camera into the XRayCamera slot on the gameobject
    //make sure the second camera's "Depth" field is set to 1
    //make sure the second camera's culling mask has the layers checked you DON'T want to dissapear (buildings, pipes)
}
