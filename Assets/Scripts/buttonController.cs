using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{

	public Button StartButton, HowToPlayButton;

	void Start()
	{
		Button btn1 = StartButton.GetComponent<Button>();
		Button btn2 = HowToPlayButton.GetComponent<Button>();

		//Calls the TaskOnClick/TaskWithParameters method when you click the Button
		btn1.onClick.AddListener(TaskOnClick);
		btn2.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene("level1");
	}

	void TaskWithParameters(string message)
	{
		SceneManager.LoadScene("HowToPlay");
	}
}
