﻿/// <summary>
/// This is the source of the fake gravity. Only works if an object has the <FauxGravityBody> script attached
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour 
{
	public float gravity = -10;
	//==============================================================

	public void Attract(Transform body)
	{
		Vector3 gravityUp = (body.position - transform.position).normalized;
		Vector3 bodyUp = body.up;

		body.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);

		Quaternion targetRotation = Quaternion.FromToRotation (bodyUp, gravityUp) * body.rotation;
		//body.rotation = Quaternion.Slerp (body.rotation, targetRotation, 50 * Time.deltaTime);
	}	
}
