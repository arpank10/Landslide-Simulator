/*
 * Module Name : Render Video module
 * Author : Arpan Konar
 * Date created :12/04/2018
 * Function : This class is a part of render video module. 
 *            This function sets the corresponding settings of the terrain as selected by the user.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Class name
public class SetSettings : MonoBehaviour {

    //Audio Mixer is the object which is used in unity to control the volume.
    public AudioMixer audioMixer;

    //Here person refers to the person who is having the experience.In this context, it is the camera.
    public GameObject person;

    Vector3 near = new Vector3(136.94f, 3.995971f, 101.5f);     //Position vector corresponding to starting position near
    Vector3 far = new Vector3(110.28f, 3.995971f, 120.17f);     //Position vector corresponding to starting position far

    //Keys which are used to store the settings in Player preferences
    public static string landslideIntensityKey = "LandslideIntensity";
    public static string volumeKey = "Volume";
    public static string startingPositionKey = "StartingPosition";

    // Use this for initialization
    void Start () {
        //Getting the starting position of the person in terrain from player preferences
        int startingPositionOfPersonInTerrain = PlayerPrefs.GetInt(startingPositionKey, 0);

        //Setting the volume set by user in the settings to the device by getting its value from player preferences
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat(volumeKey, 0));

        //Setting the starting position of the person in terrain
        setStartingPositionOfPersonInTerrain(startingPositionOfPersonInTerrain);
    }
	
    //This function sets the starting position of the viewer with respect to the landslide in the terrain
    public void setStartingPositionOfPersonInTerrain(int startingPositionOfPersonInTerrain)
    {
        //If starting position set is near
        if(startingPositionOfPersonInTerrain == 0)
        {
            person.transform.position = near;
        }
        //Else if starting position is set to far
        else if( startingPositionOfPersonInTerrain == 1)
        {
            person.transform.position = far;
        }
    }
   
}
