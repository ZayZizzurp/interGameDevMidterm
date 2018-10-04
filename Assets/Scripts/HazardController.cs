using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardController : MonoBehaviour
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
			SceneManager.LoadScene("gameOver");
			Debug.Log(gameObject.name);
			Debug.Log(other.gameObject.name);
		}
		
	}
}
