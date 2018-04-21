/*
 * Module Name : Settings module
 * Author : Arpan Konar
 * Date created :12/04/2018
 * Function : This function saves the corresponding settings of the terrain as selected by the user.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Class name
public class SettingsMenu : MonoBehaviour {

    //Keys corresponding to which the settings are saved in player preferences
    public static string landslideIntensityKey = "LandslideIntensity";
    public static string landslideVibrationkey = "LandslideVibration";
    public static string volumeKey = "Volume";
    public static string startingPositionKey = "StartingPosition";

    //Toggle objects for starting position in terrain 
    public Toggle near, far;

    //Function to save the corresponding volume from the volume slider in player preferences
    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat(volumeKey, volume);
    }

    //Function to save the intensity of landslide from the dropdown menu in player preferences
    public void setIntensityOfLandslide(int indexOfOption)
    {
        PlayerPrefs.SetInt(landslideIntensityKey, indexOfOption);
    }

    //Function to save the vibration of landslide from the dropdown menu in player preferences
    public void setVibrationOfLandslide(int indexOfOption)
    {
        PlayerPrefs.SetInt(landslideVibrationkey, indexOfOption);
    }

    //Function to save the starting position of the user in landslide terrain in player preferences
    public void setStartingPositionOfViewerInTerrain()
    {
        //Both cannot be selected together because they are part of a toggle group
        if (near.isOn)  //If starting position is selected as near
        {
            Debug.Log("Near On");
            PlayerPrefs.SetInt(startingPositionKey, 0);
        }
        else if(far.isOn)   //If starting position is selected as far
        {
            Debug.Log("Far on");
            PlayerPrefs.SetInt(startingPositionKey, 1);
        }
    }

    //This function saves the corresponding settings in player preferences and sends us back to the start menu 
    public void Save()
    {
        setStartingPositionOfViewerInTerrain();
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);

    }
}
