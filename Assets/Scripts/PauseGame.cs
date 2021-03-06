﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

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
            //Player.GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            //If game is paused, resume game.
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            //Player.GetComponent<CharacterController>().enabled = true;
        }
    }

    public void MainMenu()
    {
        //Code to go to the main menu.
        Application.LoadLevel("MainMenu");
    }

    public void Reset()
    {
        //Code to reset the game.
        Application.LoadLevel("Vlissingen");
        Time.timeScale = 1;
    }
}
