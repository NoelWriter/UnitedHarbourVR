using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPhysics : MonoBehaviour {

    public float Gravity_Strength;
	
	// Update is called once per frame
	void Update () {
        Physics.gravity = new Vector3(0, -Gravity_Strength, 0);
	}
}
