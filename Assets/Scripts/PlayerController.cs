using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 10f;

	public float lookSpeed = 300f;
	
	float upDownRotation;

	 AudioSource HitSound;

	Vector3 inputVector;
	

	// Use this for initialization
	void Start()
	{
		HitSound = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		// mouseDelta = difference, how fast you're moving your mouse
		// if it's "0" that means the mouse isn't moving
		// this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime; // mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime; // mouseY = vertical mouseDelta
		
		// slightly better mouse-look:
		// rotate capsule left/right, but rotate camera up/down
		transform.Rotate(0f, mouseX, 0f); // capsule rotation
		
		// BETTER MOUSE LOOK, 11 Oct 2018: add mouseinput to upDownRotation AND clamp upDownRotation
		upDownRotation -= mouseY;
		upDownRotation = Mathf.Clamp(upDownRotation, -80, 80); // clamp vertical look rotation between -80/+80 degrees
		
		// apply rotation
		Camera.main.transform.localEulerAngles = new Vector3(
			upDownRotation,
			0f,
			0f
		);
		
		// BETTER MOUSE LOOK, 11 Oct 2018: lock and hide the mouse cursor
		// important: do this when the player clicks (NOT in Start)
		if (Input.GetMouseButtonDown(0)) // 0 = left-click
		{
			Cursor.lockState = CursorLockMode.Locked; // lock cursor in center of screen
			Cursor.visible = false; // hide the cursor too, just to be safe
		}

		//first person player movement
		float vertical = Input.GetAxis("Vertical"); // W/S for Up/Down on keyboard, -1 for down, +1 for up
		float horizontal = Input.GetAxis("Horizontal"); // A/D for Left/Right on keyboard, -1 is left, +1 is right

		inputVector = transform.forward * vertical * moveSpeed;
		inputVector += transform.right * horizontal * moveSpeed;


		//Deflection Code
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		float maxDistance = 5f;

		RaycastHit mouserayHit = new RaycastHit();
		
		Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxDistance, Color.blue);

		if (Physics.Raycast(mouseRay, out mouserayHit, maxDistance))
		{
			GameObject HazardClick = mouserayHit.collider.gameObject;
			Vector3 directionFromPlayer =  HazardClick.transform.position - this.transform.position;
			
			if (Input.GetMouseButtonDown(0) && (HazardClick.CompareTag("Hazard")) )
			{
					Debug.Log("Clicked on Hazard");
					HazardClick.GetComponent<Rigidbody>().AddForce(directionFromPlayer.normalized * 40, ForceMode.Impulse);
					HitSound.PlayOneShot(HitSound.clip);
				
			}
		}

	}
	void FixedUpdate() //all physics code should go into fixedUpdate!
	{
		GetComponent<Rigidbody>().velocity = inputVector;
		//now gravity doesn't work lol
	}
}
