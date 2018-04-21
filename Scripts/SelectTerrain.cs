/*
 * Module Name : SelectTerrain
 * Author : Arpan Konar
 * Date created :12/04/2018
 * Modification History : -12/04/2018 (created the startExperienceWithSelectedTerrain() and
 			   switchToVrAndStartTerrainExperience() functions.)
			   -14/04/2018 (added the condition for excluding those VR devices 
			   which do not support reloading)		   
 * Synopsis : This module starts the terrain experience based on the terrain selected.
 *            Before starting the experience the VR mode is switched on.
 * Functions Supported : For a given index of terrain, function call to StartCoroutine() is done for starting the
 			 User visual experience by switching to VR mode.
			 Additionally,this module also checks whether that VR device support reloading when 
			 already active otherwise it waits for one frame after performing the loadDevice() call.
			 SceneManager() function of unity functions to load the video as per the index choosen.
* Input Parameters : indexOfTerrain - index of terrain choosen by user on display screen.			 
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
