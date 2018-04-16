using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SelectTerrain : MonoBehaviour {

	public void startExperienceWithSelectedTerrain(int indexOfTerrain)
    {
        StartCoroutine(SwitchToVR(indexOfTerrain));
        SceneManager.LoadScene(indexOfTerrain);
    }

    IEnumerator SwitchToVR(int indexOfTerrain)
    {
        // Device names are lowercase, as returned by `XRSettings.supportedDevices`.
        string desiredDevice = "cardboard"; // Or "cardboard".

        // Some VR Devices do not support reloading when already active, see
        // https://docs.unity3d.com/ScriptReference/XR.XRSettings.LoadDeviceByName.html
        if (System.String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(desiredDevice);

            // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
            yield return null;
        }

        // Now it's ok to enable VR mode.
        XRSettings.enabled = true;
        SceneManager.LoadScene(indexOfTerrain);
    }
}
