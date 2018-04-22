/*
 * Module Name : SetSettings
 * Author : Arpan Konar
 * Date created :14/04/2018
 * Synopsis : User's choice of video (based on volume,landslide intensity,proximity to site,vibration) of occurences 
               to be rendered is set by this module and then the SceneManager() function of Unity to invoked for being
               ready to display video.
             
 * Functions Supported : setVolume() sets the preferred volume to be used in the rendered video
                         for output.
                         setIntensityOfLandslide() sets the intensity of landslide selected by user
                         i.e.,landslide intensity level(0,1,2)
                         setVibrationOfLandslide() sets the vibrational intensity to be used in the video 
                         output.
                         setStartingPositionOfViewerInTerrain() sets the choice of video to be viewed by user
                         having two discrete options i.e Near or Far (to the landslide occurence). 
                         Save() updates the preference of user choices entered and SceneMnager() method of
                         Unity to load the video.
 * Input Parameters :  volume (float type set by the slider on the display screen)
                       indexOfIntensityOption (integer [0,1,2] for the intensity of landslide)
                       indexOfVibrationOption (integer [0,1,2] for the intensity of vibration)
                       
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Class name
public class SettingsMenu : MonoBehaviour {

    //Keys corresponding to which the settings are saved in player preferences
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

    //Function to save the vibration of landslide from the dropdown menu in player preferences
    public void setVibrationOfLandslide(int indexOfVibrationOption)
    {
        PlayerPrefs.SetInt(landslideVibrationkey, indexOfVibrationOption);
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
