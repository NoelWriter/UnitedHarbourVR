using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscript : MonoBehaviour {

	// Use this for initialization
	public void StartApp() {
        Debug.Log("Loading scene Vlissingen...");
        Application.LoadLevel("Vlissingen");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
		
	}

    // Use this for initialization
    public void QuitApp()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
