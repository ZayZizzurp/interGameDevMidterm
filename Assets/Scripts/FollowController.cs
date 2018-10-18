using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{

	public GameObject Player;

	private bool followPlayer; 
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		followPlayer = true; 
		
		if (followPlayer)
		{
		transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.03f);
		}
	}
}
