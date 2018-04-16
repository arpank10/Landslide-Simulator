using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SetSettings : MonoBehaviour {

    public AudioMixer audioMixer;
    public GameObject person;
    public static string landslideIntensityKey = "LandslideIntensity";
    public static string volumeKey = "Volume";
    public static string startingPositionKey = "StartingPosition";

    // Use this for initialization
    void Start () {
        int startingPositionOfPersonInTerrain = PlayerPrefs.GetInt(startingPositionKey, 0);
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat(volumeKey, 0));
        setStartingPositionOfPersonInTerrain(startingPositionOfPersonInTerrain);
    }
	
    public void setStartingPositionOfPersonInTerrain(int startingPositionOfPersonInTerrain)
    {
        Debug.Log(startingPositionOfPersonInTerrain.ToString());
        if(startingPositionOfPersonInTerrain == 0)
        {
            person.transform.position = new Vector3(136.94f, 3.995971f, 101.5f);
        }
        else if( startingPositionOfPersonInTerrain == 1)
        {
            person.transform.position = new Vector3(110.28f, 3.995971f, 120.17f);
        }
    }
   
}
