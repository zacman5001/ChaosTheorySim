using UnityEngine;
using System.Collections;

public class CharcterControllerFull : MonoBehaviour {

    public float verticalBuffer = 1;
    public float horizontalBuffer = 1;
	float pitch = 0;
	float currentPitch;
	float pitchRange = 45;
    public float scrollSpeed = 1f;
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

        Vector3 velocity = new Vector3(0, 0, 0);

        //yaw = currentYaw + Input.GetAxis("Mouse X");
        //currentYaw = yaw;
        //transform.rotation = Quaternion.Slerp(transform.localRotation, (Quaternion.Euler(0,yaw *5,0)),  Time.deltaTime * 7);
        //Camera.main.transform.localRotation = Quaternion.Slerp (Camera.main.transform.localRotation,  Quaternion.Euler(pitch*5, 0 , 0), Time.deltaTime * 7);
        //pitch -= Input.GetAxis("Mouse Y");

        if (Input.mousePosition.x < horizontalBuffer)
        {
            Vector3 target = new Vector3(transform.position.x - scrollSpeed, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.25F);
        }
        else if (Input.mousePosition.x > Screen.width - horizontalBuffer)
        {
            Vector3 target = new Vector3(transform.position.x + scrollSpeed, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.25F);
        }
        else if (Input.mousePosition.y < verticalBuffer) {
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z - scrollSpeed);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.25F);
        }
        else if (Input.mousePosition.y > Screen.height - verticalBuffer) {
            Vector3 target = new Vector3(transform.position.x, transform.position.y, transform.position.z + scrollSpeed);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, 0.25F);
        }
        else
        {
            float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
            transform.position = transform.position + new Vector3(sideSpeed, 0, forwardSpeed);
        }
	}
}
