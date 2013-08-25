﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Credit to lhk for increment time counter
// http://answers.unity3d.com/questions/22252/incrementing-by-x-per-second.html

public class ControlGame : MonoBehaviour 
{
	public GameObject[] allPlayers;
	public GameObject[] hudAmmoAry;
	public GameObject[] hudBackAry;
	public GameObject[] hudHealthAry;
	public GameObject hudCountdown;
	
	public static float currTime = 10.0f;
	public const int MAX_HEALTH = 100;
	public const int START_AMMO = 100;
	
	private GUIText[] hudAmmoTextAry;
	private ManagePlayerState[] allPlayerManagers;
	private GUIText hudCountdownText;
	
	private static GameObject m_instance;
	private static double realTime = 0.0;
	private const int MAX_HUD_ARY = 2;
	
	
	// Use this for initialization
	void Start () 
	{
		// There can only be one controller
		if(m_instance == null)
		{
			m_instance = gameObject;
		}
		else
		{
			Destroy(gameObject);
		}
		
		// Init private arrays
		hudAmmoTextAry = new GUIText[MAX_HUD_ARY];
		allPlayerManagers = new ManagePlayerState[MAX_HUD_ARY];
		for(int i = 0; i< MAX_HUD_ARY; i++)
		{
			hudAmmoTextAry[i] = hudAmmoAry[i].GetComponent<GUIText>();
			allPlayerManagers[i] = allPlayers[i].GetComponent<ManagePlayerState>();
		}
		
		// Setup countdown HUD
		hudCountdownText = hudCountdown.GetComponent<GUIText>();
		hudCountdownText.text = currTime.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		IncrementTime();
		UpdateAmmoHUD();
		UpdateCountdownHUD();
	}
	
	// For drawing gizmos
	void OnDrawGizmos()
	{
		
	}
	
	private void IncrementTime()
	{
		realTime += (double) Time.deltaTime;
		if(realTime > 1.0)
		{
			realTime -= 1.0;
			currTime--;
			if(currTime < 0.0f)
			{
				currTime = 10.0f;
			}	
		}
	}
	
	private void UpdateAmmoHUD()
	{
		for(int i = 0; i < MAX_HUD_ARY; i++)
		{
			if(allPlayerManagers[i] != null)
			{
				hudAmmoTextAry[i].text = allPlayerManagers[i].GetAmmo().ToString();
				if(allPlayerManagers[i].offenseMode)
				{
					hudAmmoTextAry[i].color = Color.red;
				}
				else
				{
					hudAmmoTextAry[i].color = Color.green;
				}
			}
		}
	}
	
	private void UpdateCountdownHUD()
	{
		hudCountdownText.text = currTime.ToString();
	}
}
