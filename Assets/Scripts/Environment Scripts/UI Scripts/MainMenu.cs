﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string nextLevel;

	private GameObject levelSelectBttn;

	private bool isSelecting = false;

	void Start()
	{
		if (GameObject.FindWithTag ("Level Select") != null)
			levelSelectBttn = GameObject.FindWithTag ("Level Select");
	}

	public void MenuSelect ()
	{
		SceneManager.LoadScene("Main Menu");
	}

	public void LevelSelect()
	{
		if (isSelecting == false)
			isSelecting = true;
		else
			isSelecting = false;
		
		if (isSelecting) 
		{
			foreach (Transform child in levelSelectBttn.transform)
			{
				child.gameObject.SetActive(true);
				foreach (Transform baby in child.transform)
					baby.gameObject.SetActive (true);
			} 

		}
		else if(!isSelecting)
		{
			foreach (Transform child in levelSelectBttn.transform)
			{
				if(child.name != "selectText")
					child.gameObject.SetActive(false);
			} 
		}
	}

	public void PlayAgain()
	{
		Debug.Log ("Restarted Level");
		Time.timeScale = 1f;
		SceneManager.LoadScene(startLevel);

	}

	public void BeginNextLevel()
	{
		if (nextLevel != null) 
		{
			Debug.Log ("Next Level Started");
			Time.timeScale = 1f;
			SceneManager.LoadScene(nextLevel);
		}
	}

	public void NewGame()
	{
		Debug.Log ("New Game started");
		Time.timeScale = 1f;
		SceneManager.LoadScene("Opening");
	}

	public void ExitGame()
	{
		Debug.Log("Game exited");
		Time.timeScale = 1f;
		Application.Quit ();
	}
}
