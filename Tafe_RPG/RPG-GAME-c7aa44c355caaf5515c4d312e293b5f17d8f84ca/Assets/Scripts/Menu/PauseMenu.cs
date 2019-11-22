using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //pause state that everything can see
    public static bool isPaused;
    private GameObject _pauseMenu;

    //start if the game set the defaults
    void Start()
    {
        _pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        _pauseMenu.SetActive(false);
        //we are not pauseed
        isPaused = false;
        //start time
        Time.timeScale = 1;
        //lock cursor to centre of screen
        Cursor.lockState = CursorLockMode.Locked;
        //hide cursoe
        Cursor.visible = false;
    }

    void Update()
    {
        //press escape
        if (Input.GetButtonDown("Cancel"))
        {
            //runs toggle pause function
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(isPaused)
        {
            //hide pause menu
            _pauseMenu.SetActive(false);
            //we are not paused
            isPaused = false;
            //start time
            Time.timeScale = 1;
            //lock curosr to centre
            Cursor.lockState = CursorLockMode.Locked;
            //hide cursor
            Cursor.visible = false;
        }

        else
        {
            //show pause menu
            _pauseMenu.SetActive(true);
            //we are now paused
            isPaused = true;
            //stop time
            Time.timeScale = 0;
            //allow cursor movement
            Cursor.lockState = CursorLockMode.None;
            //shows cursor
            Cursor.visible = true;
        }
    }
}
