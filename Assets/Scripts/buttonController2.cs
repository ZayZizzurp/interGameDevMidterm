using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonController2 : MonoBehaviour
{

	public Button backbutton;

	void Start()
	{
		Button btn1 = backbutton.GetComponent<Button>();
	

		//Calls the TaskOnClick/TaskWithParameters method when you click the Button
		btn1.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene("Title");
	}

	
}
