using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    //Pre set boolean value
    public static bool GameIsPaused = false;

    //Reference to UI
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //If escape key is pressed change to paused state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }



        }
    }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;

        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

        }

       public void QuitGame()
       {
            Application.Quit();
       }

        void LoadMenu()
        {
           
        }

    
}
