/*
 * Module : RenderVideo 
 * Author : Arpan Konar
 * Date created :14/04/2018
 * Modification History : 14/04/2018 :- setVibration() and setStartingPositionOfPersonInTerrain() created.
 			  15/04/2018 :- Update() function for shaking of land simulation added.
 
 * Synopsis : This class belongs to the render video module.
 *            Shakes the camera with required power after few seconds of starting the scene to give 
 	      an experience of landslide.
 * Functions Supported : Start() sets position of person in virtual world, vibration
 	     	         intensity and volume to be rendered in video appropriately.
			 Update() sets the criteria for shaking of land simulation in the video.
			 setVibration() sets the vibration intensity according to the user input.one of the vibration 
			 		levels [0,1,2].
			 setStartingPositionOfPersonInTerrain() sets the position of the person in the video either near 
			 		or far to the location of occurence of landslide.
* Input Parameters : landslideVibrationMode(integer) - one of vibration intensity levels [0,1,2] as choosen by user.
		     startingPositionOfPersonInTerrain(integer) - starting position of person in the rendered video
		     				0-for near to site and 1- for far from site of occurence.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Class name
public class RenderVideo : MonoBehaviour {
    //Camera object of the scene which defines the viewer in real worldd
    public Transform viewer;

    //Audio Mixer is the object which is used in unity to control the volume.
    public AudioMixer audioMixer;

    //Here person refers to the person who is having the experience.In this context, it is the camera.
    public GameObject person;

    //Power of the shaking due to landslide
    public float powerOfShakingDueToLandslide = 0.1f;
    //Duration of shaking due to landslide
    public float durationForWhichShakingDueToLandslideOccurs = 3.0f;
    //Duration after which shaking starts due to landslide 
    public float durationAfterWhichShakingStarts = 0.1f;
    //Boolean variable to describe if camera should shake or not
    public bool shouldShake = false;
    //Boolean variable to check that it does not shake more than once
    public bool shakedOnce = false;
    //Key to get the landslide vibration mode from the saved player preferences
    public static string landslideVibrationkey = "LandslideVibration";

    Vector3 near = new Vector3(136.94f, 3.995971f, 101.5f);     //Position vector corresponding to starting position near
    Vector3 far = new Vector3(110.28f, 3.995971f, 120.17f);     //Position vector corresponding to starting position far

    //Keys which are used to store the settings in Player preferences
    public static string LANDSLIDEINTENSITYKEY = "LandslideIntensity";
    public static string VOLUMEKEY = "Volume";
    public static string STARTINGPOSITIONKEY = "StartingPosition";


    //Starting position of the viewer in the virtual world
    Vector3 startPositionOfTheViewer;                                                     
	
	// Inbuilt function of Unity Used for initialization of controller object.
	void Start () {
        	//Initializing the variables
		viewer = Camera.main.transform;
		startPositionOfTheViewer = viewer.localPosition;
        	//Setting the vibration mode of the terrain
		setVibration(PlayerPrefs.GetInt(landslideVibrationkey, 0));
        	//Getting the starting position of the person in terrain from player preferences
        	int startingPositionOfPersonInTerrain = PlayerPrefs.GetInt(STARTINGPOSITIONKEY, 0);

        	//Setting the volume set by user in the settings to the device by getting its value from player preferences
        	audioMixer.SetFloat("volume", PlayerPrefs.GetFloat(VOLUMEKEY, 0));

        	//Setting the starting position of the person in terrain
        	setStartingPositionOfPersonInTerrain(startingPositionOfPersonInTerrain);
    }
	//Inbuilt function of unity used for defining shaking criteria of the land in the video.
	// Update is called once per frame
	void Update () {
        //If shaking is enabled, the terrain vibrates according to the vibration mode
		if (shouldShake) {
            		//If shaking is continuing
			if (durationForWhichShakingDueToLandslideOccurs > 0) {
               		 	//The position of the viewer is changed by a vector value whose magnitude is 
				//within one multiplied by the power
				viewer.localPosition = startPositionOfTheViewer + 
					Random.insideUnitSphere * powerOfShakingDueToLandslide;
                		//Time is reduced 
				durationForWhichShakingDueToLandslideOccurs -= Time.deltaTime * 0.1f;
			} 
			else {
                		//Landslide is over, so shaked once is set to true so that it doesn't shake again
                		shakedOnce = true;
				shouldShake = false;
				viewer.localPosition = startPositionOfTheViewer;
			}
		} 
		else {
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
            		powerOfShakingDueToLandslide = 0.05f; 
        	}
        	//Landslide vibration mode is medium
        	else if (landslideVibrationMode == 1)
       		{
            		powerOfShakingDueToLandslide = 0.07f;
        	}
        	//Landslide vibration mode is high
        	else
        	{
            		powerOfShakingDueToLandslide = 0.09f;
        	}
    }

    //This function sets the starting position of the viewer with respect to the landslide in the terrain
    public void setStartingPositionOfPersonInTerrain(int startingPositionOfPersonInTerrain)
    {
        	//If starting position set is near
        	if (startingPositionOfPersonInTerrain == 0)
       		 {
            		person.transform.position = near;
        	 }
        	//Else if starting position is set to far
       		 else if (startingPositionOfPersonInTerrain == 1)
        	{
            		person.transform.position = far;
       		 }
    }
}
