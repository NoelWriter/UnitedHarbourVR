using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscript : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {

    }

    //Code to start the game, Vlissingen scene
    public void StartApp() {
        Debug.Log("Loading scene Vlissingen.");
        Application.LoadLevel("Vlissingen");
        Time.timeScale = 1;
    }

    //Code to start the game, Vlissingen scene
    public void Settings()
    {
        Debug.Log("Opening settings menu.");
    }

    //Code to quit the game
    public void Quit()
    {
        //Code to quit the game.
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
}
