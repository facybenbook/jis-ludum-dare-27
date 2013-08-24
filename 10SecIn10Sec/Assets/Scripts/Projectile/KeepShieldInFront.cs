﻿using UnityEngine;
using System.Collections;

public class KeepShieldInFront : MonoBehaviour 
{
	[HideInInspector] public Transform playerTransform;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerTransform)
		{
			transform.position = playerTransform.position;
			transform.rotation = playerTransform.rotation;
		}
	}
}
