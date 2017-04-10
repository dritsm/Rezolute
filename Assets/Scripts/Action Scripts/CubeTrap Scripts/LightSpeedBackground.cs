﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpeedBackground : MonoBehaviour 
{
	public int targetRotation;
	public float targetSpeed;
	public int targetTime;

	private GameObject backgroundLayer;

	private bool startReverse;

	// Use this for initialization
	void Start () 
	{
		startReverse = false;
		backgroundLayer = this.gameObject;
		newDelay ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!startReverse) {
			iTween.RotateTo (gameObject, iTween.Hash (
				"rotation", new Vector3 (0, 0, targetRotation),
				"time", targetTime,
				"onUpdate", "UpdateSize",
				"easeType", iTween.EaseType.easeOutSine
			));
		} else if (startReverse == true) {
			iTween.RotateTo (gameObject, iTween.Hash (
				"rotation", new Vector3 (0, 0, targetRotation),
				"time", targetTime,
				"onUpdate", "UpdateSize",
				"easeType", iTween.EaseType.easeOutSine
			));
		}
	}

	//FUNCTIONS
	public void rotate90Degrees()
	{
		backgroundLayer.GetComponent<movingBackgroundVertical>().speed = 3f;
		//targetRotation = -90;
	}

	public void rotateReverse()
	{

		backgroundLayer.GetComponent<movingBackgroundVertical>().speed = .1f;
		targetRotation = 0;

		startReverse = true;
	}
		
	//COROUTINES
	void newDelay () {StartCoroutine ("newDelayCo");}

	IEnumerator newDelayCo()
	{
		yield return new WaitForSecondsRealtime (5);
		//gameObject.GetComponent<LightSpeedBackground>().enabled = false;
	}
}
