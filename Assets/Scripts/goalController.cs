using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalController : MonoBehaviour
{

	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Player")
		{
			SceneManager.LoadScene("winScreen");
			Debug.Log(gameObject.name);
			Debug.Log(other.gameObject.name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player")
		{
			SceneManager.LoadScene("winScreen");
			Debug.Log(gameObject.name);
			Debug.Log(other.gameObject.name);
		}
	}
}
