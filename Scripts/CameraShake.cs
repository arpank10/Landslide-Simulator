/*
 * Author : Arpan Konar
 * Date created :13/04/2018
 * Function : Shakes the camera with required power after few seconds of starting the scene to give an experience of landslide.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class name
public class CameraShake : MonoBehaviour {

    public Transform viewer;                                                   //Camera object of the scene which defines the viewer in real worldd


    public float powerOfShakingDueToLandslide = 0.1f;                         //Power of the shaking due to landslide
	public float durationForWhichShakingDueToLandslideOccurs = 3.0f;           //Duration of shaking due to landslide
	public float durationAfterWhichShakingStarts = 0.1f;                       //Duration after which shaking starts due to landslide 
	public bool shouldShake = false;                                           //Boolean variable to describe if camera should shake or not 
    public bool shakedOnce = false;                                            //Boolean variable to check that it does not shake more than once
    public static string landslideVibrationkey = "LandslideVibration";         //Key to get the landslide vibration mode from the saved player preferences  


    Vector3 startPositionOfTheViewer;                                          //Starting position of the viewer in the virtual world           
	
	// Use this for initialization
	void Start () {
        //Initializing the variables
		viewer = Camera.main.transform;
		startPositionOfTheViewer = viewer.localPosition;
        //Setting the vibration mode of the terrain
		setVibration(PlayerPrefs.GetInt(landslideVibrationkey, 0));
    }
	
	// Update is called once per frame
	void Update () {
        //If shaking is enabled, the terrain vibrates according to the vibration mode
		if (shouldShake) {
            //If shaking is continuing
			if (durationForWhichShakingDueToLandslideOccurs > 0) {
                //The position of the viewer is changed by a vector value whose magnitude is within one multiplied by the power
				viewer.localPosition = startPositionOfTheViewer + Random.insideUnitSphere * powerOfShakingDueToLandslide;
                //Time is reduced 
				durationForWhichShakingDueToLandslideOccurs -= Time.deltaTime * 0.1f;
			} else {
                //Landslide is over, so shaked once is set to true so that it doesn't shake again
                shakedOnce = true;
				shouldShake = false;
				viewer.localPosition = startPositionOfTheViewer;
			}
		} else {
            //Wait for few seconds before starting the landslide
            if (!shakedOnce)
            {
                if (durationAfterWhichShakingStarts > 0)
                {
                    shouldShake = false;
                    durationAfterWhichShakingStarts -= Time.deltaTime * 0.1f;
                }
                //Waiting over, now landslide will start
                else
                {
                    shouldShake = true;
                }
            }
		}
	}

    //This function is used to set the vibration mode of the landslide
    public void setVibration(int landslideVibrationMode)
    {
        Debug.Log(landslideVibrationMode.ToString());
        //Landslide vibration mode is low
        if (landslideVibrationMode == 0)
        {
            powerOfShakingDueToLandslide = 0.1f; 
        }
        //Landslide vibration mode is medium
        else if (landslideVibrationMode == 1)
        {
            powerOfShakingDueToLandslide = 0.5f;
        }
        //Landslide vibration mode is high
        else
        {
            powerOfShakingDueToLandslide = 0.9f;
        }
    }
}
