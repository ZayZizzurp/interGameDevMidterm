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
		followPlayer = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (followPlayer)
		{
		transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.05f);
		}
	}
}
