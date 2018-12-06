using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
    public Transform Player;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            //If game is not paused, pause game.
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            //If game is paused, resume game.
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //Code to reset the game.
    public void Reset()
    {
        Application.LoadLevel("Vlissingen");
        Time.timeScale = 1;
    }

    //Code to go to the main menu.
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
