/*
 * Module Name : HeadMovementControl
 * Author : Arpan Konar
 * Date created :15/04/2018
 * Synopsis : This class is a part of head movement control module. 
 *            This enables the person to walk in the virtual world when he bends head more than a particular angle.
 *Function Supported : Start() initializes the controller and gets the corresponding controller attached 
 		      with the camera.
		      Update() sets the update in the criteria for head movement, i.e., moving the person 
		      in forward direction with the defined speed.
* variables : ANGLELIMITAFTERWHICHPERSONSTARTSWAKING  (defined head angle value serving a criteria
		for walking of person.This is defined as private as it should not be changed by other functions.)
	      SPEEDOFTHEWALKINGPERSON  (defined speed of movement.This is defined as private as it should not be 
	      changed by other functions.)
	      shouldThePersonBeWalking  (boolean variable for walking condition check)	      
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class name
public class HeadMovementControl : MonoBehaviour {

    //This is the camera object which gives us the current position and direction in which to walk
    public Transform vrCamera;
    
    //The person starts to walk in the virtual world when his head angle is more than this value
    private float ANGLELIMITAFTERWHICHPERSONSTARTSWAKING = 15.0f;

    //Speed of the person walking is defined by this value
    private float speedofthewalkingperson = 3.0f;

    //A boolean value to determine if the person should be walking or not
    public bool shouldThePersonBeWalking;

    //The character controller which is to be transformed
    private CharacterController controllerObjectCorresponingToTheViewer;

    // Start() function is the inbuilt function of Unity used for initialization of controller object.
    void Start () {
        //Getting the corresponding controller attached with the camera
        controllerObjectCorresponingToTheViewer = GetComponentInParent<CharacterController>();
    }
   //Update() function is the inbuilt function of unity which sets the walking criterias of the person 
   //in the video.
   // Update is called once per frame
    void Update () {
        //The person walks only when his head is downward by an angle more than the 
	// defined angle(ANGLELIMITAFTERWHICHPERSONSTARTSWAKING) and if
	//he is above river level
        if ( vrCamera.eulerAngles.x > ANGLELIMITAFTERWHICHPERSONSTARTSWAKING && vrCamera.eulerAngles.x < 90.0f 
	    && transform.position.y > 3.5f )
        {
            shouldThePersonBeWalking = true; // the person will start walking as the above conditions are statisfied
        }
        else
        {
            shouldThePersonBeWalking = false; // the person will not be walking
        }

        //If the person is allowed to walk then move him forward by a defined speed in the same direction he is facing
        if (shouldThePersonBeWalking)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);// moves the person in forward directio
	    // moves the person with defined speed
            controllerObjectCorresponingToTheViewer.SimpleMove(forward * speedofthewalkingperson);
        }
    }
 }
