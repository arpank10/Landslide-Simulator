using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public static string landslideIntensityKey = "LandslideIntensity";
    public static string landslideVibrationkey = "LandslideVibration";
    public static string volumeKey = "Volume";
    public static string startingPositionKey = "StartingPosition";

    public Toggle near, far;


    public void setVolume(float volume)
    {
        PlayerPrefs.SetFloat(volumeKey, volume);
    }

    public void setIntensityOfLandslide(int indexOfOption)
    {
        PlayerPrefs.SetInt(landslideIntensityKey, indexOfOption);
    }

    public void setVibrationOfLandslide(int indexOfOption)
    {
        PlayerPrefs.SetInt(landslideVibrationkey, indexOfOption);
    }

    public void setStartingPositionOfViewerInTerrain()
    {
        if (near.isOn)
        {
            Debug.Log("Near On");
            PlayerPrefs.SetInt(startingPositionKey, 0);
        }
        else if(far.isOn)
        {
            Debug.Log("Far on");
            PlayerPrefs.SetInt(startingPositionKey, 1);
        }
    }

    public void Save()
    {
        Debug.Log(PlayerPrefs.GetInt(landslideVibrationkey, 1).ToString());
        setStartingPositionOfViewerInTerrain();
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);

    }
}
