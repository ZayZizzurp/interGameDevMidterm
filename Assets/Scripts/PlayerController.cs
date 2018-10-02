using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 10f;

	public float lookSpeed = 300f;

	private Rigidbody rBody;
	
	Vector3 inputVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//mouse look
		
		//mouseDelta = difference, how fast the mouse is moving
		// "0" does NOT equal position, it means the mouse isn't moving
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed *  Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
		
		//negative mouseX = moving the mouse to the left
		//negative mouseY = moving mouse downwards
		
		
		//simplest possible mouse look: rotate the camera natively
		//Camera.main.transform.Rotate(-mouseY, mouseX, 0f);
		
		//slighty better mouse look, rotate capsule left and right, rotate camera up and down
		transform.Rotate(0f, mouseX, 0f);
		Camera.main.transform.localEulerAngles = new Vector3(-mouseY, 0f, 0f);
		
			
	
			
		Camera.main.transform.localEulerAngles -= new Vector3(0, 0 , Camera.main.transform.localEulerAngles.z);
		
		//first person player movement
		float vertical = Input.GetAxis("Vertical"); // W/S for Up/Down on keyboard, -1 for down, +1 for up
		float horizontal = Input.GetAxis("Horizontal"); // A/D for Left/Right on keyboard, -1 is left, +1 is right
		
		inputVector = transform.forward * vertical * moveSpeed;
        inputVector += transform.right * horizontal * moveSpeed;
		
		/*multiply by Time.deltaTime to make it frame INDEPENDENT, more consistent across machines
		transform.position += transform.forward * vertical * moveSpeed *  Time.deltaTime;
		transform.position += transform.right * horizontal * moveSpeed * Time.deltaTime;*/
		
		//this simplest method is bad because you are moving transform directly
		// when you move transform directly, you are basically teleporting the gameObject, no collision detection
		//a better method, move using rigidBody forces in fixedUpdate(), which won't have same problems
		
	}
	
	void FixedUpdate() //all physics code should go into fixedUpdate!
	{
		GetComponent<Rigidbody>().velocity = inputVector;
		//now gravity doesn't work lol


		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.up * 50f, ForceMode.Impulse);
		}
	}
}
