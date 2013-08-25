﻿using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public GameObject shieldPrefab;
	private ManagePlayerState mps;
	
	// Use this for initialization
	void Start () 
	{
		mps = gameObject.GetComponent<ManagePlayerState>();
		if(!mps)
		{
			print("ShootBullet: Couldn't get player state!");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			if(mps.offenseMode)
			{
				if(mps.GetAmmo() > 0)
				{
					GameObject newBullet = Instantiate(bulletPrefab, 
										               transform.position + transform.forward * 1.6f, 
										               transform.rotation) as GameObject;
					newBullet.transform.forward = transform.forward;
					mps.AmmoDec();
				}
				
			}
			else
			{
				GameObject newShield = Instantiate(shieldPrefab, 
							                       transform.position, 
							                       transform.rotation) as GameObject;
				newShield.GetComponent<KeepShieldInFront>().playerTransform = transform;
				mps.AmmoInc();
			}
			
		}
		
		// Cheating to decrease health
		if(Input.GetKeyUp(KeyCode.I))
		{
			mps.HealthDec();
		}
		if(Input.GetKeyUp(KeyCode.U))
		{
			mps.HealthInc();
		}
	}
}
