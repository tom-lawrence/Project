using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinState : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        

        void MainMenu ()
        {

            SceneManager.LoadScene("MainMenu");

        }


        void QuitGame()
        {

            Application.Quit();


        }







    }
}
