using UnityEngine;
using System.Collections;

public class CharcterControllerFull : MonoBehaviour {
	
	float pitch = 0;
	float currentPitch;
	float pitchRange = 45;
    public float movementSpeed = 5.0f;
	float baseFOV;
	float yaw;
	float currentYaw;

    // Use this for initialization
    void Start () {
		baseFOV = Camera.main.fieldOfView;
		yaw = Input.GetAxis("Mouse X");
		currentYaw = yaw;
    }

    // Update is called once per frame
    void FixedUpdate () {
		
		//yaw = currentYaw + Input.GetAxis("Mouse X");
		//currentYaw = yaw;
		//transform.rotation = Quaternion.Slerp(transform.localRotation, (Quaternion.Euler(0,yaw *5,0)),  Time.deltaTime * 7);
		//Camera.main.transform.localRotation = Quaternion.Slerp (Camera.main.transform.localRotation,  Quaternion.Euler(pitch*5, 0 , 0), Time.deltaTime * 7);
		//pitch -= Input.GetAxis("Mouse Y");
   
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed; 
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
        transform.position = transform.position + new Vector3(sideSpeed, 0, forwardSpeed);
	}
}
