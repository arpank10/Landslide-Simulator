/*
 * Module Name : Head Movement Control module
 * Author : Arpan Konar
 * Date created :14/04/2018
 * Function : This class is a part of head movement control module. 
 *            This enables the person to walk in the virtual world based on an a particular angle.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class name
public class VRwalk : MonoBehaviour {

    //This is the camera object which gives us the current position and direction in which to walk
    public Transform vrCamera;
    
    //The person starts to walk in the virtual world when his head angle is more than this value
    public float angleLimitAfterWhichPersonStartsWalking = 15.0f;

    //Speed of the person walking is defined by this value
    public float speedOfTheWalkingPerson = 3.0f;

    //A boolean value to determine if the person should be walking or not
    public bool shouldThePersonBeWalking;

    //The character controller which is to be transformed
    private CharacterController controllerObjectCorresponingToTheViewer;

    // Use this for initialization
    void Start () {
        //Getting the corresponding controller attached with the camera
        controllerObjectCorresponingToTheViewer = GetComponentInParent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //The person walks only when his head is downward by an angle more than the defined angle and if he is above river level
        if ( vrCamera.eulerAngles.x >= angleLimitAfterWhichPersonStartsWalking && vrCamera.eulerAngles.x < 90.0f && transform.position.y > 3.5f )
        {
            shouldThePersonBeWalking = true;
        }
        else
        {
            shouldThePersonBeWalking = false;
        }

        //If the person is allowed to walk then move him forward by a defined speed in the same direction he is facing
        if (shouldThePersonBeWalking)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            controllerObjectCorresponingToTheViewer.SimpleMove(forward * speedOfTheWalkingPerson);
        }
	}
}
