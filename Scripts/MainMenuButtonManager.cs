/*
 * Module Name : Main module
 * Author : Arpan Konar
 * Date created :14/04/2018
 * Function : This contains the button functions of the starting screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

//Class name
public class MainMenuButtonManager : MonoBehaviour {

    //If the start select terrain button is pressed then the select terrain scene is loaded
    public void startSelectTerrainButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    //If the settings button is pressed then the settings screen is loaded
    public void settingsButtonPressed()
    {
        SceneManager.LoadScene(2);
    }

    //If the quit button is pressed then the application closes
    public void quitButtonPressed()
    {
        Application.Quit();
    }

}
