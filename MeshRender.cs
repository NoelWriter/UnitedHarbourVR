using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRender : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
        }

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    gameObject.GetComponent<Renderer>().enabled = false;
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    gameObject.GetComponent<Renderer>().enabled = true;
        //}
    }
}
