using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MainMenuButtonManager : MonoBehaviour {

    private void Start()
    {
        turnoffVR();
    }

    public void startSelectTerrainButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void settingsButtonPressed()
    {
        SceneManager.LoadScene(2);
    }

    public void quitButtonPressed()
    {
        Application.Quit();
    }
    void turnoffVR()
    {

        if (XRSettings.loadedDeviceName == "cardboard")
        {
            StartCoroutine(LoadDevice("None"));
        }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

}
