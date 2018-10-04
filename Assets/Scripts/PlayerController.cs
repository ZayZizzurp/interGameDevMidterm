using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed = 10f;

	public float lookSpeed = 300f;

	Vector3 inputVector;
	

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		//mouse look

		//mouseDelta = difference, how fast the mouse is moving
		// "0" does NOT equal position, it means the mouse isn't moving
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

		//negative mouseX = moving the mouse to the left
		//negative mouseY = moving mouse downwards


		//rotate capsule left and right, rotate camera up and down
		transform.Rotate(0f, mouseX, 0f);
		Camera.main.transform.Rotate(-mouseY, 0, 0);
		Camera.main.transform.localEulerAngles -= new Vector3(0, 0, Camera.main.transform.localEulerAngles.z);

		//first person player movement
		float vertical = Input.GetAxis("Vertical"); // W/S for Up/Down on keyboard, -1 for down, +1 for up
		float horizontal = Input.GetAxis("Horizontal"); // A/D for Left/Right on keyboard, -1 is left, +1 is right

		inputVector = transform.forward * vertical * moveSpeed;
		inputVector += transform.right * horizontal * moveSpeed;


		//Deflection Code
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		float maxDistance = 10f;

		RaycastHit mouserayHit = new RaycastHit();
		
		Debug.DrawRay(mouseRay.origin, mouseRay.direction * maxDistance, Color.blue);

		if (Physics.Raycast(mouseRay, out mouserayHit, maxDistance))
		{
			GameObject HazardClick = mouserayHit.collider.gameObject;
			Vector3 directionFromPlayer =  HazardClick.transform.position - this.transform.position;
			
			if (Input.GetMouseButton(0) && (HazardClick.CompareTag("Hazard")) )
			{
					Debug.Log("Clicked on Hazard");
					HazardClick.GetComponent<Rigidbody>().AddForce(directionFromPlayer.normalized * 10, ForceMode.Impulse);
				
			}
		}

	}
	void FixedUpdate() //all physics code should go into fixedUpdate!
	{
		GetComponent<Rigidbody>().velocity = inputVector;
		//now gravity doesn't work lol
	}
}
