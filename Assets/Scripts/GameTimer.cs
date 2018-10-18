using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//USAGE: add a timer to the game scene
public class GameTimer : MonoBehaviour
{
	public float timeLeft = 30.0f;
	public Text endText;

	void Update()
	{
		timeLeft -= Time.deltaTime;
		endText.text = "Time Left: " + (timeLeft).ToString("0") ;
		if (timeLeft < 0)
		{
			Time.timeScale = 0.0f;
			endText.text = "You ran out of time! \n GAME OVER";
		}
	}
}