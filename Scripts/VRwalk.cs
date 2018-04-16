using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRwalk : MonoBehaviour {

    public Transform vrCamera;
        
    public float angle = 5.0f;

    public float speed = 3.0f;

    public bool moveForward;

    private CharacterController myController;

    // Use this for initialization
    void Start () {
        myController = GetComponentInParent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // ray which defines where the camera is pointing
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        // whenever ray hits an object "hit" changes
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            // change state of "walking" when ray hits the ground objects
            if (hit.collider.name.Contains("River"))
            {
                Debug.Log("HIT TERRAIN");
            }
        }
        if ( vrCamera.eulerAngles.x >= angle && vrCamera.eulerAngles.x < 90.0f && transform.position.y > 3.5f )
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            myController.SimpleMove(forward * speed);
        }
	}
}
