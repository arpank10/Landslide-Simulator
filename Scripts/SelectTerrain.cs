/*
 * Module Name : Select Terrain module
 * Author : Arpan Konar
 * Date created :12/04/2018
 * Function : This module starts the terrain experience based on the terrain selected.
 *            Before starting the experience the VR mode is switched on.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

//Class name
public class SelectTerrain : MonoBehaviour {

    //This function starts the experience corresponding to the selected terrain in the user view.
	public void startExperienceWithSelectedTerrain(int indexOfTerrain)
    {
        //This command starts a coroutine to switch to VR mode and start the corresponding experience
        StartCoroutine(switchToVrAndStartTerrainExperience(indexOfTerrain));
    }

    //This function is user to turn on the VR mode before the experience begins.
    IEnumerator switchToVrAndStartTerrainExperience(int indexOfTerrain)
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active
        if (System.String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR Mode.
        XRSettings.enabled = true;

        //Now the corresponding scene is started in VR Mode.
        SceneManager.LoadScene(indexOfTerrain);
    }
}
